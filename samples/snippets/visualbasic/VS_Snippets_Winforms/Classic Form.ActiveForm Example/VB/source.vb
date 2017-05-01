Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Public Sub DisableActiveFormControls()
        ' Create an instance of a form and assign it the currently active form.
        Dim currentForm As Form = Form.ActiveForm
        
        ' Loop through all the controls on the active form.
        Dim i As Integer
        For i = 0 To currentForm.Controls.Count - 1
            ' Disable each control in the active form's control collection.
            currentForm.Controls(i).Enabled = False
        Next i
    End Sub 'DisableActiveFormControls
    ' </Snippet1>
End Class 'Form1 

