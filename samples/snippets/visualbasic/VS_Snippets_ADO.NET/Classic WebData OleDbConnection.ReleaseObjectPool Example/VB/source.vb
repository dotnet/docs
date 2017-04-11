Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.OleDb

Module Module1

    Sub Main()
        Dim x As String = "Provider=SQLOLEDB;Data Source=(local);Initial Catalog=AdventureWorks;" _
        & "Integrated Security=SSPI"
        OpenConnection(x)
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Public Sub OpenConnection(ByVal connectionString As String)

        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()
                Console.WriteLine("Connection.State: {0}", _
                    connection.State)

                connection.Close()
                OleDbConnection.ReleaseObjectPool()
                Console.WriteLine("Connection.State: {0}", _
                    connection.State)

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Using
    End Sub
    ' </Snippet1>
End Module
