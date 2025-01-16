﻿using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace IAR.Image;

public class ImageTraitement
{
    private Mat image;
    public ImageTraitement(string imagePath)
    {
        image = CvInvoke.Imread(imagePath);
    }

    public List<Movable> GetRedPlayers()
    {
        // Plage basse du rouge
        Hsv rougeMin1 = new Hsv(0, 100, 100);  // Teinte: 0-10, Saturation: 100-255, Valeur: 100-255
        Hsv rougeMax1 = new Hsv(10, 255, 255);

        // Plage haute du rouge
        Hsv rougeMin2 = new Hsv(170, 100, 100); // Teinte: 170-180, Saturation: 100-255, Valeur: 100-255
        Hsv rougeMax2 = new Hsv(180, 255, 255);
        
        // Conversion en HSV
        Mat hsvImage = new Mat();
        CvInvoke.CvtColor(image, hsvImage, ColorConversion.Bgr2Hsv);

        // Détection des couleurs
        Mat redMask1 = DetectColor(hsvImage, rougeMin1, rougeMax1);
        Mat redMask2 = DetectColor(hsvImage, rougeMin2, rougeMax2);
        Mat redMask = new Mat();
        
        CvInvoke.BitwiseOr(redMask1, redMask2, redMask);
        return DetectMovables(redMask);
    }

    public Movable GetBlackBall()
    {
        // Plage pour le noir
        Hsv noirMin = new Hsv(0, 0, 0);       // Teinte: 0-180 (toutes les teintes), Saturation: 0-255 (toutes les intensités), Luminosité: 0-50
        Hsv noirMax = new Hsv(180, 255, 50);
        
        // Conversion en HSV
        Mat hsvImage = new Mat();
        CvInvoke.CvtColor(image, hsvImage, ColorConversion.Bgr2Hsv);
        
        Mat blackMask = DetectColor(hsvImage, noirMin, noirMax);
        
        return DetectMovables(blackMask)[0];
    }
    
    public List<Movable> GetBluePlayers()
    {
        // Plage pour le bleu
        Hsv bleuMin = new Hsv(100, 150, 50);  // Teinte: 100-130, Saturation: 150-255, Valeur: 50-255
        Hsv bleuMax = new Hsv(130, 255, 255);
        // Conversion en HSV
        Mat hsvImage = new Mat();
        CvInvoke.CvtColor(image, hsvImage, ColorConversion.Bgr2Hsv);
        
        Mat blueMask = DetectColor(hsvImage, bleuMin, bleuMax);
        
        return DetectMovables(blueMask);
    }

    protected static Mat DetectColor(Mat image, Hsv rougeMin, Hsv rougeMax)
    {
        Mat mask = new Mat();
        CvInvoke.InRange(
            image,
            new ScalarArray(new MCvScalar(rougeMin.Hue, rougeMin.Satuation, rougeMin.Value)),
            new ScalarArray(new MCvScalar(rougeMax.Hue, rougeMax.Satuation, rougeMax.Value)),
            mask
        );
        return mask;
    }

    protected List<Movable> DetectMovables(Mat mask)
    {
        List<Movable> players = new List<Movable>();
        VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
        CvInvoke.FindContours(mask, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

        int numero = 1;
        for (int i = 0; i < contours.Size; i++)
        {
            using (VectorOfPoint contour = contours[i])
            {
                Rectangle rect = CvInvoke.BoundingRectangle(contour);
                Point centre = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                int rayon = Math.Max(rect.Width, rect.Height) / 2;

                Movable joueur = new Movable(centre, rayon);
                players.Add(joueur);
            }
        }

        return players;
    }
    
    
    public void drawImage(Match match)
    {
        // Définir les paramètres du texte
        string texte = "HJ"; // La lettre ou le texte à afficher
        var couleur = new MCvScalar(0, 0, 0); // Couleur du texte (vert ici, en BGR)
        double taillePolice = 1.0; // Taille du texte
        int epaisseur = 2; // Épaisseur du texte
        FontFace stylePolice = FontFace.HersheySimplex; // Style de la police

        List<Movable> movables = match.GetPlayerOffside();
        Movable lastDefender = match.GetBeforeLastDefender();
        List<Movable> metys = match.GetTeamLeadingTheBall().GetPLayerInFrontOfTheBall(match.ball);
        CvInvoke.Line(image, new Point(0,lastDefender.GetBackPoint().Y), new Point(image.Width,lastDefender.GetBackPoint().Y), new MCvScalar(0, 0, 255), 2);

        // Ajouter le texte à l'image
        foreach (Movable movable in movables)
        {
            CvInvoke.PutText(image, texte, movable.centerPoint, stylePolice, taillePolice, couleur, epaisseur);
        }

        foreach (Movable mety in metys)
        {
            if (!movables.Contains(mety))
            {
                CvInvoke.ArrowedLine(image,  match.ball.centerPoint,mety.centerPoint, new MCvScalar(0, 0, 0), 2);
                CvInvoke.PutText(image, "N", mety.centerPoint, stylePolice, taillePolice, couleur, epaisseur);
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