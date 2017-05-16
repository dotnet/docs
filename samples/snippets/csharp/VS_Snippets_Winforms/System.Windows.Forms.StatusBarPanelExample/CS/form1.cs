using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

{
	#region " Windows Form Designer generated code "

	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		InitializeStatusBarPanels();

		//Add any initialization after the InitializeComponent() call

	}

	//Form overrides dispose to clean up the component list.
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

	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	internal System.Windows.Forms.RichTextBox RichTextBox1;

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
		this.SuspendLayout();
		//
		//RichTextBox1
		//
		this.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.RichTextBox1.Location = new System.Drawing.Point(0, 0);
		this.RichTextBox1.Name = "RichTextBox1";
		this.RichTextBox1.Size = new System.Drawing.Size(292, 266);
		this.RichTextBox1.TabIndex = 0;
		this.RichTextBox1.Text = " ";
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.RichTextBox1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	#endregion
	//<snippet1>
	
	internal System.Windows.Forms.StatusBar statusBar1;

	private void InitializeStatusBarPanels()
	{

		// Create a StatusBar control.
		statusBar1 = new StatusBar();

		// Dock the status bar at the top of the form. 
		statusBar1.Dock = DockStyle.Top;

		// Set the SizingGrip property to false so the user cannot 
		// resize the status bar.
		statusBar1.SizingGrip = false;

		// Associate the event-handling method with the 
		// PanelClick event.
		statusBar1.PanelClick += 
			new StatusBarPanelClickEventHandler(statusBar1_PanelClick);

		// Create two StatusBarPanel objects to display in statusBar1.
		StatusBarPanel panel1 = new StatusBarPanel();
		StatusBarPanel panel2 = new StatusBarPanel();

		// Set the width of panel2 explicitly and set
		// panel1 to fill in the remaining space.
		panel2.Width = 80;
		panel1.AutoSize = StatusBarPanelAutoSize.Spring;

		// Set the text alignment within each panel.
		panel1.Alignment = HorizontalAlignment.Left;
		panel2.Alignment = HorizontalAlignment.Right;

		// Display the first panel without a border and the second
		// with a raised border.
		panel1.BorderStyle = StatusBarPanelBorderStyle.None;
		panel2.BorderStyle = StatusBarPanelBorderStyle.Raised;

		// Set the text of the panels. The panel1 object is reserved
		// for line numbers, while panel2 is set to the current time.
		panel1.Text = "Reserved for important information.";
		panel2.Text = System.DateTime.Now.ToShortTimeString();

		// Set a tooltip for panel2
		panel2.ToolTipText = "Click time to display seconds";

		// Display panels in statusBar1 and add them to the
		// status bar's StatusBarPanelCollection.
		statusBar1.ShowPanels = true;
		statusBar1.Panels.Add(panel1);
		statusBar1.Panels.Add(panel2);

		// Add the StatusBar to the form.
		this.Controls.Add(statusBar1);
	}
	

	// If the user clicks the status bar, check the text of the 
	// StatusBarPanel.  If the text equals a short time string,
	// change it to long time display.
	private void statusBar1_PanelClick(object sender, 
		StatusBarPanelClickEventArgs e)
	{
		if (e.StatusBarPanel.Text == 
			System.DateTime.Now.ToShortTimeString())
		{
			e.StatusBarPanel.Text = 
				System.DateTime.Now.ToLongTimeString();
		}
	}
	//</snippet1>

	[System.STAThreadAttribute]
	public static void Main()
	{
		Application.Run(new Form1());
	}
}

