namespace TCA_Kurs
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
            txbIn = new TextBox();
            btnRun = new Button();
            txbOut = new TextBox();
            btnOpen = new Button();
            txbMatrix = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txbOPN = new TextBox();
            openFD = new OpenFileDialog();
            btnLowerAnalyzer = new Button();
            SuspendLayout();
            // 
            // txbIn
            // 
            txbIn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbIn.Location = new Point(12, 12);
            txbIn.Multiline = true;
            txbIn.Name = "txbIn";
            txbIn.ScrollBars = ScrollBars.Vertical;
            txbIn.Size = new Size(360, 287);
            txbIn.TabIndex = 0;
            // 
            // btnRun
            // 
            btnRun.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRun.Location = new Point(378, 12);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(88, 93);
            btnRun.TabIndex = 1;
            btnRun.Text = "Create list tokens";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // txbOut
            // 
            txbOut.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbOut.Location = new Point(472, 12);
            txbOut.Multiline = true;
            txbOut.Name = "txbOut";
            txbOut.ReadOnly = true;
            txbOut.ScrollBars = ScrollBars.Vertical;
            txbOut.Size = new Size(343, 287);
            txbOut.TabIndex = 2;
            // 
            // btnOpen
            // 
            btnOpen.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpen.Location = new Point(378, 210);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(88, 91);
            btnOpen.TabIndex = 3;
            btnOpen.Text = "Open file";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // txbMatrix
            // 
            txbMatrix.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbMatrix.Location = new Point(821, 105);
            txbMatrix.Multiline = true;
            txbMatrix.Name = "txbMatrix";
            txbMatrix.ScrollBars = ScrollBars.Vertical;
            txbMatrix.Size = new Size(343, 194);
            txbMatrix.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(821, 87);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 11;
            label2.Text = "Матрица";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(821, 11);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 10;
            label1.Text = "ОПН";
            // 
            // txbOPN
            // 
            txbOPN.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txbOPN.Location = new Point(821, 29);
            txbOPN.Multiline = true;
            txbOPN.Name = "txbOPN";
            txbOPN.ScrollBars = ScrollBars.Vertical;
            txbOPN.Size = new Size(343, 53);
            txbOPN.TabIndex = 9;
            // 
            // openFD
            // 
            openFD.FileName = "openFD";
            // 
            // btnLowerAnalyzer
            // 
            btnLowerAnalyzer.Enabled = false;
            btnLowerAnalyzer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLowerAnalyzer.Location = new Point(378, 111);
            btnLowerAnalyzer.Name = "btnLowerAnalyzer";
            btnLowerAnalyzer.Size = new Size(88, 93);
            btnLowerAnalyzer.TabIndex = 5;
            btnLowerAnalyzer.Text = "Lower analyzer";
            btnLowerAnalyzer.UseVisualStyleBackColor = true;
            btnLowerAnalyzer.Click += btnLowerAnalyzer_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1181, 313);
            Controls.Add(txbMatrix);
            Controls.Add(label2);
            Controls.Add(btnLowerAnalyzer);
            Controls.Add(label1);
            Controls.Add(txbOPN);
            Controls.Add(btnOpen);
            Controls.Add(txbOut);
            Controls.Add(btnRun);
            Controls.Add(txbIn);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbIn;
        private Button btnRun;
        private TextBox txbOut;
        private Button btnOpen;
        private OpenFileDialog openFD;
        private Button btnLowerAnalyzer;
        private TextBox txbMatrix;
        private Label label2;
        private Label label1;
        private TextBox txbOPN;
    }
}
