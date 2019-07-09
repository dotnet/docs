---
title: "Structs - C# Programming Guide"
ms.custom: seodec18
ms.date: 08/21/2018
helpviewer_keywords: 
  - "C# language, structs"
  - "structs [C#]"
ms.assetid: b7cf4ff2-0eb7-4e5c-93d5-b2196b4f5d89
---
# Structs (C# Programming Guide)

Structs are defined by using the [struct](../../language-reference/keywords/struct.md) keyword, for example:  
  
 [!code-csharp[csProgGuideObjects#39](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideObjects/CS/Objects.cs#39)]  
  
Structs share most of the same syntax as classes. The name of the struct must be a valid C# [identifier name](../inside-a-program/identifier-names.md). Structs are more limited than classes in the following ways:  
  
- Within a struct declaration, fields cannot be initialized unless they are declared as const or static.  
- A struct cannot declare a parameterless constructor (a constructor without parameters) or a finalizer.  
- Structs are copied on assignment. When a struct is assigned to a new variable, all the data is copied, and any modification to the new copy does not change the data for the original copy. This is important to remember when working with collections of value types such as `Dictionary<string, myStruct>`.  
- Structs are value types, unlike classes, which are reference types.  
- Unlike classes, structs can be instantiated without using a `new` operator.  
- Structs can declare constructors that have parameters.
- A struct cannot inherit from another struct or class, and it cannot be the base of a class. All structs inherit directly from <xref:System.ValueType>, which inherits from <xref:System.Object>.  
- A struct can implement interfaces.
- A struct cannot be `null`, and a struct variable cannot be assigned `null` unless the variable is declared as a nullable type.
  
## See also

- [C# Programming Guide](../index.md)
- [Classes and Structs](index.md)
- [Classes](classes.md)
- [Nullable Types](../nullable-types/index.md)
- [Identifier names](../inside-a-program/identifier-names.md)
- [Using Structs](using-structs.md)
- [How to: Know the Difference Between Passing a Struct and Passing a Class Reference to a Method](how-to-know-the-difference-passing-a-struct-and-passing-a-class-to-a-method.md)
