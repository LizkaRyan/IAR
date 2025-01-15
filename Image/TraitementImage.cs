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

        public List<Movable> GetAllPixel(ScalarArray lower1, ScalarArray upper1, ScalarArray lower2, ScalarArray upper2)
        {
            // Convertir en HSV
            Mat hsvImage = new Mat();
            CvInvoke.CvtColor(image, hsvImage, ColorConversion.Bgr2Hsv);

            // Créer des masques pour détecter le rouge
            Mat mask1 = new Mat();
            Mat mask2 = new Mat();
            CvInvoke.InRange(hsvImage, lower1, upper1, mask1);
            CvInvoke.InRange(hsvImage, lower2, upper2, mask2);

            // Combinez les deux masques
            Mat redMask = new Mat();
            CvInvoke.Add(mask1, mask2, redMask);

            // Appliquer un flou pour réduire le bruit
            Mat blurred = new Mat();
            CvInvoke.GaussianBlur(redMask, blurred, new Size(7, 7), 2);

            // Détection des cercles
            CircleF[] circles = CvInvoke.HoughCircles(
                blurred,
                HoughModes.Gradient,
                dp: 1.5,
                minDist: 50,
                param1: 100,
                param2: 1,
                minRadius: 5,
                maxRadius: 10);

            // Afficher les cercles détectés
            List<Movable> movables = new List<Movable>();
            foreach (var circle in circles)
            {
                movables.Add(new Movable(new Point((int)circle.Center.X, (int)circle.Center.Y), circle.Radius));
            }

            return movables;
        }

        public List<Movable> GetPlayersRed()
        {
            // Définir la plage de rouge en HSV
            // Remarque : Le rouge est à deux plages dans HSV (autour de 0° et 360°)
            var lowerRed1 = new ScalarArray(new MCvScalar(0, 120, 70)); // Rouge bas - plage 1
            var upperRed1 = new ScalarArray(new MCvScalar(10, 255, 255)); // Rouge haut - plage 1

            var lowerRed2 = new ScalarArray(new MCvScalar(170, 120, 70)); // Rouge bas - plage 2
            var upperRed2 = new ScalarArray(new MCvScalar(180, 255, 255)); // Rouge haut - plage 2

            // Liste de groupes
            return GetAllPixel(lowerRed1, upperRed1, lowerRed2, upperRed2);
        }

        public List<Movable> GetPlayersBlue()
        {
            // Définir la plage de rouge en HSV
            // Remarque : Le rouge est à deux plages dans HSV (autour de 0° et 360°)// Plage basse et haute pour le bleu
            var lowerBlue1 = new ScalarArray(new MCvScalar(100, 120, 70)); // Bleu bas - plage 1
            var upperBlue1 = new ScalarArray(new MCvScalar(140, 255, 255)); // Bleu haut - plage 1

            var lowerBlue2 = new ScalarArray(new MCvScalar(100, 120, 70)); // Bleu bas - plage 2
            var upperBlue2 = new ScalarArray(new MCvScalar(140, 255, 255)); // Bleu haut - plage 2
            
            return GetAllPixel(lowerBlue1, upperBlue1, lowerBlue2, upperBlue2);
        }

        public Movable GetBlackBall()
        {
            // Prétraitement
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);
            CvInvoke.GaussianBlur(grayImage, grayImage, new Size(9, 9), 2);

// Binarisation pour mieux voir le cercle noir
            Mat binaryImage = new Mat();
            CvInvoke.Threshold(grayImage, binaryImage, 50, 255, ThresholdType.BinaryInv);

// Détection des cercles
            CircleF[] circles = CvInvoke.HoughCircles(
                binaryImage,
                HoughModes.Gradient,
                dp: 1.5,
                minDist: 50,
                param1: 100,
                param2: 1,
                minRadius: 0,
                maxRadius: 10);

            // Liste de groupes
            return new Movable(new Point((int)circles[0].Center.X, (int)circles[0].Center.Y),circles[0].Radius/2);
        }

        static bool IsClose(Point p1, Point p2, double threshold)
        {
            double distance = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            return distance <= threshold;
        }
    }
}