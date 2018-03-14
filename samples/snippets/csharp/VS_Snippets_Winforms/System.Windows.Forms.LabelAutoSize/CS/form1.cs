// The following code example demonstrates how setting the 
// Label.Autosize property to True will causes the width of 
// the label to adjust.
using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form


{
	#region " Windows Form Designer generated code "

	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		InitializeLabel();

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
		this.SuspendLayout();
		this.ClientSize = new System.Drawing.Size(266, 300);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	#endregion
	public static void Main()
	{
		Application.Run(new Form1());
	}

	//<snippet1>
	// Declare a label.
	internal System.Windows.Forms.Label Label1;
    
	// Initialize the label.
	private void InitializeLabel()
	{
		this.Label1 = new Label();
		this.Label1.Location = new System.Drawing.Point(10, 10);
		this.Label1.Name = "Label1";
		this.Label1.TabIndex = 0;

		// Set the label to a small size, but set the AutoSize property 
		// to true. The label will adjust its length so all the text
		// is visible, however if the label is wider than the form,
		// the entire label will not be visible.
		this.Label1.Size = new System.Drawing.Size(10, 10);
		this.Controls.Add(this.Label1);
		this.Label1.AutoSize = true;
		this.Label1.Text = "The text in this label is longer" +  
			" than the set size.";

	}
	//</snippet1>
}

