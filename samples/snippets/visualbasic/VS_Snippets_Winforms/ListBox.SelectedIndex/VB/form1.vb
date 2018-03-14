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
   Friend WithEvents button1 As System.Windows.Forms.Button
   Friend WithEvents listBox1 As System.Windows.Forms.ListBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.button1 = New System.Windows.Forms.Button()
      Me.listBox1 = New System.Windows.Forms.ListBox()
      Me.SuspendLayout()
      '
      'button1
      '
      Me.button1.Location = New System.Drawing.Point(296, 64)
      Me.button1.Name = "button1"
      Me.button1.Size = New System.Drawing.Size(88, 24)
      Me.button1.TabIndex = 3
      Me.button1.Text = "button1"
      '
      'listBox1
      '
      Me.listBox1.Items.AddRange(New Object() {"Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf", "Hotel"})
      Me.listBox1.Location = New System.Drawing.Point(48, 48)
      Me.listBox1.Name = "listBox1"
      Me.listBox1.Size = New System.Drawing.Size(216, 69)
      Me.listBox1.TabIndex = 2
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(440, 214)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.listBox1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
      RemoveTopItems()
   End Sub

   '<Snippet1>
   Private Sub RemoveTopItems()
      ' Determine if the currently selected item in the ListBox 
      ' is the item displayed at the top in the ListBox.
      If listBox1.TopIndex <> listBox1.SelectedIndex Then
         ' Make the currently selected item the top item in the ListBox.
         listBox1.TopIndex = listBox1.SelectedIndex
      End If
      ' Remove all items before the top item in the ListBox.
      Dim x As Integer
      For x = listBox1.SelectedIndex - 1 To 0 Step -1
         listBox1.Items.RemoveAt(x)
      Next x

      ' Clear all selections in the ListBox.
      listBox1.ClearSelected()
   End Sub 'RemoveTopItems
   '</Snippet1>
End Class
