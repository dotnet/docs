Public Class BoxLengthFirst
	Inherits Comparer(Of Box)
	' Compares by Length, Height, and Width.
	Public Overrides Function Compare(ByVal x As Box, ByVal y As Box) As Integer
		If x.Length.CompareTo(y.Length) <> 0 Then
			Return x.Length.CompareTo(y.Length)
		ElseIf x.Height.CompareTo(y.Height) <> 0 Then
			Return x.Height.CompareTo(y.Height)
		ElseIf x.Width.CompareTo(y.Width) <> 0 Then
			Return x.Width.CompareTo(y.Width)
		Else
			Return 0
		End If
	End Function

End Class