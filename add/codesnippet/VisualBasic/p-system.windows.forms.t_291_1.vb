
    ' Declare the TreeView control.
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView

    ' Initialize the TreeView to blend with the form, giving it the 
    ' same color as the form and no border.
    Private Sub InitializeTreeView()

        ' Create a new TreeView control and set the location and size.
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.TreeView1.Location = New System.Drawing.Point(72, 48)
        Me.TreeView1.Size = New System.Drawing.Size(200, 200)

        ' Set the BorderStyle property to none, the BackColor property to  
        ' the form's backcolor, and the Scrollable property to false.  
        ' This allows the TreeView to blend in form.
        Me.TreeView1.BorderStyle = BorderStyle.None
        Me.TreeView1.BackColor = Me.BackColor
        Me.TreeView1.Scrollable = False

        
        ' Set the ShowRootLines and ShowLines properties to false to 
        ' give the TreeView a list-like appearance.
        Me.TreeView1.ShowRootLines = False
        Me.TreeView1.ShowLines = False

        ' Add the nodes.
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() _
            {New System.Windows.Forms.TreeNode("Features", _
            New System.Windows.Forms.TreeNode() _
            {New System.Windows.Forms.TreeNode("Full Color"), _
            New System.Windows.Forms.TreeNode("Project Wizards"), _
            New System.Windows.Forms.TreeNode("Visual C# and Visual Basic Support")}), _
            New System.Windows.Forms.TreeNode("System Requirements", _
            New System.Windows.Forms.TreeNode() _
            {New System.Windows.Forms.TreeNode _
            ("Pentium 133 MHz or faster processor "), _
            New System.Windows.Forms.TreeNode("Windows 98 or later"), _
            New System.Windows.Forms.TreeNode("100 MB Disk space")})})

        ' Set the tab index and add the TreeView to the form.
        Me.TreeView1.TabIndex = 0
        Me.Controls.Add(Me.TreeView1)
    End Sub