Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.Common

Module Module1
    ' <Snippet1>
    Sub Main()
        Try
            Dim builder As New DbConnectionStringBuilder
            builder.Add("Data Source", "ServerName")
            builder.Add("Initial Catalog", "TheDatabase")
            builder.Add("User ID", "UserName")
            builder.Add("Password", "*******")
            builder.Add("Command Logging", False)

            ' Overwrite the existing "User ID" value.
            builder.Add("User ID", "NewUserName")

            ' The following code would trigger 
            ' an ArgumentNullException.
            ' builder.Add(Nothing, "Some Value")

            Console.WriteLine(builder.ConnectionString)

        Catch ex As ArgumentNullException
            Console.WriteLine("Null key values are not allowed.")
        End Try

        Console.WriteLine("Press Enter to continue.")
        Console.ReadLine()
    End Sub
    ' </Snippet1>
End Module

