---
title: "Query Expression Basics (C# Programming Guide) | Microsoft Docs"
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
  - "query expressions [LINQ in C#], query execution"
  - "query expressions [LINQ in C#], basics"
  - "queries [LINQ in C#], basics"
ms.assetid: d3e1f4e6-1cf0-4066-87e3-1a42387223a6
caps.latest.revision: 32
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# Query Expression Basics (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

## What Is a Query and What Does It Do?  
 A *query* is a set of instructions that describes what data to retrieve from a given data source (or sources) and what shape and organization the returned data should have. A query is distinct from the results that it produces.  
  
 Generally, the source data is organized logically as a sequence of elements of the same kind. A SQL database table contains a sequence of rows. Similarly, an [!INCLUDE[vstecado](../../../includes/vstecado-md.md)] <xref:System.Data.DataTable> contains a sequence of <xref:System.Data.DataRow> objects. In an XML file, there is a "sequence" of XML elements (although these are organized hierarchically in a tree structure). An in-memory collection contains a sequence of objects.  
  
 From an application's viewpoint, the specific type and structure of the original source data is not important. The application always sees the source data as an <xref:System.Collections.Generic.IEnumerable%601> or <xref:System.Linq.IQueryable%601> collection. In [!INCLUDE[sqltecxlinq](../../../includes/sqltecxlinq-md.md)], the source data is made visible as an `IEnumerable`\<<xref:System.Xml.Linq.XElement>>. In [!INCLUDE[linq_dataset](../../../includes/linq-dataset-md.md)], it is an `IEnumerable`\<<xref:System.Data.DataRow>>. In [!INCLUDE[vbtecdlinq](../../../includes/vbtecdlinq-md.md)], it is an `IEnumerable` or `IQueryable` of whatever custom objects you have defined to represent the data in the SQL table.  
  
 Given this source sequence, a query may do one of three things:  
  
