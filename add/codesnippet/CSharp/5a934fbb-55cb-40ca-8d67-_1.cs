      // Create a new LinkLabel control.
		private LinkLabel linkLabel1 = new LinkLabel();
		
		public void InitializeMyLinkLabel()
		{
			
			// Set the control to autosize based on the text content.
			linkLabel1.AutoSize = true;
			// Position and size the control on the form.
			linkLabel1.Location = new System.Drawing.Point(8,16);
			linkLabel1.Size = new System.Drawing.Size(135,13);
			// Set the text to display in the label.
			linkLabel1.Text = "Click here to get more info.";

			// Create a new link using the Add method of the LinkCollection class.
			linkLabel1.Links.Add(6,4,"www.microsoft.com");

			// Create an event handler for the LinkClicked event.
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);

			// Add the control to the form.
			this.Controls.Add(linkLabel1);
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			// Determine which link was clicked within the LinkLabel.
			linkLabel1.Links[linkLabel1.Links.IndexOf(e.Link)].Visited = true;
			// Display the appropriate link based on the value of the LinkData property of the Link object.
			System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
		}