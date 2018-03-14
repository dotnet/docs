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
      Me.button1.Location = New System.Drawing.Point(275, 129)
      Me.button1.Name = "button1"
      Me.button1.TabIndex = 3
      Me.button1.Text = "button1"
      '
      'listBox1
      '
      Me.listBox1.Location = New System.Drawing.Point(59, 121)
      Me.listBox1.Name = "listBox1"
      Me.listBox1.Size = New System.Drawing.Size(160, 69)
      Me.listBox1.TabIndex = 2
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(408, 310)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.listBox1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
      DisplayHScroll()
   End Sub
   '<Snippet1>
   Private Sub DisplayHScroll()
        ' Make sure no items are displayed partially.
      listBox1.IntegralHeight = True
      Dim x As Integer

      ' Add items that are wide to the ListBox.
      For x = 0 To 10
         listBox1.Items.Add("Item  " + x.ToString() + " is a very large value that requires scroll bars")
      Next x

      ' Display a horizontal scroll bar.
      listBox1.HorizontalScrollbar = True

      ' Create a Graphics object to use when determining the size of the largest item in the ListBox.
      Dim g As System.Drawing.Graphics = listBox1.CreateGraphics()


      ' Determine the size for HorizontalExtent using the MeasureString method using the last item in the list.
      Dim hzSize As Integer = g.MeasureString(listBox1.Items(listBox1.Items.Count - 1).ToString(), listBox1.Font).Width
      ' Set the HorizontalExtent property.
      listBox1.HorizontalExtent = hzSize
   End Sub
   '</Snippet1>
End Class
