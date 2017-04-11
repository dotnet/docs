Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        InitializeTreeView()
        InitializePrintPreviewDialog()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        Me.Button1.Location = New System.Drawing.Point(192, 104)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Print Preview"
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub

#End Region
    '<snippet1>
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
    '</snippet1>

    '<snippet2>
    ' Handle the After_Select event.
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.TreeViewEventArgs) _
            Handles TreeView1.AfterSelect

        ' Vary the response depending on which TreeViewAction
        ' triggered the event. 
        Select Case (e.Action)
            Case TreeViewAction.ByKeyboard
                MessageBox.Show("You like the keyboard!")
            Case TreeViewAction.ByMouse
                MessageBox.Show("You like the mouse!")
        End Select
    End Sub
    '</snippet2>


    ' The following code example assumes the form contains a TreeView
    ' object named TreeView1 that contains TreeNode objects. Each 
    ' TreeNode objects Tag property must be set to a fully-qualified
    ' document name that can be accessed by the machine running the 
    ' example.  Set each Text property to a string that identifies 
    ' the file specified by the Tag property. For example, you could set 
    ' TreeNode1.Tag to  c:\myDocuments\recipe.doc and 
    ' TreeNode1.Text to recipe.doc.


    ' It also assumes the form contains a PrintPreviewDialog object 
    ' named PrintPreviewDialog1 and a button named Button1. To run this 
    ' example call the InitializePrintPreviewDialog method in the form's 
    ' constructor.


    '<snippet3>

    ' Declare the dialog.
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog

    ' Declare a PrintDocument object named document.
    Private WithEvents document As New System.Drawing.Printing.PrintDocument

    ' Initalize the dialog.
    Private Sub InitializePrintPreviewDialog()

        ' Create a new PrintPreviewDialog using constructor.
        Me.PrintPreviewDialog1 = New PrintPreviewDialog

        'Set the size, location, and name.
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Location = New System.Drawing.Point(29, 29)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"

        ' Set the minimum size the dialog can be resized to.
        Me.PrintPreviewDialog1.MinimumSize = New System.Drawing.Size(375, 250)

        ' Set the UseAntiAlias property to true, which will allow the 
        ' operating system to smooth fonts.
        Me.PrintPreviewDialog1.UseAntiAlias = True
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        If (TreeView1.SelectedNode IsNot Nothing) Then

            ' Set the PrintDocument object's name to the selectedNode
            ' object's  tag, which in this case contains the 
            ' fully-qualified name of the document. This value will 
            ' show when the dialog reports progress.
            document.DocumentName = TreeView1.SelectedNode.Tag
        End If

        ' Set the PrintPreviewDialog.Document property to
        ' the PrintDocument object selected by the user.
        PrintPreviewDialog1.Document = document

        ' Call the ShowDialog method. This will trigger the document's
        '  PrintPage event.
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub document_PrintPage(ByVal sender As Object, _
        ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
            Handles document.PrintPage

        ' Insert code to render the page here.
        ' This code will be called when the PrintPreviewDialog.Show 
        ' method is called.

        ' The following code will render a simple
        ' message on the document in the dialog.
        Dim text As String = "In document_PrintPage method."
        Dim printFont As New System.Drawing.Font _
            ("Arial", 35, System.Drawing.FontStyle.Regular)

        e.Graphics.DrawString(text, printFont, _
            System.Drawing.Brushes.Black, 0, 0)

    End Sub
    '</snippet3>

    <System.STAThreadAttribute()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class

