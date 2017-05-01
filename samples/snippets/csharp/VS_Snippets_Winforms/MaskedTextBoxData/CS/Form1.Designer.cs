namespace MaskedTextBoxDataCSharp
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
            this.firstName = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.phoneMask = new System.Windows.Forms.MaskedTextBox();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
// 
// firstName
// 
            this.firstName.Location = new System.Drawing.Point(13, 14);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(184, 20);
            this.firstName.TabIndex = 0;
// 
// lastName
// 
            this.lastName.Location = new System.Drawing.Point(204, 14);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(184, 20);
            this.lastName.TabIndex = 1;
// 
// phoneMask
// 
            this.phoneMask.Location = new System.Drawing.Point(441, 14);
            this.phoneMask.Mask = "(009) 000-0000 x9999";
            this.phoneMask.Name = "phoneMask";
            this.phoneMask.Size = new System.Drawing.Size(169, 20);
            this.phoneMask.TabIndex = 2;
// 
// previousButton
// 
            this.previousButton.Location = new System.Drawing.Point(630, 14);
            this.previousButton.Name = "previousButton";
            this.previousButton.TabIndex = 3;
            this.previousButton.Text = "Previous";
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
// 
// nextButton
// 
            this.nextButton.Location = new System.Drawing.Point(723, 14);
            this.nextButton.Name = "nextButton";
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = "Next";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
// 
// Form1
// 
            this.ClientSize = new System.Drawing.Size(887, 46);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.phoneMask);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.firstName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.MaskedTextBox phoneMask;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
    }
}

