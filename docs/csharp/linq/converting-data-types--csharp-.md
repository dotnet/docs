---
title: "Converting Data Types (C#)"
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
ms.assetid: 46e5682f-77a1-4302-8f93-a2b53c408808
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
# Converting Data Types (C#)
Conversion methods change the type of input objects.  
  
 Conversion operations in LINQ queries are useful in a variety of applications. Following are some examples:  
  
-   The <xref:System.Linq.Enumerable.AsEnumerable*?displayProperty=fullName> method can be used to hide a type's custom implementation of a standard query operator.  
  
-   The <xref:System.Linq.Enumerable.OfType*?displayProperty=fullName> method can be used to enable non-parameterized collections for LINQ querying.  
  
-   The <xref:System.Linq.Enumerable.ToArray*?displayProperty=fullName>, <xref:System.Linq.Enumerable.ToDictionary*?displayProperty=fullName>, <xref:System.Linq.Enumerable.ToList*?displayProperty=fullName>, and <xref:System.Linq.Enumerable.ToLookup*?displayProperty=fullName> methods can be used to force immediate query execution instead of deferring it until the query is enumerated.  
  
## Methods  
 The following table lists the standard query operator methods that perform data-type conversions.  
  
 The conversion methods in this table whose names start with "As" change the static type of the source collection but do not enumerate it. The methods whose names start with "To" enumerate the source collection and put the items into the corresponding collection type.  
  
|Method Name|Description|C# Query Expression Syntax|More Information|  
|-----------------|-----------------|---------------------------------|----------------------|  
|AsEnumerable|Returns the input typed as <xref:System.Collections.Generic.IEnumerable`1>.|Not applicable.|<xref:System.Linq.Enumerable.AsEnumerable*?displayProperty=fullName>|  
|AsQueryable|Converts a (generic) <xref:System.Collections.IEnumerable> to a (generic) <xref:System.Linq.IQueryable>.|Not applicable.|<xref:System.Linq.Queryable.AsQueryable*?displayProperty=fullName>|  
|Cast|Casts the elements of a collection to a specified type.|Use an explicitly typed range variable. For example:<br /><br /> `from string str in words`|<xref:System.Linq.Enumerable.Cast*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Cast*?displayProperty=fullName>|  
|OfType|Filters values, depending on their ability to be cast to a specified type.|Not applicable.|<xref:System.Linq.Enumerable.OfType*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.OfType*?displayProperty=fullName>|  
|ToArray|Converts a collection to an array. This method forces query execution.|Not applicable.|<xref:System.Linq.Enumerable.ToArray*?displayProperty=fullName>|  
|ToDictionary|Puts elements into a <xref:System.Collections.Generic.Dictionary`2> based on a key selector function. This method forces query execution.|Not applicable.|<xref:System.Linq.Enumerable.ToDictionary*?displayProperty=fullName>|  
|ToList|Converts a collection to a <xref:System.Collections.Generic.List`1>. This method forces query execution.|Not applicable.|<xref:System.Linq.Enumerable.ToList*?displayProperty=fullName>|  
|ToLookup|Puts elements into a <xref:System.Linq.Lookup`2> (a one-to-many dictionary) based on a key selector function. This method forces query execution.|Not applicable.|<xref:System.Linq.Enumerable.ToLookup*?displayProperty=fullName>|  
  
## Query Expression Syntax Example  
 The following code example uses an explicitly-typed range variable  to cast a type to a subtype before accessing a member that is available only on the subtype.  
  
```c#  
class Plant  
{  
    public string Name { get; set; }  
}  
  
class CarnivorousPlant : Plant  
{  
    public string TrapType { get; set; }  
}  
  
static void Cast()  
{  
    Plant[] plants = new Plant[] {  
        new CarnivorousPlant { Name = "Venus Fly Trap", TrapType = "Snap Trap" },  
        new CarnivorousPlant { Name = "Pitcher Plant", TrapType = "Pitfall Trap" },  
        new CarnivorousPlant { Name = "Sundew", TrapType = "Flypaper Trap" },  
        new CarnivorousPlant { Name = "Waterwheel Plant", TrapType = "Snap Trap" }  
    };  
  
    var query = from CarnivorousPlant cPlant in plants  
                where cPlant.TrapType == "Snap Trap"  
                select cPlant;  
  
    foreach (Plant plant in query)  
        Console.WriteLine(plant.Name);  
  
    /* This code produces the following output:  
  
        Venus Fly Trap  
        Waterwheel Plant  
    */  
}  
```  
  
## See Also  
 <xref:System.Linq>   
 [Standard Query Operators Overview (C#)](../linq/standard-query-operators-overview--csharp-.md)   
 [from clause](../keywords/from-clause--csharp-reference-.md)   
 [LINQ Query Expressions](../linq-query-expressions/linq-query-expressions--csharp-programming-guide-.md)   
 [How to: Query an ArrayList with LINQ (C#)](../linq/how-to--query-an-arraylist-with-linq--csharp-.md)