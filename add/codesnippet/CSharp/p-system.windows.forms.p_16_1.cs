
	// Declare the dialog.
	internal PrintPreviewDialog PrintPreviewDialog1;

	// Declare a PrintDocument object named document.
	private System.Drawing.Printing.PrintDocument document =
		new System.Drawing.Printing.PrintDocument();

	// Initalize the dialog.
	private void InitializePrintPreviewDialog()
	{

		// Create a new PrintPreviewDialog using constructor.
		this.PrintPreviewDialog1 = new PrintPreviewDialog();

		//Set the size, location, and name.
		this.PrintPreviewDialog1.ClientSize = 
			new System.Drawing.Size(400, 300);
		this.PrintPreviewDialog1.Location = 
			new System.Drawing.Point(29, 29);
		this.PrintPreviewDialog1.Name = "PrintPreviewDialog1";
		
		// Associate the event-handling method with the 
		// document's PrintPage event.
		this.document.PrintPage += 
			new System.Drawing.Printing.PrintPageEventHandler
			(document_PrintPage);

		// Set the minimum size the dialog can be resized to.
		this.PrintPreviewDialog1.MinimumSize = 
			new System.Drawing.Size(375, 250);

		// Set the UseAntiAlias property to true, which will allow the 
		// operating system to smooth fonts.
		this.PrintPreviewDialog1.UseAntiAlias = true;
	}

	private void Button1_Click(object sender, System.EventArgs e)
	{

		if (TreeView1.SelectedNode != null)

			// Set the PrintDocument object's name to the selectedNode
			// object's  tag, which in this case contains the 
			// fully-qualified name of the document. This value will 
			// show when the dialog reports progress.
		{
			document.DocumentName = TreeView1.SelectedNode.Tag.ToString();
		}

		// Set the PrintPreviewDialog.Document property to
		// the PrintDocument object selected by the user.
		PrintPreviewDialog1.Document = document;

		// Call the ShowDialog method. This will trigger the document's
		//  PrintPage event.
		PrintPreviewDialog1.ShowDialog();
	}

	private void document_PrintPage(object sender, 
		System.Drawing.Printing.PrintPageEventArgs e)
	{

		// Insert code to render the page here.
		// This code will be called when the PrintPreviewDialog.Show 
		// method is called.

		// The following code will render a simple
		// message on the document in the dialog.
		string text = "In document_PrintPage method.";
		System.Drawing.Font printFont = 
			new System.Drawing.Font("Arial", 35, 
			System.Drawing.FontStyle.Regular);

		e.Graphics.DrawString(text, printFont, 
			System.Drawing.Brushes.Black, 0, 0);

	}