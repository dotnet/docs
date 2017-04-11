Imports System
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Form1
    Inherits Form
    Protected button1 As Button
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub MatchesAttributes()
     ' Creates a new collection and assigns it the attributes for button1.
     Dim myCollection As AttributeCollection
     myCollection = TypeDescriptor.GetAttributes(button1)
        
     ' Checks to see whether the attributes in myCollection match the attributes.
     ' for textBox1.
     Dim myAttrArray(100) As Attribute
     TypeDescriptor.GetAttributes(textBox1).CopyTo(myAttrArray, 0)
     If myCollection.Matches(myAttrArray) Then
         textBox1.Text = "The attributes in the button and text box match."
     Else
         textBox1.Text = "The attributes in the button and text box do not match."
     End If
 End Sub
' </Snippet1>
End Class
