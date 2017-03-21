Public Class myCultureComparer
    Implements IEqualityComparer

    Dim myComparer As CaseInsensitiveComparer

    Public Sub New()
        myComparer = CaseInsensitiveComparer.DefaultInvariant
    End Sub

    Public Sub New(ByVal myCulture As CultureInfo)
        myComparer = New CaseInsensitiveComparer(myCulture)
    End Sub

    Public Function Equals1(ByVal x As Object, ByVal y As Object) _
        As Boolean Implements IEqualityComparer.Equals

        If (myComparer.Compare(x, y) = 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetHashCode1(ByVal obj As Object) _
        As Integer Implements IEqualityComparer.GetHashCode
        Return obj.ToString().ToLower().GetHashCode()
    End Function
End Class