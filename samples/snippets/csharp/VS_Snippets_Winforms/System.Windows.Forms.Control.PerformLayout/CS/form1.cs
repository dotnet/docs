// This example demonstrates using the Control.PerformLayout method.  
// It contains a custom LayoutControl object and three buttons.  
// The Click event handler for Button1 explicitly calls PerformLayout.  
// The Click event handler for Button2 implicitly calls PerformLayout. 
// PerformLayout is also called when the form is loaded. Button3 returns 
// the control to the state it was in when loaded.

//<snippet1>

using System.Windows.Forms;
using System.Drawing;



public class LayoutForm:
	System.Windows.Forms.Form

{
	public LayoutForm() : base()
	{        
		InitializeComponent();
	}

	internal System.Windows.Forms.Button Button1;
	internal System.Windows.Forms.Button Button2;
	internal LayoutControl LayoutControl1;
	internal System.Windows.Forms.Button Button3;

	private void InitializeComponent()
	{
		this.Button1 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.Button3 = new System.Windows.Forms.Button();
		this.LayoutControl1 = new LayoutControl();
		this.SuspendLayout();
		this.Button1.Location = new System.Drawing.Point(16, 16);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(120, 32);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Center textbox on control";
		this.Button2.Location = new System.Drawing.Point(152, 16);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(104, 32);
		this.Button2.TabIndex = 3;
		this.Button2.Text = "Shrink user control";
		this.Button3.Location = new System.Drawing.Point(96, 232);
		this.Button3.Name = "Button3";
		this.Button3.TabIndex = 5;
		this.Button3.Text = "Reset";
		this.LayoutControl1.BackColor = System.Drawing.SystemColors.ControlDark;
		this.LayoutControl1.Location = new System.Drawing.Point(72, 64);
		this.LayoutControl1.Name = "LayoutControl1";
		this.LayoutControl1.Size = new System.Drawing.Size(150, 160);
		this.LayoutControl1.TabIndex = 6;
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.Button3);
		this.Controls.Add(this.Button2);
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.LayoutControl1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);
		this.Button1.Click += new System.EventHandler(Button1_Click);
		this.Button2.Click += new System.EventHandler(Button2_Click);
		this.Button3.Click += new System.EventHandler(Button3_Click);

	}

	[System.STAThread]
	public static void Main()
	{
		Application.Run(new LayoutForm());
	}


	// This method explicitly calls raises the layout event on 
	// LayoutControl1, changing the Bounds property.
	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		LayoutControl1.PerformLayout(LayoutControl1, "Bounds");
	}

	// This resize of LayoutControl1 implicitly triggers the layout event. 
	//  Changing the size of the control affects its Bounds property.
	private void Button2_Click(System.Object sender, System.EventArgs e)
	{
		LayoutControl1.Size = new System.Drawing.Size(100, 100);
	}

	// This method explicitly calls PerformLayout with no parameters, 
	// which raises the Layout event with the LayoutEventArgs properties
	// equal to Nothing.
	private void Button3_Click(System.Object sender, System.EventArgs e)
	{
		LayoutControl1.PerformLayout();
	}

}


// This custom control has the Layout event implented so that when 
// PerformLayout(AffectedControl, AffectedProperty) is called 
// on the control, where AffectedProperty equals "Bounds" the 
// textbox is centered on the control.
public class LayoutControl:
	System.Windows.Forms.UserControl
{
	internal System.Windows.Forms.TextBox TextBox1;

	public LayoutControl() : base()
	{        
		InitializeComponent();
	}

	private void InitializeComponent()
	{
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.SuspendLayout();
		this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.TabIndex = 0;
		this.BackColor = System.Drawing.SystemColors.ControlDark;
		this.Controls.Add(this.TextBox1);
		this.Name = "LayoutControl";
		this.ResumeLayout(false);
		this.Layout += new LayoutEventHandler(LayoutControl_Layout);

	}

	// This method is called when the Layout event is fired. 
	// This happens by during the initial load, by calling PerformLayout
	// or by resizing, adding or removing controls or other actions that 
	// affect how the control is laid out. This method checks the 
	// value of e.AffectedProperty and changes the look of the 
	// control accordingly. 
	private void LayoutControl_Layout(object sender, 
		System.Windows.Forms.LayoutEventArgs e)
	{
		if (e.AffectedProperty != null)
		{
			if (e.AffectedProperty.Equals("Bounds"))
			{
				TextBox1.Left = (this.Width-TextBox1.Width)/2;
				TextBox1.Top = (this.Height-TextBox1.Height)/2;
			}
		}
		else
		{
			this.Size = new System.Drawing.Size(150, 160);
			TextBox1.Location = new System.Drawing.Point(16, 24);
		}
		TextBox1.Text = "Left = "+TextBox1.Left+" Top = "+TextBox1.Top;
	}

}

	//</snippet1>





