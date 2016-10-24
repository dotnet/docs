---
title: "Data Transformations with LINQ (C#)"
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
  - "LINQ [C#], data transformations"
  - "source elements [LINQ in C#]"
  - "joining multiple inputs [LINQ in C#]"
  - "multiple outputs for one output sequence [LINQ in C#]"
  - "subset of source elements [LINQ in C#]"
  - "data sources [LINQ in C#], data transformations"
  - "data transformations [LINQ in C#]"
ms.assetid: 674eae9e-bc72-4a88-aed3-802b45b25811
caps.latest.revision: 17
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
# Data Transformations with LINQ (C#)
[!INCLUDE[vbteclinqext](../getting-started/includes/vbteclinqext_md.md)] is not only about retrieving data. It is also a powerful tool for transforming data. By using a [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] query, you can use a source sequence as input and modify it in many ways to create a new output sequence. You can modify the sequence itself without modifying the elements themselves by sorting and grouping. But perhaps the most powerful feature of [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] queries is the ability to create new types. This is accomplished in the [select](../keywords/select-clause--csharp-reference-.md) clause. For example, you can perform the following tasks:  
  
-   Merge multiple input sequences into a single output sequence that has a new type.  
  
-   Create output sequences whose elements consist of only one or several properties of each element in the source sequence.  
  
-   Create output sequences whose elements consist of the results of operations performed on the source data.  
  
-   Create output sequences in a different format. For example, you can transform data from SQL rows or text files into XML.  
  
 These are just several examples. Of course, these transformations can be combined in various ways in the same query. Furthermore, the output sequence of one query can be used as the input sequence for a new query.  
  
## Joining Multiple Inputs into One Output Sequence  
 You can use a [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] query to create an output sequence that contains elements from more than one input sequence. The following example shows how to combine two in-memory data structures, but the same principles can be applied to combine data from XML or SQL or DataSet sources. Assume the following two class types:  
  
 [!code[CsLINQGettingStarted#7](../linq/codesnippet/CSharp/data-transformations-with-linq--csharp-_1.cs)]  
  
 The following example shows the query:  
  
 [!code[CSLinqGettingStarted#8](../linq/codesnippet/CSharp/data-transformations-with-linq--csharp-_2.cs)]  
  
 For more information, see [join clause](../keywords/join-clause--csharp-reference-.md) and [select clause](../keywords/select-clause--csharp-reference-.md).  
  
## Selecting a Subset of each Source Element  
 There are two primary ways to select a subset of each element in the source sequence:  
  
1.  To select just one member of the source element, use the dot operation. In the following example, assume that a `Customer` object contains several public properties including a string named `City`. When executed, this query will produce an output sequence of strings.  
  
    ```  
    var query = from cust in Customers  
                select cust.City;  
    ```  
  
2.  To create elements that contain more than one property from the source element, you can use an object initializer with either a named object or an anonymous type. The following example shows the use of an anonymous type to encapsulate two properties from each `Customer` element:  
  
    ```  
    var query = from cust in Customer  
                select new {Name = cust.Name, City = cust.City};  
    ```  
  
 For more information, see [Object and Collection Initializers](../classes-and-structs/object-and-collection-initializers--csharp-programming-guide-.md) and [Anonymous Types](../classes-and-structs/anonymous-types--csharp-programming-guide-.md).  
  
## Transforming in-Memory Objects into XML  
 [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] queries make it easy to transform data between in-memory data structures, SQL databases, [!INCLUDE[vstecado](../linq/includes/vstecado_md.md)] Datasets and XML streams or documents. The following example transforms objects in an in-memory data structure into XML elements.  
  
 [!code[CsLINQGettingStarted#9](../linq/codesnippet/CSharp/data-transformations-with-linq--csharp-_3.cs)]  
  
 The code produces the following XML output:  
  
```  
< Root>  
  <student>  
    <First>Svetlana</First>  
    <Last>Omelchenko</Last>  
    <Scores>97,92,81,60</Scores>  
  </student>  
  <student>  
    <First>Claire</First>  
    <Last>O'Donnell</Last>  
    <Scores>75,84,91,39</Scores>  
  </student>  
  <student>  
    <First>Sven</First>  
    <Last>Mortensen</Last>  
    <Scores>88,94,65,91</Scores>  
  </student>  
</Root>  
```  
  
 For more information, see [Creating XML Trees in C# (LINQ to XML)](../linq/creating-xml-trees-in-csharp--linq-to-xml-2.md).  
  
## Performing Operations on Source Elements  
 An output sequence might not contain any elements or element properties from the source sequence. The output might instead be a sequence of values that is computed by using the source elements as input arguments. The following simple query, when it is executed, outputs a sequence of strings whose values represent a calculation based on the source sequence of elements of type `double`.  
  
> [!NOTE]
>  Calling methods in query expressions is not supported if the query will be translated into some other domain. For example, you cannot call an ordinary C# method in [!INCLUDE[vbtecdlinq](../keywords/includes/vbtecdlinq_md.md)] because SQL Server has no context for it. However, you can map stored procedures to methods and call those. For more information, see [Stored Procedures](../Topic/Stored%20Procedures.md).  
  
 [!code[CsLINQGettingStarted#10](../linq/codesnippet/CSharp/data-transformations-with-linq--csharp-_4.cs)]  
  
## See Also  
 [Language-Integrated Query (LINQ) (C#)](../linq/language-integrated-query--linq---csharp-.md)   
 [LINQ to SQL](../Topic/LINQ%20to%20SQL.md)   
 [LINQ to DataSet](../Topic/LINQ%20to%20DataSet.md)   
 [LINQ to XML (C#)](../linq/linq-to-xml--csharp-.md)   
 [LINQ Query Expressions](../linq-query-expressions/linq-query-expressions--csharp-programming-guide-.md)   
 [select clause](../keywords/select-clause--csharp-reference-.md)