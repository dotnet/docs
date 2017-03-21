
	// Declare the TreeView control.
	internal System.Windows.Forms.TreeView TreeView2;

	// Initialize the TreeView to blend with the form, giving it the 
	// same color as the form and no border.
	private void InitializeSelectedTreeView()
	{

		// Create a new TreeView control and set the location and size.
		this.TreeView2 = new System.Windows.Forms.TreeView();
		this.TreeView2.Location = new System.Drawing.Point(72, 48);
		this.TreeView2.Size = new System.Drawing.Size(200, 200);

		this.TreeView2.BorderStyle = BorderStyle.Fixed3D;
		
		// Set the HideSelection property to false to keep the 
		// selection highlighted when the user leaves the control. 
		// This helps it blend with form.
		this.TreeView2.HideSelection = false;

		// Add the nodes.
		this.TreeView2.Nodes.AddRange(new TreeNode[]
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
		this.TreeView2.TabIndex = 0;
		this.Controls.Add(this.TreeView2);
	}