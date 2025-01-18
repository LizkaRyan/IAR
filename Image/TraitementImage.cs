using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using IAR.Game;

namespace IAR.Image
{
    public class TraitementImage
    {
        Mat image;

        public TraitementImage(string imagePath)
        {
            image = CvInvoke.Imread(imagePath);
        }

        public List<Movable> GetRedPlayers()
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

        public List<Movable> GetBluePlayers()
        {
            // Définir la plage de rouge en HSV
            // Remarque : Le rouge est à deux plages dans HSV (autour de 0° et 360°)// Plage basse et haute pour le bleu
            var lowerBlue1 = new ScalarArray(new MCvScalar(100, 120, 70)); // Bleu bas - plage 1
            var upperBlue1 = new ScalarArray(new MCvScalar(140, 255, 255)); // Bleu haut - plage 1

            var lowerBlue2 = new ScalarArray(new MCvScalar(100, 120, 70)); // Bleu bas - plage 2
            var upperBlue2 = new ScalarArray(new MCvScalar(140, 255, 255)); // Bleu haut - plage 2

            return GetAllPixel(lowerBlue1, upperBlue1, lowerBlue2, upperBlue2);
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
            CvInvoke.GaussianBlur(redMask, blurred, new Size(9, 9), 2);

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

        public Movable GetBlackBall()
        {
            ScalarArray lower = new ScalarArray(new MCvScalar(0, 0, 0));
            ScalarArray upper = new ScalarArray(new MCvScalar(180, 50, 50));

            // Convertir en HSV
            Mat hsvImage = new Mat();
            CvInvoke.CvtColor(image, hsvImage, ColorConversion.Bgr2Hsv);

            // Créer des masques pour détecter le rouge
            Mat mask1 = new Mat();
            CvInvoke.InRange(hsvImage, lower, upper, mask1);

            // Appliquer un flou pour réduire le bruit
            Mat blurred = new Mat();
            CvInvoke.GaussianBlur(mask1, blurred, new Size(9, 9), 2);

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

            return movables[3];
        }

        public void drawImage(Match match)
        {
            // Définir les paramètres du texte
            string texte = "H"; // La lettre ou le texte à afficher
            var couleur = new MCvScalar(0, 0, 0); // Couleur du texte (vert ici, en BGR)
            double taillePolice = 1.0; // Taille du texte
            int epaisseur = 2; // Épaisseur du texte
            FontFace stylePolice = FontFace.HersheySimplex; // Style de la police

            List<Movable> movables = match.GetPlayerOffside();
            Movable lastDefender = match.GetBeforeLastDefender();
            List<Movable> metys = match.GetTeamLeadingTheBall().GetPLayerInFrontOfTheBall(match.ball);
            CvInvoke.Line(image, new Point(0, lastDefender.GetBackPoint().Y),
                new Point(image.Width, lastDefender.GetBackPoint().Y), new MCvScalar(0, 0, 255), 2);

            // Ajouter le texte à l'image
            foreach (Movable movable in movables)
            {
                CvInvoke.PutText(image, texte, movable.centerPoint, stylePolice, taillePolice, couleur, epaisseur);
            }

            foreach (Movable mety in metys)
            {
                if (!movables.Contains(mety))
                {
                    CvInvoke.ArrowedLine(image,match.ball.centerPoint,mety.centerPoint, new MCvScalar(0, 0, 0), 2);
                    CvInvoke.PutText(image, "M", mety.centerPoint, stylePolice, taillePolice, couleur, epaisseur);
                }
            }
            // CvInvoke.Transpose(image, image);

            // On flip si c'est rotation degre anti-horaire
            // CvInvoke.Flip(transposedImage, rotatedImage, Emgu.CV.CvEnum.FlipType.Horizontal);

            // Afficher l'image
            CvInvoke.Imshow("Image avec texte", image);
            CvInvoke.WaitKey(0);
        }
    }
}