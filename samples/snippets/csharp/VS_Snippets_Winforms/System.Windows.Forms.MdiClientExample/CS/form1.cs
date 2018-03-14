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
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Name = "Form1";
		this.Text = "Form1";
		this.Load += new System.EventHandler(Form1_Load);

	}

	#endregion



	// The following code example demonstrates using the IsMdiContainer
	// property and changing the BackColor property of an MDI Form.


	//<snippet1>

	// Create a new form.
	Form mdiChildForm = new Form();

	private void Form1_Load(object sender, System.EventArgs e)
	{

		// Set the IsMdiContainer property to true.
		IsMdiContainer = true;

		// Set the child form's MdiParent property to 
		// the current form.
		mdiChildForm.MdiParent = this;

		// Call the method that changes the background color.
		SetBackGroundColorOfMDIForm();
	}

	private void SetBackGroundColorOfMDIForm()
	{
		foreach ( Control ctl in this.Controls )
		{
			if ((ctl) is MdiClient)

				// If the control is the correct type,
				// change the color.
			{
				ctl.BackColor = System.Drawing.Color.PaleGreen;
			}
		}

	}
	//</snippet1>

	public static void Main()
	{
		Application.Run(new Form1());
	}

}

