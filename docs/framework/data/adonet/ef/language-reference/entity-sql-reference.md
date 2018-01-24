---
title: "Entity SQL Reference"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 61ce7ee1-ffe2-477d-8a9f-835b0a11d900
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Entity SQL Reference
This section contains [!INCLUDE[esql](../../../../../../includes/esql-md.md)] reference topics. This topic summarizes and groups the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] operators by category.  
  
## Arithmetic Operators  
 Arithmetic operators perform mathematical operations on two expressions of one or more numeric data types. The following table lists the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] arithmetic operators.  
  
|Operator|Use|  
|--------------|---------|  
|[+ (Add)](../../../../../../docs/framework/data/adonet/ef/language-reference/add.md)|Addition.|  
|"/ (Divide)"|Division.|  
|[% (Modulo)](../../../../../../docs/framework/data/adonet/ef/language-reference/modulo-entity-sql.md)|Returns the remainder of a division.|  
|[* (Multiply)](../../../../../../docs/framework/data/adonet/ef/language-reference/multiply-entity-sql.md)|Multiplication.|  
|[- (Negative)](../../../../../../docs/framework/data/adonet/ef/language-reference/negative-entity-sql.md)|Negation.|  
|[- (Subtract)](../../../../../../docs/framework/data/adonet/ef/language-reference/subtract-entity-sql.md)|Subtraction.|  
  
## Canonical Functions  
 Canonical functions are supported by all data providers and can be used by all querying technologies. The following table lists the canonical functions.  
  
