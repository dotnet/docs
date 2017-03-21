	// This method initializes CheckedListBox1 with a list of all 
	// the controls on the form. It sets the selection mode
	// to single selection and allows selection with a single click.
	// It adds itself to the list before adding itself to the form.

	internal System.Windows.Forms.CheckedListBox CheckedListBox1;

	private void InitializeCheckedListBox()
	{
		this.CheckedListBox1 = new CheckedListBox();
		this.CheckedListBox1.Location = new System.Drawing.Point(40, 90);
		this.CheckedListBox1.CheckOnClick = true;
		this.CheckedListBox1.Name = "CheckedListBox1";
		this.CheckedListBox1.Size = new System.Drawing.Size(120, 94);
		this.CheckedListBox1.TabIndex = 1;
		this.CheckedListBox1.SelectionMode = SelectionMode.One;
		this.CheckedListBox1.ThreeDCheckBoxes = true;

		foreach ( Control aControl in this.Controls )
		{
			this.CheckedListBox1.Items.Add(aControl, false);
		}

		this.CheckedListBox1.DisplayMember = "Name";
		this.CheckedListBox1.Items.Add(CheckedListBox1);
		this.Controls.Add(this.CheckedListBox1);
	}