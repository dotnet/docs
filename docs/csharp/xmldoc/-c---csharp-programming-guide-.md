---
title: "&lt;c&gt; (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
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
manager: "wpickett"
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
 The \<c> tag gives you a way to indicate that text within a description should be marked as code. Use [\<code>](../xmldoc/-code---csharp-programming-guide-.md) to indicate multiple lines as code.  
  
 Compile with [/doc](../compiler-options/-doc--csharp-compiler-options-.md) to process documentation comments to a file.  
  
## Example  
 [!code[csProgGuideDocComments#2](../xmldoc/codesnippet/CSharp/-c---csharp-programming-guide-_1.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Recommended Tags for Documentation Comments](../xmldoc/recommended-tags-for-documentation-comments--csharp-programming-guide-.md)