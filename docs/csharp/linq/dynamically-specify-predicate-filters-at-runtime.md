---
title: Dynamically specify predicate filters at runtime
description: How to dynamically specify predicate filters at runtime.
keywords: .NET, .NET Core, C#
author: BillWagner
manager: wpickett
ms.author: wiwagn
ms.date: 12/1/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.assetid: 90238470-0767-497c-916c-52d0d16845e0
---
# Dynamically specify predicate filters at runtime

In some cases you do not know until run time how many predicates you have to apply to source elements in the `where` clause. One way to dynamically specify multiple predicate filters is to use the <xref:System.Linq.Enumerable.Contains%2A> method, as shown in the following example. The example is constructed in two ways. First, the project is run by filtering on values that are provided in the program. Then the project is run again by using input provided at run time.  
  
## To filter by using the Contains method  
  
1.  Open a new console application and name it `PredicateFilters`.  
  
2.  Copy the `StudentClass` class from [Query a collection of objects](query-a-collection-of-objects.md) and paste it into namespace `PredicateFilters` underneath class `Program`. `StudentClass` provides a list of `Student` objects.  
  
3.  Comment out the `Main` method in `StudentClass`.  
  
4.  Replace class `Program` with the following code.  
  
     [!code-csharp[csProgGuideLINQ#26](../../../samples/snippets/csharp/concepts/linq/how-to-dynamically-specify-predicate-filters-at-runtime_1.cs)]  
  
5.  Add the following line to the `Main` method in class `DynamicPredicates`, under the declaration of `ids`.  
  
     ```csharp
     QueryById(ids);
     ```

6.  Run the project.  
  
7.  The following output is displayed in a console window:  
  
     Garcia: 114  
  
     O'Donnell: 112  
  
     Omelchenko: 111  
  
8.  The next step is to run the project again, this time by using input entered at run time instead of array `ids`. Change `QueryByID(ids)` to `QueryByID(args)` in the `Main` method.  
  
9. Run the project with the command line arguments `122 117 120 115`. When the project is run, those values become elements of `args`, the parameter of the `Main` method..  
  
10. The following output is displayed in a console window:  
  
     Adams: 120  
  
     Feng: 117  
  
     Garcia: 115  
  
     Tucker: 122  
  
## To filter by using a switch statement  
  
1.  You can use a `switch` statement to select among predetermined alternative queries. In the following example, `studentQuery` uses a different `where` clause depending on which grade level, or year, is specified at run time.  
  
2.  Copy the following method and paste it into class `DynamicPredicates`.  
  
     [!code-csharp[csProgGuideLINQ#27](../../../samples/snippets/csharp/concepts/linq//how-to-dynamically-specify-predicate-filters-at-runtime_2.cs)]  
  
3.  In the `Main` method, replace the call to `QueryByID` with the following call, which sends the first element from the `args` array as its argument: `QueryByYear(args[0])`.  
  
4.  Run the project with a command line argument of an integer value between 1 and 4.  
  
 
## See Also  
 [LINQ Query Expressions](index.md)  
 [where clause](../language-reference/keywords/where-clause.md)
