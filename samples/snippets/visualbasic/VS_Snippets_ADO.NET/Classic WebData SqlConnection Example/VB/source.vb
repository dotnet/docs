' <Snippet1>
Imports System.Data

Class Program

    Public Shared Sub Main(args As String())

        Dim connection As IDbConnection



        ' First use a SqlClient connection

        connection = New System.Data.SqlClient.SqlConnection("Server=(localdb)\V11.0")

        Console.WriteLine("SqlClient" & vbCr & vbLf & "{0}", GetServerVersion(connection))

        connection = New System.Data.SqlClient.SqlConnection("Server=(local);Integrated Security=true")

        Console.WriteLine("SqlClient" & vbCr & vbLf & "{0}", GetServerVersion(connection))



        ' Call the same method using ODBC

        ' NOTE: LocalDB requires the SQL Server 2012 Native Client ODBC driver

        connection = New System.Data.Odbc.OdbcConnection("Driver={SQL Server Native Client 11.0};Server=(localdb)\v11.0")

        Console.WriteLine("ODBC" & vbCr & vbLf & "{0}", GetServerVersion(connection))

        connection = New System.Data.Odbc.OdbcConnection("Driver={SQL Server Native Client 11.0};Server=(local);Trusted_Connection=yes")

        Console.WriteLine("ODBC" & vbCr & vbLf & "{0}", GetServerVersion(connection))


        ' Call the same method using OLE DB

        connection = New System.Data.OleDb.OleDbConnection("Provider=SQLNCLI11;Server=(localdb)\v11.0;Trusted_Connection=yes;")

        Console.WriteLine("OLE DB" & vbCr & vbLf & "{0}", GetServerVersion(connection))

        connection = New System.Data.OleDb.OleDbConnection("Provider=SQLNCLI11;Server=(local);Trusted_Connection=yes;")

        Console.WriteLine("OLE DB" & vbCr & vbLf & "{0}", GetServerVersion(connection))

    End Sub



    Public Shared Function GetServerVersion(connection As IDbConnection) As String

        ' Ensure that the connection is opened (otherwise executing the command will fail)

        Dim originalState As ConnectionState = connection.State

        If originalState <> ConnectionState.Open Then

            connection.Open()

        End If

        Try

            ' Create a command to get the server version

            ' NOTE: The query's syntax is SQL Server specific

            Dim command As IDbCommand = connection.CreateCommand()

            command.CommandText = "SELECT @@version"

            Return DirectCast(command.ExecuteScalar(), String)

        Finally

            ' Close the connection if that's how we got it

            If originalState = ConnectionState.Closed Then

                connection.Close()

            End If

        End Try

    End Function

End Class
' </Snippet1>