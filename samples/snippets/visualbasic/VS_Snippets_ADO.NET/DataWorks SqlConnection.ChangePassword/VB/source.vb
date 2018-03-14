' <Snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        Try
            DemonstrateChangePassword()
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
        Console.WriteLine("Press ENTER to continue...")
        Console.ReadLine()
    End Sub

    Private Sub DemonstrateChangePassword()
        Dim connectionString As String = GetConnectionString()
        Using cnn As New SqlConnection()
            For i As Integer = 0 To 1
                ' Run this loop at most two times. If the first attempt fails, 
                ' the code checks the Number property of the SqlException object.
                ' If that contains the special values 18487 or 18488, the code 
                ' attempts to set the user's password to a new value. 
                ' Assuming this succeeds, the second pass through 
                ' successfully opens the connection.
                ' If not, the exception handler catches the exception.
                Try
                    cnn.ConnectionString = connectionString
                    cnn.Open()
                    ' Once this succeeds, just get out of the loop.
                    ' No need to try again if the connection is already open.
                    Exit For

                Catch ex As SqlException _
                 When (i = 0 And (ex.Number = 18487 Or ex.Number = 18488))
                    ' You must reset the password.
                    connectionString = ModifyConnectionString( _
                     connectionString, GetNewPassword())

                Catch ex As SqlException
                    ' Bubble all other SqlException occurrences
                    ' back up to the caller.
                    Throw
                End Try
            Next
            Dim cmd As New SqlCommand("SELECT ProductID, Name FROM Product", cnn)
            ' Use the connection and command here...
        End Using
    End Sub

    Private Function ModifyConnectionString( _
     ByVal connectionString As String, ByVal NewPassword As String) As String

        ' Use the SqlConnectionStringBuilder class to modify the
        ' password portion of the connection string. 
        Dim builder As New SqlConnectionStringBuilder(connectionString)
        builder.Password = NewPassword
        Return builder.ConnectionString
    End Function

    Private Function GetNewPassword() As String
        ' In a real application, you might display a modal
        ' dialog box to retrieve the new password. The concepts
        ' are the same as for this simple console application, however.
        Console.Write("Your password must be reset. Enter a new password: ")
        Return Console.ReadLine()
    End Function

    Private Function GetConnectionString() As String
        ' For this demonstration, the connection string must
        ' contain both user and password information. In your own
        ' application, you might want to retrieve this setting
        ' from a config file, or from some other source.

        ' In a production application, you would want to 
        ' display a modal form that could gather user and password
        ' information.
        Dim builder As New SqlConnectionStringBuilder( _
         "Data Source=(local);Initial Catalog=AdventureWorks")

        Console.Write("Enter your user id: ")
        builder.UserID = Console.ReadLine()
        Console.Write("Enter your password: ")
        builder.Password = Console.ReadLine()

        Return builder.ConnectionString
    End Function
End Module
' </Snippet1>

