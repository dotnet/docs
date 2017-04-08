
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections


'Create a Class that inherits from System.Windows.Forms.Form. 

Class Form1
    Inherits Form
    
    Public Sub New() 
        InitializeComponent()
        'InitializeStatefulTreeView();
        'InitializeTreeViewWithToolTips()
        InitializeTreeView1()
      
        'InitializeLineTreeView();
    End Sub 'New 
    
   
    ' <snippet1>
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
    ' </snippet1>

    ' The following code example demonstrates setting the TreeNode line color.
    ' To run this example, paste the code into a Windows Form. Call 
    ' InitializeLineTreeView from the form's constructor or Load
    ' event handling method.
    ' <snippet2>
    Private lineTreeView As TreeView
    
    Public Sub InitializeLineTreeView() 
        lineTreeView = New TreeView()
        lineTreeView.Size = New Size(200, 200)
        
        lineTreeView.LineColor = Color.Red
        
        ' Create the root nodes.
        Dim docNode As New TreeNode("Documents")
        
        ' Add some additional nodes.
        docNode.Nodes.Add("phoneList.doc")
        docNode.Nodes.Add("resume.doc")
        
        lineTreeView.Nodes.Add(docNode)
        Controls.Add(lineTreeView)
    
    End Sub
    
    ' </snippet2>
    <STAThreadAttribute()>  _
    Public Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub 'Main
    
    
    Private Sub InitializeComponent() 
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        ' 
        ' textBox1
        ' 
        Me.textBox1.Location = New System.Drawing.Point(180, 93)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.TabIndex = 0
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(textBox1)
        Me.Name = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    
    End Sub 'InitializeComponent
     
    
    
    
    ' The following example code demonstrates how to use the TreeNode.Level, 
    ' TreeViewHitTestInfo.Node and TreeView.HitTest members.
    ' To run this example create a Windows Form that contains a TreeView 
    ' named treeView1 and populate it with several levels of nodes.
    ' Paste the following code into the form and associate the MouseDown
    ' event of treeView1 with the treeView1_MouseDown method in this example. 
    '<snippet3>
    Sub treeView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) 
        Dim info As TreeViewHitTestInfo = treeView1.HitTest(e.X, e.Y)
        Dim hitNode As TreeNode
        If (info.Node IsNot Nothing) Then
            hitNode = info.Node
            MessageBox.Show(hitNode.Level.ToString())
        End If
    
    End Sub 'treeView1_MouseDown
    
    '</snippet3>
    
    
    
    ' The following example demonstrates how to handle the NodeMouseClick event.
    '<snippet4>
    Sub treeView1_NodeMouseClick(ByVal sender As Object, _
        ByVal e As TreeNodeMouseClickEventArgs) _
        Handles treeView1.NodeMouseClick

        textBox1.Text = e.Node.Text

    End Sub 'treeView1_NodeMouseClick
    
    
    '</snippet4>
    ' The following example demonstrates how to handle the NodeMouseDoubleClick 
    ' event and how to use the TreeNodeMouseClickEventArgs.
    ' To run this example, paste the code into a Windows Form that contains a 
    ' TreeView named treeView1. Populate the treeView1 with the names of files 
    ' located in the c:\ directly of the system the sample is running on, and associate
    ' the NodeMouseDoubleClick event of treeView1 with the treeView1_NodeMouseDoubleClick
    ' method in this example.
    '<snippet5>
    ' If a node is double-clicked, open the file indicated by the TreeNode.
    Sub treeView1_NodeMouseDoubleClick(ByVal sender As Object, _
        ByVal e As TreeNodeMouseClickEventArgs) _
        Handles treeView1.NodeMouseDoubleClick

        Try
            ' Look for a file extension, and open the file.
            If e.Node.Text.Contains(".") Then
                System.Diagnostics.Process.Start("c:\" + e.Node.Text)
            End If
            ' If the file is not found, handle the exception and inform the user.
        Catch
            MessageBox.Show("File not found.")
        End Try

    End Sub 'treeView1_NodeMouseDoubleClick
    
    '</snippet5>
    ' The following example demonstrates how to handle the
    ' NodeMouseHover event.
    ' <snippet6>
    Sub treeView1_NodeMouseHover(ByVal sender As Object, _
        ByVal e As TreeNodeMouseHoverEventArgs) _
        Handles treeView1.NodeMouseHover

        e.Node.Toggle()

    End Sub 'treeView1_NodeMouseHover
    
    ' </snippet6>

    ' The following code example demonstrates how to use the ToolTipText
    ' and ShowNodeToolTips members.  To run this example, paste
    ' the following code into a Windows Form and call 
    ' InitializeTreeViewWithToolTips from the form's constructor
    ' or Load event-handling method.
    ' <snippet7>
    Private treeViewWithToolTips As TreeView
    
    Private Sub InitializeTreeViewWithToolTips() 
        treeViewWithToolTips = New TreeView()
        Dim node1 As New TreeNode("Node1")
        node1.ToolTipText = "Help for Node1"
        Dim node2 As New TreeNode("Node2")
        node2.ToolTipText = "A Tip for Node2"
        treeViewWithToolTips.Nodes.AddRange(New TreeNode() {node1, node2})
        treeViewWithToolTips.ShowNodeToolTips = True
        Me.Controls.Add(treeViewWithToolTips)
    
    End Sub
    ' </snippet7>

    ' The following code example demonstrates the StateImageList 
    ' property. To run this example, paste the code into a Windows
    ' Form and call InitializeCheckTreeView from the form's 
    ' constructor or Load event-handling method.
    ' <snippet8>
    Private checkTreeView As TreeView
    
    Private Sub InitializeCheckTreeView() 
        checkTreeView = New TreeView()
        
        ' Show check boxes for the TreeView.
        checkTreeView.CheckBoxes = True
        
        ' Create the StateImageList and add two images.
        checkTreeView.StateImageList = New ImageList()
        checkTreeView.StateImageList.Images.Add(SystemIcons.Question)
        checkTreeView.StateImageList.Images.Add(SystemIcons.Exclamation)
        
        ' Add some nodes to the TreeView and the TreeView to the form.
        checkTreeView.Nodes.Add("Node1")
        checkTreeView.Nodes.Add("Node2")
        Me.Controls.Add(checkTreeView)
    
    End Sub
    '</snippet8>
End Class 'Form1 