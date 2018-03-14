Imports System
Imports System.Windows.Forms
Imports System.Data



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub RemoveFromList()
        ' Get the CurrencyManager of a TextBox control.
        Dim myCurrencyManager As CurrencyManager = CType(textBox1.BindingContext(0), CurrencyManager)
        ' If the count is 0, exit the function.
        If myCurrencyManager.Count > 1 Then
            myCurrencyManager.RemoveAt(0)
        End If
        
    End Sub 'RemoveFromList
    ' </Snippet1>
End Class 'Form1 
