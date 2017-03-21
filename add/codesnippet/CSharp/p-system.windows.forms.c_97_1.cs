    
	// Declare ComboBox1.
	internal System.Windows.Forms.ComboBox ComboBox1;
    
	// Initialize ComboBox1.
	private void InitializeComboBox()
	{
		this.ComboBox1 = new ComboBox();
		this.ComboBox1.Location = new System.Drawing.Point(128, 48);
		this.ComboBox1.Name = "ComboBox1";
		this.ComboBox1.Size = new System.Drawing.Size(100, 21);
		this.ComboBox1.TabIndex = 0;
		this.ComboBox1.Text	= "Typical";
		string[] installs = new string[]{"Typical", "Compact", "Custom"};
		ComboBox1.Items.AddRange(installs);
		this.Controls.Add(this.ComboBox1);
		
		// Hook up the event handler.
		this.ComboBox1.DropDown +=  
			new System.EventHandler(ComboBox1_DropDown);
	}

	// Handles the ComboBox1 DropDown event. If the user expands the  
	// drop-down box, a message box will appear, recommending the
	// typical installation.
	private void ComboBox1_DropDown(object sender, System.EventArgs e)
	{
		MessageBox.Show("Typical installation is strongly recommended.", 
		"Install information", MessageBoxButtons.OK, 
			MessageBoxIcon.Information);
	}