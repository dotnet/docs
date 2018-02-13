---
title: Handle null values in query expressions
description: How to handle null values in query expressions.
keywords: .NET, .NET Core, C#
author: BillWagner
manager: wpickett
ms.author: wiwagn
ms.date: 12/1/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.assetid: ac63ae8b-724d-4251-9334-528f4e884ae7
---
# Handle null values in query expressions

This example shows how to handle possible null values in source collections. An object collection such as an <xref:System.Collections.Generic.IEnumerable%601> can contain elements whose value is [null](../language-reference/keywords/null.md). If a source collection is null or contains an element whose value is null, and your query does not handle null values, a <xref:System.NullReferenceException> will be thrown when you execute the query.  
  
## Example

 You can code defensively to avoid a null reference exception as shown in the following example:  
  
 [!code-csharp[csProgGuideLINQ#82](../../../samples/snippets/csharp/concepts/linq/how-to-handle-null-values-in-query-expressions_1.cs)]  
  
 In the previous example, the `where` clause filters out all null elements in the categories sequence. This technique is independent of the null check in the join clause. The conditional expression with null in this example works because `Products.CategoryID` is of type `int?` which is shorthand for `Nullable<int>`.  
  
## Example

 In a join clause, if only one of the comparison keys is a nullable value type, you can cast the other to a nullable type in the query expression. In the following example, assume that `EmployeeID` is a column that contains values of type `int?`:  
  
 [!code-csharp[csProgGuideLINQ#83](../../../samples/snippets/csharp/concepts/linq/how-to-handle-null-values-in-query-expressions_2.cs)]  
  
## See also  
 <xref:System.Nullable%601>  
 [LINQ query expressions](index.md)  
 [Nullable types](../programming-guide/nullable-types/index.md)
