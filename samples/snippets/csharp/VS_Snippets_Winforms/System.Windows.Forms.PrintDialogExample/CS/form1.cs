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
	internal System.Windows.Forms.PrintDialog PrintDialog1;
	internal System.Windows.Forms.Button Button1;
	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.PrintDialog1 = new System.Windows.Forms.PrintDialog();
		this.Button1 = new System.Windows.Forms.Button();
		this.SuspendLayout();
		//
		//Button1
		//
		this.Button1.Location = new System.Drawing.Point(104, 104);
		this.Button1.Name = "Button1";
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Print";
		this.Button1.Click += new System.EventHandler(Button1_Click);
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

	[System.STAThread]
	public static void Main()
	{
		Application.Run(new Form1());
	}

	//<snippet1>

	// Declare the PrintDocument object.
	private System.Drawing.Printing.PrintDocument docToPrint = 
		new System.Drawing.Printing.PrintDocument();

	// This method will set properties on the PrintDialog object and
	// then display the dialog.
	private void Button1_Click(System.Object sender, 
		System.EventArgs e)
	{

		// Allow the user to choose the page range he or she would
		// like to print.
		PrintDialog1.AllowSomePages = true;

		// Show the help button.
		PrintDialog1.ShowHelp = true;

		// Set the Document property to the PrintDocument for 
		// which the PrintPage Event has been handled. To display the
		// dialog, either this property or the PrinterSettings property 
		// must be set 
		PrintDialog1.Document = docToPrint;

		DialogResult result = PrintDialog1.ShowDialog();

		// If the result is OK then print the document.
		if (result==DialogResult.OK)
		{
			docToPrint.Print();
		}
        
	}

	// The PrintDialog will print the document
	// by handling the document's PrintPage event.
	private void document_PrintPage(object sender, 
		System.Drawing.Printing.PrintPageEventArgs e)
	{

		// Insert code to render the page here.
		// This code will be called when the control is drawn.

		// The following code will render a simple
		// message on the printed document.
		string text = "In document_PrintPage method.";
		System.Drawing.Font printFont = new System.Drawing.Font
			("Arial", 35, System.Drawing.FontStyle.Regular);

		// Draw the content.
		e.Graphics.DrawString(text, printFont, 
			System.Drawing.Brushes.Black, 10, 10);
	}
	//</snippet1>


}

