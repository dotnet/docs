namespace HtmlElementProjectCSharp
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
            this.PrintDOMButton = new System.Windows.Forms.Button();
            this.enableElementMoveButton = new System.Windows.Forms.Button();
            this.enableEditingButton = new System.Windows.Forms.Button();
            this.createLinkFromSelectionButton = new System.Windows.Forms.Button();
            this.CreateHtmlMenuButton = new System.Windows.Forms.Button();
            this.GetOffsetsButton = new System.Windows.Forms.Button();
            this.AddUrlToTooltipButton = new System.Windows.Forms.Button();
            this.AddDivMessageButton = new System.Windows.Forms.Button();
            this.submitFormButtom = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.AttachEventHandlerButton = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.browserStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.PrintDOMButton);
            this.flowLayoutPanel1.Controls.Add(this.enableElementMoveButton);
            this.flowLayoutPanel1.Controls.Add(this.enableEditingButton);
            this.flowLayoutPanel1.Controls.Add(this.createLinkFromSelectionButton);
            this.flowLayoutPanel1.Controls.Add(this.CreateHtmlMenuButton);
            this.flowLayoutPanel1.Controls.Add(this.GetOffsetsButton);
            this.flowLayoutPanel1.Controls.Add(this.AddUrlToTooltipButton);
            this.flowLayoutPanel1.Controls.Add(this.AddDivMessageButton);
            this.flowLayoutPanel1.Controls.Add(this.submitFormButtom);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.AttachEventHandlerButton);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(754, 184);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // PrintDOMButton
            // 
            this.PrintDOMButton.Location = new System.Drawing.Point(3, 3);
            this.PrintDOMButton.Name = "PrintDOMButton";
            this.PrintDOMButton.Size = new System.Drawing.Size(116, 23);
            this.PrintDOMButton.TabIndex = 0;
            this.PrintDOMButton.Text = "Print DOM";
            this.PrintDOMButton.Click += new System.EventHandler(this.PrintDOMButton_Click);
            // 
            // enableElementMoveButton
            // 
            this.enableElementMoveButton.Location = new System.Drawing.Point(125, 3);
            this.enableElementMoveButton.Name = "enableElementMoveButton";
            this.enableElementMoveButton.Size = new System.Drawing.Size(159, 23);
            this.enableElementMoveButton.TabIndex = 1;
            this.enableElementMoveButton.Text = "EnableElementMove";
            this.enableElementMoveButton.Click += new System.EventHandler(this.enableElementMoveButton_Click);
            // 
            // enableEditingButton
            // 
            this.enableEditingButton.Location = new System.Drawing.Point(290, 3);
            this.enableEditingButton.Name = "enableEditingButton";
            this.enableEditingButton.Size = new System.Drawing.Size(143, 23);
            this.enableEditingButton.TabIndex = 2;
            this.enableEditingButton.Text = "Enable Editing";
            this.enableEditingButton.Click += new System.EventHandler(this.enableEditingButton_Click);
            // 
            // createLinkFromSelectionButton
            // 
            this.createLinkFromSelectionButton.Location = new System.Drawing.Point(439, 3);
            this.createLinkFromSelectionButton.Name = "createLinkFromSelectionButton";
            this.createLinkFromSelectionButton.Size = new System.Drawing.Size(183, 23);
            this.createLinkFromSelectionButton.TabIndex = 3;
            this.createLinkFromSelectionButton.Text = "Create Link from Selection";
            this.createLinkFromSelectionButton.Click += new System.EventHandler(this.createLinkFromSelectionButton_Click);
            // 
            // CreateHtmlMenuButton
            // 
            this.CreateHtmlMenuButton.Location = new System.Drawing.Point(3, 32);
            this.CreateHtmlMenuButton.Name = "CreateHtmlMenuButton";
            this.CreateHtmlMenuButton.Size = new System.Drawing.Size(159, 23);
            this.CreateHtmlMenuButton.TabIndex = 4;
            this.CreateHtmlMenuButton.Text = "Create HTML Menu";
            this.CreateHtmlMenuButton.Click += new System.EventHandler(this.CreateHtmlMenuButton_Click);
            // 
            // GetOffsetsButton
            // 
            this.GetOffsetsButton.Location = new System.Drawing.Point(168, 32);
            this.GetOffsetsButton.Name = "GetOffsetsButton";
            this.GetOffsetsButton.Size = new System.Drawing.Size(166, 23);
            this.GetOffsetsButton.TabIndex = 5;
            this.GetOffsetsButton.Text = "Get Offsets";
            this.GetOffsetsButton.Click += new System.EventHandler(this.GetOffsetsButton_Click);
            // 
            // AddUrlToTooltipButton
            // 
            this.AddUrlToTooltipButton.Location = new System.Drawing.Point(340, 32);
            this.AddUrlToTooltipButton.Name = "AddUrlToTooltipButton";
            this.AddUrlToTooltipButton.Size = new System.Drawing.Size(215, 23);
            this.AddUrlToTooltipButton.TabIndex = 6;
            this.AddUrlToTooltipButton.Text = "Add Url to Tooltip";
            this.AddUrlToTooltipButton.Click += new System.EventHandler(this.AddUrlToTooltipButton_Click);
            // 
            // AddDivMessageButton
            // 
            this.AddDivMessageButton.Location = new System.Drawing.Point(561, 32);
            this.AddDivMessageButton.Name = "AddDivMessageButton";
            this.AddDivMessageButton.Size = new System.Drawing.Size(160, 23);
            this.AddDivMessageButton.TabIndex = 7;
            this.AddDivMessageButton.Text = "Add DIV Message";
            this.AddDivMessageButton.Click += new System.EventHandler(this.AddDivMessageButton_Click);
            // 
            // submitFormButtom
            // 
            this.submitFormButtom.Location = new System.Drawing.Point(3, 61);
            this.submitFormButtom.Name = "submitFormButtom";
            this.submitFormButtom.Size = new System.Drawing.Size(177, 23);
            this.submitFormButtom.TabIndex = 8;
            this.submitFormButtom.Text = "Submit Form";
            this.submitFormButtom.Click += new System.EventHandler(this.submitFormButtom_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            // 
            // AttachEventHandlerButton
            // 
            this.AttachEventHandlerButton.Location = new System.Drawing.Point(349, 61);
            this.AttachEventHandlerButton.Name = "AttachEventHandlerButton";
            this.AttachEventHandlerButton.Size = new System.Drawing.Size(158, 23);
            this.AttachEventHandlerButton.TabIndex = 10;
            this.AttachEventHandlerButton.Text = "Attach Event Handler";
            this.AttachEventHandlerButton.Click += new System.EventHandler(this.AttachEventHandlerButton_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 184);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(754, 344);
            this.webBrowser1.Url = new System.Uri("c:\\userfiles\\jayallen\\HtmlElementProject\\TestCE.htm", System.UriKind.Absolute);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browserStatus});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(754, 23);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // browserStatus
            // 
            this.browserStatus.Name = "browserStatus";
            this.browserStatus.Text = "toolStripStatusLabel1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(513, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Key Down";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(754, 551);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.Button PrintDOMButton;
		private System.Windows.Forms.Button enableElementMoveButton;
		private System.Windows.Forms.Button enableEditingButton;
		private System.Windows.Forms.Button createLinkFromSelectionButton;
		private System.Windows.Forms.Button CreateHtmlMenuButton;
		private System.Windows.Forms.Button GetOffsetsButton;
		private System.Windows.Forms.Button AddUrlToTooltipButton;
		private System.Windows.Forms.Button AddDivMessageButton;
		private System.Windows.Forms.Button submitFormButtom;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button AttachEventHandlerButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel browserStatus;
        private System.Windows.Forms.Button button2;
	}
}

