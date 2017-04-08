// The following code example demonstrates the result of setting 
// the desktop bounds and desktop location. It also demonstrates
// the Form.MaximumSize property.

using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

{
	#region " Windows Form Designer generated code "

	//<snippet3>
	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Set the maximum size, so if user maximizes form, it 
		//will not cover entire desktop.  
		this.MaximumSize = new System.Drawing.Size(500, 500);


	}
	//</snippet3>

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
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.Button1 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.SuspendLayout();
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(96, 48);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(96, 40);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Click me to see the form move";
		this.Button1.Click += new System.EventHandler(Button1_Click);
		//
		//Button2
		//
		this.Button2.Location = new System.Drawing.Point(96, 120);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(96, 48);
		this.Button2.TabIndex = 1;
		this.Button2.Text = "Click me to see form shrink (and move)";
		this.Button2.Click += new System.EventHandler(Button2_Click);

		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
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

	//<snippet1>
	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		
		for (int i = 0; i <= 25; i++)
		{
			// With each loop through the code, the form's desktop 
			// location is adjusted right and down by 10 pixels. 
			this.SetDesktopLocation(this.Location.X+10, this.Location.Y+10);

			// Call Sleep to give the effect of the form walking 
			// across the screen. 
			System.Threading.Thread.Sleep(250);
		}

		// Set the location back to the upper left-hand corner of 
		// the screen.
		this.SetDesktopLocation(10, 10);
	}
	//</snippet1>

	//<snippet2>
	private void Button2_Click(System.Object sender, System.EventArgs e)
	{
		
		for(int i = 0; i <= 20; i++)
		{
			// With each loop through the code, the form's 
			// desktop location is adjusted right and down
			//  by 10 pixels and its height and width are each
			// decreased by 10 pixels. 
			this.SetDesktopBounds(this.Location.X+10, 
				this.Location.Y+10, this.Width-10, this.Height-10);

			// Call Sleep to show the form gradually shrinking.
			System.Threading.Thread.Sleep(50);
		}
	}
	//</snippet2>

}

