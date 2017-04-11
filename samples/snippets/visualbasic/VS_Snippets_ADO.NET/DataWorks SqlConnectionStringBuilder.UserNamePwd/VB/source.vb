Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Module Module1

    Sub Main()
        BuildConnectionString("(local)", "Nate", "somepassword")
        Console.ReadLine()

    End Sub

    ' <Snippet1>
    Private Sub BuildConnectionString(ByVal dataSource As String, _
        ByVal userName As String, ByVal userPassword As String)

        ' Retrieve the partial connection string named databaseConnection
        ' from the application's app.config or web.config file.
        Dim settings As ConnectionStringSettings = _
           ConfigurationManager.ConnectionStrings("partialConnectString")

        If Not settings Is Nothing Then
            ' Retrieve the partial connection string.
            Dim connectString As String = settings.ConnectionString
            Console.WriteLine("Original: {0}", connectString)

            ' Create a new SqlConnectionStringBuilder based on the
            ' partial connection string retrieved from the config file.
            Dim builder As New SqlConnectionStringBuilder(connectString)

            ' Supply the additional values.
            builder.DataSource = dataSource
            builder.UserID = userName
            builder.Password = userPassword

            Console.WriteLine("Modified: {0}", builder.ConnectionString)
        End If
    End Sub
    ' </Snippet1>

End Module
