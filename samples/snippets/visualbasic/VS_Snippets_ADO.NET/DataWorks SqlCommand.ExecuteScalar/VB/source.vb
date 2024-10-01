Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        Dim ret As Integer = AddProductCategory("newval", GetConnectionString())
        Console.WriteLine(ret.ToString())
        Console.ReadLine()
    End Sub
    ' <Snippet1>
    Public Function AddProductCategory( _
      ByVal newName As String, ByVal connString As String) As Integer
        Dim newProdID As Int32 = 0
        Dim sql As String = _
         "INSERT INTO Production.ProductCategory (Name) VALUES (@Name); " _
           & "SELECT CAST(scope_identity() AS int);"

        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand(sql, conn)
            cmd.Parameters.Add("@Name", SqlDbType.VarChar)
            cmd.Parameters("@Name").Value = newName
            Try
                conn.Open()
                newProdID = Convert.ToInt32(cmd.ExecuteScalar())
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Using

        Return newProdID
    End Function
    ' </Snippet1>

    Private Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function
End Module
