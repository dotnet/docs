Imports System
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Form1
	Inherits Form

	Protected button1 As Button
	Protected textBox1 As TextBox
	' <Snippet1>
	Private Sub PrintIndexItem2
		' Creates a new collection and assigns it the attributes for button1.
		Dim attributes As AttributeCollection
		attributes = TypeDescriptor.GetAttributes(button1)

		' Gets the designer attribute from the collection.
		Dim myDesigner As DesignerAttribute
                ' You must supply a valid fully qualified assembly name here. 
		myDesigner = CType(attributes(Type.GetType("Assembly text name, Version, Culture, PublicKeyToken")), DesignerAttribute)
		textBox1.Text = myDesigner.DesignerTypeName
	End Sub
	' </Snippet1>
End Class
