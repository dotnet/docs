---
title: "SQL Generation"
ms.date: "03/30/2017"
ms.assetid: 0e16aa02-d458-4418-a765-58b42aad9315
---
# SQL Generation
When you write a provider for the Entity Framework, you must translate Entity Framework command trees into SQL that a specific database can understand, such as Transact-SQL for SQL Server or PL/SQL for Oracle. In this section, you will learn how to develop a SQL generation component (for SELECT queries) for an Entity Framework provider. For information about insert, update, and delete queries, see [Modification SQL Generation](modification-sql-generation.md).  
  
 To understand this section, you should be familiar with the Entity Framework and the ADO.NET Provider Model. You should also understand command trees and <xref:System.Data.Common.CommandTrees.DbExpression>.  
  
## The Role of the SQL Generation Module  
 The SQL generation module of an Entity Framework provider translates a given query command tree into a single SQL SELECT statement that targets a SQL:1999-compliant database. The generated SQL should have as few nested queries as possible. The SQL generation module should not simplify the output query command tree. The Entity Framework will do this, for example by eliminating joins and collapsing consecutive filter nodes.  
  
 The <xref:System.Data.Common.DbProviderServices> class is the starting point for accessing the SQL generation layer to convert command trees into <xref:System.Data.Common.DbCommand>.  
  
## In This Section  
 [The Shape of the Command Trees](the-shape-of-the-command-trees.md)  
  
 [Generating SQL from Command Trees - Best Practices](generating-sql-from-command-trees-best-practices.md)  
  
 [SQL Generation in the Sample Provider](sql-generation-in-the-sample-provider.md)  
  
## See also

- [Writing an Entity Framework Data Provider](writing-an-ef-data-provider.md)
