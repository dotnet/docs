---
title: "Basic Data Types"
ms.date: "03/30/2017"
ms.assetid: eca2c472-9548-4800-bd31-5d8d9f11752b
---
# Basic Data Types
Because LINQ to SQL queries translate to Transact-SQL before they are executed on the Microsoft SQL Server. LINQ to SQL supports much of the same built-in functionality that SQL Server does for basic data types.  
  
## Casting  
 Implicit or explicit casts are enabled from a source CLR type to a target CLR type if there is a similar valid conversion within SQL Server. For more information about CLR casting, see [CType Function](../../../../../visual-basic/language-reference/functions/ctype-function.md) (Visual Basic) and [Type-testing and cast operators](../../../../../csharp/language-reference/operators/type-testing-and-cast.md). After conversion, casts change the behavior of operations performed on a CLR expression to match the behavior of other CLR expressions that naturally map to the destination type. Casts are also translatable in the context of inheritance mapping. Objects can be cast to more specific entity subtypes so that their subtype-specific data can be accessed.  
  
## Equality Operators  
 LINQ to SQL supports the following equality operators on basic data types inside LINQ to SQL queries:  
  
- Equal and Inequality Operator: Equality and inequality operators are supported for numeric, <xref:System.Boolean>, <xref:System.DateTime>, and <xref:System.TimeSpan> types. For more about Visual Basic operators `=` and `<>`, see [Comparison Operators](../../../../../visual-basic/language-reference/operators/comparison-operators.md). For more information about C# comparison operators `==` and `!=`, see [Equality operators](../../../../../csharp/language-reference/operators/equality-operators.md).
  
- Is operator: The `IS` operator has a supported translation when inheritance mapping is being used. It can be used instead of directly testing the discriminator column to determine whether an object is of a specific entity type, and is translated to a check on the discriminator column. For more information about the Visual Basic and C# Is operators, see [Is Operator](../../../../../visual-basic/language-reference/operators/is-operator.md) and [is](../../../../../csharp/language-reference/operators/type-testing-and-cast.md#is-operator).  
  
## See also

- [SQL-CLR Type Mapping](sql-clr-type-mapping.md)
- [Data Types and Functions](data-types-and-functions.md)
