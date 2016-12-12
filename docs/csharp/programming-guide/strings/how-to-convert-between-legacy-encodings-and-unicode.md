---
title: "How to: Convert Between Legacy Encodings and Unicode (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "conversions [C#], legacy to unicode encoding"
  - "strings [C#], converting between encodings"
ms.assetid: 4eed7d8e-47ab-4a7c-8b95-9645a0ef000b
caps.latest.revision: 11
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
# How to: Convert Between Legacy Encodings and Unicode (C# Programming Guide)
In C#, all strings in memory are encoded as Unicode (UTF-16). When you bring data from storage into a `string` object, the data is automatically converted to UTF-16. If the data contains only ASCII values from 0 through 127, the conversion requires no extra effort on your part. However, if the source text contains extended ASCII byte values (128 through 255), the extended characters will be interpreted by default according to the current code page. To specify that the source text should be interpreted according to a different code page, use the <xref:System.Text.Encoding?displayProperty=fullName> class as shown in the following example.  
  
## Example  
 The following example shows how to convert a text file that has been encoded in 8-bit ASCII, interpreting the source text according to Windows Code Page 737.  
  
 [!code-cs[csProgGuideStrings#34](../../../csharp/programming-guide/strings/codesnippet/CSharp/how-to-convert-between-legacy-encodings-and-unicode_1.cs)]  
  
## See Also  
 [Strings](../../../csharp/programming-guide/strings/index.md)