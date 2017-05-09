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
      Me.button1.Location = New System.Drawing.Point(240, 48)
      Me.button1.Name = "button1"
      Me.button1.Size = New System.Drawing.Size(104, 24)
      Me.button1.TabIndex = 3
      Me.button1.Text = "button1"
      '
      'listBox1
      '
      Me.listBox1.Items.AddRange(New Object() {"Alpha", "Bravo", "Charlie", "Delta", "Echo"})
      Me.listBox1.Location = New System.Drawing.Point(8, 48)
      Me.listBox1.Name = "listBox1"
      Me.listBox1.Size = New System.Drawing.Size(224, 108)
      Me.listBox1.TabIndex = 2
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(432, 382)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.listBox1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
      FindMySpecificString("Charlie")
   End Sub

   '<Snippet1>
   Private Sub FindMySpecificString(ByVal searchString As String)
      ' Ensure we have a proper string to search for.
      If searchString <> String.Empty Then
         ' Find the item in the list and store the index to the item.
         Dim index As Integer = listBox1.FindStringExact(searchString)
         ' Determine if a valid index is returned. Select the item if it is valid.
         If index <> ListBox.NoMatches Then
            listBox1.SetSelected(index, True)
         Else
            MessageBox.Show("The search string did not find any items in the ListBox that exactly match the specified search string")
         End If
      End If
   End Sub
   '</Snippet1>

End Class
