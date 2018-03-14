Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form

    Protected textBox1 As TextBox
    ' <Snippet1>
    Private Sub PrintPropertyNameAndIsBinding
        Dim thisControl As Control
        Dim thisBinding As Binding
        For Each thisControl In Me.Controls
            For Each thisBinding In thisControl.DataBindings
                Console.WriteLine(ControlChars.CrLf & thisControl.ToString)
                ' Print the PropertyName value for each binding.
                Console.WriteLine(thisBinding.PropertyName)
            Next
        Next
    End Sub
    ' </Snippet1>
End Class