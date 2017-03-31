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
   Friend WithEvents Button1 As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(152, 40)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(56, 24)
      Me.Button1.TabIndex = 0
      Me.Button1.Text = "Button1"
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      CreateMyTopMostForm()
   End Sub

   '<Snippet1>
   Private Sub CreateMyTopMostForm()
      ' Create lower form to display.
      Dim bottomForm As New Form()
      ' Display the lower form Maximized to demonstrate effect of TopMost property.
      bottomForm.WindowState = FormWindowState.Maximized
      ' Display the bottom form.
      bottomForm.Show()
      ' Create the top most form.
      Dim topMostForm As New Form()
      ' Set the size of the form larger than the default size.
      topMostForm.Size = New Size(300, 300)
      ' Set the position of the top most form to center of screen.
      topMostForm.StartPosition = FormStartPosition.CenterScreen
      ' Display the form as top most form.
      topMostForm.TopMost = True
      topMostForm.Show()
   End Sub 'CreateMyTopMostForm
   '</Snippet1>
End Class
