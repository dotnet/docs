//The following code example shows the use of the 
// SendKeys.Send method.
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
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.Button1 = new System.Windows.Forms.Button();
		this.Label1 = new System.Windows.Forms.Label();
		this.SuspendLayout();
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(96, 72);
		this.Button1.Name = "Button1";
		this.Button1.TabIndex = 0;
		this.Button1.Text = "&Click";
		this.Button1.Click += new System.EventHandler(Button1_Click);
		//
		//Label1
		//
		this.Label1.Location = new System.Drawing.Point(80, 16);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(128, 32);
		this.Label1.TabIndex = 1;
		this.Label1.Text = "Double-clicking form, clicks the button";
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.Button1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);
		this.DoubleClick += new System.EventHandler(Form1_DoubleClick);
	}

	#endregion


	//<snippet1>

	// Clicking Button1 causes a message box to appear.
	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		MessageBox.Show("Click here!");
	}


	// Use the SendKeys.Send method to raise the Button1 click event 
	// and display the message box.
	private void Form1_DoubleClick(object sender, System.EventArgs e)
	{

		// Send the enter key; since the tab stop of Button1 is 0, this
		// will trigger the click event.
		SendKeys.Send("{ENTER}");
	}
	//</snippet1>


	[System.STAThreadAttribute]
	public static void Main()
	{
		Application.Run(new Form1());
	}
}

