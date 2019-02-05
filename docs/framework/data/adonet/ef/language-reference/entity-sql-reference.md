---
title: "Entity SQL reference"
ms.date: "03/30/2017"
ms.assetid: 61ce7ee1-ffe2-477d-8a9f-835b0a11d900
---
# Entity SQL reference

This section contains Entity SQL reference articles. This article summarizes and groups the Entity SQL operators by category.

## Arithmetic operators

Arithmetic operators perform mathematical operations on two expressions of one or more numeric data types. The following table lists the Entity SQL arithmetic operators:

|Operator|Use|
|--------------|---------|
|[+ (Add)](add.md)|Addition.|
|[/ (Divide)](divide-entity-sql.md)|Division.|
|[% (Modulo)](modulo-entity-sql.md)|Returns the remainder of a division.|
|[* (Multiply)](multiply-entity-sql.md)|Multiplication.|
|[- (Negative)](negative-entity-sql.md)|Negation.|
|[- (Subtract)](subtract-entity-sql.md)|Subtraction.|

## Canonical functions

Canonical functions are supported by all data providers and can be used by all querying technologies. The following table lists the canonical functions:

|Function|Type|
|--------------|----------|
|[Aggregate Entity SQL Canonical Functions](aggregate-canonical-functions.md)|Discusses aggregate Entity SQL canonical functions.|
|[Math Canonical Functions](math-canonical-functions.md)|Discusses math Entity SQL canonical functions.|
|[String Canonical Functions](string-canonical-functions.md)|Discusses string Entity SQL canonical functions.|
|[Date and Time Canonical Functions](date-and-time-canonical-functions.md)|Discusses date and time Entity SQL canonical functions.|
|[Bitwise Canonical Functions](bitwise-canonical-functions.md)|Discusses bitwise Entity SQL canonical functions.|
|[Other Canonical Functions](other-canonical-functions.md)|Discusses functions not classified as bitwise, date/time, string, math, or aggregate.|

## Comparison operators

Comparison operators are defined for the following types: `Byte`, `Int16`, `Int32`, `Int64`, `Double`, `Single`, `Decimal`, `String`, `DateTime`, `Date`, `Time`, `DateTimeOffset`. Implicit type promotion occurs for the operands before the comparison operator is applied. Comparison operators always yield Boolean values. When at least one of the operands is `null`, the result is `null`.

Equality and inequality are defined for any object type that has identity, such as the `Boolean` type. Non-primitive objects with identity are considered equal if they share the same identity. The following table lists the Entity SQL comparison operators:

|Operator|Description|
|--------------|-----------------|
|[= (Equals)](equals-entity-sql.md)|Compares the equality of two expressions.|
|[> (Greater Than)](greater-than-entity-sql.md)|Compares two expressions to determine whether the left expression has a value greater than the right expression.|
|[>= (Greater Than or Equal To)](greater-than-or-equal-to-entity-sql.md)|Compares two expressions to determine whether the left expression has a value greater than or equal to the right expression.|
|[IS \[NOT\] NULL](isnull-entity-sql.md)|Determines if a query expression is null.|
|[< (Less Than)](less-than-entity-sql.md)|Compares two expressions to determine whether the left expression has a value less than the right expression.|
|[<= (Less Than or Equal To)](less-than-or-equal-to-entity-sql.md)|Compares two expressions to determine whether the left expression has a value less than or equal to the right expression.|
|[\[NOT\] BETWEEN](between-entity-sql.md)|Determines whether an expression results in a value in a specified range.|
|[\!= (Not Equal To)](not-equal-to-entity-sql.md)|Compares two expressions to determine whether the left expression isn't equal to the right expression.|
|[\[NOT\] LIKE](like-entity-sql.md)|Determines whether a specific character string matches a specified pattern.|

## Logical and case expression operators

Logical operators test for the truth of a condition. The CASE expression evaluates a set of Boolean expressions to determine the result. The following table lists the logical and CASE expression operators:

