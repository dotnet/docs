Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim s As String = GetConnectionString()
        Dim c As SqlConnection = New SqlConnection(s)
        HasRows(c)
        Console.ReadLine()
    End Sub
    ' <Snippet1>
    Private Sub HasRows(ByVal connection As SqlConnection)
        Using connection
            Dim command As SqlCommand = New SqlCommand( _
              "SELECT CategoryID, CategoryName FROM Categories;", _
              connection)
            connection.Open()

            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.HasRows Then
                Do While reader.Read()
                    Console.WriteLine(reader.GetInt32(0) _
                      & vbTab & reader.GetString(1))
                Loop
            Else
                Console.WriteLine("No rows found.")
            End If

            reader.Close()
        End Using
    End Sub
    ' </Snippet1>

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file.
        Return "Data Source=(local);Initial Catalog=Northwind;" _
           & "Integrated Security=SSPI;"
    End Function
End Module
