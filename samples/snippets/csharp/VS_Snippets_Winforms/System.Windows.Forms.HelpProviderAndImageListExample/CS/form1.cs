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
		InitializeHelpProvider();

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

	internal System.Windows.Forms.TextBox TextBox1;

	internal System.Windows.Forms.Button Button1;
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.TextBox1 = new System.Windows.Forms.TextBox();


		this.Button1 = new System.Windows.Forms.Button();
		this.SuspendLayout();
		//
		//TextBox1
		//
		this.TextBox1.Location = new System.Drawing.Point(16, 24);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.TabIndex = 0;
		this.TextBox1.Text = "Press F1 for help.";

		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(160, 24);
		this.Button1.Name = "Button1";
		this.Button1.TabIndex = 2;
		this.Button1.Text = "Button1";
		this.Button1.Click += new System.EventHandler(Button1_Click);
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.Button1);

		this.Controls.Add(this.TextBox1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	#endregion

	//<snippet1>

	//Declare the HelpProvider.
	internal System.Windows.Forms.HelpProvider HelpProvider1;


	private void InitializeHelpProvider()
	{
		// Construct the HelpProvider Object.
		this.HelpProvider1 = new System.Windows.Forms.HelpProvider();

		// Set the HelpNamespace property to the Help file for 
		// HelpProvider1.
		this.HelpProvider1.HelpNamespace = "c:\\windows\\input.chm";

		// Specify that the Help provider should open to the table
		// of contents of the Help file.
		this.HelpProvider1.SetHelpNavigator(TextBox1, 
			HelpNavigator.TableOfContents);
	}
	//</snippet1>

	//<snippet2>
	internal System.Windows.Forms.ImageList ImageList1;

	// Create an ImageList Object, populate it, and display
	// the images it contains.
	private void Button1_Click(System.Object sender, 
		System.EventArgs e)
	{

		// Construct the ImageList.
		ImageList1 = new ImageList();

		// Set the ImageSize property to a larger size 
		// (the default is 16 x 16).
		ImageList1.ImageSize = new Size(112, 112);

		// Add two images to the list.
		ImageList1.Images.Add(
			Image.FromFile("c:\\windows\\FeatherTexture.bmp"));
		ImageList1.Images.Add(
			Image.FromFile("C:\\windows\\Gone Fishing.bmp"));

		// Get a Graphics object from the form's handle.
		Graphics theGraphics = Graphics.FromHwnd(this.Handle);

		// Loop through the images in the list, drawing each image.
		for(int count = 0; count < ImageList1.Images.Count; count++)
		{
			ImageList1.Draw(theGraphics, new Point(85, 85), count);

			// Call Application.DoEvents to force a repaint of the form.
			Application.DoEvents();

			// Call the Sleep method to allow the user to see the image.
			System.Threading.Thread.Sleep(1000);
		}
	}

	//</snippet2>

	[System.STAThread]
	public static void Main()
	{
		Application.Run(new Form1());
	}
}

