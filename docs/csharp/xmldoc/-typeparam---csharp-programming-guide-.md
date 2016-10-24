---
title: "&lt;typeparam&gt; (C# Programming Guide)"
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
  - "typeparam"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "<typeparam> C# XML tag"
  - "typeparam C# XML tag"
ms.assetid: 9b99d400-e911-4e55-99c6-64367c96aa4f
caps.latest.revision: 19
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
# &lt;typeparam&gt; (C# Programming Guide)
## Syntax  
  
```  
<typeparam name="name">description</typeparam>  
```  
  
#### Parameters  
 `name`  
 The name of the type parameter. Enclose the name in double quotation marks (" ").  
  
 `description`  
 A description for the type parameter.  
  
## Remarks  
 The `<typeparam>` tag should be used in the comment for a generic type or method declaration to describe a type parameter. Add a tag for each type parameter of the generic type or method.  
  
 For more information, see [Generics](../generics/generics--csharp-programming-guide-.md).  
  
 The text for the `<typeparam>` tag will be displayed in IntelliSense, the [Object Browser Window](http://msdn.microsoft.com/en-us/3c7f1673-1f0d-41b1-94ca-a3dcfcb82cda) code comment web report.  
  
 Compile with [/doc](../compiler-options/-doc--csharp-compiler-options-.md) to process documentation comments to a file.  
  
## Example  
 [!code[csProgGuideDocComments#13](../xmldoc/codesnippet/CSharp/-typeparam---csharp-programming-guide-_1.cs)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Recommended Tags for Documentation Comments](../xmldoc/recommended-tags-for-documentation-comments--csharp-programming-guide-.md)