---
title: "How to: Define Constants in C# | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "C# language, constants"
  - "constants [C#]"
ms.assetid: 43f511be-346c-4b8a-995e-aded94542ece
caps.latest.revision: 7
author: "BillWagner"
ms.author: "wiwagn"

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# How to: Define Constants in C#
Constants are fields whose values are set at compile time and can never be changed. Use constants to provide meaningful names instead of numeric literals ("magic numbers") for special values.  
  
> [!NOTE]
>  In C# the [#define](../../../csharp/language-reference/preprocessor-directives/preprocessor-define.md) preprocessor directive cannot be used to define constants in the way that is typically used in C and C++.  
  
 To define constant values of integral types (`int`, `byte`, and so on) use an enumerated type. For more information, see [enum](../../../csharp/language-reference/keywords/enum.md).  
  
 To define non-integral constants, one approach is to group them in a single static class named `Constants`. This will require that all references to the constants be prefaced with the class name, as shown in the following example.  
  
## Example  
 [!code-cs[csProgGuideObjects#89](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-define-constants_1.cs)]  
  
 The use of the class name qualifier helps ensure that you and others who use the constant understand that it is constant and cannot be modified.  
  
## See Also  
 [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)