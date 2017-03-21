
    ' Declare the TreeView control.
    Friend WithEvents TreeView2 As System.Windows.Forms.TreeView

    ' Initialize the TreeView to blend with the form, giving it the 
    ' same color as the form and no border.
    Private Sub InitializeSelectedTreeView()

        ' Create a new TreeView control and set the location and size.
        Me.TreeView2 = New System.Windows.Forms.TreeView
        Me.TreeView2.Location = New System.Drawing.Point(72, 48)
        Me.TreeView2.Size = New System.Drawing.Size(200, 200)
        Me.TreeView2.BorderStyle = BorderStyle.Fixed3D
       
        ' Set the HideSelection property to false to keep the 
        ' selection highlighted when the user leaves the control. 
        Me.TreeView2.HideSelection = False

        ' Add the nodes.
        Me.TreeView2.Nodes.AddRange(New System.Windows.Forms.TreeNode() _
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
        Me.TreeView2.TabIndex = 0
        Me.Controls.Add(Me.TreeView2)
    End Sub