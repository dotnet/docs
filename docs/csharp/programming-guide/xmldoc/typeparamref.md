---
title: "&lt;typeparamref&gt; (C# Programming Guide) | Microsoft Docs"
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
  - "typeparamref"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "typeparamref C# XML tag"
  - "<typeparamref> C# XML tag"
ms.assetid: 6d8ffc58-12c5-4688-8db6-833a7ded5886
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# &lt;typeparamref&gt; (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

## Syntax  
  
```  
<typeparamref name="name"/>  
```  
  
#### Parameters  
 `name`  
 The name of the type parameter. Enclose the name in double quotation marks (" ").  
  
## Remarks  
 For more information on type parameters in generic types and methods, see [Generics](../../../csharp/programming-guide/generics/index.md).  
  
 Use this tag to enable consumers of the documentation file to format the word in some distinct way, for example in italics.  
  
 Compile with [/doc](../../../csharp/language-reference/compiler-options/doc-csharp-compiler-options.md) to process documentation comments to a file.  
  
## Example  
 [!code-csharp[csProgGuideDocComments#13](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#13)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Recommended Tags for Documentation Comments](../../../csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments.md)