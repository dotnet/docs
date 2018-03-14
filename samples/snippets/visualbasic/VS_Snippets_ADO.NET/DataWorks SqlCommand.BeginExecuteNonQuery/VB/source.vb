Option Explicit On
Option Strict On

Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient

Module Module1

    Sub Main()
        ' This is a simple example that demonstrates the usage of the 
        ' BeginExecuteNonQuery functionality.
        ' The WAITFOR statement simply adds enough time to prove the 
        ' asynchronous nature of the command.
        Dim commandText As String = _
         "UPDATE Production.Product SET ReorderPoint = ReorderPoint + 1 " & _
         "WHERE ReorderPoint Is Not Null;" & _
         "WAITFOR DELAY '0:0:3';" & _
         "UPDATE Production.Product SET ReorderPoint = ReorderPoint - 1 " & _
         "WHERE ReorderPoint Is Not Null"

        RunCommandAsynchronously(commandText, GetConnectionString())

        Console.WriteLine("Press ENTER to continue.")
        Console.ReadLine()
    End Sub

    Private Sub RunCommandAsynchronously( _
     ByVal commandText As String, ByVal connectionString As String)

        ' Given command text and connection string, asynchronously execute
        ' the specified command against the connection. For this example,
        ' the code displays an indicator as it is working, verifying the 
        ' asynchronous behavior. 
        Using connection As New SqlConnection(connectionString)
            Try
                Dim count As Integer = 0
                Dim command As New SqlCommand(commandText, connection)
                connection.Open()
                Dim result As IAsyncResult = command.BeginExecuteNonQuery()
                While Not result.IsCompleted
                    Console.WriteLine("Waiting ({0})", count)
                    ' Wait for 1/10 second, so the counter
                    ' does not consume all available resources 
                    ' on the main thread.
                    Threading.Thread.Sleep(100)
                    count += 1
                End While
                Console.WriteLine("Command complete. Affected {0} rows.", _
                    command.EndExecuteNonQuery(result))
            Catch ex As SqlException
                Console.WriteLine("Error ({0}): {1}", ex.Number, ex.Message)
            Catch ex As InvalidOperationException
                Console.WriteLine("Error: {0}", ex.Message)
            Catch ex As Exception
                ' You might want to pass these errors
                ' back out to the caller.
                Console.WriteLine("Error: {0}", ex.Message)
            End Try
        End Using
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,            
        ' you can retrieve it from a configuration file. 

        ' If you have not included "Asynchronous Processing=true" in the
        ' connection string, the command is not able
        ' to execute asynchronously.
        Return "Data Source=(local);Integrated Security=SSPI;" & _
          "Initial Catalog=AdventureWorks; Asynchronous Processing=true"
    End Function
End Module
' </Snippet1>
