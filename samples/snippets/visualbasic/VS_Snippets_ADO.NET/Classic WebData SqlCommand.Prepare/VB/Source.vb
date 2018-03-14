Option Explicit On
Option Strict On

Imports System.Data
Imports system.Data.SqlClient

Module Module1

    Sub Main()
        Dim connectionString As String = _
        "Persist Security Info=False;Integrated Security=SSPI;database=Northwind;server=(local)"
        SqlCommandPrepareEx(connectionString)
        Console.ReadLine()

    End Sub
    ' <Snippet1>
    Private Sub SqlCommandPrepareEx(ByVal connectionString As String)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As SqlCommand = New SqlCommand("", connection)

            ' Create and prepare an SQL statement.
            command.CommandText = _
               "INSERT INTO Region (RegionID, RegionDescription) " & _
               "VALUES (@id, @desc)"
            Dim idParam As SqlParameter = _
                New SqlParameter("@id", SqlDbType.Int, 0)
            Dim descParam As SqlParameter = _
                New SqlParameter("@desc", SqlDbType.Text, 100)
            idParam.Value = 20
            descParam.Value = "First Region"
            command.Parameters.Add(idParam)
            command.Parameters.Add(descParam)

            ' Call Prepare after setting the Commandtext and Parameters.
            command.Prepare()
            command.ExecuteNonQuery()

            ' Change parameter values and call ExecuteNonQuery.
            command.Parameters(0).Value = 21
            command.Parameters(1).Value = "Second Region"
            command.ExecuteNonQuery()
        End Using
    End Sub
    ' </Snippet1>
End Module
