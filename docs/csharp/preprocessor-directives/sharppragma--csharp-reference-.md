---
title: "#pragma (C# Reference)"
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
  - "#pragma"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "#pragma directive [C#]"
ms.assetid: 5b7944cd-d402-46a1-ad8f-feffb2d83673
caps.latest.revision: 18
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
# #pragma (C# Reference)
`#pragma` gives the compiler special instructions for the compilation of the file in which it appears. The instructions must be supported by the compiler. In other words, you cannot use `#pragma` to create custom preprocessing instructions. The Microsoft C# compiler supports the following two `#pragma` instructions:  
  
 [#pragma warning](../preprocessor-directives/sharppragma-warning--csharp-reference-.md)  
  
 [#pragma checksum](../preprocessor-directives/sharppragma-checksum--csharp-reference-.md)  
  
## Syntax  
  
```  
#pragma pragma-name pragma-arguments  
```  
  
#### Parameters  
 `pragma-name`  
 The name of a recognized pragma.  
  
 `pragma-arguments`  
 Pragma-specific arguments.  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Preprocessor Directives](../preprocessor-directives/csharp-preprocessor-directives.md)   
 [#pragma warning](../preprocessor-directives/sharppragma-warning--csharp-reference-.md)   
 [#pragma checksum](../preprocessor-directives/sharppragma-checksum--csharp-reference-.md)