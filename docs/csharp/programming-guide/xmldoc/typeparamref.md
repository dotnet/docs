---
title: "&lt;typeparamref&gt; (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

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
# &lt;typeparamref&gt; (C# Programming Guide)
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
  
 Compile with [/doc](../../../csharp/language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.  
  
## Example  
 [!code-cs[csProgGuideDocComments#13](../../../csharp/programming-guide/xmldoc/codesnippet/CSharp/typeparamref_1.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Recommended Tags for Documentation Comments](../../../csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments.md)