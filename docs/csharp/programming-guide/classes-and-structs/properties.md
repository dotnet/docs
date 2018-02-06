---
title: "Properties (C# Programming Guide)"
ms.date: 03/10/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "cs.properties"
helpviewer_keywords: 
  - "properties [C#]"
  - "C# language, properties"
ms.assetid: e295a8a2-b357-4ee7-a12e-385a44146fa8
caps.latest.revision: 38
author: "BillWagner"
ms.author: "wiwagn"
---
# Properties (C# Programming Guide)

A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field. Properties can be used as if they are public data members, but they are actually special methods called *accessors*. This enables data to be accessed easily and still helps promote the safety and flexibility of methods.  

## Properties overview  
  
- Properties enable a class to expose a public way of getting and setting values, while hiding implementation or verification code.  
  
- A [get](../../../csharp/language-reference/keywords/get.md) property accessor is used to return the property value, and a [set](../../../csharp/language-reference/keywords/set.md) property accessor is used to assign a new value. These accessors can have different access levels. For more information, see [Restricting Accessor Accessibility](../../../csharp/programming-guide/classes-and-structs/restricting-accessor-accessibility.md).  
  
- The [value](../../../csharp/language-reference/keywords/value.md) keyword is used to define the value being assigned by the `set` accessor.  
- Properties can be *read-write* (they have both a `get` and a `set` accessor), *read-only* (they have a `get` accessor but no `set` accessor), or *write-only* (they have a `set` accessor, but no `get` accessor). Write-only properties are rare and are most commonly used to restrict access to sensitive data.

- Simple properties that require no custom accessor code can be implemented either as expression body definitions or as [auto-implemented properties](../../../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md).
 
## Properties with backing fields

One basic pattern for implementing a property involves using a private backing field for setting and retrieving the property value. The `get` accessor returns the value of the private field, and the `set` accessor may perform some data validation before assigning a value to the private field. Both accessors may also perform some conversion or computation on the data before it is stored or returned.

The following example illustrates this pattern. In this example, the `TimePeriod` class represents an interval of time. Internally, the class stores the time interval in seconds in a private field named `seconds`. A read-write property named `Hours` allows the customer to specify the time interval in hours. Both the `get` and the `set` accessors perform the necessary conversion between hours and seconds. In addition, the `set` accessor validates the data and throws an <xref:System.ArgumentOutOfRangeException> if the number of hours is invalid. 
   
 [!code-csharp[Properties#1](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/properties-1.cs)]  
  
## Expression body definitions  

 Property accessors often consist of single-line statements that just assign or return the result of an expression. You can implement these properties as expression-bodied members. Expression body definitions consist of the `=>` symbol followed by the expression to assign to or retrieve from the property.

 Starting with C# 6, read-only properties can implement the `get` accessor as an expression-bodied member. In this case, neither the `get` accessor keyword nor the `return` keyword is used. The following example implements the read-only `Name` property as an expression-bodied member.

 [!code-csharp[Properties#2](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/properties-2.cs)]  

 Starting with C# 7, both the `get` and the `set` accessor can be implemented as expression-bodied members. In this case, the `get` and `set` keywords must be present. The following example illustrates the use of expression body definitions for both accessors. Note that the `return` keyword is not used with the `get` accessor.
 
  [!code-csharp[Properties#3](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/properties-3.cs)]  

## Auto-implemented properties

In some cases, property `get` and `set` accessors just assign a value to or retrieve a value from a backing field without including any additional logic. By using auto-implemented properties, you can simplify your code while having the C# compiler transparently provide the backing field for you. 

If a property has both a `get` and a `set` accessor, both must be auto-implemented. You define an auto-implemented property by using the `get` and `set` keywords without providing any implementation. The following example repeats the previous one, except that `Name` and `Price` are auto-implemented properties. Note that the example also removes the parameterized constructor, so that `SaleItem` objects are now initialized with a call to the default constructor and an [object initializer](object-and-collection-initializers.md).

  [!code-csharp[Properties#4](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/properties-4.cs)]  

## Related sections  
  
-   [Using Properties](../../../csharp/programming-guide/classes-and-structs/using-properties.md)  
  
-   [Interface Properties](../../../csharp/programming-guide/classes-and-structs/interface-properties.md)  
  
-   [Comparison Between Properties and Indexers](../../../csharp/programming-guide/indexers/comparison-between-properties-and-indexers.md)  
  
-   [Restricting Accessor Accessibility](../../../csharp/programming-guide/classes-and-structs/restricting-accessor-accessibility.md)  
  
-   [Auto-Implemented Properties](../../../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Using Properties](../../../csharp/programming-guide/classes-and-structs/using-properties.md)  
 [Indexers](../../../csharp/programming-guide/indexers/index.md)  
 [get keyword](../../../csharp/language-reference/keywords/get.md)    
 [set keyword](../../../csharp/language-reference/keywords/set.md)    
