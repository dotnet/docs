Option Explicit On
Option Strict On

Imports System.Data
' <Snippet1>
Imports System.Data.SqlClient
Imports System.Xml

Module Module1

    Sub Main()
        ' This example is not terribly effective, but it proves a point.
        ' The WAITFOR statement simply adds enough time to prove the 
        ' asynchronous nature of the command.
        Dim commandText As String = _
         "WAITFOR DELAY '00:00:03';" & _
         "SELECT Name, ListPrice FROM Production.Product " & _
         "WHERE ListPrice < 100 " & _
         "FOR XML AUTO, XMLDATA"

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
                Dim command As New SqlCommand(commandText, connection)
                connection.Open()
                Dim result As IAsyncResult = command.BeginExecuteXmlReader()

                ' Although it is not necessary, the following procedure
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

                Using reader As XmlReader = command.EndExecuteXmlReader(result)
                    DisplayProductInfo(reader)
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
        End Using
    End Sub

    Private Sub DisplayProductInfo(ByVal reader As XmlReader)
        ' Display the data within the reader.
        While reader.Read()
            ' Skip past items that are not from the correct table.
            If reader.LocalName.ToString = "Production.Product" Then
                Console.WriteLine("{0}: {1:C}", _
                 reader("Name"), CSng(reader("ListPrice")))
            End If
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
