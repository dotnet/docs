---
description: "Learn more about: Analyzing LINQ to SQL Source Code"
title: "Analyzing LINQ to SQL Source Code"
ms.date: "03/30/2017"
ms.assetid: cba3eef8-e108-4478-b588-ad59580e133e
---
# Analyzing LINQ to SQL Source Code

By using the following steps, you can produce [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] source code from the Northwind sample database. You can compare elements of the object model with elements of the database to better see how different items are mapped.  
  
> [!NOTE]
> Developers using Visual Studio can use the O/R Designer to produce this code.  
  
1. If you do not already have the Northwind sample database on your development computer, you can download it free of charge. For more information, see [Downloading Sample Databases](downloading-sample-databases.md).  
  
2. Use the SqlMetal command-line tool to generate a Visual Basic or C# source file. For more information, see [SqlMetal.exe (Code Generation Tool)](../../../../tools/sqlmetal-exe-code-generation-tool.md). By typing the following commands at a command prompt, you can generate Visual Basic and C# source files that include stored procedures and functions:  
  
    - `sqlmetal /code:northwind.vb /language:vb "c:\northwnd.mdf" /sprocs /functions /pluralize`  
  
    - `sqlmetal /code:northwind.cs /language:csharp "c:\northwnd.mdf" /sprocs /functions /pluralize`  
  
## See also

- [Reference](reference.md)
- [Background Information](background-information.md)
