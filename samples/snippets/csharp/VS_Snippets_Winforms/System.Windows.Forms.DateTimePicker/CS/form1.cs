// This example demonstrates using the read-only fields DateTimePicker.MaxDateTime
// and DateTimePicker.MinDateTime.

using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

{
	#region " Windows Form Designer generated code "

	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		InitializeDateTimePicker();

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

	internal System.Windows.Forms.ToolTip ToolTip1;

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();

		this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.SuspendLayout();
		//
		//DateTimePicker1
		//
      
		//
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

	// Declare the DateTimePicker.
	internal System.Windows.Forms.DateTimePicker DateTimePicker1;


	private void InitializeDateTimePicker()
	{
		// Construct the DateTimePicker.
		this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();

		//Set size and location.
		this.DateTimePicker1.Location = new System.Drawing.Point(40, 88);
		this.DateTimePicker1.Size = new System.Drawing.Size(160, 21);
        
		// Set the alignment of the drop-down MonthCalendar to right.
		this.DateTimePicker1.DropDownAlign = LeftRightAlignment.Right;

		// Set the Value property to 50 years before today.
		DateTimePicker1.Value = System.DateTime.Now.AddYears(-50);

		//Set a custom format containing the string "of the year"
		DateTimePicker1.Format = DateTimePickerFormat.Custom;
		DateTimePicker1.CustomFormat = "MMM dd, 'of the year' yyyy ";

		// Add the DateTimePicker to the form.
		this.Controls.Add(this.DateTimePicker1);
	}
	//</snippet1>

	//<snippet2>

	// When the calendar drops down, display a MessageBox indicating 
	// that DateTimePicker will not accept dates before MinDateTime or 
	// after MaxDateTime. Use a StringBuilder object to build the string
	// for efficiency.
	private void DateTimePicker1_DropDown(object sender, 
		System.EventArgs e)
	{

		System.Text.StringBuilder messageBuilder = 
			new System.Text.StringBuilder();
		messageBuilder.Append("Choose a date after: ");
		messageBuilder.Append
			(DateTimePicker.MinDateTime.ToShortDateString());
		messageBuilder.Append(" and a date before: ");
		messageBuilder.Append
			(DateTimePicker.MaxDateTime.ToShortDateString());
		MessageBox.Show(messageBuilder.ToString());
	}
	//</snippet2>

    
}

