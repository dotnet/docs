---
title: "$ (C# Reference) | Microsoft Docs"
ms.date: "2017-02-09"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "$_CSharpKeyword"
  - "$"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "$ special character [C#]"
  - "$ language element [C#]"
ms.assetid: 7d9e21b5-eac3-4878-9530-50e4da578acd
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
# $ (C# Reference)

Identifies a string literal as an [interpolated string](../keywords/interpolated-strings.md). An interpolated string is a template-like string that contains literal text along with *interpolated expressions*. When the interpolated string is resolved, for example in an assignment statement or a method call, its interpolated expressions are replaced by their string representations in the result string. Interpolated strings are replacements for the [composite format strings](../../../standard/base-types/composite-format.md) supported by the .NET Framework.

The following example uses the `$` character to define an interpolated string.

[!CODE-cs[interpolated-string-symbol](../../../../samples/snippets/csharp/language-reference/keywords/dollar-sign1.cs#1)]

For more information on interpolated strings, see the [Interpolated Strings](../keywords/interpolated-strings.md) topic.

## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Special Characters](../../../csharp/language-reference/tokens/index.md)
