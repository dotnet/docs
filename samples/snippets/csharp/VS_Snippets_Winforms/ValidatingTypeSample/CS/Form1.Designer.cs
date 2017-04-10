namespace ValidatingTypeSampleCSharp
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
            this.components = new System.ComponentModel.Container();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
// 
// maskedTextBox1
// 
            this.maskedTextBox1.Location = new System.Drawing.Point(23, 26);
            this.maskedTextBox1.Name = "maskedTextBox1";
            //this.maskedTextBox1.Text = "";
            this.maskedTextBox1.Size = new System.Drawing.Size(352, 20);
            this.maskedTextBox1.TabIndex = 0;
// 
// textBox1
// 
            this.textBox1.Location = new System.Drawing.Point(526, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.TabIndex = 1;
// 
// Form1
// 
            this.ClientSize = new System.Drawing.Size(660, 64);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.maskedTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

