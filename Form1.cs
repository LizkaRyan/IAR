using Emgu.CV.Structure;
using IAR.Image;
using IAR.Game;

namespace IAR
{
    public partial class Form1 : Form
    {
        private Match match;
        private bool offside;
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
            openFileDialog.Title = "Sélectionner un fichier";

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
            if (this.match == null)
            {
                this.match = traitementImage.GenerateMatch();
            }
            else
            {
                this.match.Next(traitementImage);
            }
            offside = this.match.IsPlayerLeadingOffside();
            traitementImage.drawImage(this.match);
            traitementImage.setImagePath(ImageFilePath.Text);
            this.match.Next(traitementImage);
            if (offside)
            {
                this.match.SetPointTeam();
            }
            traitementImage.drawImage(this.match);
            
            Console.WriteLine($"{this.match.Team1.teamName} : {this.match.Team1.point} - " +
                              $"{this.match.Team2.teamName} : {this.match.Team2.point} ");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Sélectionner un fichier";

            // Afficher la bo�te de dialogue et v�rifier si l'utilisateur a choisi un fichier
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Afficher le chemin du fichier s�lectionn� dans la zone de texte
                ImageFilePath.Text = openFileDialog.FileName;
            }
        }
    }
}
