---
title: Walkthrough - Generating F# Types from an EDMX Schema File (F#)
description: Walkthrough - Generating F# Types from an EDMX Schema File (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 81adb2eb-625f-4ad8-aeaa-8f672a6d79a2
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/tutorials/type-providers/generating-fsharp-types-from-edmx 
---

# Walkthrough: Generating F# Types from an EDMX Schema File (F#)

This walkthrough for F# 3.0 shows you how to create types for data that is represented by the Entity Data Model (EDM), the schema for which is specified in an .edmx file. This walkthrough also shows how to use the EdmxFile type provider. Before you begin, consider whether a SqlEntityConnection type provider is a more appropriate type provider option. The SqlEntityConnection type provider works best for scenarios where you have a live database that you can connect to during the development phase of your project, and you do not mind specifying the connection string at compile time. However, this type provider is also limited in that it doesn't expose as much database functionality as the EdmxFile type provider. Also, if you don't have a live database connection for a database project that uses the Entity Data Model, you can use the .edmx file to code against the database. When you use the EdmxFile type provider, the F# compiler runs EdmGen.exe to generate the types that it provides.

This walkthrough illustrates the following tasks, which you must perform in this order for the walkthrough to succeed:


- Creating an EDMX file
<br />

- Creating the project
<br />

- Finding or creating the entity data model connection string
<br />

- Configuring the type provider
<br />

- Querying the data
<br />

- Calling a stored procedure
<br />


## Prerequisites

## Creating an EDMX file
If you already have an EDMX file, you can skip this step.


#### To create an EDMX file

- If you don't already have an EDMX file, you can follow the instructions at the end of this walkthrough in the step **To configure the Entity Data Model**.
<br />

## Creating the project
In this step, you create a project and add appropriate references to it to use the EDMX type provider.


#### To create and set up an F# project

1. Close the previous project, create another project, and name it SchoolEDM.
<br />

2. In **Solution Explorer**, open the shortcut menu for **References**, and then choose **Add Reference**.
<br />

3. In the **Assemblies** area, choose the **Framework** node.
<br />

4. In the list of available assemblies, choose the **System.Data.Entity** and **System.Data.Linq** assemblies, and then choose the **Add** button to add references to these assemblies to your project.
<br />

5. In the **Assemblies** area, select the **Extensions** node.
<br />

6. In the  list of available extensions, add a reference to the FSharp.Data.TypeProviders assembly.
<br />

7. Add the following code to open the appropriate namespaces.
<br />

```fsharp
  open System.Data.Linq
  open System.Data.Entity
  open Microsoft.FSharp.Data.TypeProviders
```

## Finding or creating the connection string for the Entity Data Model
The connection string for the Entity Data Model (EDMX connection string) includes not only the connection string for the database provider but also additional information. For example, EDMX connection string for a simple SQL Server database resembles the following code.

```fsharp
let edmConnectionString = "metadata=res://*/;provider=System.Data.SqlClient;Provider Connection String='Server=SERVER\Instance;Initial Catalog=DatabaseName;Integrated Security=SSPI;'"
```

