using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace IAR.Image
{
    public class TraitementImage
    {
        Mat image;

        public TraitementImage(string imagePath)
        {
            image = CvInvoke.Imread(imagePath);
        }

        public List<Point> GetAllPixel(ScalarArray lower1,ScalarArray upper1,ScalarArray lower2,ScalarArray upper2)
        {
            // Convertir en HSV
            Mat hsvImage = new Mat();
            CvInvoke.CvtColor(image, hsvImage, ColorConversion.Bgr2Hsv);

            // Créer des masques pour les deux plages de rouge
            Mat mask1 = new Mat();
            Mat mask2 = new Mat();
            CvInvoke.InRange(hsvImage, lower1, upper1, mask1);
            CvInvoke.InRange(hsvImage, lower2, upper2, mask2);

            // Fusionner les deux masques
            Mat redMask = new Mat();
            CvInvoke.Add(mask1, mask2, redMask);

            List<Point> points = new List<Point>();
            // Trouver les contours des zones rouges
            using (var contours = new Emgu.CV.Util.VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(redMask, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                for (int i = 0; i < contours.Size; i++)
                {
                    var contour = contours[i];
                    foreach (var point in contour.ToArray())
                    {
                        points.Add(new Point(point.X, point.Y));
                    }
                }
            }
            return points;
        }

        public List<Movable> GetPlayersRed()
        {
            // Définir la plage de rouge en HSV
            // Remarque : Le rouge est à deux plages dans HSV (autour de 0° et 360°)
            var lowerRed1 = new ScalarArray(new MCvScalar(0, 120, 70));   // Rouge bas - plage 1
            var upperRed1 = new ScalarArray(new MCvScalar(10, 255, 255)); // Rouge haut - plage 1

            var lowerRed2 = new ScalarArray(new MCvScalar(170, 120, 70)); // Rouge bas - plage 2
            var upperRed2 = new ScalarArray(new MCvScalar(180, 255, 255)); // Rouge haut - plage 2
            
            List<Point> points=GetAllPixel(lowerRed1, upperRed1, lowerRed2, upperRed2);
            // Distance seuil
            double threshold = 20.0;

            // Liste de groupes
            return ClusterPoints(points, threshold);
        }
        
        public List<Movable> GetPlayersBlue()
        {
            // Définir la plage de rouge en HSV
            // Remarque : Le rouge est à deux plages dans HSV (autour de 0° et 360°)// Plage basse et haute pour le bleu
            var lowerBlue1 = new ScalarArray(new MCvScalar(100, 120, 70));   // Bleu bas - plage 1
            var upperBlue1 = new ScalarArray(new MCvScalar(140, 255, 255));  // Bleu haut - plage 1

            var lowerBlue2 = new ScalarArray(new MCvScalar(100, 120, 70));   // Bleu bas - plage 2
            var upperBlue2 = new ScalarArray(new MCvScalar(140, 255, 255));  // Bleu haut - plage 2
            
            List<Point> points=GetAllPixel(lowerBlue1, upperBlue1, lowerBlue2, upperBlue2);
            // Distance seuil
            double threshold = 20.0;

            // Liste de groupes
            return ClusterPoints(points, threshold);
        }
        
        public Movable GetBlackBall()
        {
            // Définir la plage de rouge en HSV
            // Remarque : Le rouge est à deux plages dans HSV (autour de 0° et 360°)// Plage basse et haute pour le noir
            var lowerBlack1 = new ScalarArray(new MCvScalar(0, 0, 0));     // Noir bas - plage 1
            var upperBlack1 = new ScalarArray(new MCvScalar(180, 50, 50)); // Noir haut - plage 1

            var lowerBlack2 = new ScalarArray(new MCvScalar(0, 0, 0));     // Noir bas - plage 2
            var upperBlack2 = new ScalarArray(new MCvScalar(180, 50, 50)); // Noir haut - plage 2

            
            List<Point> points=GetAllPixel(lowerBlack1, upperBlack1, lowerBlack2, upperBlack2);
            // Distance seuil
            double threshold = 20.0;

            // Liste de groupes
            return ClusterPoints(points, threshold)[0];
        }
        
        static List<Movable> ClusterPoints(List<Point> points, double threshold)
        {
            List<Movable> clusters = new List<Movable>();

            foreach (var point in points)
            {
                bool addedToCluster = false;

                foreach (var cluster in clusters)
                {
                    // Vérifier la distance avec le premier point du cluster
                    if (IsClose(point, cluster.points[0], threshold))
                    {
                        cluster.AddPoint(point);
                        addedToCluster = true;
                        break;
                    }
                }

                // Si aucun cluster existant ne correspond, créer un nouveau cluster
                if (!addedToCluster)
                {
                    clusters.Add(new Movable(new List<Point>{point}));
                }
            }

            return clusters;
        }

        static bool IsClose(Point p1, Point p2, double threshold)
        {
            double distance = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            return distance <= threshold;
        }
    }
}