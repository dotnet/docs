Imports System
Imports System.Collections
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub CopyToArray()
     ' Declare the array.
     Dim myArray(100) As Object
     CType(Me.BindingContext, ICollection).CopyTo(myArray, 0)
 End Sub
' </Snippet1>
End Class
