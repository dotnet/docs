Public Class Form1
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
   Friend WithEvents listBox2 As System.Windows.Forms.ListBox
   Friend WithEvents listBox1 As System.Windows.Forms.ListBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.listBox2 = New System.Windows.Forms.ListBox()
      Me.listBox1 = New System.Windows.Forms.ListBox()
      Me.SuspendLayout()
      '
      'listBox2
      '
      Me.listBox2.Items.AddRange(New Object() {"D", "A", "B", "E", "C", "F", "H", "G", "K", "I", "J"})
      Me.listBox2.Location = New System.Drawing.Point(224, 64)
      Me.listBox2.Name = "listBox2"
      Me.listBox2.Size = New System.Drawing.Size(136, 95)
      Me.listBox2.TabIndex = 4
      '
      'listBox1
      '
      Me.listBox1.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K"})
      Me.listBox1.Location = New System.Drawing.Point(64, 64)
      Me.listBox1.Name = "listBox1"
      Me.listBox1.Size = New System.Drawing.Size(136, 95)
      Me.listBox1.TabIndex = 3
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(440, 302)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.listBox2, Me.listBox1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   ' <Snippet1>
   Private Sub listBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listBox1.SelectedIndexChanged
      ' Get the currently selected item in the ListBox.
      Dim curItem As String = listBox1.SelectedItem.ToString()

      ' Find the string in ListBox2.
      Dim index As Integer = listBox2.FindString(curItem)
      ' If the item was not found in ListBox 2 display a message box, otherwise select it in ListBox2.
      If index = -1 Then
         MessageBox.Show("Item is not available in ListBox2")
      Else
         listBox2.SetSelected(index, True)
      End If
   End Sub
   '</Snippet1>
End Class
