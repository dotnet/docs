namespace CS
{
    partial class LookupBox
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
            this.DisplayMemberBox=new System.Windows.Forms.TextBox();
            this.ValueMemberBox=new System.Windows.Forms.TextBox();
            this.SelectedValueBox=new System.Windows.Forms.TextBox();
            this.comboBox1=new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // DisplayMemberBox
            // 
            this.DisplayMemberBox.Location=new System.Drawing.Point(4, 14);
            this.DisplayMemberBox.Name="DisplayMemberBox";
            this.DisplayMemberBox.Size=new System.Drawing.Size(100, 20);
            this.DisplayMemberBox.TabIndex=0;
            // 
            // ValueMemberBox
            // 
            this.ValueMemberBox.Location=new System.Drawing.Point(4, 41);
            this.ValueMemberBox.Name="ValueMemberBox";
            this.ValueMemberBox.Size=new System.Drawing.Size(100, 20);
            this.ValueMemberBox.TabIndex=1;
            // 
            // SelectedValueBox
            // 
            this.SelectedValueBox.Location=new System.Drawing.Point(4, 68);
            this.SelectedValueBox.Name="SelectedValueBox";
            this.SelectedValueBox.Size=new System.Drawing.Size(100, 20);
            this.SelectedValueBox.TabIndex=2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled=true;
            this.comboBox1.Location=new System.Drawing.Point(4, 104);
            this.comboBox1.Name="comboBox1";
            this.comboBox1.Size=new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex=3;
            // 
            // LookupBox
            // 
            this.AutoScaleDimensions=new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.SelectedValueBox);
            this.Controls.Add(this.ValueMemberBox);
            this.Controls.Add(this.DisplayMemberBox);
            this.Name="LookupBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DisplayMemberBox;
        private System.Windows.Forms.TextBox ValueMemberBox;
        private System.Windows.Forms.TextBox SelectedValueBox;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
