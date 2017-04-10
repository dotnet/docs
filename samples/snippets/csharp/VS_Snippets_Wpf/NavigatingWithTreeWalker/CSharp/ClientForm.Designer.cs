namespace NavigateWithTreeWalker
{
    partial class NavigationWithTreeWalker
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
            this.label11 = new System.Windows.Forms.Label();
            this.btnStartAutomation = new System.Windows.Forms.Button();
            this.tbStructure = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 47);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(480, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "After you have started, click the tab control tabs to see how the structure chang" +
                "es.";
            // 
            // btnStartAutomation
            // 
            this.btnStartAutomation.Location = new System.Drawing.Point(12, 13);
            this.btnStartAutomation.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartAutomation.Name = "btnStartAutomation";
            this.btnStartAutomation.Size = new System.Drawing.Size(177, 28);
            this.btnStartAutomation.TabIndex = 11;
            this.btnStartAutomation.Text = "Start Automation";
            this.btnStartAutomation.Click += new System.EventHandler(this.btnStartAutomation_Click);
            // 
            // tbStructure
            // 
            this.tbStructure.Location = new System.Drawing.Point(12, 79);
            this.tbStructure.Multiline = true;
            this.tbStructure.Name = "tbStructure";
            this.tbStructure.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbStructure.Size = new System.Drawing.Size(572, 485);
            this.tbStructure.TabIndex = 12;
            // 
            // NavigationWithTreeWalker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 576);
            this.Controls.Add(this.tbStructure);
            this.Controls.Add(this.btnStartAutomation);
            this.Controls.Add(this.label11);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NavigationWithTreeWalker";
            this.Text = "Navigate With TreeWalker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NavigationWithTreeWalker_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnStartAutomation;
        public System.Windows.Forms.TextBox tbStructure;
    }
}

