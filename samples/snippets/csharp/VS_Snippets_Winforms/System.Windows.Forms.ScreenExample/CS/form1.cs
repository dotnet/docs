using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

{
	#region " Windows Form Designer generated code "

	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeComponent();


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
	internal System.Windows.Forms.Button Button1;
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.Button1 = new System.Windows.Forms.Button();
		this.SuspendLayout();
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(112, 32);
		this.Button1.Name = "Button1";
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Resize form";
		this.Button1.Click += new System.EventHandler(Button1_Click);
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.Button1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	#endregion

	//<snippet1>
	// This method will adjust the size of the form to utilize 
	// the working area of the screen.
	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		// Retrieve the working rectangle from the Screen class
		// using the PrimaryScreen and the WorkingArea properties.
		System.Drawing.Rectangle workingRectangle = 
			Screen.PrimaryScreen.WorkingArea;
		
		// Set the size of the form slightly less than size of 
		// working rectangle.
		this.Size = new System.Drawing.Size(
			workingRectangle.Width-10, workingRectangle.Height-10);

		// Set the location so the entire form is visible.
		this.Location = new System.Drawing.Point(5, 5);
	}
	//</snippet1>

	[System.STAThreadAttribute]
	public static void Main()
	{
		Application.Run(new Form1());
	}

}

