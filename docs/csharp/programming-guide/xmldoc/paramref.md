---
title: "&lt;paramref&gt; (C# Programming Guide) | Microsoft Docs"
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
  - "paramref"
  - "<paramref>"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "<paramref> C# XML tag"
  - "paramref C# XML tag"
ms.assetid: 756c24c1-f591-40e8-a838-559761539b0b
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# &lt;paramref&gt; (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

## Syntax  
  
```  
<paramref name="name"/>  
```  
  
#### Parameters  
 `name`  
 The name of the parameter to refer to. Enclose the name in double quotation marks (" ").  
  
## Remarks  
 The \<paramref> tag gives you a way to indicate that a word in the code comments, for example in a \<summary> or \<remarks> block refers to a parameter. The XML file can be processed to format this word in some distinct way, such as with a bold or italic font.  
  
 Compile with [/doc](../../../csharp/language-reference/compiler-options/doc-csharp-compiler-options.md) to process documentation comments to a file.  
  
## Example  
 [!code-csharp[csProgGuideDocComments#7](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#7)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Recommended Tags for Documentation Comments](../../../csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments.md)