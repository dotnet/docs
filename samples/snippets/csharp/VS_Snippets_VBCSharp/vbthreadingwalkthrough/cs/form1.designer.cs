namespace ThreadingWalkthroughCS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.LinesCounted = new System.Windows.Forms.TextBox();
            this.WordsCounted = new System.Windows.Forms.TextBox();
            this.CompareString = new System.Windows.Forms.TextBox();
            this.SourceFile = new System.Windows.Forms.TextBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(18, 163);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(75, 13);
            this.Label4.TabIndex = 29;
            this.Label4.Text = "Lines Counted";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(18, 137);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(85, 13);
            this.Label3.TabIndex = 28;
            this.Label3.Text = "Matching Words";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(17, 111);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(79, 13);
            this.Label2.TabIndex = 27;
            this.Label2.Text = "Compare String";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(18, 85);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(60, 13);
            this.Label1.TabIndex = 26;
            this.Label1.Text = "Source File";
            // 
            // LinesCounted
            // 
            this.LinesCounted.Location = new System.Drawing.Point(112, 160);
            this.LinesCounted.Name = "LinesCounted";
            this.LinesCounted.Size = new System.Drawing.Size(100, 20);
            this.LinesCounted.TabIndex = 25;
            this.LinesCounted.Text = "0";
            // 
            // WordsCounted
            // 
            this.WordsCounted.Location = new System.Drawing.Point(112, 134);
            this.WordsCounted.Name = "WordsCounted";
            this.WordsCounted.Size = new System.Drawing.Size(100, 20);
            this.WordsCounted.TabIndex = 24;
            this.WordsCounted.Text = "0";
            // 
            // CompareString
            // 
            this.CompareString.Location = new System.Drawing.Point(112, 108);
            this.CompareString.Name = "CompareString";
            this.CompareString.Size = new System.Drawing.Size(100, 20);
            this.CompareString.TabIndex = 23;
            // 
            // SourceFile
            // 
            this.SourceFile.Location = new System.Drawing.Point(112, 82);
            this.SourceFile.Name = "SourceFile";
            this.SourceFile.Size = new System.Drawing.Size(100, 20);
            this.SourceFile.TabIndex = 22;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(112, 53);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 21;
            this.Cancel.Text = "Cancel";
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(112, 23);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 20;
            this.Start.Text = "Start";
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 212);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.LinesCounted);
            this.Controls.Add(this.WordsCounted);
            this.Controls.Add(this.CompareString);
            this.Controls.Add(this.SourceFile);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox LinesCounted;
        internal System.Windows.Forms.TextBox WordsCounted;
        internal System.Windows.Forms.TextBox CompareString;
        internal System.Windows.Forms.TextBox SourceFile;
        internal System.Windows.Forms.Button Cancel;
        internal System.Windows.Forms.Button Start;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

