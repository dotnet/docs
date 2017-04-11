Imports System
Imports System.Data
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected button1 As Button
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub MyEnumerator()
     ' Creates a new collection and assigns it the properties for button1.
     Dim properties As PropertyDescriptorCollection = _
        TypeDescriptor.GetProperties(button1)
        
     ' Creates an enumerator.
     Dim ie As IEnumerator = properties.GetEnumerator()
        
     ' Prints the name of each property in the collection.
     Dim myProperty As Object
     While ie.MoveNext() = True
         myProperty = ie.Current
         textBox1.Text &= myProperty.ToString() & ControlChars.Cr
     End While
 End Sub

' </Snippet1>
End Class

