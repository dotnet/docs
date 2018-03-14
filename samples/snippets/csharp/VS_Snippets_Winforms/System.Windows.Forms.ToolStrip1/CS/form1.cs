using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Windows.Forms.ToolStripExamplesCS
{
	/// <summary>
	/// Summary description for form.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
// 
// statusStrip1
// 
			this.statusStrip1.CanOverflow = false;
			this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.statusStrip1.Location = new System.Drawing.Point(9, 233);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(274, 24);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			this.statusStrip1.Visible = true;

// 
// movingToolStrip
// 
            //this.movingToolStrip.Anchor = System.Windows.Forms.AnchorStyles.Right;
            //this.movingToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            //this.movingToolStrip.Location = new System.Drawing.Point(0, 0);
            //this.movingToolStrip.Name = "movingToolStrip";
            //this.movingToolStrip.TabIndex = 2;
            //this.movingToolStrip.Text = "toolStrip2";
            //this.movingToolStrip.Visible = true;
// 
// toolStrip1
// 
			this.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(0, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.Visible = true;
 
// 
// Form1
// 
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.toolStripContainer1);
			this.Name = "Form1";
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.Name = "Form1";
			this.Padding = new System.Windows.Forms.Padding(9);
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		[STAThread]
		static void Main()
		{
			Application.Run(new Form1());
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStrip movingToolStrip;
	
		public Form1()
		{

			InitializeComponent();
			InitializeMovingToolStrip();
			InitializeBoldButton();
			InitializeToolStripStatusLabels();
			InitializeDropDownButton();
			
		}

		

		// The following example demonstrates setting the drop-down property
		// for a ToolStripDropDownItem.
		//<snippet5>
		// Declare the drop-down button and the items it will contain.
		internal ToolStripDropDownButton dropDownButton1;
		internal ToolStripDropDown dropDown;
		internal ToolStripButton buttonRed;
		internal ToolStripButton buttonBlue;
		internal ToolStripButton buttonYellow;


		private void InitializeDropDownButton()
		{
			dropDownButton1 = new ToolStripDropDownButton();
			dropDown = new ToolStripDropDown();
			dropDownButton1.Text = "A";

			// Set the drop-down on the ToolStripDropDownButton.
			dropDownButton1.DropDown = dropDown;

            // Set the drop-down direction.
            dropDownButton1.DropDownDirection = ToolStripDropDownDirection.Left;

            // Do not show a drop-down arrow.
            dropDownButton1.ShowDropDownArrow = false;

			// Declare three buttons, set their foreground color and text, 
			// and add the buttons to the drop-down.
			buttonRed = new ToolStripButton();
			buttonRed.ForeColor = Color.Red;
			buttonRed.Text = "A";

			buttonBlue = new ToolStripButton();
			buttonBlue.ForeColor = Color.Blue;
			buttonBlue.Text = "A";

			buttonYellow = new ToolStripButton();
			buttonYellow.ForeColor = Color.Yellow;
			buttonYellow.Text = "A";
			
			buttonBlue.Click += new EventHandler(colorButtonsClick);
			buttonRed.Click += new EventHandler(colorButtonsClick);
			buttonYellow.Click += new EventHandler(colorButtonsClick);

			dropDown.Items.AddRange(new ToolStripItem[] 
				{ buttonRed, buttonBlue, buttonYellow });
			toolStrip1.Items.Add(dropDownButton1);
		}


		// Handle the buttons' click event by setting the foreground color of the
		// form to the foreground color of the button that is clicked.
		private void colorButtonsClick(object sender, EventArgs e)
		{
			ToolStripButton senderButton = (ToolStripButton)sender;
			this.ForeColor = senderButton.ForeColor;
		}
		//</snippet5>

		//Sample for ToolStripButton, ToolStripButton.CheckOnClick, 
		//ToolStripButton.CheckedChanged, and ToolStripButton.Checked.
		//<snippet50>
		internal ToolStripButton boldButton;

		private void InitializeBoldButton()
		{
			boldButton = new ToolStripButton();
			boldButton.Text = "B";
			boldButton.CheckOnClick = true;
			toolStrip1.Items.Add(boldButton);

		}

		private void boldButton_CheckedChanged(object sender, EventArgs e)
		{
			if (boldButton.Checked)
			{
				this.Font = new Font(this.Font, FontStyle.Bold);
			}
			else
			{
				this.Font = new Font(this.Font, FontStyle.Regular);
			}

		}

		//</snippet50>

		// This demonstrates ToolStripItem.Image, 
		// ToolStripItem.ImageAlign, ToolStripItemImageScaling, 
		// ToolStripItem.ImageTransparentColor, ToolStripItem.ToolTipText,
		// ToolStripItem.AutoToolTip, and ToolStrip.ShowItemToolTips.
		//<snippet20>
		internal ToolStripButton imageButton;

		private void InitializeImageButtonWithToolTip()
		{

			// Construct the button and set the image-related properties.
			imageButton = new ToolStripButton();
			imageButton.Image = new Bitmap(typeof(Timer), "Timer.bmp");
			imageButton.ImageScaling = ToolStripItemImageScaling.SizeToFit;

			// Set the background color of the image to be transparent.
			imageButton.ImageTransparentColor = Color.FromArgb(0, 255, 0);

			// Show ToolTip text, set custom ToolTip text, and turn
			// off the automatic ToolTips.
			toolStrip1.ShowItemToolTips = true;
			imageButton.ToolTipText = "Click for the current time";
			imageButton.AutoToolTip = false;

			// Add the button to the ToolStrip.
			toolStrip1.Items.Add(imageButton);

		}
		//</snippet20>

		// This demonstrates the ToolStrip.AutoSize,
		// ToolStrip.RenderMode, ToolStripItem.TextDirection, and ToolStripItem.TextAlign properties.
		//<snippet4>
		internal ToolStripButton changeDirectionButton;

		private void InitializeMovingToolStrip()
		{
            movingToolStrip = new ToolStrip();

			changeDirectionButton = new ToolStripButton();

			movingToolStrip.AutoSize = true;
			movingToolStrip.RenderMode = ToolStripRenderMode.System;

			changeDirectionButton.TextDirection = ToolStripTextDirection.Vertical270;
			changeDirectionButton.Overflow = ToolStripItemOverflow.Never;
			changeDirectionButton.Text = "Change Alignment";
				movingToolStrip.Items.Add(changeDirectionButton);
		}


		private void changeDirectionButton_Click(object sender, EventArgs e)
		{

			ToolStripItem item = (ToolStripItem)sender;

			if (item.TextDirection == ToolStripTextDirection.Vertical270 || item.TextDirection == ToolStripTextDirection.Vertical90)
			{
				item.TextDirection = ToolStripTextDirection.Horizontal;
				movingToolStrip.Dock = System.Windows.Forms.DockStyle.Top;
			}
			else
			{
				item.TextDirection = ToolStripTextDirection.Vertical270;
				movingToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
			}

		}
		//</snippet4>


		

		// This demonstrates ToolStripStatusLabel.BorderSides 
		// and ToolStripStatusLabel.BorderStyle.
		//<snippet40>
		private void InitializeToolStripStatusLabels()
		{

			// Create two ToolStripStatusLabel objects to display in the
			// StatusStrip.
			ToolStripStatusLabel panel1 = new ToolStripStatusLabel();
			ToolStripStatusLabel panel2 = new ToolStripStatusLabel();

			// Display the first panel with a sunken border style on all
			// sides.
			panel1.BorderSides = ToolStripStatusLabelBorderSides.All;
			panel1.BorderStyle = Border3DStyle.Sunken;

			// Display the second panel with a raised border style on the
			// left side only.
			panel2.BorderSides = ToolStripStatusLabelBorderSides.Left;
			panel2.BorderStyle = Border3DStyle.Bump;

			// Initialize the text of the panel.
			panel1.Text = "Ready...";

			// Set the text of the panel to the current date.
			panel2.Text = System.DateTime.Today.ToLongDateString();

			// Add both panels to the StatusStripPanel collection of the
			// StatusStrip.
			statusStrip1.Items.AddRange(new ToolStripItem[] { panel1, panel2 });

		}

		//</snippet40>
		private void SetCustomRenderer()
		{
			//<snippet7>
			toolStrip1.Renderer = new RedTextRenderer();
			//</snippet7>
		}


		private void SetCustomerRenderInManagerMode()
		{
			//<snippet8>
			toolStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
			ToolStripManager.Renderer = new RedTextRenderer();
			//</snippet8>
		}

	}


//<snippet1>
// Extend the ToolStripRenderer class.

	public class RedTextRenderer :
		System.Windows.Forms.ToolStripRenderer

		// Override methods to render items as desired.
	{
		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
			e.TextColor = Color.Red;
			e.TextFont = new Font("Helvetica", 7, FontStyle.Bold);
			base.OnRenderItemText(e);

		} 
	} 
}
//</snippet1>









