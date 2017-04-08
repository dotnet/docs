Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public NotInheritable Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(232, 8)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(296, 251)
        Me.ListBox1.TabIndex = 1
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(8, 8)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(216, 248)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(592, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox1, Me.RichTextBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

'<snippet1>
Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   ' Sets the AllowDrop property so that data can be dragged onto the control.
   RichTextBox1.AllowDrop = True

   ' Add code here to populate the ListBox1 with paths to text files.

End Sub

Private Sub RichTextBox1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles RichTextBox1.DragEnter
   ' If the data is text, copy the data to the RichTextBox control.
   If (e.Data.GetDataPresent("Text")) Then
      e.Effect = DragDropEffects.Copy
   End If
End Sub


Private Overloads Sub RichTextBox1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles RichTextBox1.DragDrop
   ' Loads the file into the control. 
   RichTextBox1.LoadFile(e.Data.GetData("Text"), System.Windows.Forms.RichTextBoxStreamType.RichText)
End Sub

Private Sub ListBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDown
   Dim Lb As ListBox
   Dim Pt As New Point(e.X, e.Y)
   Dim Index As Integer

   ' Determines which item was selected.
   Lb = sender
   Index = Lb.IndexFromPoint(Pt)

   ' Starts a drag-and-drop operation with that item.
   If Index >= 0 Then
      Lb.DoDragDrop(Lb.Items(Index), DragDropEffects.Link)
   End If
End Sub
'</snippet1>

End Class
