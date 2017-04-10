Imports System.Data
Imports System.Data.OleDb

Module Module1

    Sub Main()
    End Sub


    ' <Snippet1>
    Public Sub CreateReader(ByVal connectionString As String, _
        ByVal queryString As String)

        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)

            connection.Open()

            Dim reader As OleDbDataReader = command.ExecuteReader()
            While reader.Read()
                Console.WriteLine(reader(0).ToString())
            End While
            reader.Close()
        End Using
    End Sub
    ' </Snippet1>

End Module
