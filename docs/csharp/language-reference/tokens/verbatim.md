---
title: "@ (C# Reference) | Microsoft Docs"
ms.date: "2017-02-09"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "@_CSharpKeyword"
  - "@"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "@ special character [C#]"
  - "@ language element [C#]"
ms.assetid: 89bc7e53-85f5-478a-866d-1cca003c4e8c
author: "rpetrusha"
ms.author: "ronpet"
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
# @ (C# Reference)

The `@` special character serves as a verbatim identifier. It can be used in the following ways:

1. To enable C# keywords to be used as identifiers. The `@` character prefixes a code element that the compiler is to interpret as an identifier rather than a C# keyword. The following example uses the `@` character to define an identifier named `for` that it uses in a `for` loop.

   [!code-cs[verbatim1](../../../../samples/snippets/csharp/language-reference/keywords/verbatim1.cs#1)]

1. To indicate that a string literal is to be interpreted verbatim. The `@` character in this instance defines a *verbatim string literal*. Simple escape sequences (such as `"\\"` for a backslash), hexadecimal escape sequences (such as `"\x0041"` for an uppercase A, and Unicode escape sequences, such as `"\u0041"` for an uppercase A, are interpreted literally. Only a quote escape sequence (`""`) is not interpreted literally; it produces a single quotation mark. The following example defines two identical file paths, one by using a regular string literal and the other by using a verbatim string literal. This is one of the more common uses of verbatim string literals.

   [!code-cs[verbatim2](../../../../samples/snippets/csharp/language-reference/keywords/verbatim1.cs#2)]

   The following example illustrates the effect of defining a regular string literal and a verbatim string literal that contain identical character sequences.

   [!code-cs[verbatim3](../../../../samples/snippets/csharp/language-reference/keywords/verbatim1.cs#3)]

1. To enable the compiler to distinguish between attributes in cases of a naming conflict. An attribute is a type that derives from @System.Attribute. Its type name typically includes the suffix **Attribute**, although the compiler does not enforce this convention. The attribute can then be referenced in code either by its full type name (for example, `[InfoAttribute]` or its shortened name (for example, `[Info]`). However, a naming conflict occurs if two shortened attribute type names are identical, and one type name includes the **Attribute** suffix but the other does not. For example, the following code fails to compile because the compiler cannot determine whether the `Info` or `InfoAttribute` attribute is applied to the `Main` method.

   ```csharp
   using System;

   [AttributeUsage(AttributeTargets.Class)]
   public class Info : Attribute
   {
      private string information;
      
      public Info(string info)
      {
          information = info;
      }
   }

   [AttributeUsage(AttributeTargets.Method)]
   public class InfoAttribute : Attribute
   {
      private string information;
      
      public InfoAttribute(string info)
      {
          information = info;
      }
   }

   [Info("A simple executable.")]
   public class Example
   {
      [InfoAttribute("The entry point.")]
      public static void Main()
      {
      }
   }
   ```  

   If the verbatim identifier is used to identify the `Info` attribute, the example compiles successfully.

   [!code-cs[verbatim4](../../../../samples/snippets/csharp/language-reference/keywords/verbatim4.cs#1)]

## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Special Characters](../../../csharp/language-reference/tokens/index.md)
