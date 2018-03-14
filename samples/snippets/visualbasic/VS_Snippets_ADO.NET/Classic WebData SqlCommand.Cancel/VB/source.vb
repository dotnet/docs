' <Snippet1>
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading

Module Module1
    Private m_rCommand As SqlCommand

    Public Property Command() As SqlCommand
        Get
            Return m_rCommand
        End Get
        Set(ByVal value As SqlCommand)
            m_rCommand = value
        End Set
    End Property

    Public Sub Thread_Cancel()
        Command.Cancel()
    End Sub

    Sub Main()
        Dim connectionString As String = GetConnectionString()

        Try
            Using connection As New SqlConnection(connectionString)

                connection.Open()

                Command = connection.CreateCommand()
                Command.CommandText = "DROP TABLE TestCancel"
                Try
                    Command.ExecuteNonQuery()
                Catch
                End Try

                Command.CommandText = "CREATE TABLE TestCancel(co1 int, co2 char(10))"
                Command.ExecuteNonQuery()
                Command.CommandText = "INSERT INTO TestCancel VALUES (1, '1')"
                Command.ExecuteNonQuery()

                Command.CommandText = "SELECT * FROM TestCancel"
                Dim reader As SqlDataReader = Command.ExecuteReader()

                Dim rThread2 As Thread = New Thread( _
                    New ThreadStart(AddressOf Thread_Cancel))

                rThread2.Start()
                rThread2.Join()

                reader.Read()
                Console.WriteLine(reader.FieldCount)
                reader.Close()
            End Using

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,  
        ' you can retrieve it from a configuration file.
        Return "Data Source=(local);Initial Catalog=AdventureWorks;" _
           & "Integrated Security=SSPI;"
    End Function
End Module
' </Snippet1>
