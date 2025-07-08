' <snippet100>
' <snippet1>
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports System.Diagnostics
Imports System.IO
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
        Private Shared ReadOnly insertCount As Integer = 256

        ' The size of a single batch of employees to add to the database.
        ' TODO: Change this value to experiment with different batch sizes.
        Private Shared ReadOnly insertBatchSize As Integer = 96

        ' The source database file.
        ' TODO: Change this value if Northwind.sdf is at a different location
        ' on your computer.
        Private Shared ReadOnly sourceDatabase As String = "C:\Program Files\Microsoft SQL Server Compact Edition\v3.5\Samples\Northwind.sdf"

        ' TODO: Change this value if you require a different temporary location.
        Private Shared ReadOnly scratchDatabase As String = "C:\Temp\Northwind.sdf"
        ' </snippet2>

        ' <snippet3>
        ' Describes an employee. Each property maps to a 
        ' column in the Employees table in the Northwind database.
        ' For brevity, the Employee class does not contain
        ' all columns from the Employees table.
        Private Class Employee
            Public Property EmployeeID() As Integer
            Public Property LastName() As String
            Public Property FirstName() As String

            ' A random number generator that helps tp generate
            ' Employee property values.
            Private Shared rand As New Random(42)

            ' Possible random first names.
            Private Shared ReadOnly firstNames() As String = {"Tom", "Mike", "Ruth", "Bob", "John"}
            ' Possible random last names.
            Private Shared ReadOnly lastNames() As String = {"Jones", "Smith", "Johnson", "Walker"}

            ' Creates an Employee object that contains random 
            ' property values.
            Public Shared Function Random() As Employee
                Return New Employee With {.EmployeeID = -1, .LastName = lastNames(rand.Next() Mod lastNames.Length), .FirstName = firstNames(rand.Next() Mod firstNames.Length)}
            End Function
        End Class
        ' </snippet3>

        ' <snippet4>
        ' Adds new employee records to the database.
        Private Shared Sub InsertEmployees(ByVal employees() As Employee, ByVal connectionString As String)
            Using connection As New SqlConnection(connectionString)
                Try
                    ' Create the SQL command.
                    Dim command As New SqlCommand("INSERT INTO Employees ([Last Name], [First Name])" & "VALUES (@lastName, @firstName)", connection)

                    connection.Open()
                    For i As Integer = 0 To employees.Length - 1
                        ' Set parameters.
                        command.Parameters.Clear()
                        command.Parameters.Add("@lastName", employees(i).LastName)
                        command.Parameters.Add("@firstName", employees(i).FirstName)

                        ' Execute the command.
                        command.ExecuteNonQuery()
                    Next i
                Finally
                    connection.Close()
                End Try
            End Using
        End Sub

        ' Retrieves the number of entries in the Employees table in 
        ' the Northwind database.
        Private Shared Function GetEmployeeCount(ByVal connectionString As String) As Integer
            Dim result As Integer = 0
            Using sqlConnection As New SqlConnection(connectionString)
                Dim sqlCommand As New SqlCommand("SELECT COUNT(*) FROM Employees", sqlConnection)

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
                Dim command As New SqlCommand(String.Format("SELECT [Employee ID] FROM Employees " & "WHERE [Last Name] = '{0}' AND [First Name] = '{1}'", lastName, firstName), connection)

                connection.Open()
                Try
                    Return CInt(Fix(command.ExecuteScalar()))
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
            Dim printEmployees = New ActionBlock(Of Tuple(Of IList(Of Employee), IList(Of Exception)))(Sub(data)
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
                Catch e As NullReferenceException
                    ' GetEmployeeID throws NullReferenceException when there is 
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

        Shared Sub Main(ByVal args() As String)
            ' Create a connection string for accessing the database.
            ' The connection string refers to the temporary database location.
            Dim connectionString As String = String.Format("Data Source={0}", scratchDatabase)

            ' Create a Stopwatch object to time database insert operations.
            Dim stopwatch As New Stopwatch()

            ' Start with a clean database file by copying the source database to 
            ' the temporary location.
            File.Copy(sourceDatabase, scratchDatabase, True)

            ' Demonstrate multiple insert operations without batching.
            Console.WriteLine("Demonstrating non-batched database insert operations...")
            Console.WriteLine("Original size of Employee table: {0}.", GetEmployeeCount(connectionString))
            stopwatch.Start()
            AddEmployees(connectionString, insertCount)
            stopwatch.Stop()
            Console.WriteLine("New size of Employee table: {0}; elapsed insert time: {1} ms.", GetEmployeeCount(connectionString), stopwatch.ElapsedMilliseconds)

            Console.WriteLine()

            ' Start again with a clean database file.
            File.Copy(sourceDatabase, scratchDatabase, True)

            ' Demonstrate multiple insert operations, this time with batching.
            Console.WriteLine("Demonstrating batched database insert operations...")
            Console.WriteLine("Original size of Employee table: {0}.", GetEmployeeCount(connectionString))
            stopwatch.Restart()
            AddEmployeesBatched(connectionString, insertBatchSize, insertCount)
            stopwatch.Stop()
            Console.WriteLine("New size of Employee table: {0}; elapsed insert time: {1} ms.", GetEmployeeCount(connectionString), stopwatch.ElapsedMilliseconds)

            Console.WriteLine()

            ' Start again with a clean database file.
            File.Copy(sourceDatabase, scratchDatabase, True)

            ' Demonstrate multiple retrieval operations with error reporting.
            Console.WriteLine("Demonstrating batched join database select operations...")
            ' Add a small number of employees to the database.
            AddEmployeesBatched(connectionString, insertBatchSize, 16)
            ' Query for random employees.
            GetRandomEmployees(connectionString, insertBatchSize, 10)
        End Sub
    End Class
End Namespace
' Sample output:
'Demonstrating non-batched database insert operations...
'Original size of Employee table: 15.
'Adding 256 entries to Employee table...
'New size of Employee table: 271; elapsed insert time: 11035 ms.
'
'Demonstrating batched database insert operations...
'Original size of Employee table: 15.
'Adding 256 entries to Employee table...
'New size of Employee table: 271; elapsed insert time: 197 ms.
'
'Demonstrating batched join database insert operations...
'Adding 16 entries to Employee table...
'Selecting items from Employee table...
'Received a batch...
'Last=Jones First=Tom ID=21
'Last=Jones First=John ID=24
'Last=Smith First=Tom ID=26
'Last=Jones First=Tom ID=21
'There were 4 errors in this batch...
'Received a batch...
'Last=Smith First=Tom ID=26
'Last=Jones First=Mike ID=28
'There were 0 errors in this batch...
'Finished. There were 4 total errors.
'
' </snippet100>
