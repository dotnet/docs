
	// Declare the TreeView control.
	internal System.Windows.Forms.TreeView TreeView1;

	// Initialize the TreeView to blend with the form, giving it the 
	// same color as the form and no border.
	private void InitializeTreeView()
	{

		// Create a new TreeView control and set the location and size.
		this.TreeView1 = new System.Windows.Forms.TreeView();
		this.TreeView1.Location = new System.Drawing.Point(72, 48);
		this.TreeView1.Size = new System.Drawing.Size(200, 200);

		// Set the BorderStyle property to none, the BackColor property to  
		// the form's backcolor, and the Scrollable property to false.  
		// This allows the TreeView to blend in form.

		this.TreeView1.BorderStyle = BorderStyle.None;
		this.TreeView1.BackColor = this.BackColor;
		this.TreeView1.Scrollable = false;

		// Set the HideSelection property to false to keep the 
		// selection highlighted when the user leaves the control. 
		// This helps it blend with form.
		this.TreeView1.HideSelection = false;

		// Set the ShowRootLines and ShowLines properties to false to 
		// give the TreeView a list-like appearance.
		this.TreeView1.ShowRootLines = false;
		this.TreeView1.ShowLines = false;

		// Add the nodes.
		this.TreeView1.Nodes.AddRange(new TreeNode[]
			{new TreeNode("Features", 
				new TreeNode[]{
				new TreeNode("Full Color"), 
				new TreeNode("Project Wizards"), 
				new TreeNode("Visual C# and Visual Basic Support")}), 
				new TreeNode("System Requirements", 
				new TreeNode[]{
					new TreeNode("Pentium 133 MHz or faster processor "),
					new TreeNode("Windows 98 or later"), 
					new TreeNode("100 MB Disk space")})
			});

		// Set the tab index and add the TreeView to the form.
		this.TreeView1.TabIndex = 0;
		this.Controls.Add(this.TreeView1);
	}