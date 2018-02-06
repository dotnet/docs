---
title: "Object and Collection Initializers (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "object initializers [C#]"
  - "collection initializers [C#]"
ms.assetid: c58f3db5-d7d4-4651-bd2d-5a3a97357f61
caps.latest.revision: 27
author: "BillWagner"
ms.author: "wiwagn"
---
# Object and Collection Initializers (C# Programming Guide)
Object initializers let you assign values to any accessible fields or properties of an object at creation time without having to invoke a constructor followed by lines of assignment statements. The object initializer syntax enables you to specify arguments for a constructor or omit the arguments (and parentheses syntax).  The following example shows how to use an object initializer with a named type, `Cat` and how to invoke the default constructor. Note the use of auto-implemented properties in the `Cat` class. For more information, see [Auto-Implemented Properties](../../../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md).  
  
 [!code-csharp[csProgGuideLINQ#39](../../../csharp/programming-guide/arrays/codesnippet/CSharp/object-and-collection-initializers_1.cs)]  
  
 [!code-csharp[csProgGuideLINQ#45](../../../csharp/programming-guide/arrays/codesnippet/CSharp/object-and-collection-initializers_2.cs)] 
 
The object initializers syntax allows you to create an instance, and after that it assigns the newly created object, with its assigned properties, to the variable in the assignment.
  
## Object Initializers with anonymous types  
 Although object initializers can be used in any context, they are especially useful in [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] query expressions. Query expressions make frequent use of [anonymous types](../../../csharp/programming-guide/classes-and-structs/anonymous-types.md), which can only be initialized by using an object initializer, as shown in the following declaration.  
  
```csharp
var pet = new { Age = 10, Name = "Fluffy" };  
```  
  
 Anonymous types enable the `select` clause in a [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] query expression to transform objects of the original sequence into objects whose value and shape may differ from the original. This is useful if you want to store only a part of the information from each object in a sequence. In the following example, assume that a product object (`p`) contains many fields and methods, and that you are only interested in creating a sequence of objects that contain the product name and the unit price.  
  
 [!code-csharp[csProgGuideLINQ#40](../../../csharp/programming-guide/arrays/codesnippet/CSharp/object-and-collection-initializers_3.cs)]  
  
 When this query is executed, the `productInfos` variable will contain a sequence of objects that can be accessed in a `foreach` statement as shown in this example:  
  
```csharp
foreach(var p in productInfos){...}  
```  
  
 Each object in the new anonymous type has two public properties which receive the same names as the properties or fields in the original object. You can also rename a field when you are creating an anonymous type; the following example renames the `UnitPrice` field to `Price`.  
  
```csharp
select new {p.ProductName, Price = p.UnitPrice};  
```  
  
## Object initializers with nullable types  
 It is a compile-time error to use an object initializer with a nullable struct.  
  
## Collection initializers  
 Collection initializers let you specify one or more element initializers when you initialize a collection type that implements <xref:System.Collections.IEnumerable> and has `Add` with the appropriate signature as an instance method or an extension method. The element initializers can be a simple value, an expression or an object initializer. By using a collection initializer you do not have to specify multiple calls to the `Add` method of the class in your source code; the compiler adds the calls.  
  
 The following examples shows two simple collection initializers:  
  
```csharp
List<int> digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };  
List<int> digits2 = new List<int> { 0 + 1, 12 % 3, MakeInt() };  
```  
  
 The following collection initializer uses object initializers to initialize objects of the `Cat` class defined in a previous example. Note that the individual object initializers are enclosed in braces and separated by commas.  
  
 [!code-csharp[csProgGuideLINQ#41](../../../csharp/programming-guide/arrays/codesnippet/CSharp/object-and-collection-initializers_4.cs)]  
  
 You can specify [null](../../../csharp/language-reference/keywords/null.md) as an element in a collection initializer if the collection's `Add` method allows it.  
  
 [!code-csharp[csProgGuideLINQ#42](../../../csharp/programming-guide/arrays/codesnippet/CSharp/object-and-collection-initializers_5.cs)]  
  
 You can specify indexed elements if the collection supports indexing.  
  
```csharp
var numbers = new Dictionary<int, string> {   
    [7] = "seven",   
    [9] = "nine",   
    [13] = "thirteen"   
};  
```  
  
## Examples

 The following example combines the concepts of object and collection initializers.

 [!code-csharp[csProgGuideLINQ#46](../../../csharp/programming-guide/arrays/codesnippet/CSharp/object-and-collection-initializers_6.cs)]  
 
 Shown in the following example, an object which implements <xref:System.Collections.IEnumerable> containing an `Add` method with multiple parameters allows for collection initializers with multiple elements per item in the list corresponding to the signature of the `Add` method. 
 
 [!code-csharp[csProgGuideLINQ#84](../../../csharp/programming-guide/arrays/codesnippet/CSharp/object-and-collection-initializers_7.cs)]
 
 `Add` methods can use the `params` keyword to take a variable number of arguments as shown in the following example. This example demonstrates the custom implementation of an indexer as well to initialize a collection using indexes.
 
 [!code-csharp[csProgGuideLINQ#85](../../../csharp/programming-guide/arrays/codesnippet/CSharp/object-and-collection-initializers_8.cs)]
 
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)  
 [Anonymous Types](../../../csharp/programming-guide/classes-and-structs/anonymous-types.md)
