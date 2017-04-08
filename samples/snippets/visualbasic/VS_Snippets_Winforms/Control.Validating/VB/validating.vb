Option Explicit
Option Strict
Imports System
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits System.Windows.Forms.Form



    <System.STAThreadAttribute()> _
    Public Shared Sub Main()
       System.Windows.Forms.Application.Run(New Form1())
    End Sub

    Private WithEvents textBox1 As System.Windows.Forms.TextBox
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents errorProvider1 As System.Windows.Forms.ErrorProvider


    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.button1 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.errorProvider1 = New System.Windows.Forms.ErrorProvider()
        Me.textBox1.Location = New System.Drawing.Point(16, 32)
        Me.textBox1.Size = New System.Drawing.Size(240, 20)
        Me.textBox1.TabIndex = 0
        Me.textBox1.Text = "textBox1"
        Me.button1.Location = New System.Drawing.Point(216, 248)
        Me.button1.TabIndex = 2
        Me.button1.Text = "button1"
        Me.button2.Location = New System.Drawing.Point(116, 248)
        Me.button2.TabIndex = 1
        Me.button2.Text = "Non-validating"
        Me.errorProvider1.DataMember = Nothing
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1, Me.button1, Me.button2})
        Me.Text = "Form1"

    End Sub

' <snippet2>
    Public Sub New()
        MyBase.New()

        InitializeComponent()
        'Set button2 to be non-validating.
        Me.button2.CausesValidation = False
    End Sub

' <snippet1>
   Private Function ValidEmailAddress(ByVal emailAddress As String, ByRef errorMessage As String) As Boolean
      ' Confirm there is text in the control.
      If textBox1.Text.Length = 0 Then
         errorMessage = "E-mail address is required."
         Return False

      End If

      ' Confirm that there is an "@" and a "." in the e-mail address, and in the correct order.
      If emailAddress.IndexOf("@") > -1 Then
         If (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@")) Then
            errorMessage = ""
            Return True
         End If
      End If

      errorMessage = "E-mail address must be valid e-mail address format." + ControlChars.Cr + _
        "For example 'someone@example.com' "
      Return False
End Function

   Private Sub textBox1_Validating(ByVal sender As Object, _
   ByVal e As System.ComponentModel.CancelEventArgs) Handles textBox1.Validating

      Dim errorMsg As String
      If Not ValidEmailAddress(textBox1.Text, errorMsg) Then
         ' Cancel the event and select the text to be corrected by the user.
         e.Cancel = True
         textBox1.Select(0, textBox1.Text.Length)

         ' Set the ErrorProvider error with the text to display. 
         Me.errorProvider1.SetError(textBox1, errorMsg)
      End If
   End Sub


   Private Sub textBox1_Validated(ByVal sender As Object, _
   ByVal e As System.EventArgs) Handles textBox1.Validated
      ' If all conditions have been met, clear the error provider of errors.
      errorProvider1.SetError(textBox1, "")
   End Sub
   ' </snippet1>
   ' </snippet2>

End Class
