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