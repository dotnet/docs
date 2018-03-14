---
title: "Standard Query Operators Overview (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 812fa119-5f65-4139-b4fa-55dccd8dc3ac
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Standard Query Operators Overview (C#)
The *standard query operators* are the methods that form the LINQ pattern. Most of these methods operate on sequences, where a sequence is an object whose type implements the <xref:System.Collections.Generic.IEnumerable%601> interface or the <xref:System.Linq.IQueryable%601> interface. The standard query operators provide query capabilities including filtering, projection, aggregation, sorting and more.  
  
 There are two sets of LINQ standard query operators, one that operates on objects of type <xref:System.Collections.Generic.IEnumerable%601> and the other that operates on objects of type <xref:System.Linq.IQueryable%601>. The methods that make up each set are static members of the <xref:System.Linq.Enumerable> and <xref:System.Linq.Queryable> classes, respectively. They are defined as *extension methods* of the type that they operate on. This means that they can be called by using either static method syntax or instance method syntax.  
  
 In addition, several standard query operator methods operate on types other than those based on <xref:System.Collections.Generic.IEnumerable%601> or <xref:System.Linq.IQueryable%601>. The <xref:System.Linq.Enumerable> type defines two such methods that both operate on objects of type <xref:System.Collections.IEnumerable>. These methods, <xref:System.Linq.Enumerable.Cast%60%601%28System.Collections.IEnumerable%29> and <xref:System.Linq.Enumerable.OfType%60%601%28System.Collections.IEnumerable%29>, let you enable a non-parameterized, or non-generic, collection to be queried in the LINQ pattern. They do this by creating a strongly-typed collection of objects. The <xref:System.Linq.Queryable> class defines two similar methods, <xref:System.Linq.Queryable.Cast%60%601%28System.Linq.IQueryable%29> and <xref:System.Linq.Queryable.OfType%60%601%28System.Linq.IQueryable%29>, that operate on objects of type <xref:System.Linq.Queryable>.  
  
 The standard query operators differ in the timing of their execution, depending on whether they return a singleton value or a sequence of values. Those methods that return a singleton value (for example, <xref:System.Linq.Enumerable.Average%2A> and <xref:System.Linq.Enumerable.Sum%2A>) execute immediately. Methods that return a sequence defer the query execution and return an enumerable object.  
  
 In the case of the methods that operate on in-memory collections, that is, those methods that extend <xref:System.Collections.Generic.IEnumerable%601>, the returned enumerable object captures the arguments that were passed to the method. When that object is enumerated, the logic of the query operator is employed and the query results are returned.  
  
 In contrast, methods that extend <xref:System.Linq.IQueryable%601> do not implement any querying behavior, but build an expression tree that represents the query to be performed. The query processing is handled by the source <xref:System.Linq.IQueryable%601> object.  
  
 Calls to query methods can be chained together in one query, which enables queries to become arbitrarily complex.  
  
 The following code example demonstrates how the standard query operators can be used to obtain information about a sequence.  
  
```csharp  
string sentence = "the quick brown fox jumps over the lazy dog";  
// Split the string into individual words to create a collection.  
string[] words = sentence.Split(' ');  
  
// Using query expression syntax.  
var query = from word in words  
            group word.ToUpper() by word.Length into gr  
            orderby gr.Key  
            select new { Length = gr.Key, Words = gr };  
  
// Using method-based query syntax.  
var query2 = words.  
    GroupBy(w => w.Length, w => w.ToUpper()).  
    Select(g => new { Length = g.Key, Words = g }).  
    OrderBy(o => o.Length);  
  
foreach (var obj in query)  
{  
    Console.WriteLine("Words of length {0}:", obj.Length);  
    foreach (string word in obj.Words)  
        Console.WriteLine(word);  
}  
  
// This code example produces the following output:  
//  
// Words of length 3:  
// THE  
// FOX  
// THE  
// DOG  
// Words of length 4:  
// OVER  
// LAZY  
// Words of length 5:  
// QUICK  
// BROWN  
// JUMPS   
```  
  
## Query Expression Syntax  
 Some of the more frequently used standard query operators have dedicated C# and Visual Basic language keyword syntax that enables them to be called as part of a *query* *expression*. For more information about standard query operators that have dedicated keywords and their corresponding syntaxes, see [Query Expression Syntax for Standard Query Operators (C#)](../../../../csharp/programming-guide/concepts/linq/query-expression-syntax-for-standard-query-operators.md).  
  
## Extending the Standard Query Operators  
 You can augment the set of standard query operators by creating domain-specific methods that are appropriate for your target domain or technology. You can also replace the standard query operators with your own implementations that provide additional services such as remote evaluation, query translation, and optimization. See <xref:System.Linq.Enumerable.AsEnumerable%2A> for an example.  
  
## Related Sections  
 The following links take you to topics that provide additional information about the various standard query operators based on functionality.  
  
 [Sorting Data (C#)](../../../../csharp/programming-guide/concepts/linq/sorting-data.md)  
  
 [Set Operations (C#)](../../../../csharp/programming-guide/concepts/linq/set-operations.md)  
  
 [Filtering Data (C#)](../../../../csharp/programming-guide/concepts/linq/filtering-data.md)  
  
 [Quantifier Operations (C#)](../../../../csharp/programming-guide/concepts/linq/quantifier-operations.md)  
  
 [Projection Operations (C#)](../../../../csharp/programming-guide/concepts/linq/projection-operations.md)  
  
 [Partitioning Data (C#)](../../../../csharp/programming-guide/concepts/linq/partitioning-data.md)  
  
 [Join Operations (C#)](../../../../csharp/programming-guide/concepts/linq/join-operations.md)  
  
 [Grouping Data (C#)](../../../../csharp/programming-guide/concepts/linq/grouping-data.md)  
  
 [Generation Operations (C#)](../../../../csharp/programming-guide/concepts/linq/generation-operations.md)  
  
 [Equality Operations (C#)](../../../../csharp/programming-guide/concepts/linq/equality-operations.md)  
  
 [Element Operations (C#)](../../../../csharp/programming-guide/concepts/linq/element-operations.md)  
  
 [Converting Data Types (C#)](../../../../csharp/programming-guide/concepts/linq/converting-data-types.md)  
  
 [Concatenation Operations (C#)](../../../../csharp/programming-guide/concepts/linq/concatenation-operations.md)  
  
 [Aggregation Operations (C#)](../../../../csharp/programming-guide/concepts/linq/aggregation-operations.md)  
  
## See Also  
 <xref:System.Linq.Enumerable>  
 <xref:System.Linq.Queryable>  
 [Introduction to LINQ Queries (C#)](../../../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md)  
 [Query Expression Syntax for Standard Query Operators (C#)](../../../../csharp/programming-guide/concepts/linq/query-expression-syntax-for-standard-query-operators.md)  
 [Classification of Standard Query Operators by Manner of Execution (C#)](../../../../csharp/programming-guide/concepts/linq/classification-of-standard-query-operators-by-manner-of-execution.md)  
 [Extension Methods](../../../../csharp/programming-guide/classes-and-structs/extension-methods.md)
