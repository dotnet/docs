' <snippet1>
Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Public Sub New()
        ' Create a TextBox control.
        Dim tb As New TextBox()
        Me.Controls.Add(tb)
        AddHandler tb.KeyPress, AddressOf keypressed
    End Sub 'New

    Private Sub keypressed(ByVal o As [Object], ByVal e As KeyPressEventArgs)
        ' The keypressed method uses the KeyChar property to check 
        ' whether the ENTER key is pressed. 

        ' If the ENTER key is pressed, the Handled property is set to true, 
        ' to indicate the event is handled.

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
        End If
    End Sub 'keypressed

    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub 'Main
End Class 'Form1
' </snippet1>