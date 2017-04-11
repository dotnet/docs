Imports System
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Form1
	Inherits Form

	Protected button1 As Button
	Protected textBox1 As Button
	' <Snippet1>
	Private Sub MatchesAttribute
		' Creates a new collection and assigns it the attributes for button
		Dim attributes As AttributeCollection
		attributes = TypeDescriptor.GetAttributes(button1)

		' Checks to see if the browsable attribute is true.
		If attributes.Matches(BrowsableAttribute.Yes) Then
			textBox1.Text = "button1 is browsable."
		Else
			textBox1.Text = "button1 is not browsable."
		End If
    End Sub
    ' </Snippet1>
End Class