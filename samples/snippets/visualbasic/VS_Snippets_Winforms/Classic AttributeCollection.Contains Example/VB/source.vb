Imports System
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Form1
	Inherits Form

	Protected button1 As Button
	Protected textBox1 As TextBox

    ' <Snippet1>
	Private Sub ContainsAttribute
		' Creates a new collection and assigns it the attributes for button.
		Dim attributes As AttributeCollection
		attributes = TypeDescriptor.GetAttributes(button1)

		' Sets an Attribute to the specific attribute.
		Dim myAttribute As BrowsableAttribute = BrowsableAttribute.Yes

		If Attributes.Contains(myAttribute) Then
			textBox1.Text = "button1 has a browsable attribute."
		Else
			textBox1.Text = "button1 does not have a browsable attribute."
		End If
	End Sub
    ' </Snippet1>
End Class