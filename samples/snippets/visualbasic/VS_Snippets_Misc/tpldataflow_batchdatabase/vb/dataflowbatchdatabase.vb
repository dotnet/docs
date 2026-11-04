' <snippet100>
' <snippet1>
Imports System.Data
Imports Microsoft.Data.SqlClient
Imports System.Collections.Generic
Imports System.Threading.Tasks.Dataflow

' </snippet1>

' Demonstrates how to use batched dataflow blocks to improve
' the performance of database operations.
Namespace DataflowBatchDatabase
    Friend Class Program
        ' <snippet2>
        ' The number of employees to add to the database.
        ' TODO: Change this value to experiment with different numbers of 
        ' employees to insert into the database.
        Private Shared ReadOnly s_insertCount As Integer = 256

        ' The size of a single batch of employees to add to the database.
        ' TODO: Change this value to experiment with different batch sizes.
        Private Shared ReadOnly s_insertBatchSize As Integer = 96

        Private Shared ReadOnly s_employeeTable As String =
            "##DataflowEmployees_" & Guid.NewGuid().ToString("N")
        ' </snippet2>

        ' <snippet3>
        ' Describes an employee. Each property maps to a 
        ' column in the sample employee table.
        Private Class Employee
            Public Property EmployeeID() As Integer
            Public Property LastName() As String
            Public Property FirstName() As String

            ' A random number generator that helps tp generate
            ' Employee property values.
            Private Shared ReadOnly s_rand As New Random(42)

            ' Possible random first names.
            Private Shared ReadOnly s_firstNames() As String =
                {"Tom", "Mike", "Ruth", "Bob", "John"}
            ' Possible random last names.
            Private Shared ReadOnly s_lastNames() As String =
                {"Jones", "Smith", "Johnson", "Walker"}

            ' Creates an Employee object that contains random 
            ' property values.
            Public Shared Function Random() As Employee
                Return New Employee With {
                    .EmployeeID = -1,
                    .LastName = s_lastNames(s_rand.Next() Mod s_lastNames.Length),
                    .FirstName = s_firstNames(s_rand.Next() Mod s_firstNames.Length)
                }
            End Function
        End Class
        ' </snippet3>

        ' <snippet4>
        ' Adds new employee records to the database.
        Private Shared Sub InsertEmployees(ByVal employees() As Employee, ByVal connectionString As String)
            Using connection As New SqlConnection(connectionString)
                Try
                    ' Create the SQL command.
                    Dim command As New SqlCommand($"INSERT INTO [{s_employeeTable}] ([Last Name], [First Name]) VALUES (@lastName, @firstName)", connection)

                    connection.Open()
                    For i As Integer = 0 To employees.Length - 1
                        ' Set parameters.
                        command.Parameters.Clear()
                        command.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = employees(i).LastName
                        command.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = employees(i).FirstName

                        ' Execute the command.
                        command.ExecuteNonQuery()
                    Next i
                Finally
                    connection.Close()
                End Try
            End Using
        End Sub

        ' Retrieves the number of entries in the sample employee table.
        Private Shared Function GetEmployeeCount(ByVal connectionString As String) As Integer
            Dim result As Integer = 0
            Using sqlConnection As New SqlConnection(connectionString)
                Dim sqlCommand As New SqlCommand($"SELECT COUNT(*) FROM [{s_employeeTable}]", sqlConnection)

                sqlConnection.Open()
                Try
                    result = CInt(Fix(sqlCommand.ExecuteScalar()))
                Finally
                    sqlConnection.Close()
                End Try
            End Using
            Return result
        End Function

        ' Retrieves the ID of the first employee that has the provided name.
        Private Shared Function GetEmployeeID(ByVal lastName As String, ByVal firstName As String, ByVal connectionString As String) As Integer
            Using connection As New SqlConnection(connectionString)
                Dim query As String = $"SELECT TOP (1) [Employee ID] FROM [{s_employeeTable}] WHERE [Last Name] = @lastName AND [First Name] = @firstName ORDER BY [Employee ID]"
                Dim command As New SqlCommand(query, connection)
                command.Parameters.Add("@lastName", SqlDbType.NVarChar, 50).Value = lastName
                command.Parameters.Add("@firstName", SqlDbType.NVarChar, 50).Value = firstName

                connection.Open()
                Try
                    Dim result = command.ExecuteScalar()
                    If result Is Nothing Then
                        Throw New KeyNotFoundException("No matching employee.")
                    End If
                    Return CInt(result)
                Finally
                    connection.Close()
                End Try
            End Using
        End Function
        ' </snippet4>

        ' <snippet5>
        ' Posts random Employee data to the provided target block.
        Private Shared Sub PostRandomEmployees(ByVal target As ITargetBlock(Of Employee), ByVal count As Integer)
            Console.WriteLine("Adding {0} entries to Employee table...", count)

            For i As Integer = 0 To count - 1
                target.Post(Employee.Random())
            Next i
        End Sub

        ' Adds random employee data to the database by using dataflow.
        Private Shared Sub AddEmployees(ByVal connectionString As String, ByVal count As Integer)
            ' Create an ActionBlock<Employee> object that adds a single
            ' employee entry to the database.
            Dim insertEmployee = New ActionBlock(Of Employee)(Sub(e) InsertEmployees(New Employee() {e}, connectionString))

            ' Post several random Employee objects to the dataflow block.
            PostRandomEmployees(insertEmployee, count)

            ' Set the dataflow block to the completed state and wait for 
            ' all insert operations to complete.
            insertEmployee.Complete()
            insertEmployee.Completion.Wait()
        End Sub
        ' </snippet5>

        ' <snippet6>
        ' Adds random employee data to the database by using dataflow.
        ' This method is similar to AddEmployees except that it uses batching
        ' to add multiple employees to the database at a time.
        Private Shared Sub AddEmployeesBatched(ByVal connectionString As String, ByVal batchSize As Integer, ByVal count As Integer)
            ' Create a BatchBlock<Employee> that holds several Employee objects and
            ' then propagates them out as an array.
            Dim batchEmployees = New BatchBlock(Of Employee)(batchSize)

            ' Create an ActionBlock<Employee[]> object that adds multiple
            ' employee entries to the database.
            Dim insertEmployees = New ActionBlock(Of Employee())(Sub(a) Program.InsertEmployees(a, connectionString))

            ' Link the batch block to the action block.
            batchEmployees.LinkTo(insertEmployees)

            ' When the batch block completes, set the action block also to complete.
            batchEmployees.Completion.ContinueWith(Sub() insertEmployees.Complete())

            ' Post several random Employee objects to the batch block.
            PostRandomEmployees(batchEmployees, count)

            ' Set the batch block to the completed state and wait for 
            ' all insert operations to complete.
            batchEmployees.Complete()
            insertEmployees.Completion.Wait()
        End Sub
        ' </snippet6>

        ' <Snippet7>
        ' Displays information about several random employees to the console.
        Private Shared Sub GetRandomEmployees(ByVal connectionString As String, ByVal batchSize As Integer, ByVal count As Integer)
            ' Create a BatchedJoinBlock<Employee, Exception> object that holds
            ' both employee and exception data.
            Dim selectEmployees = New BatchedJoinBlock(Of Employee, Exception)(batchSize)

            ' Holds the total number of exceptions that occurred.
            Dim totalErrors As Integer = 0

            ' Create an action block that prints employee and error information
            ' to the console.
            Dim printEmployees = New ActionBlock(Of Tuple(Of IList(Of Employee), IList(Of Exception)))(
                Sub(data)
                    ' Print information about the employees in this batch.
                    ' Print the error count for this batch.
                    ' Update total error count.
                    Console.WriteLine("Received a batch...")
                    For Each e As Employee In data.Item1
                        Console.WriteLine("Last={0} First={1} ID={2}", e.LastName, e.FirstName, e.EmployeeID)
                    Next e
                    Console.WriteLine("There were {0} errors in this batch...", data.Item2.Count)
                    totalErrors += data.Item2.Count
                End Sub)

            ' Link the batched join block to the action block.
            selectEmployees.LinkTo(printEmployees)

            ' When the batched join block completes, set the action block also to complete.
            selectEmployees.Completion.ContinueWith(Sub() printEmployees.Complete())

            ' Try to retrieve the ID for several random employees.
            Console.WriteLine("Selecting random entries from Employees table...")
            For i As Integer = 0 To count - 1
                Try
                    ' Create a random employee.
                    Dim e As Employee = Employee.Random()

                    ' Try to retrieve the ID for the employee from the database.
                    e.EmployeeID = GetEmployeeID(e.LastName, e.FirstName, connectionString)

                    ' Post the Employee object to the Employee target of 
                    ' the batched join block.
                    selectEmployees.Target1.Post(e)
                Catch e As KeyNotFoundException
                    ' GetEmployeeID throws KeyNotFoundException when there is
                    ' no such employee with the given name. When this happens,
                    ' post the Exception object to the Exception target of
                    ' the batched join block.
                    selectEmployees.Target2.Post(e)
                End Try
            Next i

            ' Set the batched join block to the completed state and wait for 
            ' all retrieval operations to complete.
            selectEmployees.Complete()
            printEmployees.Completion.Wait()

            ' Print the total error count.
            Console.WriteLine("Finished. There were {0} total errors.", totalErrors)
        End Sub
        ' </Snippet7>

        Shared Sub Main()
            Dim connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")
            If String.IsNullOrWhiteSpace(connectionString) Then
                Throw New InvalidOperationException("Set the SQL_CONNECTION_STRING environment variable.")
            End If

            ' Keep the global temporary table alive while worker connections use it.
            Using keeper As New SqlConnection(connectionString)
                keeper.Open()
                Using setup As New SqlCommand(
                    $"CREATE TABLE [{s_employeeTable}] " &
                    "([Employee ID] int IDENTITY PRIMARY KEY, " &
                    "[Last Name] nvarchar(50) NOT NULL, [First Name] nvarchar(50) NOT NULL)", keeper)
                    setup.ExecuteNonQuery()
                End Using

                Try
                    Dim stopwatch As New Stopwatch()
                    Console.WriteLine("Demonstrating non-batched database insert operations...")
                    Console.WriteLine("Original size of Employee table: {0}.", GetEmployeeCount(connectionString))
                    stopwatch.Start()
                    AddEmployees(connectionString, s_insertCount)
                    stopwatch.Stop()
                    Console.WriteLine("New size of Employee table: {0}; elapsed insert time: {1} ms.", GetEmployeeCount(connectionString), stopwatch.ElapsedMilliseconds)
                    Console.WriteLine()

                    Using reset As New SqlCommand($"TRUNCATE TABLE [{s_employeeTable}]", keeper)
                        reset.ExecuteNonQuery()
                    End Using

                    Console.WriteLine("Demonstrating batched database insert operations...")
                    Console.WriteLine("Original size of Employee table: {0}.", GetEmployeeCount(connectionString))
                    stopwatch.Restart()
                    AddEmployeesBatched(connectionString, s_insertBatchSize, s_insertCount)
                    stopwatch.Stop()
                    Console.WriteLine("New size of Employee table: {0}; elapsed insert time: {1} ms.", GetEmployeeCount(connectionString), stopwatch.ElapsedMilliseconds)
                    Console.WriteLine()

                    Using reset As New SqlCommand($"TRUNCATE TABLE [{s_employeeTable}]", keeper)
                        reset.ExecuteNonQuery()
                    End Using

                    Console.WriteLine("Demonstrating batched join database select operations...")
                    AddEmployeesBatched(connectionString, s_insertBatchSize, 16)
                    GetRandomEmployees(connectionString, s_insertBatchSize, 10)
                Finally
                    Using cleanup As New SqlCommand($"DROP TABLE [{s_employeeTable}]", keeper)
                        cleanup.ExecuteNonQuery()
                    End Using
                End Try
            End Using
        End Sub
    End Class
End Namespace

' </snippet100>
