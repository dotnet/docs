---
title: "Troubleshooting"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8cd4401c-b12c-4116-a421-f3dcffa65670
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Troubleshooting
The following information exposes some issues you might encounter in your [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] applications, and provides suggestions to avoid or otherwise reduce the effect of these issues.  
  
 Additional issues are addressed in [Frequently Asked Questions](../../../../../../docs/framework/data/adonet/sql/linq/frequently-asked-questions.md).  
  
## Unsupported Standard Query Operators  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not support all standard query operator methods (for example, <xref:System.Linq.Enumerable.ElementAt%2A>). As a result, projects that compile can still produce run-time errors. For more information, see [Standard Query Operator Translation](../../../../../../docs/framework/data/adonet/sql/linq/standard-query-operator-translation.md).  
  
## Memory Issues  
 If a query involves an in-memory collection and [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] <xref:System.Data.Linq.Table%601>, the query might be executed in memory, depending on the order in which the two collections are specified. If the query must be executed in memory, then the data from the database table will need to be retrieved.  
  
 This approach is inefficient and could result in significant memory and processor usage. Try to avoid such multi-domain queries.  
  
## File Names and SQLMetal  
 To specify an input file name, add the name to the command line as the input file. Including the file name in the connection string (using the **/conn** option) is not supported. For more information, see [SqlMetal.exe (Code Generation Tool)](../../../../../../docs/framework/tools/sqlmetal-exe-code-generation-tool.md).  
  
## Class Library Projects  
 The [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] creates a connection string in the `app.config` file of the project. In class library projects, the `app.config` file is not used. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] uses the Connection String provided in the design-time files. Changing the value in `app.config` does not change the database to which your application connects.  
  
## Cascade Delete  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not support or recognize cascade-delete operations. If you want to delete a row in a table that has constraints against it, you must do either of the following:  
  
-   Set the `ON DELETE CASCADE` rule in the foreign-key constraint in the database.  
  
-   Use your own code to first delete the child objects that prevent the parent object from being deleted.  
  
 Otherwise, a <xref:System.Data.SqlClient.SqlException> exception is thrown.  
  
 For more information, see [How to: Delete Rows From the Database](../../../../../../docs/framework/data/adonet/sql/linq/how-to-delete-rows-from-the-database.md).  
  
## Expression Not Queryable  
 If you get the "Expression [expression] is not queryable; are you missing an assembly reference?" error, make sure of the following:  
  
-   Your application is targeting [!INCLUDE[compact_v35_short](../../../../../../includes/compact-v35-short-md.md)].  
  
-   You have a reference to `System.Core.dll` and `System.Data.Linq.dll`.  
  
-   You have an `Imports` ([!INCLUDE[vbprvb](../../../../../../includes/vbprvb-md.md)]) or `using` (C#) directive for <xref:System.Linq> and <xref:System.Data.Linq>.  
  
## DuplicateKeyException  
 In the course of debugging a [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] project, you might traverse an entity's relations. Doing so brings these items into the cache, and [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] becomes aware of their presence. If you then try to execute <xref:System.Data.Linq.Table%601.Attach%2A> or <xref:System.Data.Linq.Table%601.InsertOnSubmit%2A> or a similar method that produces multiple rows that have the same key, a <xref:System.Data.Linq.DuplicateKeyException> is thrown.  
  
## String Concatenation Exceptions  
 Concatenation on operands mapped to `[n]text` and other `[n][var]char` is not supported. An exception is thrown for concatenation of strings mapped to the two different sets of types. For more information, see [System.String Methods](../../../../../../docs/framework/data/adonet/sql/linq/system-string-methods.md).  
  
## Skip and Take Exceptions in SQL Server 2000  
 You must use identity members (<xref:System.Data.Linq.Mapping.ColumnAttribute.IsPrimaryKey%2A>) when you use <xref:System.Linq.Queryable.Take%2A> or <xref:System.Linq.Queryable.Skip%2A> against a SQL Server 2000 database. The query must be against a single table (that is, not a join), or be a <xref:System.Linq.Queryable.Distinct%2A>, <xref:System.Linq.Queryable.Except%2A>, <xref:System.Linq.Queryable.Intersect%2A>, or <xref:System.Linq.Queryable.Union%2A> operation, and must not include a <xref:System.Linq.Queryable.Concat%2A> operation. For more information, see the "SQL Server 2000 Support" section in [Standard Query Operator Translation](../../../../../../docs/framework/data/adonet/sql/linq/standard-query-operator-translation.md).  
  
 This requirement does not apply to [!INCLUDE[sqprsqlong](../../../../../../includes/sqprsqlong-md.md)].  
  
## GroupBy InvalidOperationException  
 This exception is thrown when a column value is null in a <xref:System.Linq.Enumerable.GroupBy%2A> query that groups by a `boolean` expression, such as `group x by (Phone==@phone)`. Because the expression is a `boolean`, the key is inferred to be `boolean`, not `nullable``boolean`. When the translated comparison produces a null, an attempt is made to assign a `nullable``boolean` to a `boolean`, and the exception is thrown.  
  
 To avoid this situation (assuming you want to treat nulls as false), use an approach such as the following:  
  
 `GroupBy="(Phone != null) && (Phone=@Phone)"`  
  
## OnCreated() Partial Method  
 The generated method `OnCreated()` is called each time the object constructor is called, including the scenario in which [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] calls the constructor to make a copy for original values. Take this behavior into account if you implement the `OnCreated()` method in your own partial class.  
  
## See Also  
 [Debugging Support](../../../../../../docs/framework/data/adonet/sql/linq/debugging-support.md)  
 [Frequently Asked Questions](../../../../../../docs/framework/data/adonet/sql/linq/frequently-asked-questions.md)
