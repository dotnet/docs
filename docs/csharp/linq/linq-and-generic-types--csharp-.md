---
title: "LINQ and Generic Types (C#)"
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
helpviewer_keywords: 
  - "LINQ [C#], generic types"
  - "generic types [LINQ]"
  - "generics [LINQ]"
ms.assetid: 660e3799-25ca-462c-8c4a-8bce04fbb031
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# LINQ and Generic Types (C#)
[!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] queries are based on generic types, which were introduced in version 2.0 of the [!INCLUDE[dnprdnshort](../classes-and-structs/includes/dnprdnshort_md.md)]. You do not need an in-depth knowledge of generics before you can start writing queries. However, you may want to understand two basic concepts:  
  
1.  When you create an instance of a generic collection class such as <xref:System.Collections.Generic.List`1>, you replace the "T" with the type of objects that the list will hold. For example, a list of strings is expressed as `List<string>`, and a list of `Customer` objects is expressed as `List<Customer>`. A generic list is strongly typed and provides many benefits over collections that store their elements as <xref:System.Object>. If you try to add a `Customer` to a `List<string>`, you will get an error at compile time. It is easy to use generic collections because you do not have to perform run-time type-casting.  
  
2.  <xref:System.Collections.Generic.IEnumerable`1> is the interface that enables generic collection classes to be enumerated by using the `foreach` statement. Generic collection classes support <xref:System.Collections.Generic.IEnumerable`1> just as non-generic collection classes such as <xref:System.Collections.ArrayList> support <xref:System.Collections.IEnumerable>.  
  
 For more information about generics, see [Generics](../generics/generics--csharp-programming-guide-.md).  
  
## IEnumerable<T\> variables in LINQ Queries  
 [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] query variables are typed as <xref:System.Collections.Generic.IEnumerable`1> or a derived type such as <xref:System.Linq.IQueryable`1>. When you see a query variable that is typed as `IEnumerable<Customer>`, it just means that the query, when it is executed, will produce a sequence of zero or more `Customer` objects.  
  
 [!code[csLINQGettingStarted#34](../linq/codesnippet/CSharp/linq-and-generic-types--csharp-_1.cs)]  
  
 For more information, see [Type Relationships in LINQ Query Operations](../linq/type-relationships-in-linq-query-operations--csharp-.md).  
  
## Letting the Compiler Handle Generic Type Declarations  
 If you prefer, you can avoid generic syntax by using the [var](../keywords/var--csharp-reference-.md) keyword. The `var` keyword instructs the compiler to infer the type of a query variable by looking at the data source specified in the `from` clause. The following example produces the same compiled code as the previous example:  
  
 [!code[csLINQGettingStarted#35](../linq/codesnippet/CSharp/linq-and-generic-types--csharp-_2.cs)]  
  
 The `var` keyword is useful when the type of the variable is obvious or when it is not that important to explicitly specify nested generic types such as those that are produced by group queries. In general, we recommend that if you use `var`, realize that it can make your code more difficult for others to read. For more information, see [Implicitly Typed Local Variables](../classes-and-structs/implicitly-typed-local-variables--csharp-programming-guide-.md).  
  
## See Also  
 [Getting Started with LINQ in C#](../linq/getting-started-with-linq-in-csharp.md)   
 [Generics](../generics/generics--csharp-programming-guide-.md)