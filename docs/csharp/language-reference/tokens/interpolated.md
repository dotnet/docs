---
title: "$ (C# Reference)"
ms.date: 02/09/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "$_CSharpKeyword"
  - "$"
helpviewer_keywords: 
  - "$ special character [C#]"
  - "$ language element [C#]"
ms.assetid: 7d9e21b5-eac3-4878-9530-50e4da578acd
author: "rpetrusha"
ms.author: "ronpet"
---
# $ (C# Reference)

Identifies a string literal as an [interpolated string](../keywords/interpolated-strings.md). An interpolated string is a template-like string that contains literal text along with *interpolated expressions*. When the interpolated string is resolved, for example in an assignment statement or a method call, its interpolated expressions are replaced by their string representations in the result string. Interpolated strings are replacements for the [composite format strings](../../../standard/base-types/composite-format.md) supported by the .NET Framework.

The following example uses the `$` character to define an interpolated string.

[!code-csharp[interpolated-string-symbol](../../../../samples/snippets/csharp/language-reference/keywords/dollar-sign1.cs#1)]

For more information on interpolated strings, see the [Interpolated Strings](../keywords/interpolated-strings.md) topic.

## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Special Characters](../../../csharp/language-reference/tokens/index.md)
