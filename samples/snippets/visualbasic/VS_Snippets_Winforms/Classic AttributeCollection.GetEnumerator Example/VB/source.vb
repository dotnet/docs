Imports System
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Microsoft.VisualBasic

Public Class Form1
	Inherits Form

	protected button1 As Button
	protected textBox1 As TextBox

	' <Snippet1>
	Private Sub MyEnumerator
		' Creates a new collection and assigns it the attributes for button1.
		Dim attributes As AttributeCollection
		attributes = TypeDescriptor.GetAttributes(button1)

		' Creates an enumerator for the collection.
		Dim ie As System.Collections.IEnumerator = attributes.GetEnumerator

		' Prints the type of each attribute in the collection.
		Dim myAttribute As Object
		Do While ie.MoveNext
			myAttribute = ie.Current
			textBox1.Text = textBox1.Text & myAttribute.toString & ControlChars.crlf
		Loop
	End Sub
	' </Snippet1>
End Class
