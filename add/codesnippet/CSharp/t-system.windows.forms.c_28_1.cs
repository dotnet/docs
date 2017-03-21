	// Declare comboBox1 as a ComboBox.
	internal System.Windows.Forms.ComboBox ComboBox1;
    
	// This method initializes the combo box, adding a large string array
	// but limiting the drop-down size to six rows so the combo box doesn't 
	// cover other controls when it expands.
	private void InitializeComboBox()
	{
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		string[] employees = new string[]{"Hamilton, David", "Hensien, Kari",
				"Hammond, Maria", "Harris, Keith", "Henshaw, Jeff D.", 
				"Hanson, Mark", "Harnpadoungsataya, Sariya", 
				"Harrington, Mark", "Harris, Keith", "Hartwig, Doris", 
				"Harui, Roger", "Hassall, Mark", "Hasselberg, Jonas", 
				"Harnpadoungsataya, Sariya", "Henshaw, Jeff D.", 
				"Henshaw, Jeff D.", "Hensien, Kari", "Harris, Keith", 
				"Henshaw, Jeff D.", "Hensien, Kari", "Hasselberg, Jonas",
				"Harrington, Mark", "Hedlund, Magnus", "Hay, Jeff", 
				"Heidepriem, Brandon D."};

		ComboBox1.Items.AddRange(employees);
		this.ComboBox1.Location = new System.Drawing.Point(136, 32);
        this.ComboBox1.IntegralHeight = false;
        this.ComboBox1.MaxDropDownItems = 5;
		this.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
		this.ComboBox1.Name = "ComboBox1";
		this.ComboBox1.Size = new System.Drawing.Size(136, 81);
		this.ComboBox1.TabIndex = 0;
		this.Controls.Add(this.ComboBox1);
		
		// Associate the event-handling method with the 
		// SelectedIndexChanged event.
		this.ComboBox1.SelectedIndexChanged += 
			new System.EventHandler(ComboBox1_SelectedIndexChanged);
	}