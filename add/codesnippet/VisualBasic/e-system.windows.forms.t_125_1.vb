    Private Sub InitializeTreeView()

        ' Construct the TreeView object.
        Me.TreeView1 = New System.Windows.Forms.TreeView

        ' Set dock, location, size name, and tab order
        ' values for the TreeView object.

        With TreeView1
            .Dock = System.Windows.Forms.DockStyle.Left
            .Location = New System.Drawing.Point(0, 0)
            .Name = "TreeView1"
            .Size = New System.Drawing.Size(152, 266)
            .TabIndex = 1
        End With

        ' Set the LabelEdit property to true to allow the 
        ' user to edit the TreeNode text.
        Me.TreeView1.LabelEdit = True

        ' Declare and create objects needed to populate 
        ' the TreeView.
        Dim file, files(), filePath As String
        files = New String() {"bigPresentation.ppt", "myFinances.xls", _
            "myResume.doc"}
        filePath = "c:\myFiles"
        Dim nodes As New System.Collections.ArrayList

        ' Create a node for each file, setting the Text property to the 
        ' file's name and the Tag property to file's fully-qualified name.
        For Each file In files
            Dim node As New TreeNode(file)
            node.Tag = filePath & "\" & file
            nodes.Add(node)
        Next

        ' Create a new node named topNode and add the ArrayList of 
        ' nodes to topNode.
        Dim topNode As New TreeNode("myFiles", _
            nodes.ToArray(GetType(TreeNode)))

        topNode.Tag = filePath

        ' Add topNode to the TreeView.
        TreeView1.Nodes.Add(topNode)

        ' Add the TreeView to the form.
        Me.Controls.Add(TreeView1)
    End Sub

    Private Sub TreeView1_BeforeLabelEdit(ByVal sender As Object, _
        ByVal e As NodeLabelEditEventArgs) Handles TreeView1.BeforeLabelEdit

        ' Determine whether the user has selected the top node. If so,
        ' change the CancelEdit property to true to cancel the edit.  
        If (e.Node Is TreeView1.TopNode) Then

            e.CancelEdit = True
            MessageBox.Show("You are not allowed to edit the top node")
        End If


    End Sub