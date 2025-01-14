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
            panel1 = new Panel();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // button1
            // 
            button1.Location = new Point(167, 12);
            button1.Name = "button1";
            button1.Size = new Size(127, 29);
            button1.TabIndex = 0;
            button1.Text = "Parcourir fichier";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // buttonAnalyse
            // 
            buttonAnalyse.Location = new Point(436, 12);
            buttonAnalyse.Name = "buttonAnalyse";
            buttonAnalyse.Size = new Size(94, 29);
            buttonAnalyse.TabIndex = 1;
            buttonAnalyse.Text = "Analyser";
            buttonAnalyse.UseVisualStyleBackColor = true;
            buttonAnalyse.Click += buttonAnalyse_Click;
            // 
            // filePathTextBox
            // 
            filePathTextBox.Location = new Point(167, 65);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.Size = new Size(363, 27);
            filePathTextBox.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 123);
            panel1.Name = "panel1";
            panel1.Size = new Size(978, 604);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1288, 751);
            Controls.Add(panel1);
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
        private Panel panel1;
    }
}
