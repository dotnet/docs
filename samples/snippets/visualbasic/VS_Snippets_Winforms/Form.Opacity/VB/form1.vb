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
      Me.Button1.Location = New System.Drawing.Point(200, 48)
      Me.Button1.Name = "Button1"
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
      CreateMyOpaqueForm()
   End Sub

   '<Snippet1>
   Private Sub CreateMyOpaqueForm()
      ' Create a new form.
      Dim form2 As New Form()
      ' Set the text displayed in the caption.
      form2.Text = "My Form"
      ' Set the opacity to 75%.
      form2.Opacity = 0.75
      ' Size the form to be 300 pixels in height and width.
      form2.Size = New Size(300, 300)
      ' Display the form in the center of the screen.
      form2.StartPosition = FormStartPosition.CenterScreen

      ' Display the form as a modal dialog box.
      form2.ShowDialog()
   End Sub
   '</Snippet1>
End Class
