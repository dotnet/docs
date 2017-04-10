Imports System
Imports System.Collections
Imports System.Windows.Forms

Public Class Form1 : Inherits Form

 Protected textBox1 As TextBox
' <Snippet1>
 Private Sub PrintCount()
    Console.WriteLine("BindingContext.Count " _
       + CType(Me.BindingContext, ICollection).Count.ToString())
 End Sub 
' </Snippet1>
End Class
