// The following code example demonstrates using the 
// ContextMenu.Show() method.

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
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.Button1 = new System.Windows.Forms.Button();
		this.Button1.Click += new System.EventHandler(Button1_Click);
		this.SuspendLayout();
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(104, 80);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(80, 80);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Click To See shortcut menu";
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.Button1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	#endregion

	[System.STAThreadAttribute]
	public static void Main()
	{
		Application.Run(new Form1());
	}


	//<snippet1>
	
	// Displays the shortcut menu, offsetting its location 
	// from the upper-left corner of Button1 by 20 pixels in each direction. 
	private void Button1_Click(System.Object sender, System.EventArgs e)
	{

		//Declare the menu items and the shortcut menu.
		MenuItem[] menuItems = new MenuItem[]{new MenuItem("Some Button Info"), 
			new MenuItem("Some Other Button Info"), new MenuItem("Exit")};

		ContextMenu buttonMenu = new ContextMenu(menuItems);
		buttonMenu.Show(Button1, new System.Drawing.Point(20, 20));
	}
	//</snippet1>

}

