using Emgu.CV.Structure;
using IAR.Image;
using IAR.Game;

namespace IAR
{
    public partial class Form1 : Form
    {
        private Match match;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "S�lectionner un fichier";

            // Afficher la bo�te de dialogue et v�rifier si l'utilisateur a choisi un fichier
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Afficher le chemin du fichier s�lectionn� dans la zone de texte
                filePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void buttonAnalyse_Click(object sender, EventArgs e)
        {
            ImageTraitement traitementImage = new ImageTraitement(filePathTextBox.Text);
            // TraitementImage traitementImage = new TraitementImage(filePathTextBox.Text);
            List<Movable> playersRed = traitementImage.GetRedPlayers();
            List<Movable> playersBlue = traitementImage.GetBluePlayers();
            Team teamBlue = new Team(playersBlue, "Blue", Brushes.Blue);
            Team teamRed = new Team(playersRed, "Red", Brushes.Red);
            Movable ball = traitementImage.GetBlackBall();
            List<LineSegment2D> lines = traitementImage.GetLines();
            this.match = new Match(teamRed, teamBlue, ball,lines);
            traitementImage.drawImage(this.match,lines);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
