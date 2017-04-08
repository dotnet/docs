' <Snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.OleDb

Public Class Program
    Public Shared Sub Main()

        ' The connection string assumes that the Access 
        ' Northwind.mdb is located in the c:\Data folder.
        Dim connectionString As String = _
             "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" _
            & "c:\Data\Northwind.mdb;User Id=admin;Password=;"

        ' Provide the query string with a parameter placeholder.
        Dim queryString As String = _
            "SELECT ProductID, UnitPrice, ProductName from Products " _
            & "WHERE UnitPrice > ? " _
            & "ORDER BY UnitPrice DESC;"

        ' Specify the parameter value.
        Dim paramValue As Integer = 5

        ' Create and open the connection in a using block. This
        ' ensures that all resources will be closed and disposed
        ' when the code exits.
        Using connection As New OleDbConnection(connectionString)

            ' Create the Command and Parameter objects.
            Dim command As New OleDbCommand(queryString, connection)
            command.Parameters.AddWithValue("@pricePoint", paramValue)

            ' Open the connection in a try/catch block. 
            ' Create and execute the DataReader, writing the result
            ' set to the console window.
            Try
                connection.Open()
                Dim dataReader As OleDbDataReader = _
                 command.ExecuteReader()
                Do While dataReader.Read()
                    Console.WriteLine( _
                        vbTab & "{0}" & vbTab & "{1}" & vbTab & "{2}", _
                     dataReader(0), dataReader(1), dataReader(2))
                Loop
                dataReader.Close()

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            Console.ReadLine()
        End Using
    End Sub
End Class
' </Snippet1>