|Function|Type|  
|--------------|----------|  
|[Aggregate Entity SQL Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/aggregate-canonical-functions.md)|Discusses aggregate [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.|  
|[Math Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/math-canonical-functions.md)|Discusses math [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.|  
|[String Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/string-canonical-functions.md)|Discusses string [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.|  
|[Date and Time Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/date-and-time-canonical-functions.md)|Discusses date and time [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.|  
|[Bitwise Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/bitwise-canonical-functions.md)|Discusses bitwise [!INCLUDE[esql](../../../../../../includes/esql-md.md)] canonical functions.|  
|[Other Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/other-canonical-functions.md)|Discusses functions not classified as bitwise, date/time, string, math, or aggregate.|  
  
## Comparison Operators  
 Comparison operators are defined for the following types: `Byte`, `Int16`, `Int32`, `Int64`, `Double`, `Single`, `Decimal`, `String`, `DateTime`, `Date`, `Time`, `DateTimeOffset`. Implicit type promotion occurs for the operands before the comparison operator is applied. Comparison operators always yield Boolean values. When at least one of the operands is `null`, the result is `null`.  
  
 Equality and inequality are defined for any object type that has identity, such as the `Boolean` type. Non-primitive objects with identity are considered equal if they share the same identity. The following table lists the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] comparison operators.  
  
|Operator|Description|  
|--------------|-----------------|  
|[= (Equals)](../../../../../../docs/framework/data/adonet/ef/language-reference/equals-entity-sql.md)|Compares the equality of two expressions.|  
|[> (Greater Than)](../../../../../../docs/framework/data/adonet/ef/language-reference/greater-than-entity-sql.md)|Compares two expressions to determine whether the left expression has a value greater than the right expression.|  
|[>= (Greater Than or Equal To)](../../../../../../docs/framework/data/adonet/ef/language-reference/greater-than-or-equal-to-entity-sql.md)|Compares two expressions to determine whether the left expression has a value greater than or equal to the right expression.|  
|[IS &#91;NOT&#93; NULL](../../../../../../docs/framework/data/adonet/ef/language-reference/isnull-entity-sql.md)|Determines if a query expression is null.|  
|[< (Less Than)](../../../../../../docs/framework/data/adonet/ef/language-reference/less-than-entity-sql.md)|Compares two expressions to determine whether the left expression has a value less than the right expression.|  
|[<= (Less Than or Equal To)](../../../../../../docs/framework/data/adonet/ef/language-reference/less-than-or-equal-to-entity-sql.md)|Compares two expressions to determine whether the left expression has a value less than or equal to the right expression.|  
|[&#91;NOT&#93; BETWEEN](../../../../../../docs/framework/data/adonet/ef/language-reference/between-entity-sql.md)|Determines whether an expression results in a value in a specified range.|  
|[!= (Not Equal To)](../../../../../../docs/framework/data/adonet/ef/language-reference/not-equal-to-entity-sql.md)|Compares two expressions to determine whether the left expression is not equal to the right expression.|  
|[&#91;NOT&#93; LIKE](../../../../../../docs/framework/data/adonet/ef/language-reference/like-entity-sql.md)|Determines whether a specific character string matches a specified pattern.|  
  
## Logical and Case Expression Operators  
 Logical operators test for the truth of a condition. The CASE expression evaluates a set of Boolean expressions to determine the result. The following table lists the logical and CASE expression operators.  
  
|Operator|Description|  
|--------------|-----------------|  
|[&& (Logical AND)](../../../../../../docs/framework/data/adonet/ef/language-reference/and-entity-sql.md)|Logical AND.|  
|[! (Logical NOT)](../../../../../../docs/framework/data/adonet/ef/language-reference/not-entity-sql.md)|Logical NOT.|  
|[&#124;&#124; (Logical OR)](../../../../../../docs/framework/data/adonet/ef/language-reference/or-entity-sql.md)|Logical OR.|  
|[CASE](../../../../../../docs/framework/data/adonet/ef/language-reference/case-entity-sql.md)|Evaluates a set of Boolean expressions to determine the result.|  
|[THEN](../../../../../../docs/framework/data/adonet/ef/language-reference/then-entity-sql.md)|The result of a [WHEN](http://msdn.microsoft.com/library/6233fe9f-00b0-460e-8372-64e138a5f998) clause when it evaluates to true.|  
  
## Query Operators  
 Query operators are used to define query expressions that return entity data. The following table lists query operators.  
  
|Operator|Use|  
|--------------|---------|  
|[FROM](../../../../../../docs/framework/data/adonet/ef/language-reference/from-entity-sql.md)|Specifies the collection that is used in [SELECT](../../../../../../docs/framework/data/adonet/ef/language-reference/select-entity-sql.md) statements.|  
|[GROUP BY](../../../../../../docs/framework/data/adonet/ef/language-reference/group-by-entity-sql.md)|Specifies groups into which objects that are returned by a query ([SELECT](../../../../../../docs/framework/data/adonet/ef/language-reference/select-entity-sql.md)) expression are to be placed.|  
|[GroupPartition](../../../../../../docs/framework/data/adonet/ef/language-reference/grouppartition-entity-sql.md)|Returns a collection of argument values, projected off the group partition to which the aggregate is related.|  
|[HAVING](../../../../../../docs/framework/data/adonet/ef/language-reference/having-entity-sql.md)|Specifies a search condition for a group or an aggregate.|  
|[LIMIT](../../../../../../docs/framework/data/adonet/ef/language-reference/limit-entity-sql.md)|Used with the [ORDER BY](../../../../../../docs/framework/data/adonet/ef/language-reference/order-by-entity-sql.md) clause to performed physical paging.|  
|[ORDER BY](../../../../../../docs/framework/data/adonet/ef/language-reference/order-by-entity-sql.md)|Specifies the sort order that is used on objects returned in a [SELECT](../../../../../../docs/framework/data/adonet/ef/language-reference/select-entity-sql.md) statement.|  
|[SELECT](../../../../../../docs/framework/data/adonet/ef/language-reference/select-entity-sql.md)|Specifies the elements in the projection that are returned by a query.|  
|[SKIP](../../../../../../docs/framework/data/adonet/ef/language-reference/skip-entity-sql.md)|Used with the [ORDER BY](../../../../../../docs/framework/data/adonet/ef/language-reference/order-by-entity-sql.md) clause to performed physical paging.|  
|[TOP](../../../../../../docs/framework/data/adonet/ef/language-reference/top-entity-sql.md)|Specifies that only the first set of rows will be returned from the query result.|  
|[WHERE](../../../../../../docs/framework/data/adonet/ef/language-reference/where-entity-sql.md)|Conditionally filters data that is returned by a query.|  
  
## Reference Operators  
 A reference is a logical pointer (foreign key) to a specific entity in a specific entity set. [!INCLUDE[esql](../../../../../../includes/esql-md.md)] supports the following operators to construct, deconstruct, and navigate through references.  
  
|Operator|Use|  
|--------------|---------|  
|[CREATEREF](../../../../../../docs/framework/data/adonet/ef/language-reference/createref-entity-sql.md)|Creates references to an entity in an entity set.|  
|[DEREF](../../../../../../docs/framework/data/adonet/ef/language-reference/deref-entity-sql.md)|Dereferences a reference value and produces the result of that dereference.|  
|[KEY](../../../../../../docs/framework/data/adonet/ef/language-reference/key-entity-sql.md)|Extracts the key of a reference or of an entity expression.|  
|[NAVIGATE](../../../../../../docs/framework/data/adonet/ef/language-reference/navigate-entity-sql.md)|Allows you to navigate over the relationship from one entity type to another|  
|[REF](../../../../../../docs/framework/data/adonet/ef/language-reference/ref-entity-sql.md)|Returns a reference to an entity instance.|  
  
## Set Operators  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] provides various powerful set operations. This includes set operators similar to Transact-SQL  operators such as UNION, INTERSECT, EXCEPT, and EXISTS. [!INCLUDE[esql](../../../../../../includes/esql-md.md)] also supports operators for duplicate elimination (SET), membership testing (IN), and joins (JOIN). The following table lists the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators.  
  
|Operator|Use|  
|--------------|---------|  
|[ANYELEMENT](../../../../../../docs/framework/data/adonet/ef/language-reference/anyelement-entity-sql.md)|Extracts an element from a multivalued collection.|  
|[EXCEPT](../../../../../../docs/framework/data/adonet/ef/language-reference/except-entity-sql.md)|Returns a collection of any distinct values from the query expression to the left of the EXCEPT operand that are not also returned from the query expression to the right of the EXCEPT operand.|  
|[&#91;NOT&#93; EXISTS](../../../../../../docs/framework/data/adonet/ef/language-reference/exists-entity-sql.md)|Determines if a collection is empty.|  
|[FLATTEN](../../../../../../docs/framework/data/adonet/ef/language-reference/flatten-entity-sql.md)|Converts a collection of collections into a flattened collection.|  
|[&#91;NOT&#93; IN](../../../../../../docs/framework/data/adonet/ef/language-reference/in-entity-sql.md)|Determines whether a value matches any value in a collection.|  
|[INTERSECT](../../../../../../docs/framework/data/adonet/ef/language-reference/intersect-entity-sql.md)|Returns a collection of any distinct values that are returned by both the query expressions on the left and right sides of the INTERSECT operand.|  
|[OVERLAPS](../../../../../../docs/framework/data/adonet/ef/language-reference/overlaps-entity-sql.md)|Determines whether two collections have common elements.|  
|[SET](../../../../../../docs/framework/data/adonet/ef/language-reference/set-entity-sql.md)|Used to convert a collection of objects into a set by yielding a new collection with all duplicate elements removed.|  
|[UNION](../../../../../../docs/framework/data/adonet/ef/language-reference/union-entity-sql.md)|Combines the results of two or more queries into a single collection.|  
  
## Type Operators  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] provides operations that allow the type of an expression (value) to be constructed, queried, and manipulated. The following table lists operators that are used to work with types.  
  
|Operator|Use|  
|--------------|---------|  
|[CAST](../../../../../../docs/framework/data/adonet/ef/language-reference/cast-entity-sql.md)|Converts an expression of one data type to another.|  
|[COLLECTION](../../../../../../docs/framework/data/adonet/ef/language-reference/collection-entity-sql.md)|Used in a [FUNCTION](../../../../../../docs/framework/data/adonet/ef/language-reference/function-entity-sql.md) operation to declare a collection of entity types or complex types.|  
|[IS &#91;NOT&#93; OF](../../../../../../docs/framework/data/adonet/ef/language-reference/isof-entity-sql.md)|Determines whether the type of an expression is of the specified type or one of its subtypes.|  
|[OFTYPE](../../../../../../docs/framework/data/adonet/ef/language-reference/oftype-entity-sql.md)|Returns a collection of objects from a query expression that is of a specific type.|  
|[Named Type Constructor](../../../../../../docs/framework/data/adonet/ef/language-reference/named-type-constructor-entity-sql.md)|Used to create instances of entity types or complex types.|  
|[MULTISET](../../../../../../docs/framework/data/adonet/ef/language-reference/multiset-entity-sql.md)|Creates an instance of a multiset from a list of values.|  
|[ROW](../../../../../../docs/framework/data/adonet/ef/language-reference/row-entity-sql.md)|Constructs anonymous, structurally typed records from one or more values.|  
|[TREAT](../../../../../../docs/framework/data/adonet/ef/language-reference/treat-entity-sql.md)|Treats an object of a particular base type as an object of the specified derived type.|  
  
## Other Operators  
 The following table lists other [!INCLUDE[esql](../../../../../../includes/esql-md.md)] operators.  
  
|Operator|Use|  
|--------------|---------|  
|[+ (String Concatenation)](../../../../../../docs/framework/data/adonet/ef/language-reference/string-concatenation-entity-sql.md)|Used to concatenate strings in [!INCLUDE[esql](../../../../../../includes/esql-md.md)].|  
|[. (Member Access)](../../../../../../docs/framework/data/adonet/ef/language-reference/member-access-entity-sql.md)|Used to access the value of a property or field of an instance of structural conceptual model type.|  
|[-- (Comment)](../../../../../../docs/framework/data/adonet/ef/language-reference/comment-entity-sql.md)|Include [!INCLUDE[esql](../../../../../../includes/esql-md.md)] comments.|  
|[FUNCTION](../../../../../../docs/framework/data/adonet/ef/language-reference/function-entity-sql.md)|Defines an inline function that can be executed in an Entity SQL query.|  
  
## See Also  
 [Entity SQL Language](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-language.md)
