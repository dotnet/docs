---
title: "Query Expression Syntax for Standard Query Operators (C#)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
ms.assetid: e1e17ef2-68ff-4c26-b6e2-015668227fa5
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Query Expression Syntax for Standard Query Operators (C#)
Some of the more frequently used standard query operators have dedicated C# language keyword syntax that enables them to be called as part of a *query expression*. A query expression is a different, more readable form of expressing a query than its *method-based*  equivalent. Query expression clauses are translated into calls to the query methods at compile time.  
  
## Query Expression Syntax Table  
 The following table lists the standard query operators that have equivalent query expression clauses.  
  
|Method|C# Query Expression Syntax|  
|------------|---------------------------------|  
|<xref:System.Linq.Enumerable.Cast*>|Use an explicitly typed range variable, for example:<br /><br /> `from int i in numbers`<br /><br /> (For more information, see [from clause](../keywords/from-clause--csharp-reference-.md).)|  
|<xref:System.Linq.Enumerable.GroupBy*>|`group … by`<br /><br /> -or-<br /><br /> `group … by … into …`<br /><br /> (For more information, see [group clause](../keywords/group-clause--csharp-reference-.md).)|  
|<xref:System.Linq.Enumerable.GroupJoin``4(System.Collections.Generic.IEnumerable{``0},System.Collections.Generic.IEnumerable{``1},System.Func{``0,``2},System.Func{``1,``2},System.Func{``0,System.Collections.Generic.IEnumerable{``1},``3})>|`join … in … on … equals … into …`<br /><br /> (For more information, see [join clause](../keywords/join-clause--csharp-reference-.md).)|  
|<xref:System.Linq.Enumerable.Join``4(System.Collections.Generic.IEnumerable{``0},System.Collections.Generic.IEnumerable{``1},System.Func{``0,``2},System.Func{``1,``2},System.Func{``0,``1,``3})>|`join … in … on … equals …`<br /><br /> (For more information, see [join clause](../keywords/join-clause--csharp-reference-.md).)|  
|<xref:System.Linq.Enumerable.OrderBy``2(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1})>|`orderby`<br /><br /> (For more information, see [orderby clause](../keywords/orderby-clause--csharp-reference-.md).)|  
<xref:System.Linq.Enumerable.OrderByDescending``2(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1})>|`orderby … descending`<br /><br /> (For more information, see [orderby clause](../keywords/orderby-clause--csharp-reference-.md).)|  
|<xref:System.Linq.Enumerable.Select*>|`select`<br /><br /> (For more information, see [select clause](../keywords/select-clause--csharp-reference-.md).)|  
|<xref:System.Linq.Enumerable.SelectMany*>|Multiple `from` clauses.<br /><br /> (For more information, see [from clause](../keywords/from-clause--csharp-reference-.md).)|  
|<xref:System.Linq.Enumerable.ThenBy``2(System.Linq.IOrderedEnumerable{``0},System.Func{``0,``1})>|`orderby …, …`<br /><br /> (For more information, see [orderby clause](../keywords/orderby-clause--csharp-reference-.md).)|  
|<xref:System.Linq.Enumerable.ThenByDescending``2(System.Linq.IOrderedEnumerable{``0},System.Func{``0,``1})>|`orderby …, … descending`<br /><br /> (For more information, see [orderby clause](../keywords/orderby-clause--csharp-reference-.md).)|  
|<xref:System.Linq.Enumerable.Where*>|`where`<br /><br /> (For more information, see [where clause](../keywords/where-clause--csharp-reference-.md).)|  
  
## See Also  
 <xref:System.Linq.Enumerable>   
 <xref:System.Linq.Queryable>   
 [Standard Query Operators Overview (C#)](../linq/standard-query-operators-overview--csharp-.md)   
 [Classification of Standard Query Operators by Manner of Execution (C#)](../linq/classification-of-standard-query-operators-by-manner-of-execution--csharp-.md)