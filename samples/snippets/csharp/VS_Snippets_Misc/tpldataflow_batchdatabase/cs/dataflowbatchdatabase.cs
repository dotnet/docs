// <snippet100>
// <snippet1>
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks.Dataflow;
// </snippet1>

// Demonstrates how to use batched dataflow blocks to improve
// the performance of database operations.
namespace DataflowBatchDatabase
{
   class Program
   {
      // <snippet2>
      // The number of employees to add to the database.
      // TODO: Change this value to experiment with different numbers of
      // employees to insert into the database.
      static readonly int insertCount = 256;

      // The size of a single batch of employees to add to the database.
      // TODO: Change this value to experiment with different batch sizes.
      static readonly int insertBatchSize = 96;

      // The source database file.
      // TODO: Change this value if Northwind.sdf is at a different location
      // on your computer.
      static readonly string sourceDatabase =
         @"C:\...\Northwind.sdf";

      // TODO: Change this value if you require a different temporary location.
      static readonly string scratchDatabase =
         @"C:\Temp\Northwind.sdf";
      // </snippet2>

      // <snippet3>
      // Describes an employee. Each property maps to a
      // column in the Employees table in the Northwind database.
      // For brevity, the Employee class does not contain
      // all columns from the Employees table.
      class Employee
      {
         public int EmployeeID { get; set; }
         public string LastName { get; set; }
         public string FirstName { get; set; }

         // A random number generator that helps tp generate
         // Employee property values.
         static Random rand = new Random(42);

         // Possible random first names.
         static readonly string[] firstNames = { "Tom", "Mike", "Ruth", "Bob", "John" };
         // Possible random last names.
         static readonly string[] lastNames = { "Jones", "Smith", "Johnson", "Walker" };

         // Creates an Employee object that contains random
         // property values.
         public static Employee Random()
         {
            return new Employee
            {
               EmployeeID = -1,
               LastName = lastNames[rand.Next() % lastNames.Length],
               FirstName = firstNames[rand.Next() % firstNames.Length]
            };
         }
      }
      // </snippet3>

      // <snippet4>
      // Adds new employee records to the database.
      static void InsertEmployees(Employee[] employees, string connectionString)
      {
         using (SqlConnection connection =
            new SqlConnection(connectionString))
         {
            try
            {
               // Create the SQL command.
               SqlCommand command = new SqlCommand(
                  "INSERT INTO Employees ([Last Name], [First Name])" +
                  "VALUES (@lastName, @firstName)",
                  connection);

               connection.Open();
               for (int i = 0; i < employees.Length; i++)
               {
                  // Set parameters.
                  command.Parameters.Clear();
                  command.Parameters.Add("@lastName", employees[i].LastName);
                  command.Parameters.Add("@firstName", employees[i].FirstName);

                  // Execute the command.
                  command.ExecuteNonQuery();
               }
            }
            finally
            {
               connection.Close();
            }
         }
      }

      // Retrieves the number of entries in the Employees table in
      // the Northwind database.
      static int GetEmployeeCount(string connectionString)
      {
         int result = 0;
         using (SqlConnection sqlConnection =
            new SqlConnection(connectionString))
         {
            SqlCommand sqlCommand = new SqlCommand(
               "SELECT COUNT(*) FROM Employees", sqlConnection);

            sqlConnection.Open();
            try
            {
               result = (int)sqlCommand.ExecuteScalar();
            }
            finally
            {
               sqlConnection.Close();
            }
         }
         return result;
      }

      // Retrieves the ID of the first employee that has the provided name.
      static int GetEmployeeID(string lastName, string firstName,
         string connectionString)
      {
         using (SqlConnection connection =
            new SqlConnection(connectionString))
         {
            SqlCommand command = new SqlCommand(
               string.Format(
                  "SELECT [Employee ID] FROM Employees " +
                  "WHERE [Last Name] = '{0}' AND [First Name] = '{1}'",
                  lastName, firstName),
               connection);

            connection.Open();
            try
            {
               return (int)command.ExecuteScalar();
            }
            finally
            {
               connection.Close();
            }
         }
      }
      // </snippet4>

      // <snippet5>
      // Posts random Employee data to the provided target block.
      static void PostRandomEmployees(ITargetBlock<Employee> target, int count)
      {
         Console.WriteLine($"Adding {count} entries to Employee table...");

         for (int i = 0; i < count; i++)
         {
            target.Post(Employee.Random());
         }
      }

      // Adds random employee data to the database by using dataflow.
      static void AddEmployees(string connectionString, int count)
      {
         // Create an ActionBlock<Employee> object that adds a single
         // employee entry to the database.
         var insertEmployee = new ActionBlock<Employee>(e =>
            InsertEmployees(new Employee[] { e }, connectionString));

         // Post several random Employee objects to the dataflow block.
         PostRandomEmployees(insertEmployee, count);

         // Set the dataflow block to the completed state and wait for
         // all insert operations to complete.
         insertEmployee.Complete();
         insertEmployee.Completion.Wait();
      }
      // </snippet5>

      // <snippet6>
      // Adds random employee data to the database by using dataflow.
      // This method is similar to AddEmployees except that it uses batching
      // to add multiple employees to the database at a time.
      static void AddEmployeesBatched(string connectionString, int batchSize,
         int count)
      {
         // Create a BatchBlock<Employee> that holds several Employee objects and
         // then propagates them out as an array.
         var batchEmployees = new BatchBlock<Employee>(batchSize);

         // Create an ActionBlock<Employee[]> object that adds multiple
         // employee entries to the database.
         var insertEmployees = new ActionBlock<Employee[]>(a =>
            InsertEmployees(a, connectionString));

         // Link the batch block to the action block.
         batchEmployees.LinkTo(insertEmployees);

         // When the batch block completes, set the action block also to complete.
         batchEmployees.Completion.ContinueWith(delegate { insertEmployees.Complete(); });

         // Post several random Employee objects to the batch block.
         PostRandomEmployees(batchEmployees, count);

         // Set the batch block to the completed state and wait for
         // all insert operations to complete.
         batchEmployees.Complete();
         insertEmployees.Completion.Wait();
      }
      // </snippet6>

