// This example demonstrates handling the use of a ColorDialog object. 
// The ColorDialog object does not allow the user to set a custom color 
// but it allows the full set of basic colors to be displayed. By setting the
// SolidColorOnly property to false, it allows the display of colors that 
// are combinations of other colors on systems with 256 or less colors. 
// The dialog also shows the handling of a HelpRequest event.


using System.Windows.Forms;
using System.Drawing;

public class Form1:
	System.Windows.Forms.Form

{
	public Form1() : base()
	{        
		InitializeComponent();
		InitializeColorDialog();
	}

	internal System.Windows.Forms.Button Button1;
	internal System.Windows.Forms.TextBox TextBox1;
	internal System.Windows.Forms.ColorDialog ColorDialog1;

	private void InitializeComponent()
	{
		this.Button1 = new System.Windows.Forms.Button();
		this.Button1.Click += new System.EventHandler(Button1_Click);
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.SuspendLayout();
		this.Button1.Location = new System.Drawing.Point(24, 16);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(88, 56);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Click to change the color of the textbox";
		this.TextBox1.Location = new System.Drawing.Point(24, 88);
		this.TextBox1.Multiline = true;
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(96, 96);
		this.TextBox1.TabIndex = 1;
		this.TextBox1.Text = "Here is some text";
		this.ClientSize = new System.Drawing.Size(152, 266);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.Button1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);
	}

	[System.STAThread]
	public static void Main()
	{
		Application.Run(new Form1());
	}

	//<snippet1>
	// This method initializes ColorDialog1 to allow any colors, 
	// and combination colors on systems with 256 colors or less, 
	// but will not allow the user to set custom colors.  The
	// dialog will contain the help button.
	private void InitializeColorDialog()
	{
		this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
		this.ColorDialog1.AllowFullOpen = false;
		this.ColorDialog1.AnyColor = true;
		this.ColorDialog1.SolidColorOnly = false;
		this.ColorDialog1.ShowHelp = true;
		
		// Associate the event-handling method with
		// the HelpRequest event.
		this.ColorDialog1.HelpRequest 
			+= new System.EventHandler(ColorDialog1_HelpRequest);
	}
	
	
	// This method opens the dialog and checks the DialogResult value. 
	// If the result is OK, the text box's background color will be changed 
	// to the user-selected color.
	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		DialogResult result = ColorDialog1.ShowDialog();
		if (result.Equals(DialogResult.OK))
		{
			TextBox1.BackColor = ColorDialog1.Color;
		}
	}
	
	// This method is called when the HelpRequest event is raised, 
	//which occurs when the user clicks the Help button on the ColorDialog object.
	private void ColorDialog1_HelpRequest(object sender, System.EventArgs e)
	{

		MessageBox.Show("Please select a color by clicking it. "
           + "This will change the BackColor property of the TextBox.");
	}
	//</snippet1>

}