|Operator|Description|
|--------------|-----------------|
|[&& (Logical AND)](and-entity-sql.md)|Logical AND.|
|[\! (Logical NOT)](not-entity-sql.md)|Logical NOT.|
|[&#124;&#124; (Logical OR)](or-entity-sql.md)|Logical OR.|
|[CASE](case-entity-sql.md)|Evaluates a set of Boolean expressions to determine the result.|
|[THEN](then-entity-sql.md)|The result of a [WHEN](https://msdn.microsoft.com/library/6233fe9f-00b0-460e-8372-64e138a5f998) clause when it evaluates to true.|

## Query operators

Query operators are used to define query expressions that return entity data. The following table lists query operators:

|Operator|Use|
|--------------|---------|
|[FROM](from-entity-sql.md)|Specifies the collection that is used in [SELECT](select-entity-sql.md) statements.|
|[GROUP BY](group-by-entity-sql.md)|Specifies groups into which objects that are returned by a query ([SELECT](select-entity-sql.md)) expression are to be placed.|
|[GroupPartition](grouppartition-entity-sql.md)|Returns a collection of argument values, projected off the group partition to which the aggregate is related.|
|[HAVING](having-entity-sql.md)|Specifies a search condition for a group or an aggregate.|
|[LIMIT](limit-entity-sql.md)|Used with the [ORDER BY](order-by-entity-sql.md) clause to performed physical paging.|
|[ORDER BY](order-by-entity-sql.md)|Specifies the sort order that is used on objects returned in a [SELECT](select-entity-sql.md) statement.|
|[SELECT](select-entity-sql.md)|Specifies the elements in the projection that are returned by a query.|
|[SKIP](skip-entity-sql.md)|Used with the [ORDER BY](order-by-entity-sql.md) clause to performed physical paging.|
|[TOP](top-entity-sql.md)|Specifies that only the first set of rows will be returned from the query result.|
|[WHERE](where-entity-sql.md)|Conditionally filters data that is returned by a query.|

## Reference operators

A reference is a logical pointer (foreign key) to a specific entity in a specific entity set. Entity SQL supports the following operators to construct, deconstruct, and navigate through references:

|Operator|Use|
|--------------|---------|
|[CREATEREF](createref-entity-sql.md)|Creates references to an entity in an entity set.|
|[DEREF](deref-entity-sql.md)|Dereferences a reference value and produces the result of that dereference.|
|[KEY](key-entity-sql.md)|Extracts the key of a reference or of an entity expression.|
|[NAVIGATE](navigate-entity-sql.md)|Allows you to navigate over the relationship from one entity type to another|
|[REF](ref-entity-sql.md)|Returns a reference to an entity instance.|

## Set operators

Entity SQL provides various powerful set operations. This includes set operators similar to Transact-SQL operators such as UNION, INTERSECT, EXCEPT, and EXISTS. Entity SQL also supports operators for duplicate elimination (SET), membership testing (IN), and joins (JOIN). The following table lists the Entity SQL set operators:

|Operator|Use|
|--------------|---------|
|[ANYELEMENT](anyelement-entity-sql.md)|Extracts an element from a multivalued collection.|
|[EXCEPT](except-entity-sql.md)|Returns a collection of any distinct values from the query expression to the left of the EXCEPT operand that aren't also returned from the query expression to the right of the EXCEPT operand.|
|[\[NOT\] EXISTS](exists-entity-sql.md)|Determines if a collection is empty.|
|[FLATTEN](flatten-entity-sql.md)|Converts a collection of collections into a flattened collection.|
|[\[NOT\] IN](in-entity-sql.md)|Determines whether a value matches any value in a collection.|
|[INTERSECT](intersect-entity-sql.md)|Returns a collection of any distinct values that are returned by both the query expressions on the left and right sides of the INTERSECT operand.|
|[OVERLAPS](overlaps-entity-sql.md)|Determines whether two collections have common elements.|
|[SET](set-entity-sql.md)|Used to convert a collection of objects into a set by yielding a new collection with all duplicate elements removed.|
|[UNION](union-entity-sql.md)|Combines the results of two or more queries into a single collection.|

## Type operators

Entity SQL provides operations that allow the type of an expression (value) to be constructed, queried, and manipulated. The following table lists operators that are used to work with types:

|Operator|Use|
|--------------|---------|
|[CAST](cast-entity-sql.md)|Converts an expression of one data type to another.|
|[COLLECTION](collection-entity-sql.md)|Used in a [FUNCTION](function-entity-sql.md) operation to declare a collection of entity types or complex types.|
|[IS \[NOT\] OF](isof-entity-sql.md)|Determines whether the type of an expression is of the specified type or one of its subtypes.|
|[OFTYPE](oftype-entity-sql.md)|Returns a collection of objects from a query expression that is of a specific type.|
|[Named Type Constructor](named-type-constructor-entity-sql.md)|Used to create instances of entity types or complex types.|
|[MULTISET](multiset-entity-sql.md)|Creates an instance of a multiset from a list of values.|
|[ROW](row-entity-sql.md)|Constructs anonymous, structurally typed records from one or more values.|
|[TREAT](treat-entity-sql.md)|Treats an object of a particular base type as an object of the specified derived type.|

## Other operators

The following table lists other Entity SQL operators:

|Operator|Use|
|--------------|---------|
|[+ (String Concatenation)](string-concatenation-entity-sql.md)|Used to concatenate strings in Entity SQL.|
|[. (Member Access)](member-access-entity-sql.md)|Used to access the value of a property or field of an instance of structural conceptual model type.|
|[-- (Comment)](comment-entity-sql.md)|Include Entity SQL comments.|
|[FUNCTION](function-entity-sql.md)|Defines an inline function that can be executed in an Entity SQL query.|

## See also

- [Entity SQL Language](entity-sql-language.md)
