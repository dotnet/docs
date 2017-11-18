---
title: "&lt;paramref&gt; (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "paramref"
  - "<paramref>"
helpviewer_keywords: 
  - "<paramref> C# XML tag"
  - "paramref C# XML tag"
ms.assetid: 756c24c1-f591-40e8-a838-559761539b0b
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
---
# &lt;paramref&gt; (C# Programming Guide)
## Syntax  
  
```xml  
<paramref name="name"/>  
```  
  
#### Parameters  
 `name`  
 The name of the parameter to refer to. Enclose the name in double quotation marks (" ").  
  
## Remarks  
 The \<paramref> tag gives you a way to indicate that a word in the code comments, for example in a \<summary> or \<remarks> block refers to a parameter. The XML file can be processed to format this word in some distinct way, such as with a bold or italic font.  
  
 Compile with [/doc](../../../csharp/language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.  
  
## Example  
 [!code-csharp[csProgGuideDocComments#7](../../../csharp/programming-guide/xmldoc/codesnippet/CSharp/paramref_1.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Recommended Tags for Documentation Comments](../../../csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments.md)
