---
title: Walkthrough - Accessing a SQL Database by Using Type Providers (F#)
description: Walkthrough - Accessing a SQL Database by Using Type Providers (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1c413eb0-16a5-4c1a-9a4e-ad6877e645d6
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/tutorials/type-providers/accessing-a-sql-database 
---

# Walkthrough: Accessing a SQL Database by Using Type Providers (F#)

This walkthrough explains how to use the SqlDataConnection (LINQ to SQL) type provider that is available in F# 3.0 to generate types for data in a SQL database when you have a live connection to a database. If you do not have a live connection to a database, but you do have a LINQ to SQL schema file (DBML file), see [Walkthrough: Generating F&#35; Types from a DBML File &#40;F&#35;&#41;](Walkthrough-Generating-FSharp-Types-from-a-DBML-File-%5BFSharp%5D.md).

This walkthrough illustrates the following tasks. These tasks must be performed in this order for the walkthrough to succeed:


- Preparing a test database
<br />

- Creating the project
<br />

- Setting up a type provider
<br />

- Querying the data
<br />

- Working with nullable fields
<br />

- Calling a stored procedure
<br />

- Updating the database
<br />

- Executing Transact-SQL code
<br />

- Using the full data context
<br />

- Deleting data
<br />

- Create a test database (as needed)
<br />

## Preparing a Test Database
On a server that's running SQL Server, create a database for testing purposes. You can use the database create script at the bottom of this page in the section [MyDatabase Create Script]: #BKMK_MyDBCreateScript to do this.


#### To prepare a test database

- To run the MyDatabase Create Script, open the **View** menu, and then choose **SQL Server Object Explorer** or choose the Ctrl+\, Ctrl+S keys. In **SQL Server Object Explorer** window, open the shortcut menu for the appropriate instance, choose **New Query**, copy the script at the bottom of this page, and then paste the script into the editor. To run the SQL script, choose the toolbar icon with the triangular symbol, or choose the Ctrl+Q keys. For more information about **SQL Server Object Explorer**, see [Connected Database Development](http://go.microsoft.com/fwlink/?LinkId=237128).
<br />


## Creating the project
Next, you create an F# application project.


#### To create and set up the project

1. Create a new F# Application project.
<br />

2. Add references to [.FSharp.Data.TypeProviders](https://msdn.microsoft.com/library/a858f859-047a-44ab-945b-8731d7a0e6e3), as well as `System.Data`, and `System.Data.Linq`.
<br />

3. Open the appropriate namespaces by adding the following lines of code to the top of your F# code file Program.fs.
<br />

```fsharp
  open System
  open System.Data
  open System.Data.Linq
  open Microsoft.FSharp.Data.TypeProviders
  open Microsoft.FSharp.Linq
```

4. As with most F# programs, you can execute the code in this walkthrough as a compiled program, or you can run it interactively as a script. If you prefer to use scripts, open the shortcut menu for the project node, select **Add New Item**, add an F# script file, and add the code in each step to the script. You will need to add the following lines at the top of the file to load the assembly references.
<br />

```fsharp
  #r "System.Data.dll"
  #r "FSharp.Data.TypeProviders.dll"
  #r "System.Data.Linq.dll"
```

  You can then select each block of code as you add it and press Alt+Enter to run it in F# Interactive.
<br />

## Setting up a type provider
In this step, you create a type provider for your database schema.


#### To set up the type provider from a direct database connection

- There are two critical lines of code that you need in order to create the types that you can use to query a SQL database using the type provider. First, you instantiate the type provider. To do this, create what looks like a type abbreviation for a `SqlDataConnection` with a static generic parameter. `SqlDataConnection` is a SQL type provider, and should not be confused with `SqlConnection` type that is used in ADO.NET programming. If you have a database that you want to connect to, and have a connection string, use the following code to invoke the type provider. Substitute your own connection string for the example string given. For example, if your server is MYSERVER and the database instance is INSTANCE, the database name is MyDatabase, and you want to use Windows Authentication to access the database, then the connection string would be as given in the following example code.
<br />

```fsharp
  type dbSchema = SqlDataConnection<"Data Source=MYSERVER\INSTANCE;Initial Catalog=MyDatabase;Integrated Security=SSPI;">
  let db = dbSchema.GetDataContext()
  
  // Enable the logging of database activity to the console.
  db.DataContext.Log <- System.Console.Out
```

Now you have a type, `dbSchema`, which is a parent type that contains all the generated types that represent database tables. You also have an object, `db`, which has as its members all the tables in the database. The table names are properties, and the type of these properties is generated by the F# compiler. The types themselves appear as nested types under `dbSchema.ServiceTypes`. Therefore, any data retrieved for rows of these tables is an instance of the appropriate type that was generated for that table. The name of the type is `ServiceTypes.Table1`.
<br />  To familiarize yourself with how the F# language interprets queries into SQL queries, review the line that sets the `Log` property on the data context.
<br />  To further explore the types created by the type provider, add the following code.
<br />

```fsharp
  let table1 = db.Table1
```

Hover over `table1` to see its type. Its type is`System.Data.Linq.Table<dbSchema.ServiceTypes.Table1>` and the generic argument implies that the type of each row is the generated type, `dbSchema.ServiceTypes.Table1`. The compiler creates a similar type for each table in the database.
<br />

## Querying the data
In this step, you write a query using F# query expressions.


#### To query the data

1. Now create a query for that table in the database. Add the following code.
<br />

```fsharp
  let query1 =
  query {
  for row in db.Table1 do
  select row
  }
  query1 |> Seq.iter (fun row -> printfn "%s %d" row.Name row.TestData1)
```

The appearance of the word `query` indicates that this is a query expression, a type of computation expression that generates a collection of results similar of a typical database query. If you hover over query, you will see that it is an instance of [Linq.QueryBuilder Class &#40;F&#35;&#41;](Linq.QueryBuilder-Class-%5BFSharp%5D.md), a type that defines the query computation expression. If you hover over `query1`, you will see that it is an instance of `System.Linq.IQueryable`. As the name suggests, `System.Linq.IQueryable` represents data that may be queried, not the result of a query. A query is subject to lazy evaluation, which means that the database is only queried when the query is evaluated. The final line passes the query through `Seq.iter`. Queries are enumerable and may be iterated like sequences. For more information, see [Query Expressions &#40;F&#35;&#41;](Query-Expressions-%5BFSharp%5D.md).

<br />

2. Now add a query operator to the query. There are a number of query operators available that you can use to construct more complex queries. This example also shows that you can eliminate the query variable and use a pipeline operator instead.
<br />

```fsharp
  query {
  for row in db.Table1 do
  where (row.TestData1 > 2)
  select row
  }
  |> Seq.iter (fun row -> printfn "%d %s" row.TestData1 row.Name)
```

3. Add a more complex query with a join of two tables.
<br />

```fsharp
  query {
  for row1 in db.Table1 do
  join row2 in db.Table2 on (row1.Id = row2.Id)
  select (row1, row2)
  }
  |> Seq.iteri (fun index (row1, row2) ->
  if (index = 0) then printfn "Table1.Id TestData1 TestData2 Name Table2.Id TestData1 TestData2 Name"
  printfn "%d %d %f %s %d %d %f %s" row1.Id row1.TestData1 row1.TestData2 row1.Name
  row2.Id (row2.TestData1.GetValueOrDefault()) (row2.TestData2.GetValueOrDefault()) row2.Name)
```

4. In real-world code, the parameters in your query are usually values or variables, not compile-time constants. Add the following code that wraps a query in a function that takes a parameter, and then calls that function with the value 10.
<br />

```fsharp
  let findData param =
  query {
  for row in db.Table1 do
  where (row.TestData1 = param)
  select row
  }
  findData 10 |> Seq.iter (fun row -> printfn "Found row: %d %d %f %s" row.Id row.TestData1 row.TestData2 row.Name)
```

## Working with nullable fields
In databases, fields often allow null values. In the .NET type system, you cannot use the ordinary numerical data types for data that allows nulls because those types do not have null as a possible value. Therefore, these values are represented by instances of `System.Nullable` type. Instead of accessing the value of such fields directly with the name of the field, you need to add some extra steps. You can use the `System.Nullable.Value` property to access the underlying value of a nullable type. The `System.Nullable.Value` property throws an exception if the object is null rather than having a value. You can use the `System.Nullable.HasValue` Boolean method to determine if a value exists, or use `System.Nullable.GetValueOrDefault()` to ensure that you have an actual value in all cases. If you use `System.Nullable.GetValueOrDefault()` and there is a null in the database, then it is replaced with a value such as an empty string for string types, 0 for integral types or 0.0 for floating point types.

When you need to perform equality tests or comparisons on nullable values in a `where` clause in a query, you can use the nullable operators found in the [Linq.NullableOperators Module &#40;F&#35;&#41;](Linq.NullableOperators-Module-%5BFSharp%5D.md). These are like the regular comparison operators `=`, `>`, `<=`, and so on, except that a question mark appears on the left or right of the operator where the nullable values are. For example, the operator `>?` is a greater-than operator with a nullable value on the right. The way these operators work is that if either side of the expression is null, the expression evaluates to `false`. In a `where` clause, this generally means that the rows that contain null fields are not selected and not returned in the query results.


#### To work with nullable fields

1. The following code shows working with nullable values; assume that **TestData1** is an integer field that allows nulls.
<br />

```fsharp
  query {
  for row in db.Table2 do
  where (row.TestData1.HasValue && row.TestData1.Value > 2)
  select row
  }
  |> Seq.iter (fun row -> printfn "%d %s" row.TestData1.Value row.Name)
  
  query {
  for row in db.Table2 do
  // Use a nullable operator ?>
  where (row.TestData1 ?> 2)
  select row
  }
  |> Seq.iter (fun row -> printfn "%d %s" (row.TestData1.GetValueOrDefault()) row.Name)
```

## Calling a stored procedure
Any stored procedures on the database can be called from F#. You must set the static parameter `StoredProcedures` to `true` in the type provider instantiation. The type provider `SqlDataConnection` contains several static methods that you can use to configure the types that are generated. For a complete description of these, see [SqlDataConnection Type Provider &#40;F&#35;&#41;](SqlDataConnection-Type-Provider-%5BFSharp%5D.md). A method on the data context type is generated for each stored procedure.


#### To call a stored procedure

- If the stored procedures takes parameters that are nullable, you need to pass an appropriate `System.Nullable` value. The return value of a stored procedure method that returns a scalar or a table is `System.Data.Linq.ISingleResult`, which contains properties that enable you to access the returned data. The type argument for `System.Data.Linq.ISingleResult` depends on the specific procedure and is also one of the types that the type provider generates. For a stored procedure named `Procedure1`, the type is `Procedure1Result`. The type `Procedure1Result` contains the names of the columns in a returned table, or, for a stored procedure that returns a scalar value, it represents the return value.
<br />  The following code assumes that there is a procedure `Procedure1` on the database that takes two nullable integers as parameters, runs a query that returns a column named `TestData1`, and returns an integer.
<br />

```fsharp
  type schema = SqlDataConnection<"Data Source=MYSERVER\INSTANCE;Initial Catalog=MyDatabase;Integrated Security=SSPI;",
  StoredProcedures = true>
  
  let testdb = schema.GetDataContext()
  
  let nullable value = new System.Nullable<_>(value)
  
  let callProcedure1 a b =
  let results = testdb.Procedure1(nullable a, nullable b)
  for result in results do
  printfn "%d" (result.TestData1.GetValueOrDefault())
  results.ReturnValue :?> int
  
  printfn "Return Value: %d" (callProcedure1 10 20)
```

## Updating the database
The LINQ DataContext type contains methods that make it easier to perform transacted database updates in a fully typed fashion with the generated types.


#### To update the database

1. In the following code, several rows are added to the database. If you are only adding a row, you can use `System.Data.Linq.Table.InsertOnSubmit()` to specify the new row to add. If you are inserting multiple rows, you should put them into a collection and call `System.Data.Linq.Table.InsertAllOnSubmit(System.Collections.Generic.IEnumerable)`. When you call either of these methods, the database is not immediately changed. You must call `System.Data.Linq.DataContext.SubmitChanges` to actually commit the changes. By default, everything that you do before you call `System.Data.Linq.DataContext.SubmitChanges` is implicitly part of the same transaction.
<br />

```fsharp
  let newRecord = new dbSchema.ServiceTypes.Table1(Id = 100,
  TestData1 = 35, 
  TestData2 = 2.0,
  Name = "Testing123")
  let newValues =
  [ for i in [1 .. 10] ->
  new dbSchema.ServiceTypes.Table3(Id = 700 + i,
  Name = "Testing" + i.ToString(),
  Data = i) ]
  // Insert the new data into the database.
  db.Table1.InsertOnSubmit(newRecord)
  db.Table3.InsertAllOnSubmit(newValues)
  try
  db.DataContext.SubmitChanges()
  printfn "Successfully inserted new rows."
  with
  | exn -> printfn "Exception:\n%s" exn.Message
```

2. Now clean up the rows by calling a delete operation.
<br />

```fsharp
  // Now delete what was added.
  db.Table1.DeleteOnSubmit(newRecord)
  db.Table3.DeleteAllOnSubmit(newValues)
  try
  db.DataContext.SubmitChanges()
  printfn "Successfully deleted all pending rows."
  with
  | exn -> printfn "Exception:\n%s" exn.Message
```

## Executing Transact-SQL code
You can also specify Transact-SQL directly by using the `System.Data.Linq.DataContext.ExecuteCommand(System.String,System.Object[])` method on the `DataContext` class.


#### To execute custom SQL commands

- The following code shows how to send SQL commands to insert a record into a table and also to delete a record from a table.
<br />

```fsharp
  try
  db.DataContext.ExecuteCommand("INSERT INTO Table3 (Id, Name, Data) VALUES (102, 'Testing', 55)") |> ignore
  with
  | exn -> printfn "Exception:\n%s" exn.Message
  try //AND Name = 'Testing' AND Data = 55
  db.DataContext.ExecuteCommand("DELETE FROM Table3 WHERE Id = 102 ") |> ignore
  with
  | exn -> printfn "Exception:\n%s" exn.Message
```

## Using the full data context
In the previous examples, the `GetDataContext` method was used to get what is called the *simplified data context* for the database schema. The simplified data context is easier to use when you are constructing queries because there are not as many members available. Therefore, when you browse the properties in IntelliSense, you can focus on the database structure, such as the tables and stored procedures. However, there is a limit to what you can do with the simplified data context. A full data context that provides the ability to perform other actions. is also available This is located in the `ServiceTypes` and has the name of the *DataContext* static parameter if you provided it. If you did not provide it, the name of the data context type is generated for you by SqlMetal.exe based on the other input. The full data context inherits from `System.Data.Linq.DataContext` and exposes the members of its base class, including references to ADO.NET data types such as the `Connection` object, methods such as `System.Data.Linq.DataContext.ExecuteCommand(System.String,System.Object[])` and `System.Data.Linq.DataContext.ExecuteQuery(System.String,System.Object[])` that you can use to write queries in SQL, and also a means to work with transactions explicitly.


#### To use the full data context

- The following code demonstrates getting a full data context object and using it to execute commands directly against the database. In this case, two commands are executed as part of the same transaction.
<br />

```fsharp
  let dbConnection = testdb.Connection
  let fullContext = new dbSchema.ServiceTypes.MyDatabase(dbConnection)
  dbConnection.Open()
  let transaction = dbConnection.BeginTransaction()
  fullContext.Transaction <- transaction
  try
  let result1 = fullContext.ExecuteCommand("INSERT INTO Table3 (Id, Name, Data) VALUES (102, 'A', 55)")
  printfn "ExecuteCommand Result: %d" result1
  let result2 = fullContext.ExecuteCommand("INSERT INTO Table3 (Id, Name, Data) VALUES (103, 'B', -2)")
  printfn "ExecuteCommand Result: %d" result2
  if (result1 <> 1 || result2 <> 1) then
  transaction.Rollback()
  printfn "Rolled back creation of two new rows."
  else
  transaction.Commit()
  printfn "Successfully committed two new rows."
  with
  | exn -> transaction.Rollback()
  printfn "Rolled back creation of two new rows due to exception:\n%s" exn.Message
  
  dbConnection.Close()
```

## Deleting data
This step shows you how to delete rows from a data table.


#### To delete rows from the database

- Now, clean up any added rows by writing a function that deletes rows from a specified table, an instance of the `System.Data.Linq.Table` class. Then write a query to find all the rows that you want to delete, and pipe the results of the query into the `deleteRows` function. This code takes advantage of the ability to provide partial application of function arguments.
<br />

```fsharp
  let deleteRowsFrom (table:Table<_>) rows =
  table.DeleteAllOnSubmit(rows)
  
  query {
  for rows in db.Table3 do
  where (rows.Id > 10)
  select rows
  }
  |> deleteRowsFrom db.Table3
  
  db.DataContext.SubmitChanges()
  printfn "Successfully deleted rows with Id greater than 10 in Table3."
```

## Creating a test database
This section shows you how to set up the test database to use in this walkthrough.

Note that if you alter the database in some way, you will have to reset the type provider. To reset the type provider, rebuild or clean the project that contains the type provider.


#### To create the test database

1. In **Server Explorer**, open the shortcut menu for the **Data Connections** node, and choose **Add Connection**. The **Add Connection** dialog box appears.
<br />

2. In the **Server name** box, specify the name of an instance of SQL Server that you have administrative access to, or if you do not have access to a server, specify (localdb\v11.0). SQL Express LocalDB provides a lightweight database server for development and testing on your machine. A new node is created in **Server Explorer** under **Data Connections**. For more information about LocalDB, see [Walkthrough: Creating a Local Database File in Visual Studio](https://msdn.microsoft.com/library/ms233763.aspx).
<br />

3. Open the shortcut menu for the new connection node, and select **New Query**.
<br />


4. Copy the following SQL script, paste it into the query editor, and then choose the **Execute** button on the toolbar or choose the Ctrl+Shift+E keys.
<br />

```sql
  SET ANSI_NULLS ON
  GO
  SET QUOTED_IDENTIFIER ON
  GO
  
  USE [master];
  GO
  
  IF EXISTS (SELECT * FROM sys.databases WHERE name = 'MyDatabase')
  DROP DATABASE MyDatabase;
  GO
  
  -- Create the MyDatabase database.
  CREATE DATABASE MyDatabase;
  GO
  
  -- Specify a simple recovery model 
  -- to keep the log growth to a minimum.
  ALTER DATABASE MyDatabase 
  SET RECOVERY SIMPLE;
  GO
  
  USE MyDatabase;
  GO
  
  -- Create the Table1 table.
  CREATE TABLE [dbo].[Table1] (
  [Id]        INT        NOT NULL,
  [TestData1] INT        NOT NULL,
  [TestData2] FLOAT (53) NOT NULL,
  [Name]      NTEXT      NOT NULL,
  PRIMARY KEY CLUSTERED ([Id] ASC)
  );
  
  --Create Table2.
  CREATE TABLE [dbo].[Table2] (
  [Id]        INT        NOT NULL,
  [TestData1] INT        NULL,
  [TestData2] FLOAT (53) NULL,
  [Name]      NTEXT      NOT NULL,
  PRIMARY KEY CLUSTERED ([Id] ASC)
  );
  
  
  --     Create Table3.
  CREATE TABLE [dbo].[Table3] (
  [Id]   INT           NOT NULL,
  [Name] NVARCHAR (50) NOT NULL,
  [Data] INT           NOT NULL,
  PRIMARY KEY CLUSTERED ([Id] ASC)
  );
  GO
  
  CREATE PROCEDURE [dbo].[Procedure1]
  @param1 int = 0,
  @param2 int
  AS
  SELECT TestData1 FROM Table1
  RETURN 0
  GO
  
  -- Insert data into the Table1 table.
  USE MyDatabase
  
  INSERT INTO Table1 (Id, TestData1, TestData2, Name)
  VALUES(1, 10, 5.5, 'Testing1');
  INSERT INTO Table1 (Id, TestData1, TestData2, Name)
  VALUES(2, 20, -1.2, 'Testing2');
  
  --Insert data into the Table2 table.
  INSERT INTO Table2 (Id, TestData1, TestData2, Name)
  VALUES(1, 10, 5.5, 'Testing1');
  INSERT INTO Table2 (Id, TestData1, TestData2, Name)
  VALUES(2, 20, -1.2, 'Testing2');
  INSERT INTO Table2 (Id, TestData1, TestData2, Name)
  VALUES(3, NULL, NULL, 'Testing3');
  
  INSERT INTO Table3 (Id, Name, Data)
  VALUES (1, 'Testing1', 10);
  INSERT INTO Table3 (Id, Name, Data)
  VALUES (2, 'Testing2', 100);
```


## See Also
[Type Providers](Type-Providers.md)

[SqlDataConnection Type Provider &#40;F&#35;&#41;](SqlDataConnection-Type-Provider-%5BFSharp%5D.md)

[Walkthrough: Generating F&#35; Types from a DBML File &#40;F&#35;&#41;](Walkthrough-Generating-FSharp-Types-from-a-DBML-File-%5BFSharp%5D.md)

[Query Expressions &#40;F&#35;&#41;](Query-Expressions-%5BFSharp%5D.md)

[LINQ to SQL](https://msdn.microsoft.com/library/bb386976)

[SqlMetal.exe &#40;Code Generation Tool&#41;](https://msdn.microsoft.com/library/bb386987)