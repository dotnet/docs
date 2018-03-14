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
   Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
   Friend WithEvents Button1 As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.ListBox1 = New System.Windows.Forms.ListBox()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'ListBox1
      '
      Me.ListBox1.Location = New System.Drawing.Point(32, 72)
      Me.ListBox1.Name = "ListBox1"
      Me.ListBox1.Size = New System.Drawing.Size(136, 56)
      Me.ListBox1.TabIndex = 0
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(192, 88)
      Me.Button1.Name = "Button1"
      Me.Button1.TabIndex = 1
      Me.Button1.Text = "Button1"
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.ListBox1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      SizeMyListBox()
   End Sub

   '<Snippet1>
   Private Sub SizeMyListBox()
      ' Add items to the ListBox.
      Dim x As Integer
      For x = 0 To 19
         listBox1.Items.Add(("Item " + x.ToString()))
      Next x
      ' Set the height of the ListBox to the preferred height to display all items.
      listBox1.Height = listBox1.PreferredHeight
   End Sub 'SizeMyListBox
   '</Snippet1>
End Class
