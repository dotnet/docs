Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form

    Protected textBox1 As TextBox
    '<Snippet1>
    Private Sub PrintBindingIsBinding
        Dim c As Control
        Dim b As Binding
        For Each c In Me.Controls
            For Each b in c.DataBindings
                Console.WriteLine (ControlChars.CrLf & c.ToString)
                Console.WriteLine (b.PropertyName & " IsBinding: " & _
                    b.IsBinding)
            Next
        Next
    End Sub
    '</Snippet1>
End Class