namespace CS
{
    partial class PhoneNumberBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing&&(components!=null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.maskedTextBox1=new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.CutCopyMaskFormat=System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.maskedTextBox1.HidePromptOnLeave=false;
            this.maskedTextBox1.Location=new System.Drawing.Point(19, 28);
            this.maskedTextBox1.Mask="(999) 000-0000";
            this.maskedTextBox1.Name="maskedTextBox1";
            this.maskedTextBox1.Size=new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex=0;
            this.maskedTextBox1.TextMaskFormat=System.Windows.Forms.MaskFormat.IncludeLiterals;
            // 
            // PhoneNumberBox
            // 
            this.AutoScaleDimensions=new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.maskedTextBox1);
            this.Name="PhoneNumberBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    }
}
