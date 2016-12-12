---
title: "How to: Add Custom Methods for LINQ Queries (C#) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
ms.assetid: 1a500f60-2e10-49fb-8b2a-d8d08e4817cb
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# How to: Add Custom Methods for LINQ Queries (C#)
You can extend the set of methods that you can use for LINQ queries by adding extension methods to the <xref:System.Collections.Generic.IEnumerable%601> interface. For example, in addition to the standard average or maximum operations, you can create a custom aggregate method to compute a single value from a sequence of values. You can also create a method that works as a custom filter or a specific data transform for a sequence of values and returns a new sequence. Examples of such methods are <xref:System.Linq.Enumerable.Distinct%2A>, <xref:System.Linq.Enumerable.Skip%2A>, and <xref:System.Linq.Enumerable.Reverse%2A>.  
  
 When you extend the <xref:System.Collections.Generic.IEnumerable%601> interface, you can apply your custom methods to any enumerable collection. For more information, see [Extension Methods](../../../../csharp/programming-guide/classes-and-structs/extension-methods.md).  
  
## Adding an Aggregate Method  
 An aggregate method computes a single value from a set of values. LINQ provides several aggregate methods, including <xref:System.Linq.Enumerable.Average%2A>, <xref:System.Linq.Enumerable.Min%2A>, and <xref:System.Linq.Enumerable.Max%2A>. You can create your own aggregate method by adding an extension method to the <xref:System.Collections.Generic.IEnumerable%601> interface.  
  
 The following code example shows how to create an extension method called `Median` to compute a median for a sequence of numbers of type `double`.  
  
```cs  
public static class LINQExtension  
{  
    public static double Median(this IEnumerable<double> source)  
    {  
        if (source.Count() == 0)  
        {  
            throw new InvalidOperationException("Cannot compute median for an empty set.");  
        }  
  
        var sortedList = from number in source  
                         orderby number  
                         select number;  
  
        int itemIndex = (int)sortedList.Count() / 2;  
  
        if (sortedList.Count() % 2 == 0)  
        {  
            // Even number of items.  
            return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2;  
        }  
        else  
        {  
            // Odd number of items.  
            return sortedList.ElementAt(itemIndex);  
        }  
    }  
}  
```  
  
 You call this extension method for any enumerable collection in the same way you call other aggregate methods from the <xref:System.Collections.Generic.IEnumerable%601> interface.  
  
 The following code example shows how to use the `Median` method for an array of type `double`.  
  
<CodeContentPlaceHolder>1</CodeContentPlaceHolder>  
<CodeContentPlaceHolder>2</CodeContentPlaceHolder>  
### Overloading an Aggregate Method to Accept Various Types  
 You can overload your aggregate method so that it accepts sequences of various types. The standard approach is to create an overload for each type. Another approach is to create an overload that will take a generic type and convert it to a specific type by using a delegate. You can also combine both approaches.  
  
#### To create an overload for each type  
 You can create a specific overload for each type that you want to support. The following code example shows an overload of the `Median` method for the `integer` type.  
  
<CodeContentPlaceHolder>3</CodeContentPlaceHolder>  
 You can now call the `Median` overloads for both `integer` and `double` types, as shown in the following code:  
  
<CodeContentPlaceHolder>4</CodeContentPlaceHolder>  
<CodeContentPlaceHolder>5</CodeContentPlaceHolder>  
<CodeContentPlaceHolder>6</CodeContentPlaceHolder>  
#### To create a generic overload  
 You can also create an overload that accepts a sequence of generic objects. This overload takes a delegate as a parameter and uses it to convert a sequence of objects of a generic type to a specific type.  
  
 The following code shows an overload of the `Median` method that takes the <xref:System.Func%602> delegate as a parameter. This delegate takes an object of generic type T and returns an object of type `double`.  
  
```cs  
// Generic overload.  
  
public static double Median<T>(this IEnumerable<T> numbers,  
                       Func<T, double> selector)  
{  
    return (from num in numbers select selector(num)).Median();  
}  
```  
  
 You can now call the `Median` method for a sequence of objects of any type. If the type does not have its own method overload, you have to pass a delegate parameter. In C#, you can use a lambda expression for this purpose. Also, in Visual Basic only, if you use the `Aggregate` or `Group By` clause instead of the method call, you can pass any value or expression that is in the scope this clause.  
  
 The following example code shows how to call the `Median` method for an array of integers and an array of strings. For strings, the median for the lengths of strings in the array is calculated. The example shows how to pass the <xref:System.Func%602> delegate parameter to the `Median` method for each case.  
  
<CodeContentPlaceHolder>8</CodeContentPlaceHolder>  
## Adding a Method That Returns a Collection  
 You can extend the <xref:System.Collections.Generic.IEnumerable%601> interface with a custom query method that returns a sequence of values. In this case, the method must return a collection of type <xref:System.Collections.Generic.IEnumerable%601>. Such methods can be used to apply filters or data transforms to a sequence of values.  
  
 The following example shows how to create an extension method named `AlternateElements` that returns every other element in a collection, starting from the first element.  
  
<CodeContentPlaceHolder>9</CodeContentPlaceHolder>  
 You can call this extension method for any enumerable collection just as you would call other methods from the <xref:System.Collections.Generic.IEnumerable%601> interface, as shown in the following code:  
  
```cs  
string[] strings = { "a", "b", "c", "d", "e" };  
  
var query = strings.AlternateElements();  
  
foreach (var element in query)  
{  
    Console.WriteLine(element);  
}  
/*  
 This code produces the following output:  
  
 a  
 c  
 e  
*/  
```  
  
## See Also  
 <xref:System.Collections.Generic.IEnumerable%601>   
 [Extension Methods](../../../../csharp/programming-guide/classes-and-structs/extension-methods.md)