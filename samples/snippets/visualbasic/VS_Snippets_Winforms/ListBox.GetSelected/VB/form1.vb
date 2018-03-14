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
      Me.button1.Location = New System.Drawing.Point(291, 162)
      Me.button1.Name = "button1"
      Me.button1.TabIndex = 3
      Me.button1.Text = "button1"
      '
      'listBox1
      '
      Me.listBox1.Items.AddRange(New Object() {"Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtro", "Golf", "Hotel", "Igloo", "Java", "Koala", "Lima", "Mama"})
      Me.listBox1.Location = New System.Drawing.Point(83, 130)
      Me.listBox1.Name = "listBox1"
      Me.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None
      Me.listBox1.Size = New System.Drawing.Size(200, 82)
      Me.listBox1.TabIndex = 2
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(448, 342)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.listBox1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      listBox1.Items.Clear()
      InitializeMyListBox()
   End Sub

   '<Snippet1>
   Private Sub InitializeMyListBox()
      ' Add items to the ListBox.
      listBox1.Items.Add("A")
      listBox1.Items.Add("C")
      listBox1.Items.Add("E")
      listBox1.Items.Add("F")
      listBox1.Items.Add("G")
      listBox1.Items.Add("D")
      listBox1.Items.Add("B")

      ' Sort all items added previously.
      listBox1.Sorted = True

      ' Set the SelectionMode to select multiple items.
      listBox1.SelectionMode = SelectionMode.MultiExtended

      ' Select three initial items from the list.
      listBox1.SetSelected(0, True)
      listBox1.SetSelected(2, True)
      listBox1.SetSelected(4, True)

      ' Force the ListBox to scroll back to the top of the list.
      listBox1.TopIndex = 0
   End Sub

   Private Sub InvertMySelection()

      Dim x As Integer
      ' Loop through all items the ListBox.
      For x = 0 To listBox1.Items.Count - 1

         ' Determine if the item is selected.
         If listBox1.GetSelected(x) = True Then
            ' Deselect all items that are selected.
            listBox1.SetSelected(x, False)
         Else
            ' Select all items that are not selected.
            listBox1.SetSelected(x, True)
         End If
      Next x
      ' Force the ListBox to scroll back to the top of the list.
      listBox1.TopIndex = 0
   End Sub
   '</Snippet1>

   Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
      InvertMySelection()
   End Sub

End Class
