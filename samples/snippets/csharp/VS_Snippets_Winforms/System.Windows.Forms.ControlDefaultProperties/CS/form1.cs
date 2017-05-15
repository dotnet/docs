using System.Windows.Forms;
using System.Drawing;

public class Form1:
	System.Windows.Forms.Form

{
	#region " Windows Form Designer generated code "

	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		Populate_ListBox();

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
	internal FunButton Button1;
	internal System.Windows.Forms.ListBox ListBox1;
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		Button1 = new FunButton();
		Button1.Text = "CLICK";
		this.ListBox1 = new System.Windows.Forms.ListBox();
		this.SuspendLayout();
		//
		//ListBox1
		this.Button1.Location = new System.Drawing.Point(40, 40);
		//
		this.ListBox1.Location = new System.Drawing.Point(88, 112);
		this.ListBox1.Name = "ListBox1";
		this.ListBox1.Size = new System.Drawing.Size(120, 95);
		this.ListBox1.TabIndex = 1;
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.ListBox1);
		this.Controls.Add(this.Button1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	#endregion
	//
	// Add this method to a form containing a ListBox control named ListBox1.
	// Call the method in the constructor or Load method of the form.


	//<snippet1>

	// The following method displays the default font, 
	// background color and foreground color values for the ListBox  
	// control. The values are displayed in the ListBox, itself.

	private void Populate_ListBox()
	{
		ListBox1.Dock = DockStyle.Bottom;

		// Display the values in the read-only properties 
		// DefaultBackColor, DefaultFont, DefaultForecolor.
		ListBox1.Items.Add("Default BackColor: " + 
			ListBox.DefaultBackColor.ToString());
		ListBox1.Items.Add("Default Font: " + 
			ListBox.DefaultFont.ToString());
		ListBox1.Items.Add("Default ForeColor:" + 
			ListBox.DefaultForeColor.ToString());

	}
	//</snippet1>
}

// To use this example create a new form and paste this class 
// forming the same file, after the form class in the same file.  
// Add a button of type FunButton to the form. 


//<snippet2>
public class FunButton:
	Button

{
	protected override void OnMouseHover(System.EventArgs e)
	{

		// Get the font size in Points, add one to the
		// size, and reset the button's font to the larger
		// size.
		float fontSize = Font.SizeInPoints;
		fontSize += 1;
		System.Drawing.Size buttonSize = Size;
		this.Font = new System.Drawing.Font(
			Font.FontFamily, fontSize, Font.Style);

		// Increase the size width and height of the button 
		// by 5 points each.
		Size = new System.Drawing.Size(Size.Width+5, Size.Height+5);

		// Call myBase.OnMouseHover to activate the delegate.
		base.OnMouseHover(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{

		// Make the cursor the Hand cursor when the mouse moves 
		// over the button.
		Cursor = Cursors.Hand;

		// Call MyBase.OnMouseMove to activate the delegate.
		base.OnMouseMove(e);
	}
	//</snippet2>

	[System.STAThreadAttribute]
	public static void Main()
	{
		Application.Run(new Form1());
	}

}

