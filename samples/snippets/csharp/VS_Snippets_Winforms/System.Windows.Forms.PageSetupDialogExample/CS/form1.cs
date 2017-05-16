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
	internal System.Windows.Forms.PageSetupDialog PageSetupDialog1;
	internal System.Windows.Forms.Button Button1;
	internal System.Windows.Forms.ListBox ListBox1;
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.PageSetupDialog1 = 
			new System.Windows.Forms.PageSetupDialog();
		this.Button1 = new System.Windows.Forms.Button();
		this.ListBox1 = new System.Windows.Forms.ListBox();
		this.SuspendLayout();
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(104, 24);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(88, 40);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Modify page settings";
		this.Button1.Click += new System.EventHandler(Button1_Click);
		//
		//ListBox1
		//
		this.ListBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.ListBox1.Location = new System.Drawing.Point(0, 106);
		this.ListBox1.Name = "ListBox1";
		this.ListBox1.Size = new System.Drawing.Size(292, 160);
		this.ListBox1.TabIndex = 1;
		//
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.ListBox1);
		this.Controls.Add(this.Button1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);

	}

	#endregion
	//<snippet1>

	//This method displays a PageSetupDialog object. If the
	// user clicks OK in the dialog, selected results of
	// the dialog are displayed in ListBox1.
    private void Button1_Click(System.Object sender, System.EventArgs e)
    {

        // Initialize the dialog's PrinterSettings property to hold user
        // defined printer settings.
        PageSetupDialog1.PageSettings =
            new System.Drawing.Printing.PageSettings();

        // Initialize dialog's PrinterSettings property to hold user
        // set printer settings.
        PageSetupDialog1.PrinterSettings =
            new System.Drawing.Printing.PrinterSettings();

        //Do not show the network in the printer dialog.
        PageSetupDialog1.ShowNetwork = false;

        //Show the dialog storing the result.
        DialogResult result = PageSetupDialog1.ShowDialog();

        // If the result is OK, display selected settings in
        // ListBox1. These values can be used when printing the
        // document.
        if (result == DialogResult.OK)
        {
            object[] results = new object[]{ 
				PageSetupDialog1.PageSettings.Margins, 
				PageSetupDialog1.PageSettings.PaperSize, 
				PageSetupDialog1.PageSettings.Landscape, 
				PageSetupDialog1.PrinterSettings.PrinterName, 
				PageSetupDialog1.PrinterSettings.PrintRange};
            ListBox1.Items.AddRange(results);
        }
       
    }
	//</snippet1>

	[System.STAThreadAttribute]
	public static void Main()
	{
		Application.Run(new Form1());
	}
}

