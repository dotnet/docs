Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim s As String = GetConnectionString()
        Dim c As SqlConnection = New SqlConnection(s)
        RetrieveMultipleResults(c)
        Console.ReadLine()

    End Sub
    ' <Snippet1>
    Private Sub RetrieveMultipleResults(ByVal connection As SqlConnection)
        Using connection
            Dim command As SqlCommand = New SqlCommand( _
              "SELECT CategoryID, CategoryName FROM Categories;" & _
              "SELECT EmployeeID, LastName FROM Employees", connection)
            connection.Open()

            Dim reader As SqlDataReader = command.ExecuteReader()

            Do While reader.HasRows
                Console.WriteLine(vbTab & reader.GetName(0) _
                  & vbTab & reader.GetName(1))

                Do While reader.Read()
                    Console.WriteLine(vbTab & reader.GetInt32(0) _
                      & vbTab & reader.GetString(1))
                Loop

                reader.NextResult()
            Loop
        End Using
    End Sub
    ' </Snippet1>
    Private Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function
End Module