      // <Snippet7>
      // Displays information about several random employees to the console.
      static void GetRandomEmployees(string connectionString, int batchSize,
         int count)
      {
         // Create a BatchedJoinBlock<Employee, Exception> object that holds
         // both employee and exception data.
         var selectEmployees = new BatchedJoinBlock<Employee, Exception>(batchSize);

         // Holds the total number of exceptions that occurred.
         int totalErrors = 0;

         // Create an action block that prints employee and error information
         // to the console.
         var printEmployees =
            new ActionBlock<Tuple<IList<Employee>, IList<Exception>>>(data =>
            {
               // Print information about the employees in this batch.
               Console.WriteLine("Received a batch...");
               foreach (Employee e in data.Item1)
               {
                  Console.WriteLine($"Last={e.LastName} First={e.FirstName} ID={e.EmployeeID}");
               }

               // Print the error count for this batch.
               Console.WriteLine($"There were {data.Item2.Count} errors in this batch...");

               // Update total error count.
               totalErrors += data.Item2.Count;
            });

         // Link the batched join block to the action block.
         selectEmployees.LinkTo(printEmployees);

         // When the batched join block completes, set the action block also to complete.
         selectEmployees.Completion.ContinueWith(delegate { printEmployees.Complete(); });

         // Try to retrieve the ID for several random employees.
         Console.WriteLine("Selecting random entries from Employees table...");
         for (int i = 0; i < count; i++)
         {
            try
            {
               // Create a random employee.
               Employee e = Employee.Random();

               // Try to retrieve the ID for the employee from the database.
               e.EmployeeID = GetEmployeeID(e.LastName, e.FirstName, connectionString);

               // Post the Employee object to the Employee target of
               // the batched join block.
               selectEmployees.Target1.Post(e);
            }
            catch (NullReferenceException e)
            {
               // GetEmployeeID throws NullReferenceException when there is
               // no such employee with the given name. When this happens,
               // post the Exception object to the Exception target of
               // the batched join block.
               selectEmployees.Target2.Post(e);
            }
         }

         // Set the batched join block to the completed state and wait for
         // all retrieval operations to complete.
         selectEmployees.Complete();
         printEmployees.Completion.Wait();

         // Print the total error count.
         Console.WriteLine($"Finished. There were {totalErrors} total errors.");
      }
      // </Snippet7>

      static void Main(string[] args)
      {
         // Create a connection string for accessing the database.
         // The connection string refers to the temporary database location.
         string connectionString = "...";

         // Create a Stopwatch object to time database insert operations.
         Stopwatch stopwatch = new Stopwatch();

         // Start with a clean database file by copying the source database to
         // the temporary location.
         File.Copy(sourceDatabase, scratchDatabase, true);

         // Demonstrate multiple insert operations without batching.
         Console.WriteLine("Demonstrating non-batched database insert operations...");
         Console.WriteLine("Original size of Employee table: {0}.",
            GetEmployeeCount(connectionString));
         stopwatch.Start();
         AddEmployees(connectionString, insertCount);
         stopwatch.Stop();
         Console.WriteLine("New size of Employee table: {0}; elapsed insert time: {1} ms.",
            GetEmployeeCount(connectionString), stopwatch.ElapsedMilliseconds);

         Console.WriteLine();

         // Start again with a clean database file.
         File.Copy(sourceDatabase, scratchDatabase, true);

         // Demonstrate multiple insert operations, this time with batching.
         Console.WriteLine("Demonstrating batched database insert operations...");
         Console.WriteLine("Original size of Employee table: {0}.",
            GetEmployeeCount(connectionString));
         stopwatch.Restart();
         AddEmployeesBatched(connectionString, insertBatchSize, insertCount);
         stopwatch.Stop();
         Console.WriteLine("New size of Employee table: {0}; elapsed insert time: {1} ms.",
            GetEmployeeCount(connectionString), stopwatch.ElapsedMilliseconds);

         Console.WriteLine();

         // Start again with a clean database file.
         File.Copy(sourceDatabase, scratchDatabase, true);

         // Demonstrate multiple retrieval operations with error reporting.
         Console.WriteLine("Demonstrating batched join database select operations...");
         // Add a small number of employees to the database.
         AddEmployeesBatched(connectionString, insertBatchSize, 16);
         // Query for random employees.
         GetRandomEmployees(connectionString, insertBatchSize, 10);
      }
   }
}
/* Sample output:
Demonstrating non-batched database insert operations...
Original size of Employee table: 15.
Adding 256 entries to Employee table...
New size of Employee table: 271; elapsed insert time: 11035 ms.

Demonstrating batched database insert operations...
Original size of Employee table: 15.
Adding 256 entries to Employee table...
New size of Employee table: 271; elapsed insert time: 197 ms.

Demonstrating batched join database insert operations...
Adding 16 entries to Employee table...
Selecting items from Employee table...
Received a batch...
Last=Jones First=Tom ID=21
Last=Jones First=John ID=24
Last=Smith First=Tom ID=26
Last=Jones First=Tom ID=21
There were 4 errors in this batch...
Received a batch...
Last=Smith First=Tom ID=26
Last=Jones First=Mike ID=28
There were 0 errors in this batch...
Finished. There were 4 total errors.
*/
// </snippet100>
