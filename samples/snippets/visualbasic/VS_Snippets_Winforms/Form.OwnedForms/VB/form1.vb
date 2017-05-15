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
   Friend WithEvents Button2 As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.Button2 = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(152, 64)
      Me.Button1.Name = "Button1"
      Me.Button1.TabIndex = 0
      Me.Button1.Text = "Button1"
      '
      'Button2
      '
      Me.Button2.Location = New System.Drawing.Point(144, 128)
      Me.Button2.Name = "Button2"
      Me.Button2.TabIndex = 1
      Me.Button2.Text = "Button2"
      '
      'Form1
      '
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2, Me.Button1})
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      AddMyOwnedForm()
   End Sub

   Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      ChangeOwnedFormText()
   End Sub

   '<Snippet1>
   Private Sub AddMyOwnedForm()
      ' Create form to be owned.
      Dim ownedForm As New Form()
      ' Set the text of the owned form.
      ownedForm.Text = "Owned Form " + Me.OwnedForms.Length.ToString()
      ' Add the form to the array of owned forms.
      Me.AddOwnedForm(ownedForm)
      ' Show the owned form.
      ownedForm.Show()
   End Sub


   Private Sub ChangeOwnedFormText()
      Dim x As Integer
      ' Loop through all owned forms and change their text.
      For x = 0 To (Me.OwnedForms.Length) - 1
         Me.OwnedForms(x).Text = "My Owned Form " + x.ToString()
      Next x
   End Sub
   '</Snippet1>
End Class
