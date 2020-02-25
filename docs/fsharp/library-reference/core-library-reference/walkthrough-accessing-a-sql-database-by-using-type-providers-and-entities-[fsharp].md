---
title: Walkthrough - Accessing a SQL Database by Using Type Providers and Entities (F#)
description: Walkthrough - Accessing a SQL Database by Using Type Providers and Entities (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: dc82a932-5401-4d19-9fb3-92c50d8db514
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/tutorials/type-providers/accessing-a-sql-database-entities 
---

# Walkthrough: Accessing a SQL Database by Using Type Providers and Entities (F#)

This walkthrough for F# 3.0 shows you how to access typed data for a SQL database based on the ADO.NET Entity Data Model. This walkthrough shows you how to set up the F# `SqlEntityConnection` type provider for use with a SQL database, how to write queries against the data, how to call stored procedures on the database, as well as how to use some of the ADO.NET Entity Framework types and methods to update the database.

This walkthrough illustrates the following tasks, which you should perform in this order for the walkthrough to succeed:


- Create the School database
<br />

- Create and configure an F# project
<br />

- Configure the type provider and connect to the Entity Data Model
<br />

- Query the database
<br />

- Updating the database
<br />


## Prerequisites
You must have access to a server that's running SQL Server where you can create a database to complete these steps.

## Create the School database
You can create the School database on any server that's running SQL Server to which you have administrative access, or you can use LocalDB.


#### To create the School database

1. In **Server Explorer**, open the shortcut menu for the **Data Connections** node, and then choose **Add Connection**.
<br />  The **Add Connection** dialog box appears.
<br />

2. In the **Server name** box, specify the name of an instance of SQL Server to which you have administrative access, or specify (localdb\v11.0) if you don't have access to a server.
<br />  SQL Server Express LocalDB provides a lightweight database server for development and testing on your machine. For more information about LocalDB, see [Walkthrough: Creating a Local Database File in Visual Studio](https://msdn.microsoft.com/library/ms233763.aspx).
<br />  A new node is created in **Server Explorer** under **Data Connections**.
<br />

3. Open the shortcut menu for the new connection node, and then choose **New Query**.
<br />

4. Open [Creating the School Sample Database](http://go.microsoft.com/fwlink/?LinkID=237278) on the Microsoft website, and then copy and paste the database script that creates the Student database into the editor window.
<br />


## <a name="BKMK_CreateConfigFSProj"> </a>

## Create and configure an F# project
In this step, you create a project and set it up to use a type provider.


#### To create and configure an F# project

1. Close the previous project, create another project, and name it **SchoolEDM**.
<br />

2. In **Solution Explorer**, open the shortcut menu for **References**, and then choose **Add Reference**.
<br />

3. Choose the **Framework** node, and then, in the **Framework** list, choose **System.Data**, **System.Data.Entity**,  and **System.Data.Linq**.
<br />

4. Choose the **Extensions** node, add a reference to the [FSharp.Data.TypeProviders](https://msdn.microsoft.com/library/a858f859-047a-44ab-945b-8731d7a0e6e3) assembly, and then choose the **OK** button to dismiss the dialog box.
<br />

5. Add the following code to define an internal module and open appropriate namespaces. The type provider can inject types only into a private or internal namespace.
<br />

```fsharp
  module internal SchoolEDM
  
  open System.Data.Linq
  open System.Data.Entity
  open Microsoft.FSharp.Data.TypeProviders
```

6. To run the code in this walkthrough interactively as a script instead of as a compiled program, open the shortcut menu for the project node, choose **Add New Item**, add an F# script file, and then add the code in each step to the script. To load the assembly references, add the following lines.
<br />

```fsharp
  #r "System.Data.Entity.dll"
  #r "FSharp.Data.TypeProviders.dll"
  #r "System.Data.Linq.dll"
```

7. Highlight each block of code as you add it, and choose the Alt + Enter keys to run it in F# Interactive.
<br />

## Configure the type provider, and connect to the Entity Data Model
In this step, you set up a type provider with a data connection and obtain a data context that allows you to work with data.


#### To configure the type provider, and connect to the Entity Data Model

1. Enter the following code to configure the `SqlEntityConnection` type provider that generates F# types based on the Entity Data Model that you created previously. Instead of the full EDMX connection string, use only the SQL connection string.
<br />

```fsharp
  type private EntityConnection = SqlEntityConnection<ConnectionString="Server=SERVER\InstanceName;Initial Catalog=School;Integrated Security=SSPI;MultipleActiveResultSets=true",
  Pluralize = true>
  >
```

  This action sets up a type provider with the database connection that you created earlier. The property `MultipleActiveResultSets` is needed when you use the ADO.NET Entity Framework because this property allows multiple commands to execute asynchronously on the database in one connection, which can occur frequently in ADO.NET Entity Framework code. For more information, see [Multiple Active Result Sets (MARS)](http://go.microsoft.com/fwlink/?LinkId=236929).
<br />

2. Get the data context, which is an object that contains the database tables as properties and the database stored procedures and functions as methods.
<br />

```fsharp
  let context = EntityConnection.GetDataContext()
```

## Querying the database
In this step, you use F# query expressions to execute various queries on the database.


#### To query the data

- Enter the following code to query the data from the entity data model. Note the effect of Pluralize = true, which changes the database table Course to Courses and Person to People.
<br />

```fsharp
  query { for course in context.Courses do
  select course }
  |> Seq.iter (fun course -> printfn "%s" course.Title)
  
  query { for person in context.People do
  select person }
  |> Seq.iter (fun person -> printfn "%s %s" person.FirstName person.LastName)
  
  // Add a where clause to filter results.
  query { for course in context.Courses do
  where (course.DepartmentID = 1)
  select course }
  |> Seq.iter (fun course -> printfn "%s" course.Title)
  
  // Join two tables.
  query { for course in context.Courses do
  join dept in context.Departments on (course.DepartmentID = dept.DepartmentID)
  select (course, dept.Name) }
  |> Seq.iter (fun (course, deptName) -> printfn "%s %s" course.Title deptName)
```

## Updating the database
To update the database, you use the Entity Framework classes and methods. You can use two types of data context with the SQLEntityConnection type provider. First, `ServiceTypes.SimpleDataContextTypes.EntityContainer` is the simplified data context, which includes only the provided properties that represent database tables and columns. Second, the full data context is an instance of the Entity Framework class `System.Data.Objects.ObjectContext`, which contains the method `System.Data.Objects.ObjectContext.AddObject(System.String,System.Object)` to add rows to the database. The Entity Framework recognizes the tables and the relationships between them, so it enforces database consistency.


#### To update the database

1. Add the following code to your program. In this example, you add two objects with a relationship between them, and you add an instructor and an office assignment. The table `OfficeAssignments` contains the `InstructorID` column, which references the `PersonID` column in the `Person` table.
<br />

```fsharp
  // The full data context
  let fullContext = context.DataContext
  
  // A helper function.
  let nullable value = new System.Nullable<_>(value)
  
  let addInstructor(lastName, firstName, hireDate, office) =
  let hireDate = DateTime.Parse(hireDate)
  let newPerson = new EntityConnection.ServiceTypes.Person(LastName = lastName,
  FirstName = firstName,
  HireDate = nullable hireDate)
  fullContext.AddObject("People", newPerson)
  let newOffice = new EntityConnection.ServiceTypes.OfficeAssignment(Location = office)
  fullContext.AddObject("OfficeAssignments", newOffice)
  fullContext.CommandTimeout <- nullable 1000
  fullContext.SaveChanges() |> printfn "Saved changes: %d object(s) modified."
  
  addInstructor("Parker", "Darren", "1/1/1998", "41/3720")
```

Nothing is changed in the database until you call `System.Data.Objects.ObjectContext.SaveChanges`.
<br />

2. Now restore the database to its earlier state by deleting the objects that you added.
<br />

```fsharp
  let deleteInstructor(lastName, firstName) =
  query {
  for person in context.People do
  where (person.FirstName = firstName &&
  person.LastName = lastName)
  select person
  }
  |> Seq.iter (fun person->
  query {
  for officeAssignment in context.OfficeAssignments do
  where (officeAssignment.Person.PersonID = person.PersonID)
  select officeAssignment }
  |> Seq.iter (fun officeAssignment -> fullContext.DeleteObject(officeAssignment))
  
  fullContext.DeleteObject(person))
  
  // The call to SaveChanges should be outside of any iteration on the queries.
  fullContext.SaveChanges() |> printfn "Saved changed: %d object(s) modified."
  
  deleteInstructor("Parker", "Darren")
```

>[!WARNING] 
When you use a query expression, you must remember that the query is subject to lazy evaluation. Therefore, the database is still open for reading during any chained evaluations, such as in the lambda expression blocks after each query expression. Any database operation that explicitly or implicitly uses a transaction must occur after the read operations have completed.


## Next Steps
Explore other query options by reviewing the query operators available in [Query Expressions &#40;F&#35;&#41;](Query-Expressions-%5BFSharp%5D.md), and also review the [ADO.NET Entity Framework](https://msdn.microsoft.com/library/bb399572) to understand what functionality is available to you when you use this type provider.


## See Also
[Type Providers](Type-Providers.md)

[SqlEntityConnection Type Provider &#40;F&#35;&#41;](SqlEntityConnection-Type-Provider-%5BFSharp%5D.md)

[Walkthrough: Generating F&#35; Types from an EDMX Schema File &#40;F&#35;&#41;](Walkthrough-Generating-FSharp-Types-from-an-EDMX-Schema-File-%5BFSharp%5D.md)

[ADO.NET Entity Framework](https://msdn.microsoft.com/library/bb399572)

[.edmx File Overview](https://msdn.microsoft.com/library/f4c8e7ce-1db6-417e-9759-15f8b55155d4)

[EDM Generator &#40;EdmGen.exe&#41;](https://msdn.microsoft.com/library/bb387165)