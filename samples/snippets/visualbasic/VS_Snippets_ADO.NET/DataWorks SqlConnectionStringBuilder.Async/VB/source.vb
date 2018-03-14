Option Explicit On
Option Strict On

Imports System
Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient
Imports System.Threading


Module Module1
    Sub Main()
        ' Create a SqlConnectionStringBuilder instance, 
        ' and ensure that it is set up for asynchronous processing.
        Dim builder As _
         New SqlConnectionStringBuilder(GetConnectionString())
        ' Asynchronous method calls won't work unless you
        ' have added this option, or have added
        ' the clause "Asynchronous Processing=True"
        ' to the connection string.
        builder.AsynchronousProcessing = True

        Dim commandText As String = _
         "UPDATE Production.Product SET ReorderPoint = ReorderPoint + 1 " & _
         "WHERE ReorderPoint Is Not Null;" & _
         "WAITFOR DELAY '0:0:3';" & _
         "UPDATE Production.Product SET ReorderPoint = ReorderPoint - 1 " & _
         "WHERE ReorderPoint Is Not Null"
        RunCommandAsynchronously(commandText, builder.ConnectionString)

        Console.WriteLine("Press any key to finish.")
        Console.ReadLine()
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,
        ' you can retrieve it from a configuration file. 
        Return "Data Source=(local);Integrated Security=SSPI;" & _
          "Initial Catalog=AdventureWorks"
    End Function

    Private Sub RunCommandAsynchronously( _
     ByVal commandText As String, ByVal connectionString As String)

        ' Given command text and connection string, asynchronously execute
        ' the specified command against the connection. For this example,
        ' the code displays an indicator as it's working, verifying the 
        ' asynchronous behavior. 
        Using connection As New SqlConnection(connectionString)
            Try
                Dim count As Integer = 0
                Dim command As New SqlCommand(commandText, connection)
                connection.Open()
                Dim result As IAsyncResult = command.BeginExecuteNonQuery()
                While Not result.IsCompleted
                    Console.WriteLine("Waiting {0}.", count)
                    ' Wait for 1/10 second, so the counter
                    ' doesn't consume all available resources 
                    ' on the main thread.
                    Threading.Thread.Sleep(100)
                    count += 1
                End While
                Console.WriteLine("Command complete. Affected {0} rows.", _
                    command.EndExecuteNonQuery(result))
            Catch ex As SqlException
                Console.WriteLine( _
                "Error {0}: System.Data.SqlClient.SqlConnectionStringBuilder", _
                ex.Number, ex.Message)
            Catch ex As InvalidOperationException
                Console.WriteLine("Error: {0}", ex.Message)
            Catch ex As Exception
                ' You might want to pass these errors
                ' back out to the caller.
                Console.WriteLine("Error: {0}", ex.Message)
            End Try
        End Using
    End Sub
End Module
' </Snippet1>