-   Retrieve a subset of the elements to produce a new sequence without modifying the individual elements. The query may then sort or group the returned sequence in various ways, as shown in the following example (assume `scores` is an `int[]`):  
  
     [!code-csharp[csrefQueryExpBasics#45](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#45)]  
  
-   Retrieve a sequence of elements as in the previous example but transform them to a new type of object. For example, a query may retrieve only the last names from certain customer records in a data source. Or it may retrieve the complete record and then use it to construct another in-memory object type or even XML data before generating the final result sequence. The following example shows a transform from an `int` to a `string`. Note the new type of `highScoresQuery`.  
  
     [!code-csharp[csrefQueryExpBasics#46](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#46)]  
  
-   Retrieve a singleton value about the source data, such as:  
  
    -   The number of elements that match a certain condition.  
  
    -   The element that has the greatest or least value.  
  
    -   The first element that matches a condition, or the sum of particular values in a specified set of elements. For example, the following query returns the number of scores greater than 80 from the `scores` integer array:  
  
     [!code-csharp[csrefQueryExpBasics#47](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#47)]  
  
     In the previous example, note the use of parentheses around the query expression before the call to the `Count` method. You can also express this by using a new variable to store the concrete result. This technique is more readable because it keeps the variable that store the query separate from the query that stores a result.  
  
     [!code-csharp[csrefQueryExpBasics#48](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#48)]  
  
 In the previous example, the query is executed in the call to `Count`, because `Count` must iterate over the results in order to determine the number of elements returned by `highScoresQuery`.  
  
## What Is a Query Expression?  
 A *query expression* is a query expressed in query syntax. A query expression is a first-class language construct. It is just like any other expression and can be used in any context in which a C# expression is valid. A query expression consists of a set of clauses written in a declarative syntax similar to SQL or XQuery. Each clause in turn contains one or more C# expressions, and these expressions may themselves be either a query expression or contain a query expression.  
  
 A query expression must begin with a [from](../../../csharp/language-reference/keywords/from-clause.md) clause and must end with a [select](../../../csharp/language-reference/keywords/select-clause.md) or [group](../../../csharp/language-reference/keywords/group-clause.md) clause. Between the first `from` clause and the last `select` or `group` clause, it can contain one or more of these optional clauses: [where](../../../csharp/language-reference/keywords/where-clause.md), [orderby](../../../csharp/language-reference/keywords/orderby-clause.md), [join](../../../csharp/language-reference/keywords/join-clause.md), [let](../../../csharp/language-reference/keywords/let-clause.md) and even additional [from](../../../csharp/language-reference/keywords/from-clause.md) clauses. You can also use the [into](../../../csharp/language-reference/keywords/into.md) keyword to enable the result of a `join` or `group` clause to serve as the source for additional query clauses in the same query expression.  
  
### Query Variable  
 In [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)], a query variable is any variable that stores a *query* instead of the *results* of a query. More specifically, a query variable is always an enumerable type that will produce a sequence of elements when it is iterated over in a `foreach` statement or a direct call to its `IEnumerator.MoveNext` method.  
  
 The following code example shows a simple query expression with one data source, one filtering clause, one ordering clause, and no transformation of the source elements. The `select` clause ends the query.  
  
 [!code-csharp[csrefQueryExpBasics#49](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#49)]  
  
 In the previous example, `scoreQuery` is a *query variable,* which is sometimes referred to as just a *query*. The query variable stores no actual result data, which is produced in the `foreach` loop. And when the `foreach` statement executes, the query results are not returned through the query variable `scoreQuery`. Rather, they are returned through the iteration variable `testScore`. The `scoreQuery` variable can be iterated in a second `foreach` loop. It will produce the same results as long as neither it nor the data source has been modified.  
  
 A query variable may store a query that is expressed in query syntax or method syntax, or a combination of the two. In the following examples, both `queryMajorCities` and `queryMajorCities2` are query variables:  
  
 [!code-csharp[csrefQueryExpBasics#50](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#50)]  
  
 On the other hand, the following two examples show variables that are not query variables even through each is initialized with a query. They are not query variables because they store results:  
  
 [!code-csharp[csrefQueryExpBasics#51](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#51)]  
  
> [!NOTE]
>  In the [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)] documentation, variables that store a query have the word "query" as part of their names. Variables that store an actual result do not have "query" in their names.  
  
 For more information about the different ways to express queries, see [Query Syntax and Method Syntax in LINQ](../../../csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq.md).  
  
#### Explicit and Implicit Typing of Query Variables  
 This documentation usually provides the explicit type of the query variable in order to show the type relationship between the query variable and the [select clause](../../../csharp/language-reference/keywords/select-clause.md). However, you can also use the [var](../../../csharp/language-reference/keywords/var.md) keyword to instruct the compiler to infer the type of a query variable (or any other local variable) at compile time. For example, the query example that was shown previously in this topic can also be expressed by using implicit typing:  
  
 [!code-csharp[csrefQueryExpBasics#52](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#52)]  
  
 For more information, see [Implicitly Typed Local Variables](../../../csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables.md) and [Type Relationships in LINQ Query Operations](../../../csharp/programming-guide/concepts/linq/type-relationships-in-linq-query-operations.md).  
  
### Starting a Query Expression  
 A query expression must begin with a `from` clause. It specifies a data source together with a range variable. The range variable represents each successive element in the source sequence as the source sequence is being traversed. The range variable is strongly typed based on the type of elements in the data source. In the following example, because `countries` is an array of `Country` objects, the range variable is also typed as `Country`. Because the range variable is strongly typed, you can use the dot operator to access any available members of the type.  
  
 [!code-csharp[csrefQueryExpBasics#53](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#53)]  
  
 The range variable is in scope until the query is exited either with a semicolon or with a *continuation* clause.  
  
 A query expression may contain multiple `from` clauses. Use additional `from` clauses when each element in the source sequence is itself a collection or contains a collection. For example, assume that you have a collection of `Country` objects, each of which contains a collection of `City` objects named `Cities`. To query the `City` objects in each `Country`, use two `from` clauses as shown here:  
  
 [!code-csharp[csrefQueryExpBasics#54](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#54)]  
  
 For more information, see [from clause](../../../csharp/language-reference/keywords/from-clause.md).  
  
### Ending a Query Expression  
 A query expression must end with either a `select` clause or a `group` clause.  
  
#### group Clause  
 Use the `group` clause to produce a sequence of groups organized by a key that you specify. The key can be any data type. For example, the following query creates a sequence of groups that contains one or more `Country` objects and whose key is a `char` value.  
  
 [!code-csharp[csrefQueryExpBasics#55](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#55)]  
  
 For more information about grouping, see [group clause](../../../csharp/language-reference/keywords/group-clause.md).  
  
#### select Clause  
 Use the `select` clause to produce all other types of sequences. A simple `select` clause just produces a sequence of the same type of objects as the objects that are contained in the data source. In this example, the data source contains `Country` objects. The `orderby` clause just sorts the elements into a new order and the `select` clause produces a sequence of the reordered `Country` objects.  
  
 [!code-csharp[csrefQueryExpBasics#56](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#56)]  
  
 The `select` clause can be used to transform source data into sequences of new types. This transformation is also named a *projection*. In the following example, the `select` clause *projects* a sequence of anonymous types which contains only a subset of the fields in the original element. Note that the new objects are initialized by using an object initializer.  
  
 [!code-csharp[csrefQueryExpBasics#57](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#57)]  
  
 For more information about all the ways that a `select` clause can be used to transform source data, see [select clause](../../../csharp/language-reference/keywords/select-clause.md).  
  
#### Continuations with "into"  
 You can use the `into` keyword in a `select` or `group` clause to create a temporary identifier that stores a query. Do this when you must perform additional query operations on a query after a grouping or select operation. In the following example `countries` are grouped according to population in ranges of 10 million. After these groups are created, additional clauses filter out some groups, and then to sort the groups in ascending order. To perform those additional operations, the continuation represented by `countryGroup` is required.  
  
 [!code-csharp[csrefQueryExpBasics#58](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#58)]  
  
 For more information, see [into](../../../csharp/language-reference/keywords/into.md).  
  
### Filtering, Ordering, and Joining  
 Between the starting `from` clause, and the ending `select` or `group` clause, all other clauses (`where`, `join`, `orderby`, `from`, `let`) are optional. Any of the optional clauses may be used zero times or multiple times in a query body.  
  
#### where Clause  
 Use the `where` clause to filter out elements from the source data based on one or more predicate expressions. The `where` clause in the following example has two predicates.  
  
 [!code-csharp[csrefQueryExpBasics#59](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#59)]  
  
 For more information, see [where clause](../../../csharp/language-reference/keywords/where-clause.md).  
  
#### orderby Clause  
 Use the `orderby` clause to sort the results in either ascending or descending order. You can also specify secondary sort orders. The following example performs a primary sort on the `country` objects by using the `Area` property. It then performs a secondary sort by using the `Population` property.  
  
 [!code-csharp[csrefQueryExpBasics#60](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#60)]  
  
 The `ascending` keyword is optional; it is the default sort order if no order is specified. For more information, see [orderby clause](../../../csharp/language-reference/keywords/orderby-clause.md).  
  
#### join Clause  
 Use the `join` clause to associate and/or combine elements from one data source with elements from another data source based on an equality comparison between specified keys in each element. In [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)], join operations are performed on sequences of objects whose elements are different types. After you have joined two sequences, you must use a `select` or `group` statement to specify which element to store in the output sequence. You can also use an anonymous type to combine properties from each set of associated elements into a new type for the output sequence. The following example associates `prod` objects whose `Category` property matches one of the categories in the `categories` string array. Products whose `Category` does not match any string in `categories` are filtered out. The `select` statement projects a new type whose properties are taken from both `cat` and `prod`.  
  
 [!code-csharp[csrefQueryExpBasics#61](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#61)]  
  
 You can also perform a group join by storing the results of the `join` operation into a temporary variable by using the [into](../../../csharp/language-reference/keywords/into.md) keyword. For more information, see [join clause](../../../csharp/language-reference/keywords/join-clause.md).  
  
#### let Clause  
 Use the `let` clause to store the result of an expression, such as a method call, in a new range variable. In the following example, the range variable `firstName` stores the first element of the array of strings that is returned by `Split`.  
  
 [!code-csharp[csrefQueryExpBasics#62](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#62)]  
  
 For more information, see [let clause](../../../csharp/language-reference/keywords/let-clause.md).  
  
### Subqueries in a Query Expression  
 A query clause may itself contain a query expression, which is sometimes referred to as a *subquery*. Each subquery starts with its own `from` clause that does not necessarily point to the same data source in the first `from` clause. For example, the following query shows a query expression that is used in the select statement to retrieve the results of a grouping operation.  
  
 [!code-csharp[csrefQueryExpBasics#63](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefQueryExpBasics/CS/QEbasics.cs#63)]  
  
 For more information, see [How to: Perform a Subquery on a Grouping Operation](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-a-subquery-on-a-grouping-operation.md).  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)   
 [LINQ (Language-Integrated Query)](../Topic/LINQ%20\(Language-Integrated%20Query\).md)   
 [Query Keywords (LINQ)](../../../csharp/language-reference/keywords/query-keywords.md)   
 [Standard Query Operators Overview](../Topic/Standard%20Query%20Operators%20Overview.md)