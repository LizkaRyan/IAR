namespace IAR
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            buttonAnalyse = new Button();
            filePathTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ImageFilePath = new TextBox();
            button2 = new Button();
            AnalysePanel = new Panel();
            ScoreLabel = new Label();
            FinishButton = new Button();
            ButtonFinish = new Button();
            MenuPanel = new Panel();
            ButtonResultat = new Button();
            ButtonCommencer = new Button();
            ResultPanel = new Panel();
            ResultTable = new DataGridView();
            IdMatch = new DataGridViewTextBoxColumn();
            Exterieur = new DataGridViewTextBoxColumn();
            Interieur = new DataGridViewTextBoxColumn();
            ScoreOutside = new DataGridViewTextBoxColumn();
            ScoreInsider = new DataGridViewTextBoxColumn();
            MainPanel = new Panel();
            ArretLabel = new Label();
            AnalysePanel.SuspendLayout();
            MenuPanel.SuspendLayout();
            ResultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ResultTable).BeginInit();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(171, 45);
            button1.Name = "button1";
            button1.Size = new Size(127, 29);
            button1.TabIndex = 0;
            button1.Text = "Open file";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // buttonAnalyse
            // 
            buttonAnalyse.BackColor = SystemColors.Highlight;
            buttonAnalyse.Cursor = Cursors.Hand;
            buttonAnalyse.FlatStyle = FlatStyle.Flat;
            buttonAnalyse.ForeColor = SystemColors.ButtonFace;
            buttonAnalyse.Location = new Point(383, 79);
            buttonAnalyse.Name = "buttonAnalyse";
            buttonAnalyse.Size = new Size(94, 29);
            buttonAnalyse.TabIndex = 1;
            buttonAnalyse.Text = "Analyze";
            buttonAnalyse.UseVisualStyleBackColor = false;
            buttonAnalyse.Click += buttonAnalyse_Click;
            // 
            // filePathTextBox
            // 
            filePathTextBox.Location = new Point(104, 12);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.Size = new Size(274, 27);
            filePathTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 24F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(411, 108);
            label1.Name = "label1";
            label1.Size = new Size(136, 47);
            label1.TabIndex = 3;
            label1.Text = "IAR⚽";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(395, 187);
            label2.Name = "label2";
            label2.Size = new Size(168, 20);
            label2.TabIndex = 4;
            label2.Text = "Image Assistant Referee";
            label2.Click += label2_Click;
            // 
            // ImageFilePath
            // 
            ImageFilePath.Location = new Point(475, 12);
            ImageFilePath.Name = "ImageFilePath";
            ImageFilePath.Size = new Size(273, 27);
            ImageFilePath.TabIndex = 5;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Highlight;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(554, 45);
            button2.Name = "button2";
            button2.Size = new Size(127, 29);
            button2.TabIndex = 6;
            button2.Text = "Open file";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // AnalysePanel
            // 
            AnalysePanel.Controls.Add(ArretLabel);
            AnalysePanel.Controls.Add(ScoreLabel);
            AnalysePanel.Controls.Add(FinishButton);
            AnalysePanel.Controls.Add(filePathTextBox);
            AnalysePanel.Controls.Add(button2);
            AnalysePanel.Controls.Add(button1);
            AnalysePanel.Controls.Add(buttonAnalyse);
            AnalysePanel.Controls.Add(ImageFilePath);
            AnalysePanel.Location = new Point(34, 15);
            AnalysePanel.Name = "AnalysePanel";
            AnalysePanel.Size = new Size(874, 222);
            AnalysePanel.TabIndex = 7;
            // 
            // ScoreLabel
            // 
            ScoreLabel.AutoSize = true;
            ScoreLabel.Location = new Point(373, 163);
            ScoreLabel.Name = "ScoreLabel";
            ScoreLabel.Size = new Size(116, 20);
            ScoreLabel.TabIndex = 8;
            ScoreLabel.Text = "Red : 0 - 0 : Blue";
            // 
            // FinishButton
            // 
            FinishButton.BackColor = SystemColors.Highlight;
            FinishButton.Cursor = Cursors.Hand;
            FinishButton.FlatStyle = FlatStyle.Flat;
            FinishButton.ForeColor = SystemColors.ButtonFace;
            FinishButton.Location = new Point(383, 114);
            FinishButton.Name = "FinishButton";
            FinishButton.Size = new Size(94, 29);
            FinishButton.TabIndex = 7;
            FinishButton.Text = "Finish";
            FinishButton.UseVisualStyleBackColor = false;
            FinishButton.Click += FinishButton_Click;
            // 
            // ButtonFinish
            // 
            ButtonFinish.BackColor = SystemColors.Highlight;
            ButtonFinish.FlatStyle = FlatStyle.Flat;
            ButtonFinish.ForeColor = SystemColors.ButtonFace;
            ButtonFinish.Location = new Point(389, 14);
            ButtonFinish.Name = "ButtonFinish";
            ButtonFinish.Size = new Size(94, 29);
            ButtonFinish.TabIndex = 7;
            ButtonFinish.Text = "Finish";
            ButtonFinish.UseVisualStyleBackColor = false;
            ButtonFinish.Click += ButtonTerminer_Click;
            // 
            // MenuPanel
            // 
            MenuPanel.Controls.Add(ButtonResultat);
            MenuPanel.Controls.Add(ButtonCommencer);
            MenuPanel.Location = new Point(267, 16);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new Size(388, 69);
            MenuPanel.TabIndex = 5;
            // 
            // ButtonResultat
            // 
            ButtonResultat.BackColor = SystemColors.HotTrack;
            ButtonResultat.Cursor = Cursors.Hand;
            ButtonResultat.FlatStyle = FlatStyle.Flat;
            ButtonResultat.ForeColor = SystemColors.ButtonFace;
            ButtonResultat.Location = new Point(212, 14);
            ButtonResultat.Name = "ButtonResultat";
            ButtonResultat.Size = new Size(123, 29);
            ButtonResultat.TabIndex = 1;
            ButtonResultat.Text = "Voir résultat";
            ButtonResultat.UseVisualStyleBackColor = false;
            ButtonResultat.Click += ButtonResultat_Click;
            // 
            // ButtonCommencer
            // 
            ButtonCommencer.BackColor = SystemColors.HotTrack;
            ButtonCommencer.Cursor = Cursors.Hand;
            ButtonCommencer.FlatStyle = FlatStyle.Flat;
            ButtonCommencer.ForeColor = SystemColors.ButtonFace;
            ButtonCommencer.Location = new Point(46, 14);
            ButtonCommencer.Name = "ButtonCommencer";
            ButtonCommencer.Size = new Size(123, 29);
            ButtonCommencer.TabIndex = 0;
            ButtonCommencer.Text = "Commencer";
            ButtonCommencer.UseVisualStyleBackColor = false;
            ButtonCommencer.Click += ButtonCommencer_Click;
            // 
            // ResultPanel
            // 
            ResultPanel.Controls.Add(ResultTable);
            ResultPanel.Controls.Add(ButtonFinish);
            ResultPanel.Location = new Point(19, 13);
            ResultPanel.Name = "ResultPanel";
            ResultPanel.Size = new Size(934, 275);
            ResultPanel.TabIndex = 5;
            // 
            // ResultTable
            // 
            ResultTable.AllowUserToAddRows = false;
            ResultTable.AllowUserToDeleteRows = false;
            ResultTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ResultTable.Columns.AddRange(new DataGridViewColumn[] { IdMatch, Exterieur, Interieur, ScoreOutside, ScoreInsider });
            ResultTable.Location = new Point(29, 49);
            ResultTable.Name = "ResultTable";
            ResultTable.ReadOnly = true;
            ResultTable.RowHeadersWidth = 51;
            ResultTable.Size = new Size(876, 188);
            ResultTable.TabIndex = 0;
            // 
            // IdMatch
            // 
            IdMatch.HeaderText = "ID Match";
            IdMatch.MinimumWidth = 6;
            IdMatch.Name = "IdMatch";
            IdMatch.ReadOnly = true;
            IdMatch.Width = 125;
            // 
            // Exterieur
            // 
            Exterieur.HeaderText = "Outsider";
            Exterieur.MinimumWidth = 6;
            Exterieur.Name = "Exterieur";
            Exterieur.ReadOnly = true;
            Exterieur.Width = 125;
            // 
            // Interieur
            // 
            Interieur.HeaderText = "Insider";
            Interieur.MinimumWidth = 6;
            Interieur.Name = "Interieur";
            Interieur.ReadOnly = true;
            Interieur.Width = 125;
            // 
            // ScoreOutside
            // 
            ScoreOutside.HeaderText = "Score outsider";
            ScoreOutside.MinimumWidth = 6;
            ScoreOutside.Name = "ScoreOutside";
            ScoreOutside.ReadOnly = true;
            ScoreOutside.Width = 125;
            // 
            // ScoreInsider
            // 
            ScoreInsider.HeaderText = "Score Insider";
            ScoreInsider.MinimumWidth = 6;
            ScoreInsider.Name = "ScoreInsider";
            ScoreInsider.ReadOnly = true;
            ScoreInsider.Width = 125;
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(AnalysePanel);
            MainPanel.Location = new Point(12, 219);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(990, 436);
            MainPanel.TabIndex = 6;
            // 
            // ArretLabel
            // 
            ArretLabel.AutoSize = true;
            ArretLabel.Location = new Point(338, 183);
            ArretLabel.Name = "ArretLabel";
            ArretLabel.Size = new Size(190, 20);
            ArretLabel.TabIndex = 9;
            ArretLabel.Text = "Arret Red : 0 - 0 : Arret Blue";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 531);
            Controls.Add(MainPanel);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            AnalysePanel.ResumeLayout(false);
            AnalysePanel.PerformLayout();
            MenuPanel.ResumeLayout(false);
            ResultPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ResultTable).EndInit();
            MainPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button button1;
        private Button buttonAnalyse;
        private TextBox filePathTextBox;
        private Label label1;
        private Label label2;
        private TextBox ImageFilePath;
        private Button button2;
        private Panel AnalysePanel;
        private Panel MenuPanel;
        private Button ButtonCommencer;
        private Button ButtonResultat;
        private Panel ResultPanel;
        private DataGridView ResultTable;
        private DataGridViewTextBoxColumn IdMatch;
        private DataGridViewTextBoxColumn Exterieur;
        private DataGridViewTextBoxColumn Interieur;
        private DataGridViewTextBoxColumn ScoreOutside;
        private DataGridViewTextBoxColumn ScoreInsider;
        private Panel MainPanel;
        private Button ButtonFinish;
        private Button FinishButton;
        private Label ScoreLabel;
        private Label ArretLabel;
    }
}
