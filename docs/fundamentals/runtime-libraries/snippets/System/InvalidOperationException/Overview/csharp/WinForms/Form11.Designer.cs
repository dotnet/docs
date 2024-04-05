namespace WFCrossThreadSolutionCS
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
            this.threadExampleBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // threadExampleBtn
            //
            this.threadExampleBtn.Location = new System.Drawing.Point(100, 206);
            this.threadExampleBtn.Name = "threadExampleBtn";
            this.threadExampleBtn.Size = new System.Drawing.Size(75, 23);
            this.threadExampleBtn.TabIndex = 0;
            this.threadExampleBtn.Text = "button1";
            this.threadExampleBtn.UseVisualStyleBackColor = true;
            this.threadExampleBtn.Click += new System.EventHandler(this.threadExampleBtn_Click);
            //
            // textBox1
            //
            this.textBox1.Location = new System.Drawing.Point(12, 43);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(240, 137);
            this.textBox1.TabIndex = 1;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.threadExampleBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button threadExampleBtn;
        private System.Windows.Forms.TextBox textBox1;
    }
}

