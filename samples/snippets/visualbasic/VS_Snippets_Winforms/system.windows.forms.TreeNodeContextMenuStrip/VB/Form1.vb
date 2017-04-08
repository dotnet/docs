
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections


'Create a Class that inherits from System.Windows.Forms.Form. 

Class myForm
    Inherits Form
    
    Public Sub New() 
        InitializeComponent()
        InitializeMenuTreeView()
    
    End Sub 'New 
    
    '<snippet1>
    ' Declare the TreeView and ContextMenuStrip
    Private menuTreeView As TreeView
    Private docMenu As ContextMenuStrip
    
    
    Public Sub InitializeMenuTreeView() 

        ' Create the TreeView.
        menuTreeView = New TreeView()
        menuTreeView.Size = New Size(200, 200)
        
        ' Create the root node.
        Dim docNode As New TreeNode("Documents")
        
        ' Add some additional nodes.
        docNode.Nodes.Add("phoneList.doc")
        docNode.Nodes.Add("resume.doc")
        
        ' Add the root nodes to the TreeView.
        menuTreeView.Nodes.Add(docNode)
        
        ' Create the ContextMenuStrip.
        docMenu = New ContextMenuStrip()
        
        'Create some menu items.
        Dim openLabel As New ToolStripMenuItem()
        openLabel.Text = "Open"
        Dim deleteLabel As New ToolStripMenuItem()
        deleteLabel.Text = "Delete"
        Dim renameLabel As New ToolStripMenuItem()
        renameLabel.Text = "Rename"
        
        'Add the menu items to the menu.
        docMenu.Items.AddRange(New ToolStripMenuItem() _
            {openLabel, deleteLabel, renameLabel})
        
        ' Set the ContextMenuStrip property to the ContextMenuStrip.
        docNode.ContextMenuStrip = docMenu
        
        ' Add the TreeView to the form.
        Me.Controls.Add(menuTreeView)
    
    End Sub
    
    
    '</snippet1>
    <STAThreadAttribute()>  _
    Public Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New myForm())
    
    End Sub 'Main
    
    
    Private Sub InitializeComponent() 
        
        Me.SuspendLayout()
        
        ' 
        ' myForm
        ' 
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "myForm"
        Me.ResumeLayout(False)
    
    End Sub 'InitializeComponent 
End Class 'myForm
