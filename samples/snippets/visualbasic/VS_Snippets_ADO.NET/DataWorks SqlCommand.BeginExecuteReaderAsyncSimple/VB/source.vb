Option Explicit On
Option Strict On

Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient

Module Module1
    Sub Main()
        ' This example is not terribly useful, but it proves a point.
        ' The WAITFOR statement simply adds enough time to prove the 
        ' asynchronous nature of the command.
        Dim commandText As String = _
         "WAITFOR DELAY '00:00:03';" & _
         "SELECT ProductID, Name FROM Production.Product WHERE ListPrice < 100"

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
        Try
            ' The code does not need to handle closing the connection explicitly--
            ' the use of the CommandBehavior.CloseConnection option takes care
            ' of that for you. 
            Dim connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(commandText, connection)

            connection.Open()
            Dim result As IAsyncResult = _
              command.BeginExecuteReader(CommandBehavior.CloseConnection)

            ' Although it is not necessary, the following code
            ' displays a counter in the console window, indicating that 
            ' the main thread is not blocked while awaiting the command 
            ' results.
            Dim count As Integer = 0
            While Not result.IsCompleted
                count += 1
                Console.WriteLine("Waiting ({0})", count)
                ' Wait for 1/10 second, so the counter
                ' does not consume all available resources 
                ' on the main thread.
                Threading.Thread.Sleep(100)
            End While

            ' The "using" statement closes the SqlDataReader when it is 
            ' done executing.
            Using reader As SqlDataReader = command.EndExecuteReader(result)
                DisplayResults(reader)
            End Using
        Catch ex As SqlException
            Console.WriteLine("Error ({0}): {1}", ex.Number, ex.Message)
        Catch ex As InvalidOperationException
            Console.WriteLine("Error: {0}", ex.Message)
        Catch ex As Exception
            ' You might want to pass these errors
            ' back out to the caller.
            Console.WriteLine("Error: {0}", ex.Message)
        End Try
    End Sub

    Private Sub DisplayResults(ByVal reader As SqlDataReader)
        ' Display the data within the reader.
        While reader.Read()
            ' Display all the columns. 
            For i As Integer = 0 To reader.FieldCount - 1
                Console.Write("{0} ", reader.GetValue(i))
            Next
            Console.WriteLine()
        End While
    End Sub

    Private Function GetConnectionString() As String
        ' To avoid storing the connection string in your code,            
        ' you can retrieve it from a configuration file. 

        ' If you have not included "Asynchronous Processing=true" in the
        ' connection string, the command is not able
        ' to execute asynchronously.
        Return "Data Source=(local);Integrated Security=true;" & _
          "Initial Catalog=AdventureWorks; Asynchronous Processing=true"
    End Function
End Module
' </Snippet1>
