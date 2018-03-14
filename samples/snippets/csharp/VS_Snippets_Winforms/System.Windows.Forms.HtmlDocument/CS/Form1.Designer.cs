namespace HtmlDocumentProjectCSharp
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.EnableAllElementsButton = new System.Windows.Forms.Button();
            this.showCookiesButton = new System.Windows.Forms.Button();
            this.getLastModifiedDateButton = new System.Windows.Forms.Button();
            this.ResetFormsButton = new System.Windows.Forms.Button();
            this.GetTableRowCountButton = new System.Windows.Forms.Button();
            this.DisplayMetaButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.EnableAllElementsButton);
            this.flowLayoutPanel1.Controls.Add(this.showCookiesButton);
            this.flowLayoutPanel1.Controls.Add(this.getLastModifiedDateButton);
            this.flowLayoutPanel1.Controls.Add(this.ResetFormsButton);
            this.flowLayoutPanel1.Controls.Add(this.GetTableRowCountButton);
            this.flowLayoutPanel1.Controls.Add(this.DisplayMetaButton);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(777, 152);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // EnableAllElementsButton
            // 
            this.EnableAllElementsButton.Location = new System.Drawing.Point(3, 3);
            this.EnableAllElementsButton.Name = "EnableAllElementsButton";
            this.EnableAllElementsButton.Size = new System.Drawing.Size(165, 23);
            this.EnableAllElementsButton.TabIndex = 0;
            this.EnableAllElementsButton.Text = "Enable All Elements";
            this.EnableAllElementsButton.Click += new System.EventHandler(this.EnableAllElementsButton_Click);
            // 
            // showCookiesButton
            // 
            this.showCookiesButton.Location = new System.Drawing.Point(174, 3);
            this.showCookiesButton.Name = "showCookiesButton";
            this.showCookiesButton.Size = new System.Drawing.Size(127, 23);
            this.showCookiesButton.TabIndex = 1;
            this.showCookiesButton.Text = "Show Cookies";
            this.showCookiesButton.Click += new System.EventHandler(this.showCookiesButton_Click);
            // 
            // getLastModifiedDateButton
            // 
            this.getLastModifiedDateButton.Location = new System.Drawing.Point(307, 3);
            this.getLastModifiedDateButton.Name = "getLastModifiedDateButton";
            this.getLastModifiedDateButton.Size = new System.Drawing.Size(162, 23);
            this.getLastModifiedDateButton.TabIndex = 2;
            this.getLastModifiedDateButton.Text = "Get Last Modified Date";
            this.getLastModifiedDateButton.Click += new System.EventHandler(this.getLastModifiedDateButton_Click);
            // 
            // ResetFormsButton
            // 
            this.ResetFormsButton.Location = new System.Drawing.Point(475, 3);
            this.ResetFormsButton.Name = "ResetFormsButton";
            this.ResetFormsButton.Size = new System.Drawing.Size(137, 23);
            this.ResetFormsButton.TabIndex = 3;
            this.ResetFormsButton.Text = "Reset Forms";
            this.ResetFormsButton.Click += new System.EventHandler(this.ResetFormsButton_Click);
            // 
            // GetTableRowCountButton
            // 
            this.GetTableRowCountButton.Location = new System.Drawing.Point(618, 3);
            this.GetTableRowCountButton.Name = "GetTableRowCountButton";
            this.GetTableRowCountButton.Size = new System.Drawing.Size(147, 23);
            this.GetTableRowCountButton.TabIndex = 4;
            this.GetTableRowCountButton.Text = "Get Table Row Count";
            this.GetTableRowCountButton.Click += new System.EventHandler(this.GetTableRowCountButton_Click);
            // 
            // DisplayMetaButton
            // 
            this.DisplayMetaButton.Location = new System.Drawing.Point(3, 32);
            this.DisplayMetaButton.Name = "DisplayMetaButton";
            this.DisplayMetaButton.Size = new System.Drawing.Size(184, 23);
            this.DisplayMetaButton.TabIndex = 5;
            this.DisplayMetaButton.Text = "DIsplay META Description";
            this.DisplayMetaButton.Click += new System.EventHandler(this.DisplayMetaButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Detect Context Menu";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 152);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(777, 318);
            this.webBrowser1.Url = new System.Uri("http://www.msn.com/", System.UriKind.Absolute);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(424, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(207, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Snip Selected Text";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(777, 470);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.Button EnableAllElementsButton;
		private System.Windows.Forms.Button showCookiesButton;
		private System.Windows.Forms.Button getLastModifiedDateButton;
		private System.Windows.Forms.Button ResetFormsButton;
		private System.Windows.Forms.Button GetTableRowCountButton;
		private System.Windows.Forms.Button DisplayMetaButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
	}
}

