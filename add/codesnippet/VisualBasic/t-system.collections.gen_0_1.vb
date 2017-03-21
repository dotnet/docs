' This class is not demonstrated in the Main method
' and is provided only to show how to implement
' the interface. It is recommended to derive
' from Comparer<T> instead of implementing IComparer<T>.
Public Class BoxComp
	Implements IComparer(Of Box)
	' Compares by Height, Length, and Width.
    Public Function Compare(ByVal x As Box, ByVal y As Box) As Integer Implements _
                                                IComparer(Of Box).Compare
        If x.Height.CompareTo(y.Height) <> 0 Then
            Return x.Height.CompareTo(y.Height)
        ElseIf x.Length.CompareTo(y.Length) <> 0 Then
            Return x.Length.CompareTo(y.Length)
        ElseIf x.Width.CompareTo(y.Width) <> 0 Then
            Return x.Width.CompareTo(y.Width)
        Else
            Return 0
        End If
    End Function
End Class