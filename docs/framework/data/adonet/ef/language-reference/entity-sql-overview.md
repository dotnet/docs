---
title: "Entity SQL Overview"
ms.date: "03/30/2017"
ms.assetid: f0bb8120-e709-40a3-ac1e-5520dc47477d
---
# Entity SQL Overview
[!INCLUDE[esql](../../../../../../includes/esql-md.md)] is a SQL-like language that enables you to query conceptual models in the Entity Framework. Conceptual models represent data as entities and relationships, and [!INCLUDE[esql](../../../../../../includes/esql-md.md)] allows you to query those entities and relationships in a format that is familiar to those who have used SQL.  
      
 The Entity Framework works with storage-specific data providers to translate generic [!INCLUDE[esql](../../../../../../includes/esql-md.md)] into storage-specific queries. The EntityClient provider supplies a way to execute an [!INCLUDE[esql](../../../../../../includes/esql-md.md)] command against an entity model and return rich types of data including scalar results, result sets, and object graphs. When you construct <xref:System.Data.EntityClient.EntityCommand> objects, you can specify a stored procedure name or the text of a query by assigning an [!INCLUDE[esql](../../../../../../includes/esql-md.md)] query string to its <xref:System.Data.EntityClient.EntityCommand.CommandText%2A?displayProperty=nameWithType> property. The <xref:System.Data.EntityClient.EntityDataReader> exposes the results of executing a <xref:System.Data.EntityClient.EntityCommand> against an EDM. To execute the command that returns the <xref:System.Data.EntityClient.EntityDataReader>, call <xref:System.Data.EntityClient.EntityCommand.ExecuteReader%2A>.  
  
 In addition to the EntityClient provider, the Entity Framework enables you to use [!INCLUDE[esql](../../../../../../includes/esql-md.md)] to execute queries against a conceptual model and return data as strongly-typed CLR objects that are instances of entity types. For more information, see [Working with Objects](../working-with-objects.md).  
  
 This section provides conceptual information about [!INCLUDE[esql](../../../../../../includes/esql-md.md)].  
  
## In This Section  
 [How Entity SQL Differs from Transact-SQL](how-entity-sql-differs-from-transact-sql.md)  
  
 [Entity SQL Quick Reference](entity-sql-quick-reference.md)  
  
 [Type System](type-system-entity-sql.md)  
  
 [Type Definitions](type-definitions-entity-sql.md)  
  
 [Constructing Types](constructing-types-entity-sql.md)  
  
 [Query Plan Caching](query-plan-caching-entity-sql.md)  
  
 [Namespaces](namespaces-entity-sql.md)  
  
 [Identifiers](identifiers-entity-sql.md)  
  
 [Parameters](parameters-entity-sql.md)  
  
 [Variables](variables-entity-sql.md)  
  
 [Unsupported Expressions](unsupported-expressions-entity-sql.md)  
  
 [Literals](literals-entity-sql.md)  
  
 [Null Literals and Type Inference](null-literals-and-type-inference-entity-sql.md)  
  
 [Input Character Set](input-character-set-entity-sql.md)  
  
 [Query Expressions](query-expressions-entity-sql.md)  
  
 [Functions](functions-entity-sql.md)  
  
 [Operator Precedence](operator-precedence-entity-sql.md)  
  
 [Paging](paging-entity-sql.md)  
  
 [Comparison Semantics](comparison-semantics-entity-sql.md)  
  
 [Composing Nested Entity SQL Queries](composing-nested-entity-sql-queries.md)  
  
 [Nullable Structured Types](nullable-structured-types-entity-sql.md)  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
- [Entity SQL Language](entity-sql-language.md)
- [CSDL, SSDL, and MSL Specifications](csdl-ssdl-and-msl-specifications.md)
