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
		InitializePrintPreviewControl();
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

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{

		this.PrintDialog1 = new System.Windows.Forms.PrintDialog();
		this.SuspendLayout();
		//Form1
		//
		this.ClientSize = new System.Drawing.Size(292, 266);
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

	// Declare the PrintPreviewControl object and the 
	// PrintDocument object.
	internal PrintPreviewControl PrintPreviewControl1;
	private System.Drawing.Printing.PrintDocument docToPrint = 
		new System.Drawing.Printing.PrintDocument();

	private void InitializePrintPreviewControl()
	{

		// Construct the PrintPreviewControl.
		this.PrintPreviewControl1 = new PrintPreviewControl();

		// Set location, name, and dock style for PrintPreviewControl1.
		this.PrintPreviewControl1.Location = new Point(88, 80);
		this.PrintPreviewControl1.Name = "PrintPreviewControl1";
		this.PrintPreviewControl1.Dock = DockStyle.Fill;

		// Set the Document property to the PrintDocument 
		// for which the PrintPage event has been handled.
		this.PrintPreviewControl1.Document = docToPrint;

		// Set the zoom to 25 percent.
		this.PrintPreviewControl1.Zoom = 0.25;

		// Set the document name. This will show be displayed when 
		// the document is loading into the control.
		this.PrintPreviewControl1.Document.DocumentName = "c:\\someFile";

		// Set the UseAntiAlias property to true so fonts are smoothed
		// by the operating system.
		this.PrintPreviewControl1.UseAntiAlias = true;

		// Add the control to the form.
		this.Controls.Add(this.PrintPreviewControl1);
		
		// Associate the event-handling method with the
		// document's PrintPage event.
		this.docToPrint.PrintPage += 
			new System.Drawing.Printing.PrintPageEventHandler(
			docToPrint_PrintPage);
	}

	// The PrintPreviewControl will display the document
	// by handling the documents PrintPage event
	private void docToPrint_PrintPage(
		object sender, System.Drawing.Printing.PrintPageEventArgs e)
	{

		// Insert code to render the page here.
		// This code will be called when the control is drawn.

		// The following code will render a simple
		// message on the document in the control.
		string text = "In docToPrint_PrintPage method.";
		System.Drawing.Font printFont = 
			new Font("Arial", 35, FontStyle.Regular);

		e.Graphics.DrawString(text, printFont,
			Brushes.Black, 10, 10);
	}
	//</snippet1>



}

