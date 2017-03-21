    ' Declare the TreeView.
    Private WithEvents treeView1 As TreeView
    Private textBox1 As TextBox
    Private WithEvents button1 As Button
    
    
    Private Sub InitializeTreeView1()

        ' Create the TreeView
        treeView1 = New TreeView()
        treeView1.Size = New Size(200, 200)

        ' Create the button and set some basic properties. 
        button1 = New Button()
        button1.Location = New Point(205, 138)
        button1.Text = "Set Sorter"

        ' Create the root nodes.
        Dim docNode As New TreeNode("Documents")
        Dim spreadSheetNode As New TreeNode("Spreadsheets")

        ' Add some additional nodes.
        spreadSheetNode.Nodes.Add("payroll.xls")
        spreadSheetNode.Nodes.Add("checking.xls")
        spreadSheetNode.Nodes.Add("tracking.xls")
        docNode.Nodes.Add("phoneList.doc")
        docNode.Nodes.Add("resume.doc")

        ' Add the root nodes to the TreeView.
        treeView1.Nodes.Add(spreadSheetNode)
        treeView1.Nodes.Add(docNode)

        ' Add the TreeView to the form.
        Controls.Add(treeView1)
        Controls.Add(button1)

    End Sub
    
    
    ' Set the TreeViewNodeSorter property to a new instance
    ' of the custom sorter.
    Private Sub button1_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles button1.Click

        treeView1.TreeViewNodeSorter = New NodeSorter()

    End Sub 'button1_Click
    
    ' Create a node sorter that implements the IComparer interface.
    
    Public Class NodeSorter
        Implements IComparer
        
        ' Compare the length of the strings, or the strings
        ' themselves, if they are the same length.
        Public Function Compare(ByVal x As Object, ByVal y As Object) _
            As Integer Implements IComparer.Compare
            Dim tx As TreeNode = CType(x, TreeNode)
            Dim ty As TreeNode = CType(y, TreeNode)
           
            If tx.Text.Length <> ty.Text.Length Then
                Return tx.Text.Length - ty.Text.Length
            End If
            Return String.Compare(tx.Text, ty.Text)

        End Function
    End Class