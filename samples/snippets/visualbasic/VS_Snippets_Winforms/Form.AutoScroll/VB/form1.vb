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
      Me.Button1.Location = New System.Drawing.Point(200, 32)
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
      DisplayMyScrollableForm()
   End Sub

   '<Snippet1>
   Private Sub DisplayMyScrollableForm()
      ' Create a new form.
      Dim form2 As New Form()
      ' Create a button to add to the new form.
      Dim button1 As New Button()
      ' Set text for the button.
      button1.Text = "Scrolled Button"
      ' Set the size of the button.
      button1.Size = New Size(100, 30)
      ' Set the location of the button to be outside the form's client area.
      button1.Location = New Point(form2.Size.Width + 200, form2.Size.Height + 200)

      ' Add the button control to the new form.
      form2.Controls.Add(button1)
      ' Set the AutoScroll property to true to provide scrollbars.
      form2.AutoScroll = True

      ' Display the new form as a dialog box.
      form2.ShowDialog()
   End Sub
   '</Snippet1>
End Class
