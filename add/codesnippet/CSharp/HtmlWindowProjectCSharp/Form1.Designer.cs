using System;

namespace HtmlWindowProjectCSharp
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.getLinksFromFramesButton = new System.Windows.Forms.Button();
            this.ShowModalDialogButton = new System.Windows.Forms.Button();
            this.OpenNewWindowOverBrowserButton = new System.Windows.Forms.Button();
            this.SetWindowStatusButton = new System.Windows.Forms.Button();
            this.resetFramesButton = new System.Windows.Forms.Button();
            this.balanceWindowButton = new System.Windows.Forms.Button();
            this.LoadOrderFormButton = new System.Windows.Forms.Button();
            this.OpenThreeWindowsButton = new System.Windows.Forms.Button();
            this.displayFirstUrlButton = new System.Windows.Forms.Button();
            this.displaySecondUrlButton = new System.Windows.Forms.Button();
            this.enableClickScrollButton = new System.Windows.Forms.Button();
            this.ResizeWindowButton = new System.Windows.Forms.Button();
            this.suppressScriptErrorButton = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.windowTimeout = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.getLinksFromFramesButton);
            this.flowLayoutPanel1.Controls.Add(this.ShowModalDialogButton);
            this.flowLayoutPanel1.Controls.Add(this.OpenNewWindowOverBrowserButton);
            this.flowLayoutPanel1.Controls.Add(this.SetWindowStatusButton);
            this.flowLayoutPanel1.Controls.Add(this.resetFramesButton);
            this.flowLayoutPanel1.Controls.Add(this.balanceWindowButton);
            this.flowLayoutPanel1.Controls.Add(this.LoadOrderFormButton);
            this.flowLayoutPanel1.Controls.Add(this.OpenThreeWindowsButton);
            this.flowLayoutPanel1.Controls.Add(this.displayFirstUrlButton);
            this.flowLayoutPanel1.Controls.Add(this.displaySecondUrlButton);
            this.flowLayoutPanel1.Controls.Add(this.enableClickScrollButton);
            this.flowLayoutPanel1.Controls.Add(this.ResizeWindowButton);
            this.flowLayoutPanel1.Controls.Add(this.suppressScriptErrorButton);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(896, 182);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // getLinksFromFramesButton
            // 
            this.getLinksFromFramesButton.Location = new System.Drawing.Point(3, 3);
            this.getLinksFromFramesButton.Name = "getLinksFromFramesButton";
            this.getLinksFromFramesButton.Size = new System.Drawing.Size(166, 23);
            this.getLinksFromFramesButton.TabIndex = 0;
            this.getLinksFromFramesButton.Text = "Get Links From Frames";
            this.getLinksFromFramesButton.Click += new System.EventHandler(this.getLinksFromFramesButton_Click);
            // 
            // ShowModalDialogButton
            // 
            this.ShowModalDialogButton.Location = new System.Drawing.Point(175, 3);
            this.ShowModalDialogButton.Name = "ShowModalDialogButton";
            this.ShowModalDialogButton.Size = new System.Drawing.Size(193, 23);
            this.ShowModalDialogButton.TabIndex = 1;
            this.ShowModalDialogButton.Text = "Show Modal Dialog";
            this.ShowModalDialogButton.Click += new System.EventHandler(this.ShowModalDialogButton_Click);
            // 
            // OpenNewWindowOverBrowserButton
            // 
            this.OpenNewWindowOverBrowserButton.Location = new System.Drawing.Point(374, 3);
            this.OpenNewWindowOverBrowserButton.Name = "OpenNewWindowOverBrowserButton";
            this.OpenNewWindowOverBrowserButton.Size = new System.Drawing.Size(229, 23);
            this.OpenNewWindowOverBrowserButton.TabIndex = 2;
            this.OpenNewWindowOverBrowserButton.Text = "Open New Window Over Browser";
            this.OpenNewWindowOverBrowserButton.Click += new System.EventHandler(this.OpenNewWindowOverBrowserButton_Click);
            // 
            // SetWindowStatusButton
            // 
            this.SetWindowStatusButton.Location = new System.Drawing.Point(609, 3);
            this.SetWindowStatusButton.Name = "SetWindowStatusButton";
            this.SetWindowStatusButton.Size = new System.Drawing.Size(164, 23);
            this.SetWindowStatusButton.TabIndex = 3;
            this.SetWindowStatusButton.Text = "Set Window Status";
            this.SetWindowStatusButton.Click += new System.EventHandler(this.SetWindowStatusButton_Click);
            // 
            // resetFramesButton
            // 
            this.resetFramesButton.Location = new System.Drawing.Point(3, 32);
            this.resetFramesButton.Name = "resetFramesButton";
            this.resetFramesButton.Size = new System.Drawing.Size(142, 23);
            this.resetFramesButton.TabIndex = 4;
            this.resetFramesButton.Text = "Reset Frames";
            this.resetFramesButton.Click += new System.EventHandler(this.resetFramesButton_Click);
            // 
            // balanceWindowButton
            // 
            this.balanceWindowButton.Location = new System.Drawing.Point(151, 32);
            this.balanceWindowButton.Name = "balanceWindowButton";
            this.balanceWindowButton.Size = new System.Drawing.Size(190, 23);
            this.balanceWindowButton.TabIndex = 5;
            this.balanceWindowButton.Text = "Balance Window";
            this.balanceWindowButton.Click += new System.EventHandler(this.balanceWindowButton_Click);
            // 
            // LoadOrderFormButton
            // 
            this.LoadOrderFormButton.Location = new System.Drawing.Point(347, 32);
            this.LoadOrderFormButton.Name = "LoadOrderFormButton";
            this.LoadOrderFormButton.Size = new System.Drawing.Size(175, 23);
            this.LoadOrderFormButton.TabIndex = 6;
            this.LoadOrderFormButton.Text = "Load Order Form";
            this.LoadOrderFormButton.Click += new System.EventHandler(this.LoadOrderFormButton_Click);
            // 
            // OpenThreeWindowsButton
            // 
            this.OpenThreeWindowsButton.Location = new System.Drawing.Point(528, 32);
            this.OpenThreeWindowsButton.Name = "OpenThreeWindowsButton";
            this.OpenThreeWindowsButton.Size = new System.Drawing.Size(168, 23);
            this.OpenThreeWindowsButton.TabIndex = 7;
            this.OpenThreeWindowsButton.Text = "Open Three Windows";
            this.OpenThreeWindowsButton.Click += new System.EventHandler(this.OpenThreeWindowsButton_Click);
            // 
            // displayFirstUrlButton
            // 
            this.displayFirstUrlButton.Location = new System.Drawing.Point(702, 32);
            this.displayFirstUrlButton.Name = "displayFirstUrlButton";
            this.displayFirstUrlButton.Size = new System.Drawing.Size(141, 23);
            this.displayFirstUrlButton.TabIndex = 8;
            this.displayFirstUrlButton.Text = "Display First URL";
            this.displayFirstUrlButton.Click += new System.EventHandler(this.displayFirstUrlButton_Click);
            // 
            // displaySecondUrlButton
            // 
            this.displaySecondUrlButton.Location = new System.Drawing.Point(3, 61);
            this.displaySecondUrlButton.Name = "displaySecondUrlButton";
            this.displaySecondUrlButton.Size = new System.Drawing.Size(166, 23);
            this.displaySecondUrlButton.TabIndex = 9;
            this.displaySecondUrlButton.Text = "Display Second URL";
            this.displaySecondUrlButton.Click += new System.EventHandler(this.displaySecondUrlButton_Click);
            // 
            // enableClickScrollButton
            // 
            this.enableClickScrollButton.Location = new System.Drawing.Point(175, 61);
            this.enableClickScrollButton.Name = "enableClickScrollButton";
            this.enableClickScrollButton.Size = new System.Drawing.Size(166, 23);
            this.enableClickScrollButton.TabIndex = 10;
            this.enableClickScrollButton.Text = "Enable Click Scroll";
            this.enableClickScrollButton.Click += new System.EventHandler(this.enableClickScrollButton_Click);
            // 
            // ResizeWindowButton
            // 
            this.ResizeWindowButton.Location = new System.Drawing.Point(347, 61);
            this.ResizeWindowButton.Name = "ResizeWindowButton";
            this.ResizeWindowButton.Size = new System.Drawing.Size(152, 23);
            this.ResizeWindowButton.TabIndex = 11;
            this.ResizeWindowButton.Text = "Resize Window";
            this.ResizeWindowButton.Click += new System.EventHandler(this.ResizeWindowButton_Click);
            // 
            // suppressScriptErrorButton
            // 
            this.suppressScriptErrorButton.Location = new System.Drawing.Point(505, 61);
            this.suppressScriptErrorButton.Name = "suppressScriptErrorButton";
            this.suppressScriptErrorButton.Size = new System.Drawing.Size(191, 23);
            this.suppressScriptErrorButton.TabIndex = 12;
            this.suppressScriptErrorButton.Text = "Suppress Script Error";
            this.suppressScriptErrorButton.Click += new System.EventHandler(this.suppressScriptErrorButton_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 182);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(896, 361);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Url = new System.Uri("file://C:\\\\testStatusBarText.htm", System.UriKind.Absolute);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(702, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Surf to error";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(896, 543);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button getLinksFromFramesButton;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.Button ShowModalDialogButton;
		private System.Windows.Forms.Button OpenNewWindowOverBrowserButton;
		private System.Windows.Forms.Button SetWindowStatusButton;
		private System.Windows.Forms.Button resetFramesButton;
		private System.Windows.Forms.Button balanceWindowButton;
		private System.Windows.Forms.Timer windowTimeout;
		private System.Windows.Forms.Button LoadOrderFormButton;
		private System.Windows.Forms.Button OpenThreeWindowsButton;
		private System.Windows.Forms.Button displayFirstUrlButton;
		private System.Windows.Forms.Button displaySecondUrlButton;
		private System.Windows.Forms.Button enableClickScrollButton;
		private System.Windows.Forms.Button ResizeWindowButton;
		private System.Windows.Forms.Button suppressScriptErrorButton;
        private System.Windows.Forms.Button button1;
	}
}

