// <snippet100>
// <snippet1>
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
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
      static readonly int s_insertCount = 256;

      // The size of a single batch of employees to add to the database.
      // TODO: Change this value to experiment with different batch sizes.
      static readonly int s_insertBatchSize = 96;

      static readonly string s_employeeTable =
         "##DataflowEmployees_" + Guid.NewGuid().ToString("N");
      // </snippet2>

      // <snippet3>
      // Describes an employee. Each property maps to a
      // column in the sample employee table.
      class Employee
      {
         public int EmployeeID { get; set; }
         public string LastName { get; set; }
         public string FirstName { get; set; }

         // A random number generator that helps tp generate
         // Employee property values.
         static readonly Random s_rand = new Random(42);

         // Possible random first names.
         static readonly string[] s_firstNames =
                { "Tom", "Mike", "Ruth", "Bob", "John" };
         // Possible random last names.
         static readonly string[] s_lastNames =
                { "Jones", "Smith", "Johnson", "Walker" };

         // Creates an Employee object that contains random
         // property values.
         public static Employee Random()
         {
            return new Employee
            {
               EmployeeID = -1,
               LastName = s_lastNames[s_rand.Next() % s_lastNames.Length],
               FirstName = s_firstNames[s_rand.Next() % s_firstNames.Length]
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
                  $"INSERT INTO [{s_employeeTable}] ([Last Name], [First Name])" +
                  "VALUES (@lastName, @firstName)",
                  connection);

               connection.Open();
               for (int i = 0; i < employees.Length; i++)
               {
                  // Set parameters.
                  command.Parameters.Clear();
                  command.Parameters.AddWithValue("@lastName", employees[i].LastName);
                  command.Parameters.AddWithValue("@firstName", employees[i].FirstName);

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

      // Retrieves the number of entries in the sample employee table.
      static int GetEmployeeCount(string connectionString)
      {
         int result = 0;
         using (SqlConnection sqlConnection =
            new SqlConnection(connectionString))
         {
            SqlCommand sqlCommand = new SqlCommand(
               $"SELECT COUNT(*) FROM [{s_employeeTable}]", sqlConnection);

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
               $"SELECT TOP (1) [Employee ID] FROM [{s_employeeTable}] " +
               "WHERE [Last Name] = @lastName AND [First Name] = @firstName ORDER BY [Employee ID]",
               connection);

            command.Parameters.Add("@lastName", System.Data.SqlDbType.NVarChar).Value = lastName;
            command.Parameters.Add("@firstName", System.Data.SqlDbType.NVarChar).Value = firstName;

            connection.Open();
            try
            {
               object result = command.ExecuteScalar();
               if (result == null)
                  throw new KeyNotFoundException("No matching employee.");
               return (int)result;
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
            catch (KeyNotFoundException e)
            {
               // GetEmployeeID throws KeyNotFoundException when there is
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

      static void Main()
      {
         string connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING");
         if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("Set the SQL_CONNECTION_STRING environment variable.");

         // Keep the global temporary table alive while worker connections use it.
         using var keeper = new SqlConnection(connectionString);
         keeper.Open();
         using var setup = new SqlCommand(
            $"CREATE TABLE [{s_employeeTable}] " +
            "([Employee ID] int IDENTITY PRIMARY KEY, " +
            "[Last Name] nvarchar(50) NOT NULL, [First Name] nvarchar(50) NOT NULL)", keeper);
         setup.ExecuteNonQuery();

         try
         {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Demonstrating non-batched database insert operations...");
            Console.WriteLine($"Original size of Employee table: {GetEmployeeCount(connectionString)}.");
            stopwatch.Start();
            AddEmployees(connectionString, s_insertCount);
            stopwatch.Stop();
            Console.WriteLine("New size of Employee table: {0}; elapsed insert time: {1} ms.",
               GetEmployeeCount(connectionString), stopwatch.ElapsedMilliseconds);
            Console.WriteLine();

            using var reset = new SqlCommand($"TRUNCATE TABLE [{s_employeeTable}]", keeper);
            reset.ExecuteNonQuery();

            Console.WriteLine("Demonstrating batched database insert operations...");
            Console.WriteLine($"Original size of Employee table: {GetEmployeeCount(connectionString)}.");
            stopwatch.Restart();
            AddEmployeesBatched(connectionString, s_insertBatchSize, s_insertCount);
            stopwatch.Stop();
            Console.WriteLine("New size of Employee table: {0}; elapsed insert time: {1} ms.",
               GetEmployeeCount(connectionString), stopwatch.ElapsedMilliseconds);
            Console.WriteLine();

            reset.ExecuteNonQuery();

            Console.WriteLine("Demonstrating batched join database select operations...");
            AddEmployeesBatched(connectionString, s_insertBatchSize, 16);
            GetRandomEmployees(connectionString, s_insertBatchSize, 10);
         }
         finally
         {
            using var cleanup = new SqlCommand($"DROP TABLE [{s_employeeTable}]", keeper);
            cleanup.ExecuteNonQuery();
         }
      }
   }
}

// </snippet100>
