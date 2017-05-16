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
		this.Button1.Location = new System.Drawing.Point(24, 32);
		this.Button1.Name = "Button1";
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Button1";
		this.Button1.Paint += new PaintEventHandler(Button1_Paint);
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Paint += new PaintEventHandler(Form1_Paint);
		this.Controls.Add(this.Button1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}


	#endregion
	//<snippet1>
	// Handle the Button1 object's Paint Event to create a CaptionButton.
	private void Button1_Paint(object sender, PaintEventArgs e)
	{

		// Draw a CaptionButton control using the ClientRectangle 
		// property of Button1. Make the button a Help button 
		// with a normal state.
		ControlPaint.DrawCaptionButton(e.Graphics, Button1.ClientRectangle,
			CaptionButton.Help, ButtonState.Normal);
	}
	//</snippet1>

	//<snippet2>
	// Handle the Form's Paint event to draw a 3D three-dimensional 
	// raised border just inside the border of the frame.
	private void Form1_Paint(object sender, PaintEventArgs e)
	{

		Rectangle borderRectangle = this.ClientRectangle;
		borderRectangle.Inflate(-10, -10);
		ControlPaint.DrawBorder3D(e.Graphics, borderRectangle, 
			Border3DStyle.Raised);
	}
	//</snippet2>

	public static void Main()
	{
		Application.Run(new Form1());
	}

}





