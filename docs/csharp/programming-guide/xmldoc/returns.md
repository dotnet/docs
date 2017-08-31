---
title: "&lt;returns&gt; (C# Programming Guide) | Microsoft Docs"
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
  - "returns"
  - "<returns>"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "<returns> C# XML tag"
  - "returns C# XML tag"
ms.assetid: bb2d9958-62fc-47c7-9511-6311171f119f
caps.latest.revision: 11
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# &lt;returns&gt; (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

## Syntax  
  
```  
<returns>description</returns>  
```  
  
#### Parameters  
 `description`  
 A description of the return value.  
  
## Remarks  
 The \<returns> tag should be used in the comment for a method declaration to describe the return value.  
  
 Compile with [/doc](../../../csharp/language-reference/compiler-options/doc-csharp-compiler-options.md) to process documentation comments to a file.  
  
## Example  
 [!code-csharp[csProgGuideDocComments#10](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#10)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Recommended Tags for Documentation Comments](../../../csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments.md)