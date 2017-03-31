namespace SDKSample
{
    partial class SignatureDefinition
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///   Clean up any resources being used.</summary>
        /// <param name="disposing">true if managed resources should 
        ///   be disposed; otherwise, false.</param>
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
            this.Ok = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SigningLocale = new System.Windows.Forms.TextBox();
            this.SignBy = new System.Windows.Forms.TextBox();
            this.Intent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RequestedSigner = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ok
            // 
            this.Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok.Location = new System.Drawing.Point(185, 150);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 14;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(266, 150);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 15;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.SigningLocale);
            this.panel1.Controls.Add(this.SignBy);
            this.panel1.Controls.Add(this.Intent);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.RequestedSigner);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(18, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 117);
            this.panel1.TabIndex = 13;
            // 
            // SigningLocale
            // 
            this.SigningLocale.Location = new System.Drawing.Point(112, 85);
            this.SigningLocale.Name = "SigningLocale";
            this.SigningLocale.Size = new System.Drawing.Size(209, 20);
            this.SigningLocale.TabIndex = 4;
            // 
            // SignBy
            // 
            this.SignBy.Location = new System.Drawing.Point(112, 59);
            this.SignBy.Name = "SignBy";
            this.SignBy.Size = new System.Drawing.Size(209, 20);
            this.SignBy.TabIndex = 3;
            // 
            // Intent
            // 
            this.Intent.Location = new System.Drawing.Point(112, 30);
            this.Intent.Name = "Intent";
            this.Intent.Size = new System.Drawing.Size(209, 20);
            this.Intent.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Signing Locale:";
            // 
            // RequestedSigner
            // 
            this.RequestedSigner.Location = new System.Drawing.Point(112, 5);
            this.RequestedSigner.Name = "RequestedSigner";
            this.RequestedSigner.Size = new System.Drawing.Size(209, 20);
            this.RequestedSigner.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sign By:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Intent:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Requested Signer:";
            // 
            // SignatureDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 191);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.panel1);
            this.Name = "SignatureDefinition";
            this.Text = "SignatureDefinition";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox SigningLocale;
        public System.Windows.Forms.TextBox SignBy;
        public System.Windows.Forms.TextBox Intent;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox RequestedSigner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}