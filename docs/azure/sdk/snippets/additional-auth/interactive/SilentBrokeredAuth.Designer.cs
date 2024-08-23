namespace InteractiveBrokeredAuthSample
{
    partial class SilentBrokeredAuth
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
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(35, 36);
            button1.Name = "button1";
            button1.Size = new Size(165, 39);
            button1.TabIndex = 0;
            button1.Text = "TestSilentBrokeredAuth";
            button1.UseVisualStyleBackColor = true;
            button1.Click += testSilentBrokeredAuth_Click;
            // 
            // SilentBrokeredAuth
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Name = "SilentBrokeredAuth";
            Text = "SilentBrokeredAuth";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
    }
}