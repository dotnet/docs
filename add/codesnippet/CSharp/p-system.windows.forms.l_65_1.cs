	// Declare a label.
	internal System.Windows.Forms.Label Label1;
    
	// Initialize the label.
	private void InitializeLabel()
	{
		this.Label1 = new Label();
		this.Label1.Location = new System.Drawing.Point(10, 10);
		this.Label1.Name = "Label1";
		this.Label1.TabIndex = 0;

		// Set the label to a small size, but set the AutoSize property 
		// to true. The label will adjust its length so all the text
		// is visible, however if the label is wider than the form,
		// the entire label will not be visible.
		this.Label1.Size = new System.Drawing.Size(10, 10);
		this.Controls.Add(this.Label1);
		this.Label1.AutoSize = true;
		this.Label1.Text = "The text in this label is longer" +  
			" than the set size.";

	}