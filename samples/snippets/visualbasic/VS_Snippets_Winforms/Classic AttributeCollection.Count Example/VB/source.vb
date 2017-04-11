Imports System
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Form1
	Inherits Form

	Protected button1 As Button
	Protected textBox1 As TextBox
' <Snippet1>
Private Sub GetCount
    ' Creates a new collection and assigns it the attributes for button 1.
    Dim attributes As AttributeCollection
    attributes = TypeDescriptor.GetAttributes(button1)
    ' Prints the number of items in the collection.
    textBox1.Text = attributes.Count.ToString
End Sub
' </Snippet1>

End Class