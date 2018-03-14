namespace GetSupportedPatterns
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
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnProps = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(82, 12);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(75, 23);
            this.btnBegin.TabIndex = 0;
            this.btnBegin.Text = "&Patterns";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnProps
            // 
            this.btnProps.Location = new System.Drawing.Point(270, 11);
            this.btnProps.Name = "btnProps";
            this.btnProps.Size = new System.Drawing.Size(75, 23);
            this.btnProps.TabIndex = 1;
            this.btnProps.Text = "&Properties";
            this.btnProps.UseVisualStyleBackColor = true;
            this.btnProps.Click += new System.EventHandler(this.btnProps_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 60);
            this.Controls.Add(this.btnProps);
            this.Controls.Add(this.btnBegin);
            this.Name = "Form1";
            this.Text = "Get Supported UI Automation Control Patterns";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnProps;
    }
}

