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
	internal System.Windows.Forms.TextBox TextBox1;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.Button Button2;
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.Button1 = new System.Windows.Forms.Button();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.Button2 = new System.Windows.Forms.Button();
		this.SuspendLayout();
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(32, 160);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(80, 32);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Help";
		this.Button1.Click += new System.EventHandler(Button1_Click);
		//
		//TextBox1
		//
		this.TextBox1.Location = new System.Drawing.Point(152, 72);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.TabIndex = 1;
		this.TextBox1.Text = "";
		//
		//Label1
		//
		this.Label1.Location = new System.Drawing.Point(40, 72);
		this.Label1.Name = "Label1";
		this.Label1.TabIndex = 2;
		this.Label1.Text = "Name";
		//
		//Button2
		//
		this.Button2.Location = new System.Drawing.Point(168, 168);
		this.Button2.Name = "Button2";
		this.Button2.TabIndex = 3;
		this.Button2.Text = "More Help";
		this.Button2.Click += new System.EventHandler(Button2_Click);
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.Button2);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.Button1);
		this.Name = "Form1";
		this.Text = "Register";
		this.ResumeLayout(false);

	}

	#endregion

	[System.STAThreadAttribute]
	public static void Main()
	{
		Application.Run(new Form1());
	}

	//<snippet1>
	// Open the Help file for the Character Map topic.  
	private void Button1_Click(System.Object sender, System.EventArgs e)
	{

		Help.ShowHelp(TextBox1, "file://c:\\charmap.chm");
	}
	//</snippet1>

	//<snippet2>
	// Open the Help file for the Character Map topic and 
	// display the Index page.
	private void Button2_Click(System.Object sender, System.EventArgs e)
	{

		Help.ShowHelp(TextBox1, "file://c:\\charmap.chm", 
			HelpNavigator.Index);
	}
	//</snippet2>

}

