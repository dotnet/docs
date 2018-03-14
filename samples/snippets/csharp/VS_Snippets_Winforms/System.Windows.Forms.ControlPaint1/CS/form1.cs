//This code example demonstrates ControlPaint.DrawReversibleLine, 
//ControlPaint.DrawFocusRectangle and ControlPaint.FillReversibleRectangle.

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
	internal System.Windows.Forms.Button Button2;
	internal System.Windows.Forms.Button Button3;
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.Button1 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.Button3 = new System.Windows.Forms.Button();
		this.SuspendLayout();
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(48, 40);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(88, 80);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Click for focus rectangle on Button2";
		this.Button1.Click += new System.EventHandler(Button1_Click);
		//
		//Button2
		//
		this.Button2.Location = new System.Drawing.Point(176, 48);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(72, 64);
		this.Button2.TabIndex = 1;
		this.Button2.Text = "Hover over me for filled rectangle";
		this.Button2.MouseHover += new System.EventHandler(Button2_MouseHover);
		this.Button2.MouseLeave += new System.EventHandler(Button2_MouseLeave);
		//
		//Button3
		//
		this.Button3.Location = new System.Drawing.Point(104, 160);
		this.Button3.Name = "Button3";
		this.Button3.Size = new System.Drawing.Size(96, 72);
		this.Button3.TabIndex = 2;
		this.Button3.Text = "Hover over for me for reversible lines";
		this.Button3.MouseHover += new System.EventHandler(Button3_MouseHover);
		this.Button3.MouseLeave += new System.EventHandler(Button3_MouseLeave);
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.Button3);
		this.Controls.Add(this.Button2);
		this.Controls.Add(this.Button1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	#endregion

	
	public static void Main()
	{
		Application.Run(new Form1());
	}

	//<snippet2>
	// This method draws a focus rectangle on Button2 using the 
	// handle and client rectangle of Button2.
	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		ControlPaint.DrawFocusRectangle(Graphics.FromHwnd(Button2.Handle), 
			Button2.ClientRectangle);
	}
	//</snippet2>

	//<snippet1>
	//When the mouse hovers over Button2, its ClientRectangle is filled.
	private void Button2_MouseHover(object sender, System.EventArgs e)
	{
		Control senderControl = (Control) sender;
		Rectangle screenRectangle = senderControl.RectangleToScreen(
			senderControl.ClientRectangle);
		ControlPaint.FillReversibleRectangle(screenRectangle, 
			senderControl.BackColor);
	}

	// When the mouse leaves Button2, its ClientRectangle is cleared by
	// calling the FillReversibleRectangle method again.
	private void Button2_MouseLeave(object sender, System.EventArgs e)
	{
		Control senderControl = (Control) sender;
		Rectangle screenRectangle = senderControl.RectangleToScreen(
			senderControl.ClientRectangle);
		ControlPaint.FillReversibleRectangle(screenRectangle, 
			senderControl.BackColor);
	}
	//</snippet1>

	//<snippet3>
	// When the mouse hovers over Button3, two reversible lines are 
	// drawn using the corner coordinates of Button3, which are first 
	// converted to screen coordinates.
	private void Button3_MouseHover(object sender, System.EventArgs e)
	{
		ControlPaint.DrawReversibleLine(Button3.PointToScreen(
			new Point(0, 0)), Button3.PointToScreen(
			new Point(Button3.ClientRectangle.Right, 
			Button3.ClientRectangle.Bottom)), SystemColors.Control);
		
		ControlPaint.DrawReversibleLine(Button3.PointToScreen(
			new Point(Button3.ClientRectangle.Right, 
			Button3.ClientRectangle.Top)), 
			Button3.PointToScreen(new Point(Button1.ClientRectangle.Left, 
			Button3.ClientRectangle.Bottom)), SystemColors.Control);
	}

	// When the mouse moves from Button3, the reversible lines are erased by
	// using the same coordinates as are used in the Button3_MouseHover method.
	private void Button3_MouseLeave(object sender, System.EventArgs e)
	{
		ControlPaint.DrawReversibleLine(Button3.PointToScreen(
			new Point(0, 0)), Button3.PointToScreen(
			new Point(Button3.ClientRectangle.Right, 
			Button3.ClientRectangle.Bottom)), SystemColors.Control);
		
		ControlPaint.DrawReversibleLine(Button3.PointToScreen(
			new Point(Button3.ClientRectangle.Right, 
			Button3.ClientRectangle.Top)), 
			Button3.PointToScreen(new Point(Button3.ClientRectangle.Left,
			Button3.ClientRectangle.Bottom)), SystemColors.Control);
	}
	//</snippet3>

}

