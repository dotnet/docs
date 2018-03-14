---
title: "struct (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "struct_CSharpKeyword"
helpviewer_keywords: 
  - "struct keyword [C#]"
  - "structs [C#], struct keyword"
ms.assetid: ff3dd9b7-dc93-4720-8855-ef5558f65c7c
caps.latest.revision: 23
author: "BillWagner"
ms.author: "wiwagn"
---
# struct (C# Reference)
A `struct` type is a value type that is typically used to encapsulate small groups of related variables, such as the coordinates of a rectangle or the characteristics of an item in an inventory. The following example shows a simple struct declaration:  
  
```  
public struct Book  
{  
    public decimal price;  
    public string title;  
    public string author;  
}  
```  
  
## Remarks  
 Structs can also contain [constructors](../../../csharp/programming-guide/classes-and-structs/constructors.md), [constants](../../../csharp/programming-guide/classes-and-structs/constants.md), [fields](../../../csharp/programming-guide/classes-and-structs/fields.md), [methods](../../../csharp/programming-guide/classes-and-structs/methods.md), [properties](../../../csharp/programming-guide/classes-and-structs/properties.md), [indexers](../../../csharp/programming-guide/indexers/index.md), [operators](../../../csharp/programming-guide/statements-expressions-operators/operators.md), [events](../../../csharp/programming-guide/events/index.md), and [nested types](../../../csharp/programming-guide/classes-and-structs/nested-types.md), although if several such members are required, you should consider making your type a class instead.  
  
 For examples, see [Using Structs](../../../csharp/programming-guide/classes-and-structs/using-structs.md).  
  
 Structs can implement an interface but they cannot inherit from another struct. For that reason, struct members cannot be declared as `protected`.  
  
 For more information, see [Structs](../../../csharp/programming-guide/classes-and-structs/structs.md).  
  
## Examples  
 For examples and more information, see [Using Structs](../../../csharp/programming-guide/classes-and-structs/using-structs.md).  
  
## C# Language Specification  
 For examples, see [Using Structs](../../../csharp/programming-guide/classes-and-structs/using-structs.md).  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Default Values Table](../../../csharp/language-reference/keywords/default-values-table.md)  
 [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)  
 [Types](../../../csharp/language-reference/keywords/types.md)  
 [Value Types](../../../csharp/language-reference/keywords/value-types.md)  
 [class](../../../csharp/language-reference/keywords/class.md)  
 [interface](../../../csharp/language-reference/keywords/interface.md)  
 [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)
