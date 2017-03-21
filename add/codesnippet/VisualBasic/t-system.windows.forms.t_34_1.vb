    Public Sub New()

        ' Create and initialize the TreeView control.
        myTreeView = New TreeView()
        myTreeView.Dock = DockStyle.Fill
        myTreeView.BackColor = Color.Tan
        myTreeView.CheckBoxes = True
        
        ' Add nodes to the TreeView control.
        Dim node As TreeNode
        Dim x As Integer
        For x = 1 To 3

            ' Add a root node to the TreeView control.
            node = myTreeView.Nodes.Add(String.Format("Task {0}", x))
            Dim y As Integer
            For y = 1 To 3 

                ' Add a child node to the root node.
                node.Nodes.Add(String.Format("Subtask {0}", y))
            Next y
        Next x
        myTreeView.ExpandAll()
        
        ' Add tags containing alert messages to a few nodes 
        ' and set the node background color to highlight them.
        myTreeView.Nodes(1).Nodes(0).Tag = "urgent!"
        myTreeView.Nodes(1).Nodes(0).BackColor = Color.Yellow
        myTreeView.SelectedNode = myTreeView.Nodes(1).Nodes(0)
        myTreeView.Nodes(2).Nodes(1).Tag = "urgent!"
        myTreeView.Nodes(2).Nodes(1).BackColor = Color.Yellow
        
        ' Configure the TreeView control for owner-draw.
        myTreeView.DrawMode = TreeViewDrawMode.OwnerDrawText

        ' Add a handler for the MouseDown event so that a node can be 
        ' selected by clicking the tag text as well as the node text.
        AddHandler myTreeView.MouseDown, AddressOf myTreeView_MouseDown
        
        ' Initialize the form and add the TreeView control to it.
        Me.ClientSize = New Size(292, 273)
        Me.Controls.Add(myTreeView)
    End Sub 'New