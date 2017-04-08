Imports System.Data
Imports System.Data.OleDb

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub ReadMyData(ByVal connectionString As String)
        Dim queryString As String = "SELECT OrderID, CustomerID FROM Orders"
        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)

            connection.Open()

            Dim reader As OleDbDataReader = command.ExecuteReader()
            While reader.Read()
                Console.WriteLine(reader.GetInt32(0).ToString() + ", " _
                   + reader.GetString(1))
            End While

            ' always call Close when done reading.
            reader.Close()
        End Using
    End Sub
    ' </Snippet1>

End Module
