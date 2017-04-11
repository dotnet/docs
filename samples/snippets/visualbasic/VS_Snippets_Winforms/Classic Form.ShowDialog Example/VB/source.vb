Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Public Class Form2
   Inherits Form

   Protected okay As Button
   Protected cancel As Button
   Public TextBox1 as TextBox

   Public Sub New()
      MyBase.New()

      Me.okay = New Button()
      Me.okay.Location = New Point(50,50)
      Me.okay.Width = 50
      Me.okay.DialogResult = DialogResult.OK
      Me.okay.Text = "OK"

      Me.cancel = New Button()
      Me.cancel.Location = New Point(okay.Left + okay.Width + 10, 50)
      Me.cancel.Width = 50
      Me.cancel.DialogResult = DialogResult.Cancel
      Me.cancel.Text = "Cancel"

      Me.TextBox1 = New TextBox()
      Me.TextBox1.Location = New Point(50, 100)
      Me.TextBox1.Width = 110
      Me.TextBox1.Text = "Enter Text"

      Me.Controls.AddRange(New Control() {okay, cancel, TextBox1})
   End Sub
   
End Class


Public Class Form1
    Inherits Form

    Protected txtResult As TextBox
    Protected showButton As Button

    <System.STAThreadAttribute()>  _
    Public Shared Sub Main()
       System.Windows.Forms.Application.Run(New Form1())
    End Sub


    Public Sub New()
        MyBase.New()

        Me.txtResult = new TextBox()
        
        Me.showButton = new Button()
        Me.showButton.Width = 100
        Me.showButton.Text = "Show Dialog"
        Me.showButton.Location = New Point(0, txtResult.Height + 10)
        AddHandler Me.showButton.Click, AddressOf Me.showButton_Click

        Me.Controls.AddRange(New Control() {txtResult, showButton})
    End Sub


    
    '<Snippet1>
    Public Sub ShowMyDialogBox()
        Dim testDialog As New Form2()
        
        ' Show testDialog as a modal dialog and determine if DialogResult = OK.
        If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            ' Read the contents of testDialog's TextBox.
            txtResult.Text = testDialog.TextBox1.Text
        Else
            txtResult.Text = "Cancelled"
        End If
        testDialog.Dispose()
    End Sub 'ShowMyDialogBox
    '</Snippet1>


    Private Sub showButton_Click(sender As Object, e As System.EventArgs)
       ShowMyDialogBox()
    End Sub
End Class 'Form1 
