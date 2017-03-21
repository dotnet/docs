		// Declare the drop-down button and the items it will contain.
		internal ToolStripDropDownButton dropDownButton1;
		internal ToolStripDropDown dropDown;
		internal ToolStripButton buttonRed;
		internal ToolStripButton buttonBlue;
		internal ToolStripButton buttonYellow;


		private void InitializeDropDownButton()
		{
			dropDownButton1 = new ToolStripDropDownButton();
			dropDown = new ToolStripDropDown();
			dropDownButton1.Text = "A";

			// Set the drop-down on the ToolStripDropDownButton.
			dropDownButton1.DropDown = dropDown;

            // Set the drop-down direction.
            dropDownButton1.DropDownDirection = ToolStripDropDownDirection.Left;

            // Do not show a drop-down arrow.
            dropDownButton1.ShowDropDownArrow = false;

			// Declare three buttons, set their foreground color and text, 
			// and add the buttons to the drop-down.
			buttonRed = new ToolStripButton();
			buttonRed.ForeColor = Color.Red;
			buttonRed.Text = "A";

			buttonBlue = new ToolStripButton();
			buttonBlue.ForeColor = Color.Blue;
			buttonBlue.Text = "A";

			buttonYellow = new ToolStripButton();
			buttonYellow.ForeColor = Color.Yellow;
			buttonYellow.Text = "A";
			
			buttonBlue.Click += new EventHandler(colorButtonsClick);
			buttonRed.Click += new EventHandler(colorButtonsClick);
			buttonYellow.Click += new EventHandler(colorButtonsClick);

			dropDown.Items.AddRange(new ToolStripItem[] 
				{ buttonRed, buttonBlue, buttonYellow });
			toolStrip1.Items.Add(dropDownButton1);
		}


		// Handle the buttons' click event by setting the foreground color of the
		// form to the foreground color of the button that is clicked.
		private void colorButtonsClick(object sender, EventArgs e)
		{
			ToolStripButton senderButton = (ToolStripButton)sender;
			this.ForeColor = senderButton.ForeColor;
		}