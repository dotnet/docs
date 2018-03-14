using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form


{
	#region " Windows Form Designer generated code "

	public Form1() : base()
	{        

		//This call is required by the Windows Form Designer.
		InitializeComponent();
		ChangeTheLookOfTheTabControl();
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
	internal System.Windows.Forms.TabControl TabControl1;
	internal System.Windows.Forms.TabPage TabPage1;
	internal System.Windows.Forms.TabPage TabPage2;
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.TabControl1.SuspendLayout();
		this.SuspendLayout();
		//
		//TabControl1
		//
		this.TabControl1.Controls.Add(this.TabPage1);
		this.TabControl1.Controls.Add(this.TabPage2);
		this.TabControl1.Location = new System.Drawing.Point(0, 0);
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.SelectedIndex = 0;
		this.TabControl1.TabIndex = 0;
		//
		//TabPage1
		//
		this.TabPage1.Location = new System.Drawing.Point(4, 22);
		this.TabPage1.Name = "TabPage1";
		this.TabPage1.Size = new System.Drawing.Size(192, 74);
		this.TabPage1.TabIndex = 0;
		this.TabPage1.Text = "Errors";
		//
		//TabPage2
		//
		this.TabPage2.Location = new System.Drawing.Point(4, 22);
		this.TabPage2.Name = "TabPage2";
		this.TabPage2.Size = new System.Drawing.Size(192, 74);
		this.TabPage2.TabIndex = 1;
		this.TabPage2.Text = "Failures";
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(296, 294);
		this.Controls.Add(this.TabControl1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.TabControl1.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	#endregion
	//<snippet1>
	private void ChangeTheLookOfTheTabControl()
	{

		// Set the size and location of the TabControl.
		this.TabControl1.Location = new System.Drawing.Point(20, 20);
		TabControl1.Size = new System.Drawing.Size(250, 250);

		// Align the tabs along the bottom of the control.
		TabControl1.Alignment = TabAlignment.Bottom;

		// Change the tabs to flat buttons.
		TabControl1.Appearance = TabAppearance.FlatButtons;
	}
	//</snippet1>

	
	[System.STAThread]
	public static void Main()
	{
		Application.Run(new Form1());
	}


}

