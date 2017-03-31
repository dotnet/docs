Imports System
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
	Inherits Form

	Protected textBox1 As TextBox
	' <Snippet1>
	Private Sub PrintPositions
		Dim c As Control
		Dim xBinding As Binding
		For Each c In Me.Controls
			For Each xBinding In c.DataBindings
				Console.WriteLine(c.ToString & ControlChars.Tab & " Position: " & _
					xBinding.BindingManagerBase.Position)
			Next
		Next
	End Sub
	' </Snippet1>
End Class