For more information about EDMX connection strings, see [Connection Strings](https://msdn.microsoft.com/library/ms254494.aspx).


#### To find or create the connection string for the Entity Data Model

1. EDMX connection strings can be difficult to generate by hand, so you can save time by generating it programmatically. If you know your EDMX connection string, you can bypass this step and simply use that string in the next step. If not, use the following code to generate the EDMX connection string from a database connection string that you provide.
<br />

```fsharp
  open System
  open System.Data
  open System.Data.SqlClient
  open System.Data.EntityClient
  open System.Data.Metadata.Edm
  
  let getEDMConnectionString(dbConnectionString) =
  let dbConnection = new SqlConnection(connectionString)
  let resourceArray = [| "res://*/" |]
  let assemblyList = [| System.Reflection.Assembly.GetCallingAssembly() |]
  let metaData = MetadataWorkspace(resourceArray, assemblyList)
  new EntityConnection(metaData, dbConnection)
```

## Configuring the type provider
In this step, you create and configure the type provider with the EDMX connection string, and you generate types for the schema that's defined in the .edmx file.


#### To configure the type provider and generate types

1. Copy the .edmx file that you generated in the first step of this walkthrough to your project folder.
<br />

2. Open the shortcut menu for the project node in your F# project, choose **Add Existing Item**, and then choose the .edmx file to add it to your project.
<br />

3. Enter the following code to activate the type provider for your .edmx file. Replace *Server*\*Instance* with the name of your server that's running SQL Server and the name of your instance, and use the name of your .edmx file from the first step in this walkthrough.
<br />

```fsharp
  type edmx = EdmxFile<"Model1.edmx", ResolutionFolder = @"<folder that contains your .edmx file>>
  
  let edmConnectionString =
  getEDMConnectionString("Data Source=SERVER\instance;Initial Catalog=School;Integrated Security=true;")
  let context = new edmx.SchoolModel.SchoolEntities(edmConnectionString)
```

## Querying the data
In this step, you use F# query expressions to query the database.


#### To query the data

- Enter the following code to query the data in the entity data model.
<br />

```fsharp
  query { for course in context.Courses do
  select course }
  |> Seq.iter (fun course -> printfn "%s" course.Title)
  
  query { for person in context.Person do
  select person }
  |> Seq.iter (fun person -> printfn "%s %s" person.FirstName person.LastName)
  
  // Add a where clause to filter results
  query { for course in context.Courses do
  where (course.DepartmentID = 1)
  select course)
  |> Seq.iter (fun course -> printfn "%s" course.Title)
  
  // Join two tables
  query { for course in context.Courses do
  join (for dept in context.Departments -> course.DepartmentID = dept.DepartmentID)
  select (course, dept.Name) }
  |> Seq.iter (fun (course, deptName) -> printfn "%s %s" course.Title deptName)
```

## Calling a stored procedure
You can call stored procedures by using the EDMX type provider. In the following procedure, the School database contains a stored procedure, **UpdatePerson**, which updates a record, given new values for the columns. You can use this stored procedure because it's exposed as a method on the DataContext type.


#### To call a stored procedure

- Add the following code to update records.
<br />

```fsharp
  // Call a stored procedure.
  let nullable value = new System.Nullable<_>(value)
  
  // Assume now that you must correct someone's hire date.
  // Throw an exception if more than one matching person is found.
  let changeHireDate(lastName, firstName, hireDate) =
  
  query { for person in context.People do
  where (person.LastName = lastName &&
  person.FirstName = firstName)
  exactlyOne }
  |> (fun person ->
  context.UpdatePerson(nullable person.PersonID, person.LastName,
  person.FirstName, nullable hireDate, person.EnrollmentDate))
  
  changeHireDate("Abercrombie", "Kim", DateTime.Parse("1/12/1998"))
  |> printfn "Result: %d"
```

The result is 1 if you succeed. Notice that **exactlyOne** is used in the query expression to ensure that only one result is returned; otherwise, an exception is thrown. Also, to work with nullable values more easily, you can use the simple **nullable** function that's defined in this code to create a nullable value out of an ordinary value.

<br />

## Configuring the Entity Data Model
You should complete this procedure only if you want to know how to generate a full Entity Data Model from a database and you don't have a database with which to test.


#### To configure the Entity Data Model

1. On the menu bar, choose **SQL**, **Transact-SQL Editor**, **New Query** to create a database. If prompted, specify your database server and instance.
<br />

2. Copy and paste the contents of the database script that creates the Student database, as described in the [Entity Framework documentation](http://msdn.microsoft.com/data/JJ614587.aspx) in the Data Developer Center.
<br />

3. Run the SQL script by choosing the toolbar button with the triangle symbol or choosing the Ctrl+Q keys.
<br />

4. In **Server Explorer**, open the shortcut menu for **Data Connections**, choose **Add Connection**, and then enter the name of the database server, the name of the instance name, and the School database.
<br />

5. Create a C# or Visual Basic Console Application project, open its shortcut menu, choose **Add New Item**, and then choose **ADO.NET Entity Data Model**.
<br />  The Entity Data Model Wizard opens. By using this wizard, you can choose how you want to create the Entity Data Model.
<br />

6. Under **Choose Model Contents**, select the **Generate from database** check box.
<br />

7. On the next page, choose your newly created School database as the data connection.
<br />  This connection should resemble **&lt;servername&gt;.&lt;instancename&gt;.School.dbo**.
<br />

8. Copy your entity connection string to the Clipboard because that string might be important later.
<br />

9. Make sure the check box to save the entity connection string to the **App.Config** file is selected, and make note of the string value in the text box, which should help you locate the connection string later, if needed.
<br />

10. On the next pagechoose **Tables** and **Stored Procedures and Functions**.
<br />  By choosing these top-level nodes, you choose all tables, stored procedures, and functions. You can also choose these individually, if you want.
<br />

11. Make sure that the check boxes for the other settings are selected.
<br />  The first **Pluralize or singularize generated object names** check box indicates whether to change singular forms to plural to match conventions in naming objects that represent database tables. The **Include foreign key columns in the model** check box determines whether to include fields for which the purpose is to join to other fields in the object types that are generated for the database schema. The third check box indicates whether to include stored procedures and functions in the model.
<br />

12. Select the **Finish** button to generate an .edmx file that contains an Entity Data Model that's based on the School database.
<br />  A file, **Model1.edmx**, is added to your project, and a database diagram appears.
<br />

13. On the menu bar, choose **View**, **Other Windows**, **Entity Data Model Browser** to view all the details of the model or **Entity Data Model Mapping Details** to open a window that shows how the generated object model maps onto database tables and columns.
<br />


## Next Steps
Explore other queries by looking at the available query operators as listed in [Query Expressions &#40;F&#35;&#41;](Query-Expressions-%5BFSharp%5D.md).


## See Also
[Type Providers](Type-Providers.md)

[EdmxFile Type Provider &#40;F&#35;&#41;](EdmxFile-Type-Provider-%5BFSharp%5D.md)

[Walkthrough: Accessing a SQL Database by Using Type Providers and Entities &#40;F&#35;&#41;](Walkthrough-Accessing-a-SQL-Database-by-Using-Type-Providers-and-Entities-%5BFSharp%5D.md)

[Entity Framework](http://msdn.microsoft.com/data/ef)

[.edmx File Overview](https://msdn.microsoft.com/library/f4c8e7ce-1db6-417e-9759-15f8b55155d4)

[EDM Generator &#40;EdmGen.exe&#41;](https://msdn.microsoft.com/library/bb387165)

