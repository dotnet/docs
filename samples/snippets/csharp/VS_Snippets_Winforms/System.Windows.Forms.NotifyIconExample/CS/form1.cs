using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

{
	#region " Windows Form Designer generated code "

	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		InitializeContextMenu();

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
	internal System.Windows.Forms.NotifyIcon NotifyIcon1;
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
		this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
		//
		//NotifyIcon1
		//
		this.NotifyIcon1.Icon = System.Drawing.SystemIcons.Asterisk;
		this.NotifyIcon1.Text = "NotifyIcon1";
		this.NotifyIcon1.Visible = true;
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Name = "Form1";
		this.Text = "Form1";

	}

	#endregion

	[System.STAThreadAttribute]
	public static void Main()
	{
		Application.Run(new Form1());
	}

	// <snippet1>
	// Initalize the NofifyIcon object's shortcut menu.
	private void InitializeContextMenu()
	{
		MenuItem[] menuList = new MenuItem[]{new MenuItem("Sign In"),
			new MenuItem("Get Help"), new MenuItem("Open")};
		ContextMenu clickMenu = new ContextMenu(menuList);
		NotifyIcon1.ContextMenu = clickMenu;

		// Associate the event-handling method with 
		// the NotifyIcon object's click event.
		NotifyIcon1.Click +=new System.EventHandler(NotifyIcon1_Click);
	}


	// When user clicks the left mouse button display the shortcut menu.  
	// Use the SystemInformation.PrimaryMonitorMaximizedWindowSize property
	// to place the menu at the lower corner of the screen.
	private void NotifyIcon1_Click(object sender, System.EventArgs e)
	{
		System.Drawing.Size windowSize = 
			SystemInformation.PrimaryMonitorMaximizedWindowSize;
		System.Drawing.Point menuPoint = 
			new System.Drawing.Point(windowSize.Width-180, 
			windowSize.Height-5);
		menuPoint = this.PointToClient(menuPoint);

		NotifyIcon1.ContextMenu.Show(this, menuPoint);
		
	}
	// </snippet1>

}

