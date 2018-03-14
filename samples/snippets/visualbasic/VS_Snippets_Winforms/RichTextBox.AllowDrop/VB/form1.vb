Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "
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
   Friend WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
   Friend WithEvents listBox1 As System.Windows.Forms.ListBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
      Me.listBox1 = New System.Windows.Forms.ListBox()
      Me.SuspendLayout()
      '
      'richTextBox1
      '
      Me.richTextBox1.Location = New System.Drawing.Point(236, 39)
      Me.richTextBox1.Name = "richTextBox1"
      Me.richTextBox1.Size = New System.Drawing.Size(208, 240)
      Me.richTextBox1.TabIndex = 3
      Me.richTextBox1.Text = ""
      '
      'listBox1
      '
      Me.listBox1.Items.AddRange(New Object() {"Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot"})
      Me.listBox1.Location = New System.Drawing.Point(12, 39)
      Me.listBox1.Name = "listBox1"
      Me.listBox1.Size = New System.Drawing.Size(208, 238)
      Me.listBox1.TabIndex = 2
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(456, 318)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.richTextBox1, Me.listBox1})
      Me.Name = "Form1"
      Me.Text = "VB Version"
      Me.ResumeLayout(False)

   End Sub

#End Region

   '<Snippet1>
   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      richTextBox1.AllowDrop = True

   End Sub

   Private Sub listBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listBox1.MouseDown
      ' Determines which item was selected.
      Dim lb As ListBox = CType(sender, ListBox)
      Dim pt As New Point(e.X, e.Y)
      'Retrieve the item at the specified location within the ListBox.
      Dim index As Integer = lb.IndexFromPoint(pt)

      ' Starts a drag-and-drop operation.
      If index >= 0 Then
         ' Retrieve the selected item text to drag into the RichTextBox.
         lb.DoDragDrop(lb.Items(index).ToString(), DragDropEffects.Copy)
      End If
   End Sub 'listBox1_MouseDown


   Private Sub richTextBox1_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles richTextBox1.DragEnter
      ' If the data is text, copy the data to the RichTextBox control.
      If e.Data.GetDataPresent("Text") Then
         e.Effect = DragDropEffects.Copy
      End If
   End Sub 'richTextBox1_DragEnter

   Private Sub richTextBox1_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles richTextBox1.DragDrop
      ' Paste the text into the RichTextBox where at selection location.
      richTextBox1.SelectedText = e.Data.GetData("System.String", True).ToString()
   End Sub 'richTextBox1_DragDrop

   '</Snippet1>
End Class
