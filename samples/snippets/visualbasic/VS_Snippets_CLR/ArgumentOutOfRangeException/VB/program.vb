' <Snippet1>
Module Module1
   Public Sub Main()
       Try
           Dim guest1 As Guest = New Guest("Ben", "Miller", 17)
           Console.WriteLine(guest1.GuestInfo)
       Catch outOfRange As ArgumentOutOfRangeException
           Console.WriteLine("Error: {0}", outOfRange.Message)
       End Try
   End Sub
End Module

Class Guest
    Private FirstName As String
    Private LastName As String
    Private Age As Integer

    Public Sub New(ByVal fName As String, ByVal lName As String, ByVal age As Integer)
        MyBase.New()
        FirstName = fName
        LastName = lName
        If (age < 21) Then
            Throw New ArgumentOutOfRangeException("age", "All guests must be 21-years-old or older.")
        Else
            age = age
        End If
    End Sub

    Public Function GuestInfo() As String
        Dim gInfo As String = (FirstName + (" " _
                    + (Me.LastName + (", " + Me.Age.ToString))))
        Return gInfo
    End Function
End Class
' </Snippet1>