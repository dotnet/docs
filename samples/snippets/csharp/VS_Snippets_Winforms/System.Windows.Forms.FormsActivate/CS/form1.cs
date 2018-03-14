// The following code example demonstrates another use of the 
// Form.SetDesktopLocation and Form.Activate members, 
// and demonstrates handling the Form.Load and Form.Activate 
// events.

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
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Label Label2;
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.Button1 = new System.Windows.Forms.Button();
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.SuspendLayout();
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(104, 80);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(96, 56);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Click me for an new inactivated form.";
		this.Button1.Click += new System.EventHandler(Button1_Click);
		//
		//Label1
		//
		this.Label1.Location = new System.Drawing.Point(104, 160);
		this.Label1.Name = "Label1";
		this.Label1.TabIndex = 1;
		this.Label1.Text = "Label1";
		//
		//Label2
		//
		this.Label2.Location = new System.Drawing.Point(104, 208);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(40, 40);
		this.Label2.TabIndex = 2;
		this.Label2.Text = "Label2";
		this.Label2.AutoSize = true;
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.Button1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.Activated += new System.EventHandler(Form1_Activated);
		this.Load += new System.EventHandler(Form1_Load);
		this.Closed += new System.EventHandler(Form1_Closed);
		this.ResumeLayout(false);

	}

	#endregion

	public static void Main()
	{
		Application.Run(new Form1());
	}

	// <snippet1>
	static int x = 200;
	static int y = 200;

	private void Button1_Click(System.Object sender, 
		System.EventArgs e)
	{
		// Create a new Form1 and set its Visible property to true.
		Form1 form2 = new Form1();
		form2.Visible = true;

		// Set the new form's desktop location so it  
		// appears below and to the right of the current form.
		form2.SetDesktopLocation(x, y);
		x += 30;
		y += 30;

		// Keep the current form active by calling the Activate
		// method.
		this.Activate();
		this.Button1.Enabled = false;
	}
	


	// Updates the label text to reflect the current values of x 
	// and y, which was were incremented in the Button1 control's 
	// click event.
	private void Form1_Activated(object sender, System.EventArgs e)
	{
		Label1.Text = "x: "+x+" y: "+y;
		Label2.Text = "Number of forms currently open: "+count;
	}

	static int count = 0;

	private void Form1_Closed(object sender, System.EventArgs e)
	{
		count -= 1;
	}

	private void Form1_Load(object sender, System.EventArgs e)
	{
		count += 1;
	}
	//</snippet1>

}

