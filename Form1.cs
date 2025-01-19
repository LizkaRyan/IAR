using Emgu.CV.Structure;
using IAR.Database;
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

            // Afficher la boîte de dialogue et vérifier si l'utilisateur a choisi un fichier
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
            traitementImage.DrawImage(this.match);
            traitementImage.setImagePath(ImageFilePath.Text);
            this.match.Next(traitementImage);
            if (!offside)
            {
                this.match.SetPointTeam();
            }
            traitementImage.DrawImage(this.match);

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

        private void ButtonCommencer_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(AnalysePanel);
        }

        private void ButtonResultat_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ResultTable.Rows.Clear();
            var matches = DatabaseManager.Get("select g.*,t1.team as insider,t2.team as outsider from game as g join team as t1 on id_insider = t1.id_team join team as t2 on id_outsider = t2.id_team");
            foreach (Dictionary<string,object> match in matches)
            {
                ResultTable.Rows.Add(match["id_game"],match["outsider"],match["insider"],match["score_insider"],match["score_outsider"]);
            }
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(ResultPanel);
            Cursor = Cursors.Default;
        }

        private void ButtonTerminer_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(MenuPanel);
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            this.match.Save();
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(MenuPanel);
            Cursor = Cursors.Default;
        }
    }
}
