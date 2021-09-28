---
title: "Data Transformations with LINQ (C#)"
description: Learn how to use LINQ queries in C# to transform data. You can modify the sequence by sorting and grouping and create new types by using the select clause.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "LINQ [C#], data transformations"
  - "source elements [LINQ in C#]"
  - "joining multiple inputs [LINQ in C#]"
  - "multiple outputs for one output sequence [LINQ in C#]"
  - "subset of source elements [LINQ in C#]"
  - "data sources [LINQ in C#], data transformations"
  - "data transformations [LINQ in C#]"
ms.assetid: 674eae9e-bc72-4a88-aed3-802b45b25811
---
# Data Transformations with LINQ (C#)

Language-Integrated Query (LINQ) is not only about retrieving data. It is also a powerful tool for transforming data. By using a LINQ query, you can use a source sequence as input and modify it in many ways to create a new output sequence. You can modify the sequence itself without modifying the elements themselves by sorting and grouping. But perhaps the most powerful feature of LINQ queries is the ability to create new types. This is accomplished in the [select](../../../language-reference/keywords/select-clause.md) clause. For example, you can perform the following tasks:  
  
- Merge multiple input sequences into a single output sequence that has a new type.  
  
- Create output sequences whose elements consist of only one or several properties of each element in the source sequence.  
  
- Create output sequences whose elements consist of the results of operations performed on the source data.  
  
- Create output sequences in a different format. For example, you can transform data from SQL rows or text files into XML.  
  
 These are just several examples. Of course, these transformations can be combined in various ways in the same query. Furthermore, the output sequence of one query can be used as the input sequence for a new query.  
  
## Joining Multiple Inputs into One Output Sequence  

 You can use a LINQ query to create an output sequence that contains elements from more than one input sequence. The following example shows how to combine two in-memory data structures, but the same principles can be applied to combine data from XML or SQL or DataSet sources. Assume the following two class types:  
  
 [!code-csharp[CsLINQGettingStarted#7](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsLINQGettingStarted/CS/Class1.cs#7)]  
  
 The following example shows the query:  
  
 [!code-csharp[CSLinqGettingStarted#8](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsLINQGettingStarted/CS/Class1.cs#8)]  
  
 For more information, see [join clause](../../../language-reference/keywords/join-clause.md) and [select clause](../../../language-reference/keywords/select-clause.md).  
  
## Selecting a Subset of each Source Element  

 There are two primary ways to select a subset of each element in the source sequence:  
  
1. To select just one member of the source element, use the dot operation. In the following example, assume that a `Customer` object contains several public properties including a string named `City`. When executed, this query will produce an output sequence of strings.  
  
    ```csharp
    var query = from cust in Customers  
                select cust.City;  
    ```  
  
2. To create elements that contain more than one property from the source element, you can use an object initializer with either a named object or an anonymous type. The following example shows the use of an anonymous type to encapsulate two properties from each `Customer` element:  
  
    ```csharp
    var query = from cust in Customer  
                select new {Name = cust.Name, City = cust.City};  
    ```  
  
 For more information, see [Object and Collection Initializers](../../classes-and-structs/object-and-collection-initializers.md) and [Anonymous Types](../../../fundamentals/types/anonymous-types.md).  
  
## Transforming in-Memory Objects into XML  

 LINQ queries make it easy to transform data between in-memory data structures, SQL databases, ADO.NET Datasets and XML streams or documents. The following example transforms objects in an in-memory data structure into XML elements.  
  
 [!code-csharp[CsLINQGettingStarted#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsLINQGettingStarted/CS/Class1.cs#9)]  
  
 The code produces the following XML output:  
  
```xml  
<Root>  
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
  
 For more information, see [Creating XML Trees in C# (LINQ to XML)](../../../../standard/linq/create-xml-trees.md).  
  
## Performing Operations on Source Elements  

 An output sequence might not contain any elements or element properties from the source sequence. The output might instead be a sequence of values that is computed by using the source elements as input arguments.

 The following query will take a sequence of numbers that represent radii of circles, calculate the area for each radius, and return an output sequence containing strings formatted with the calculated area.

 Each string for the output sequence will be formatted using [string interpolation](../../../language-reference/tokens/interpolated.md). An interpolated string will have a `$` in front of the string's opening quotation mark, and operations can be performed within curly braces placed inside the interpolated string. Once those operations are performed, the results will be concatenated.
  
> [!NOTE]
> Calling methods in query expressions is not supported if the query will be translated into some other domain. For example, you cannot call an ordinary C# method in [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] because SQL Server has no context for it. However, you can map stored procedures to methods and call those. For more information, see [Stored Procedures](../../../../framework/data/adonet/sql/linq/stored-procedures.md).  
  
 [!code-csharp[CsLINQGettingStarted#10](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsLINQGettingStarted/CS/Class1.cs#10)]  
  
## See also

- [Language-Integrated Query (LINQ) (C#)](./index.md)
- [LINQ to SQL](../../../../framework/data/adonet/sql/linq/index.md)
- [LINQ to DataSet](../../../../framework/data/adonet/linq-to-dataset.md)
- [LINQ to XML (C#)](../../../../standard/linq/linq-xml-overview.md)
- [LINQ Query Expressions](../../../linq/index.md)
- [select clause](../../../language-reference/keywords/select-clause.md)
