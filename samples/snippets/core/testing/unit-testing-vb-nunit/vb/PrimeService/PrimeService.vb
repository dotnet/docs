Namespace Prime.Services
    Public Class PrimeService
        Public Function IsPrime(candidate As Integer) As Boolean
            If candidate < 2 Then
                Return False
            End If
            For divisor As Integer = 2 To Math.Sqrt(candidate)
                If candidate Mod divisor = 0 Then
                    Return False
                End If
            Next
            Return True
        End Function
    End Class
End Namespace
