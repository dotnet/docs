---
title: "Select Clause (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.QuerySelect"
helpviewer_keywords: 
  - "Select statement [Visual Basic]"
  - "Select clause [Visual Basic]"
  - "queries [Visual Basic], Select"
ms.assetid: 27a3f61c-5960-4692-9b91-4d0c4b6178fe
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
---
# Select Clause (Visual Basic)
Defines the result of a query.  
  
## Syntax  
  
```  
Select [ var1 = ] fieldName1 [, [ var2 = ] fieldName2 [...] ]  
```  
  
## Parts  
 `var1`  
 Optional. An alias that can be used to reference the results of the column expression.  
  
 `fieldName1`  
 Required. The name of the field to return in the query result.  
  
## Remarks  
 You can use the `Select` clause to define the results to return from a query. This enables you to either define the members of a new anonymous type that is created by a query, or to target the members of a named type that is returned by a query. The `Select` clause is not required for a query. If no `Select` clause is specified, the query will return a type based on all members of the range variables identified for the current scope. For more information, see [Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md). When a query creates a named type, it will return a result of type <xref:System.Collections.Generic.IEnumerable%601> where `T` is the created type.  
  
 The `Select` clause can reference any variables in the current scope. This includes range variables identified in the `From` clause (or `From` clauses). It also includes any new variables created with an alias by the `Aggregate`, `Let`, `Group By`, or `Group Join` clauses, or variables from a previous `Select` clause in the query expression. The `Select` clause can also include static values. For example, the following code example shows a query expression in which the `Select` clause defines the query result as a new anonymous type with four members: `ProductName`, `Price`, `Discount`, and `DiscountedPrice`. The `ProductName` and `Price` member values are taken from the product range variable that is defined in the `From` clause. The `DiscountedPrice` member value is calculated in the `Let` clause. The `Discount` member is a static value.  
  
 [!code-vb[VbSimpleQuerySamples#27](../../../visual-basic/language-reference/queries/codesnippet/VisualBasic/select-clause_1.vb)]  
  
 The `Select` clause introduces a new set of range variables for subsequent query clauses, and previous range variables are no longer in scope. The last `Select` clause in a query expression determines the return value of the query. For example, the following query returns the company name and order ID for every customer order for which the total exceeds 500. The first `Select` clause identifies the range variables for the `Where` clause and the second `Select` clause. The second `Select` clause identifies the values returned by the query as a new anonymous type.  
  
 [!code-vb[VbSimpleQuerySamples#28](../../../visual-basic/language-reference/queries/codesnippet/VisualBasic/select-clause_2.vb)]  
  
 If the `Select` clause identifies a single item to return, the query expression returns a collection of the type of that single item. If the `Select` clause identifies multiple items to return, the query expression returns a collection of a new anonymous type, based on the selected items. For example, the following two queries return collections of two different types based on the `Select` clause. The first query returns a collection of company names as strings. The second query returns a collection of `Customer` objects populated with the company names and address information.  
  
 [!code-vb[VbSimpleQuerySamples#29](../../../visual-basic/language-reference/queries/codesnippet/VisualBasic/select-clause_3.vb)]  
  
## Example  
 The following query expression uses a `From` clause to declare a range variable `cust` for the `customers` collection. The `Select` clause selects the customer name and ID value and populates the `CompanyName` and `CustomerID` columns of the new range variable. The `For Each` statement loops over each returned object and displays the `CompanyName` and `CustomerID` columns for each record.  
  
 [!code-vb[VbSimpleQuerySamples#30](../../../visual-basic/language-reference/queries/codesnippet/VisualBasic/select-clause_4.vb)]  
  
## See Also  
 [Introduction to LINQ in Visual Basic](../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)  
 [Queries](../../../visual-basic/language-reference/queries/queries.md)  
 [From Clause](../../../visual-basic/language-reference/queries/from-clause.md)  
 [Where Clause](../../../visual-basic/language-reference/queries/where-clause.md)  
 [Order By Clause](../../../visual-basic/language-reference/queries/order-by-clause.md)  
 [Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)
