---
title: "Constants - C# Programming Guide"
description: Constants in C# are compile-time literal values, which do not change once the program is compiled. Only C# built-in types can be constants.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "C# language, constants"
  - "constants [C#]"
ms.assetid: 1fb39621-1738-49b1-a1b3-8587f109123f
---
# Constants (C# Programming Guide)

Constants are immutable values which are known at compile time and do not change for the life of the program. Constants are declared with the [const](../../language-reference/keywords/const.md) modifier. Only the C# [built-in types](../../language-reference/builtin-types/built-in-types.md) (excluding <xref:System.Object?displayProperty=nameWithType>) may be declared as `const`. User-defined types, including classes, structs, and arrays, cannot be `const`. Use the [readonly](../../language-reference/keywords/readonly.md) modifier to create a class, struct, or array that is initialized one time at runtime (for example in a constructor) and thereafter cannot be changed.  
  
 C# does not support `const` methods, properties, or events.  
  
 The enum type enables you to define named constants for integral built-in types (for example `int`, `uint`, `long`, and so on). For more information, see [enum](../../language-reference/builtin-types/enum.md).  
  
 Constants must be initialized as they are declared. For example:  
  
 [!code-csharp[Calendar#1](snippets/constants/Calendar.cs#1)]
  
 In this example, the constant `Months` is always 12, and it cannot be changed even by the class itself. In fact, when the compiler encounters a constant identifier in C# source code (for example, `Months`), it substitutes the literal value directly into the intermediate language (IL) code that it produces. Because there is no variable address associated with a constant at run time, `const` fields cannot be passed by reference and cannot appear as an l-value in an expression.  
  
> [!NOTE]
> Use caution when you refer to constant values defined in other code such as DLLs. If a new version of the DLL defines a new value for the constant, your program will still hold the old literal value until it is recompiled against the new version.  
  
 Multiple constants of the same type can be declared at the same time, for example:  
  
 [!code-csharp[Calendar#2](snippets/constants/Calendar.cs#2)]
  
 The expression that is used to initialize a constant can refer to another constant if it does not create a circular reference. For example:  
  
 [!code-csharp[Calendar#3](snippets/constants/Calendar.cs#3)]
  
 Constants can be marked as [public](../../language-reference/keywords/public.md), [private](../../language-reference/keywords/private.md), [protected](../../language-reference/keywords/protected.md), [internal](../../language-reference/keywords/internal.md), [protected internal](../../language-reference/keywords/protected-internal.md) or [private protected](../../language-reference/keywords/private-protected.md). These access modifiers define how users of the class can access the constant. For more information, see [Access Modifiers](./access-modifiers.md).  
  
 Constants are accessed as if they were [static](../../language-reference/keywords/static.md) fields because the value of the constant is the same for all instances of the type. You do not use the `static` keyword to declare them. Expressions that are not in the class that defines the constant must use the class name, a period, and the name of the constant to access the constant. For example:  
  
 [!code-csharp[Calendar#4](snippets/constants/Calendar.cs#4)]
  
## C# Language Specification  

 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also

- [C# Programming Guide](../index.md)
- [Classes, structs, and records](/dotnet/csharp/fundamentals/object-oriented)
- [Properties](./properties.md)
- [Types](/dotnet/csharp/fundamentals/types)
- [readonly](../../language-reference/keywords/readonly.md)
- [Immutability in C# Part One: Kinds of Immutability](/archive/blogs/ericlippert/immutability-in-c-part-one-kinds-of-immutability)
