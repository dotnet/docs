Public Class MyCustomUserNameValidator
    Inherits UserNamePasswordValidator

    ' This method validates users. It allows two users, test1 and test2 
    ' with passwords 1tset and 2tset respectively.
    ' This code is for illustration purposes only and 
    ' MUST NOT be used in a production environment because it is NOT secure.	
    Public Overrides Sub Validate(ByVal userName As String, ByVal password As String)
        If Nothing = userName OrElse Nothing = password Then
            Throw New ArgumentNullException()
        End If

        If Not (userName = "test1" AndAlso password = "1tset") AndAlso Not (userName = "test2" AndAlso password = "2tset") Then
            Throw New SecurityTokenException("Unknown Username or Password")
        End If

    End Sub 'Validate
End Class 'MyCustomUserNameValidator