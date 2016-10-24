---
title: "&lt;para&gt; (C# Programming Guide)"
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
  - "<para>"
  - "para"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "<para> C# XML tag"
  - "para C# XML tag"
ms.assetid: c74b8705-29df-40b1-bff5-237492b0e978
caps.latest.revision: 11
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
# &lt;para&gt; (C# Programming Guide)
## Syntax  
  
```  
<para>content</para>  
```  
  
#### Parameters  
 `content`  
 The text of the paragraph.  
  
## Remarks  
 The \<para> tag is for use inside a tag, such as [\<summary>](../xmldoc/-summary---csharp-programming-guide-.md), [\<remarks>](../xmldoc/-remarks---csharp-programming-guide-.md), or [\<returns>](../xmldoc/-returns---csharp-programming-guide-.md), and lets you add structure to the text.  
  
 Compile with [/doc](../compiler-options/-doc--csharp-compiler-options-.md) to process documentation comments to a file.  
  
## Example  
 See [\<summary>](../xmldoc/-summary---csharp-programming-guide-.md) for an example of using \<para>.  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Recommended Tags for Documentation Comments](../xmldoc/recommended-tags-for-documentation-comments--csharp-programming-guide-.md)