---
title: "How to use lambda expressions in a query - C# Programming Guide"
description: Learn how to use lambda expressions in a query. See code examples and view additional available resources.
ms.topic: how-to
ms.date: 07/20/2015
helpviewer_keywords: 
  - "lambda expressions [C#], in LINQ"
ms.assetid: 3cac4d25-d11f-4abd-9e7c-0f02e97ae06d
---
# How to use lambda expressions in a query (C# Programming Guide)

You do not use lambda expressions directly in query syntax, but you do use them in method calls, and query expressions can contain method calls. In fact, some query operations can only be expressed in method syntax. For more information about the difference between query syntax and method syntax, see [Query Syntax and Method Syntax in LINQ](../concepts/linq/query-syntax-and-method-syntax-in-linq.md).  
  
## Examples

 The following example demonstrates how to use a lambda expression in a method-based query by using the <xref:System.Linq.Enumerable.Where%2A?displayProperty=nameWithType> standard query operator. Note that the <xref:System.Linq.Enumerable.Where%2A> method in this example has an input parameter of the delegate type <xref:System.Func%602> and that delegate takes an integer as input and returns a Boolean. The lambda expression can be converted to that delegate. If this were a [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] query that used the <xref:System.Linq.Queryable.Where%2A?displayProperty=nameWithType> method, the parameter type would be an `Expression<Func<int,bool>>` but the lambda expression would look exactly the same. For more information on the Expression type, see <xref:System.Linq.Expressions.Expression?displayProperty=nameWithType>.  
  
 [!code-csharp[csProgGuideLINQ#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csrefLINQHowTos.cs#1)]  
  
 The following example demonstrates how to use a lambda expression in a method call of a query expression. The lambda is necessary because the <xref:System.Linq.Enumerable.Sum%2A> standard query operator cannot be invoked by using query syntax.  
  
 The query first groups the students according to their grade level, as defined in the `GradeLevel` enum. Then for each group it adds the total scores for each student. This requires two `Sum` operations. The inner `Sum` calculates the total score for each student, and the outer `Sum` keeps a running, combined total for all students in the group.  
  
 [!code-csharp[csProgGuideLINQ#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csrefLINQHowTos.cs#2)]  
  
## Compiling the Code  

 To run this code, copy and paste the method into the `StudentClass` that is provided in [Query a collection of objects](../../linq/query-a-collection-of-objects.md) and call it from the `Main` method.
  
## See also

- [Lambda Expressions](../../language-reference/operators/lambda-expressions.md)
- [Expression Trees (C#)](../concepts/expression-trees/index.md)
