---
title: "How to define constants in C#"
description: Learn how to define constants in C#, which are fields whose values are set at compile time. Use constants to provide meaningful names for special values.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "C# language, constants"
  - "constants [C#]"
ms.topic: how-to
ms.custom: contperf-fy21q2
ms.assetid: 43f511be-346c-4b8a-995e-aded94542ece
---
# How to define constants in C\#

Constants are fields whose values are set at compile time and can never be changed. Use constants to provide meaningful names instead of numeric literals ("magic numbers") for special values.  
  
> [!NOTE]
> In C# the [#define](../../language-reference/preprocessor-directives.md#defining-symbols) preprocessor directive cannot be used to define constants in the way that is typically used in C and C++.  
  
 To define constant values of integral types (`int`, `byte`, and so on) use an enumerated type. For more information, see [enum](../../language-reference/builtin-types/enum.md).  
  
 To define non-integral constants, one approach is to group them in a single static class named `Constants`. This will require that all references to the constants be prefaced with the class name, as shown in the following example.  
  
## Example  

 [!code-csharp[constants](snippets/how-to-define-constants/Program.cs)]  
  
 The use of the class name qualifier helps ensure that you and others who use the constant understand that it is constant and cannot be modified.  
  
## See also

- [The C# type system](../../fundamentals/types/index.md)
