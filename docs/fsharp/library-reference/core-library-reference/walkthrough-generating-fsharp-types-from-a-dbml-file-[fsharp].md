---
title: Walkthrough - Generating F# Types from a DBML File (F#)
description: Walkthrough - Generating F# Types from a DBML File (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6fbb6ccc-248f-4226-95e9-f6f99541dbe4
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/tutorials/type-providers/generating-fsharp-types-from-dbml 
---

# Walkthrough: Generating F# Types from a DBML File (F#)

This walkthrough for F# 3.0 describes how to create types for data from a database when you have schema information encoded in a .dbml file. LINQ to SQL uses this file format to represent database schema. You can generate a LINQ to SQL schema file in Visual Studio by using the Object Relational (O/R) Designer. For more information, see [O&#47;R Designer Overview](https://msdn.microsoft.com/library/bb384511.aspx) and [Code Generation in LINQ to SQL](Code-Generation-in-https://msdn.microsoft.com/library/bb386976).

The Database Markup Language (DBML) type provider allows you to write code that uses types based on a database schema without requiring you to specify a static connection string at compile time. That can be useful if you need to allow for the possibility that the final application will use a different database, different credentials, or a different connection string than the one you use to develop the application. If you have a direct database connection that you can use at compile time and this is the same database and credentials that you will eventually use in your built application, you can also use the SQLDataConnection type provider. For more information, see [Walkthrough: Accessing a SQL Database by Using Type Providers &#40;F&#35;&#41;](Walkthrough-Accessing-a-SQL-Database-by-Using-Type-Providers-%5BFSharp%5D.md).

This walkthrough illustrates the following tasks. They should be completed in this order for the walkthrough to succeed:


- Creating a .dbml file
<br />

- Creating and setting up an F# project
<br />

- Configuring the type provider and generating the types
<br />

- Querying the database
<br />


## Prerequisites

## Creating a .dbml file
If you do not have a database to test on, create one by following the instructions at the bottom of [Walkthrough: Accessing a SQL Database by Using Type Providers &#40;F&#35;&#41;](Walkthrough-Accessing-a-SQL-Database-by-Using-Type-Providers-%5BFSharp%5D.md). If you follow these instructions, you will create a database called MyDatabase that contains a few simple tables and stored procedures on your SQL Server.

If you already have a .dbml file, you can skip to the section, **Create and Set Up an F# Project**. Otherwise, you can create a .dbml file given an existing SQL database and by using the command-line tool SqlMetal.exe.


#### To create a .dbml file by using SqlMetal.exe

1. Open a **Developer Command Prompt**.
<br />

2. Ensure that you have access to SqlMetal.exe by entering `SqlMetal.exe /?` at the command prompt. SqlMetal.exe is typically installed under the **Microsoft SDKs** folder in **Program Files** or **Program Files (x86)**.
<br />

3. Run SqlMetal.exe with the following command-line options. Substitute an appropriate path in place of `c:\destpath` to create the .dbml file, and insert appropriate values for the database server, instance name, and database name.
<br />

```
  SqlMetal.exe /sprocs /dbml:C:\destpath\MyDatabase.dbml /server:SERVER\INSTANCE /database:MyDatabase
```

>[!NOTE]
If SqlMetal.exe has trouble creating the file due to permissions issues, change the current directory to a folder that you have write access to.


4. You can also look at the other available command-line options. For example, there are options you can use if you want views and SQL functions included in the generated types. For more information, see [SqlMetal.exe &#40;Code Generation Tool&#41;](https://msdn.microsoft.com/library/bb386987).
<br />


## Creating and setting up an F# project
In this step, you create a project and add appropriate references to use the DBML type provider.


#### To create and set up an F# project

1. Add a new F# Console Application project to your solution.
<br />

2. In **Solution Explorer**, open the shortcut menu for **References**, and then choose **Add Reference**.
<br />

3. In the **Assemblies** area, choose the **Framework** node, and then, in the list of available assemblies, choose the **System.Data** and **System.Data.Linq** assemblies.
<br />

4. In the **Assemblies** area, choose **Extensions**, and then, in the list of available assemblies, choose **FSharp.Data.TypeProviders**.
<br />

5. Choose the **OK** button to add references to these assemblies to your project.
<br />

6. (Optional). Copy the .dbml file that you created in the previous step, and paste the file in the main folder for your project. This folder contains the project file (.fsproj) and code files. On the menu bar, choose **Project**, **Add Existing Item**, and then specify the .dbml file to add it to your project. If you complete these steps, you can omit the ResolutionFolder static parameter in the next step.
<br />

## Configuring the type provider
In this section, you create a type provider and generate types from the schema that’s described in the .dbml file.


#### To configure the type provider and generate the types

- Add code that opens the **TypeProviders** namespace and instantiates the type provider for the .dbml file that you want to use. If you added the .dbml file to your project, you can omit the ResolutionFolder static parameter.
<br />

```fsharp
  open Microsoft.FSharp.Data.TypeProviders
  
  
  type dbml = DbmlFile<"MyDatabase.dbml", ResolutionFolder = @"<path to folder that contains .dbml file>>
  
  // This connection string can be specified at run time.
  let connectionString = "Data Source=MYSERVER\INSTANCE;Initial Catalog=MyDatabase;Integrated Security=SSPI;"
  let dataContext = new dbml.Mydatabase(connectionString)
```

The DataContext type provides access to all the generated types and inherits from `System.Data.Linq.DataContext`. The DbmlFile type provider has various static parameters that you can set. For example, you can use a different name for the DataContext type by specifying `DataContext=MyDataContext`. In that case, your code resembles the following example:
<br />

```fsharp
  open Microsoft.FSharp.Data.TypeProviders
  
  
  type dbml = DbmlFile<"MyDatabase.dbml",
  ContextTypeName = "MyDataContext">
  
  // This connection string can be specified at run time.
  let connectionString = "Data Source=MYSERVER\INSTANCE;Initial Catalog=MyDatabase;Integrated Security=SSPI;"
  let db = new dbml.MyDataContext(connectionString)
```

## Querying the database
In this section, you use F# query expressions to query the database.


#### To query the data

- Add code to query the database.
<br />

```fsharp
  query {
  for row in db.Table1 do
  where (row.TestData1 > 2)
  select row
  }
  |> Seq.iter (fun row -> printfn "%d %s" row.TestData1 row.Name)
```

## Next Steps
You can proceed to use other query expressions, or get a database connection from the data context and perform normal ADO.NET data operations. For additional steps, see the sections after "Query the Data" in [Walkthrough: Accessing a SQL Database by Using Type Providers &#40;F&#35;&#41;](Walkthrough-Accessing-a-SQL-Database-by-Using-Type-Providers-%5BFSharp%5D.md).


## See Also
[DbmlFile Type Provider &#40;F&#35;&#41;](DbmlFile-Type-Provider-%5BFSharp%5D.md)

[Type Providers](Type-Providers.md)

[Walkthrough: Accessing a SQL Database by Using Type Providers &#40;F&#35;&#41;](Walkthrough-Accessing-a-SQL-Database-by-Using-Type-Providers-%5BFSharp%5D.md)

[SqlMetal.exe &#40;Code Generation Tool&#41;](https://msdn.microsoft.com/library/bb386987)

[Query Expressions &#40;F&#35;&#41;](Query-Expressions-%5BFSharp%5D.md)