---
title: "&lt;exception&gt; (C# Programming Guide)"
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
  - "exception"
  - "<exception>"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "<exception> C# XML tag"
  - "exception C# XML tag"
ms.assetid: dd73aac5-3c74-4fcf-9498-f11bff3a2f3c
caps.latest.revision: 16
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
# &lt;exception&gt; (C# Programming Guide)
## Syntax  
  
```  
<exception cref="member">description</exception>  
```  
  
#### Parameters  
 cref = " `member`"  
 A reference to an exception that is available from the current compilation environment. The compiler checks that the given exception exists and translates `member` to the canonical element name in the output XML. `member` must appear within double quotation marks (" ").  
  
 For more information on how to create a cref reference to a generic type, see [\<see>](../xmldoc/-see---csharp-programming-guide-.md).  
  
 `description`  
 A description of the exception.  
  
## Remarks  
 The \<exception> tag lets you specify which exceptions can be thrown. This tag can be applied to definitions for methods, properties, events, and indexers.  
  
 Compile with [/doc](../compiler-options/-doc--csharp-compiler-options-.md) to process documentation comments to a file.  
  
 For more information about exception handling, see [Exceptions and Exception Handling](../exceptions/exceptions-and-exception-handling--csharp-programming-guide-.md).  
  
## Example  
 [!code[csProgGuideDocComments#4](../xmldoc/codesnippet/CSharp/-exception---csharp-programming-guide-_1.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Recommended Tags for Documentation Comments](../xmldoc/recommended-tags-for-documentation-comments--csharp-programming-guide-.md)