
	// Create a new form.
	Form mdiChildForm = new Form();

	private void Form1_Load(object sender, System.EventArgs e)
	{

		// Set the IsMdiContainer property to true.
		IsMdiContainer = true;

		// Set the child form's MdiParent property to 
		// the current form.
		mdiChildForm.MdiParent = this;

		// Call the method that changes the background color.
		SetBackGroundColorOfMDIForm();
	}

	private void SetBackGroundColorOfMDIForm()
	{
		foreach ( Control ctl in this.Controls )
		{
			if ((ctl) is MdiClient)

				// If the control is the correct type,
				// change the color.
			{
				ctl.BackColor = System.Drawing.Color.PaleGreen;
			}
		}

	}