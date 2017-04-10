namespace UIAInvokePattern_snip
{
    partial class UIAInvokePatternTarget
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
            this.targetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // targetButton
            // 
            this.targetButton.AccessibleDescription = "target button";
            this.targetButton.AccessibleName = "targetButton";
            this.targetButton.Location = new System.Drawing.Point(109, 47);
            this.targetButton.Name = "targetButton";
            this.targetButton.Size = new System.Drawing.Size(102, 23);
            this.targetButton.TabIndex = 0;
            this.targetButton.Text = "Target button";
            this.targetButton.UseVisualStyleBackColor = true;
            // 
            // UIAInvokePatternTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.targetButton);
            this.Name = "UIAInvokePatternTarget";
            this.Text = "UIAInvokePatternTarget";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button targetButton;
    }
}