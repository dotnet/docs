using System.Drawing;
using System.Windows.Forms;
using System;
public class Form1:
	System.Windows.Forms.Form

{
	#region " Windows Form Designer generated code "

	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		InitializeRadioButtonsAndGroupBox();
		this.RadioButton1.CheckedChanged += new 			EventHandler(RadioButton_CheckedChanged);
		this.RadioButton2.CheckedChanged += new 			EventHandler(RadioButton_CheckedChanged);
		this.RadioButton3.CheckedChanged += new 			EventHandler(RadioButton_CheckedChanged);

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


		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);

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
	//<snippet2>
	internal System.Windows.Forms.GroupBox GroupBox1;
	internal System.Windows.Forms.RadioButton RadioButton1;
	internal System.Windows.Forms.RadioButton RadioButton2;
	internal System.Windows.Forms.RadioButton RadioButton3;

	private void InitializeRadioButtonsAndGroupBox()
	{

		// Construct the GroupBox object.
		this.GroupBox1 = new GroupBox();

		// Construct the radio buttons.
		this.RadioButton1 = new System.Windows.Forms.RadioButton();
		this.RadioButton2 = new System.Windows.Forms.RadioButton();
		this.RadioButton3 = new System.Windows.Forms.RadioButton();

		// Set the location, tab and text for each radio button
		// to a cursor from the Cursors enumeration.
		this.RadioButton1.Location = new System.Drawing.Point(24, 24);
		this.RadioButton1.TabIndex = 0;
		this.RadioButton1.Text = "Help";
		this.RadioButton1.Tag = Cursors.Help;
		this.RadioButton1.TextAlign = ContentAlignment.MiddleCenter;

		this.RadioButton2.Location = new System.Drawing.Point(24, 56);
		this.RadioButton2.TabIndex = 1;
		this.RadioButton2.Text = "Up Arrow";
		this.RadioButton2.Tag = Cursors.UpArrow;
		this.RadioButton2.TextAlign = ContentAlignment.MiddleCenter;

		this.RadioButton3.Location = new System.Drawing.Point(24, 80);
		this.RadioButton3.TabIndex = 3;
		this.RadioButton3.Text = "Cross";
		this.RadioButton3.Tag = Cursors.Cross;
		this.RadioButton3.TextAlign = ContentAlignment.MiddleCenter;
		
		
		// Add the radio buttons to the GroupBox.  
		this.GroupBox1.Controls.Add(this.RadioButton1);
		this.GroupBox1.Controls.Add(this.RadioButton2);
		this.GroupBox1.Controls.Add(this.RadioButton3);

		// Set the location of the GroupBox. 
		this.GroupBox1.Location = new System.Drawing.Point(56, 64);
		this.GroupBox1.Size = new System.Drawing.Size(200, 150);

		// Set the text that will appear on the GroupBox.
		this.GroupBox1.Text = "Choose a Cursor Style";
		//
		// Add the GroupBox to the form.
		this.Controls.Add(this.GroupBox1);
		//

	}
	// </snippet1>

	private void RadioButton_CheckedChanged(object sender, EventArgs e)
	{

		// Cast the sender back to a RadioButton object.
		RadioButton selectedRadioButton = (RadioButton) sender;

		// If the radio button is in a checked state, then
		// change the cursor.
		if (selectedRadioButton.Checked)
		{
			Cursor = (Cursor)selectedRadioButton.Tag;
		}
	}

	//</snippet2>
}

