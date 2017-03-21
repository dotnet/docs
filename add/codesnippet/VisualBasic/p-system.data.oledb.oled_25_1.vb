Imports System.Data.OleDb

Module Module1
    Sub Main()
        Dim builder As New OleDbConnectionStringBuilder()
        builder.DataSource = "C:\Sample.mdb"
        builder.Provider = "Microsoft.Jet.Oledb.4.0"
        Console.WriteLine(builder.ConnectionString)

        ' This sample assumes that you have a database named
        ' C:\Sample.mdb available.
        Using connection As New OleDbConnection(builder.ConnectionString)
            Try
                connection.Open()
                ' Do something with the database here.
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Using

        Console.WriteLine("Press Enter to finish.")
        Console.ReadLine()
    End Sub
End Module