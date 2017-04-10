Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Module Module1

    Sub Main()
        Dim s As String = GetConnectionString()
        ShowSqlException(s)
        Console.ReadLine()

    End Sub

    ' <Snippet1>
    Public Sub ShowSqlException(ByVal connectionString As String)
        Dim queryString As String = "EXECUTE NonExistantStoredProcedure"
        Dim errorMessages As New StringBuilder()

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryString, connection)

            Try
                command.Connection.Open()
                command.ExecuteNonQuery()

            Catch ex As SqlException
                Dim i As Integer
                For i = 0 To ex.Errors.Count - 1
                    errorMessages.Append("Index #" & i.ToString() & ControlChars.NewLine _
                        & "Message: " & ex.Errors(i).Message & ControlChars.NewLine _
                        & "LineNumber: " & ex.Errors(i).LineNumber & ControlChars.NewLine _
                        & "Source: " & ex.Errors(i).Source & ControlChars.NewLine _
                        & "Procedure: " & ex.Errors(i).Procedure & ControlChars.NewLine)
                Next i
                Console.WriteLine(errorMessages.ToString())
            End Try
        End Using
    End Sub
    ' </Snippet1>

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file.
        Return "Data Source=(local);Initial Catalog=AdventureWorks;" _
           & "Integrated Security=SSPI;"
    End Function
End Module
