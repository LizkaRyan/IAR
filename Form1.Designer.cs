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
            button1.Location = new Point(201, 285);
            button1.Name = "button1";
            button1.Size = new Size(127, 29);
            button1.TabIndex = 0;
            button1.Text = "Parcourir fichier";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // buttonAnalyse
            // 
            buttonAnalyse.BackColor = SystemColors.Highlight;
            buttonAnalyse.FlatStyle = FlatStyle.Flat;
            buttonAnalyse.ForeColor = SystemColors.ButtonFace;
            buttonAnalyse.Location = new Point(391, 324);
            buttonAnalyse.Name = "buttonAnalyse";
            buttonAnalyse.Size = new Size(94, 29);
            buttonAnalyse.TabIndex = 1;
            buttonAnalyse.Text = "Analyser";
            buttonAnalyse.UseVisualStyleBackColor = false;
            buttonAnalyse.Click += buttonAnalyse_Click;
            // 
            // filePathTextBox
            // 
            filePathTextBox.Location = new Point(126, 252);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.Size = new Size(262, 27);
            filePathTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 24F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(379, 117);
            label1.Name = "label1";
            label1.Size = new Size(136, 47);
            label1.TabIndex = 3;
            label1.Text = "IAR⚽";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(363, 196);
            label2.Name = "label2";
            label2.Size = new Size(168, 20);
            label2.TabIndex = 4;
            label2.Text = "Image Assistant Referee";
            label2.Click += label2_Click;
            // 
            // ImageFilePath
            // 
            ImageFilePath.Location = new Point(490, 252);
            ImageFilePath.Name = "ImageFilePath";
            ImageFilePath.Size = new Size(259, 27);
            ImageFilePath.TabIndex = 5;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Highlight;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(543, 285);
            button2.Name = "button2";
            button2.Size = new Size(127, 29);
            button2.TabIndex = 6;
            button2.Text = "Parcourir fichier";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 440);
            Controls.Add(button2);
            Controls.Add(ImageFilePath);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(filePathTextBox);
            Controls.Add(buttonAnalyse);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
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
    }
}
