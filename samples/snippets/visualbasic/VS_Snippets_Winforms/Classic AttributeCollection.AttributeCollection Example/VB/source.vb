Imports System
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Form1
	Inherits Form

	Protected button1 as Button
	Protected textBox1 as TextBox

	Protected Sub Method
' <Snippet1>
Dim collection1 As AttributeCollection
collection1 = TypeDescriptor.GetAttributes(button1)
' </Snippet1>

	End Sub
End Class