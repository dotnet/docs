---
title: "&lt;c&gt; (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
f1_keywords: 
  - "c"
  - "<c>"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "text, marking as code [C#]"
  - "code, marking text as [C#]"
  - "c C# XML tag"
  - "<c> C# XML tag"
ms.assetid: aad5b16e-a29e-445e-bd0d-eea0b138d7b2
caps.latest.revision: 12
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
# &lt;c&gt; (C# Programming Guide)
## Syntax  
  
```  
<c>text</c>  
```  
  
#### Parameters  
 `text`  
 The text you would like to indicate as code.  
  
## Remarks  
 The \<c> tag gives you a way to indicate that text within a description should be marked as code. Use [\<code>](../../../csharp/programming-guide/xmldoc/code.md) to indicate multiple lines as code.  
  
 Compile with [/doc](../../../csharp/language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.  
  
## Example  
 [!code-cs[csProgGuideDocComments#2](../../../csharp/programming-guide/xmldoc/codesnippet/CSharp/code-inline_1.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Recommended Tags for Documentation Comments](../../../csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments.md)