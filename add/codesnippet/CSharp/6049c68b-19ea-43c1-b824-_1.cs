
	//Declare the HelpProvider.
	internal System.Windows.Forms.HelpProvider HelpProvider1;


	private void InitializeHelpProvider()
	{
		// Construct the HelpProvider Object.
		this.HelpProvider1 = new System.Windows.Forms.HelpProvider();

		// Set the HelpNamespace property to the Help file for 
		// HelpProvider1.
		this.HelpProvider1.HelpNamespace = "c:\\windows\\input.chm";

		// Specify that the Help provider should open to the table
		// of contents of the Help file.
		this.HelpProvider1.SetHelpNavigator(TextBox1, 
			HelpNavigator.TableOfContents);
	}