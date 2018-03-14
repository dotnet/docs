---
title: "Analyzing LINQ to SQL Source Code"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cba3eef8-e108-4478-b588-ad59580e133e
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Analyzing LINQ to SQL Source Code
By using the following steps, you can produce [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] source code from the Northwind sample database. You can compare elements of the object model with elements of the database to better see how different items are mapped.  
  
> [!NOTE]
>  Developers using [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] can use the [!INCLUDE[vs_ordesigner_short](../../../../../../includes/vs-ordesigner-short-md.md)] to produce this code.  
  
1.  If you do not already have the Northwind sample database on your development computer, you can download it free of charge. For more information, see [Downloading Sample Databases](../../../../../../docs/framework/data/adonet/sql/linq/downloading-sample-databases.md).  
  
2.  Use the SqlMetal command-line tool to generate a Visual Basic or C# source file. For more information, see [SqlMetal.exe (Code Generation Tool)](../../../../../../docs/framework/tools/sqlmetal-exe-code-generation-tool.md). By typing the following commands at a command prompt, you can generate Visual Basic and C# source files that include stored procedures and functions:  
  
    -   `sqlmetal /code:northwind.vb /language:vb "c:\northwnd.mdf" /sprocs /functions /pluralize`  
  
    -   `sqlmetal /code:northwind.cs /language:csharp "c:\northwnd.mdf" /sprocs /functions /pluralize`  
  
## See Also  
 [Reference](../../../../../../docs/framework/data/adonet/sql/linq/reference.md)  
 [Background Information](../../../../../../docs/framework/data/adonet/sql/linq/background-information.md)
