---
title: "&lt;para&gt; (C# Programming Guide) | Microsoft Docs"
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
---
# &lt;para&gt; (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

## Syntax  
  
```  
<para>content</para>  
```  
  
#### Parameters  
 `content`  
 The text of the paragraph.  
  
## Remarks  
 The \<para> tag is for use inside a tag, such as [\<summary>](../../../csharp/programming-guide/xmldoc/summary.md), [\<remarks>](../../../csharp/programming-guide/xmldoc/remarks.md), or [\<returns>](../../../csharp/programming-guide/xmldoc/returns.md), and lets you add structure to the text.  
  
 Compile with [/doc](../../../csharp/language-reference/compiler-options/doc-csharp-compiler-options.md) to process documentation comments to a file.  
  
## Example  
 See [\<summary>](../../../csharp/programming-guide/xmldoc/summary.md) for an example of using \<para>.  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Recommended Tags for Documentation Comments](../../../csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments.md)