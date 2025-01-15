using IAR.Image;

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
            TraitementImage traitementImage = new TraitementImage(filePathTextBox.Text);
            List<Movable> playersRed = traitementImage.GetPlayersRed();
            List<Movable> playersBlue = traitementImage.GetPlayersBlue();
            Team teamBlue = new Team(playersBlue, "Blue", Brushes.Blue);
            teamBlue.attackingUp = true;
            Team teamRed = new Team(playersRed, "Red", Brushes.Red);
            teamRed.attackingUp = false;
            Movable ball = traitementImage.GetBlackBall();
            this.match = new Match(teamRed, teamBlue, ball);
            traitementImage.drawImage(this.match.GetPlayerOffside());
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (this.match != null)
            {
                this.match.paint(e.Graphics);
            }
        }
    }
}
