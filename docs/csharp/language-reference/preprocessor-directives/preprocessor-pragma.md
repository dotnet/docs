---
title: "#pragma (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "#pragma"
helpviewer_keywords: 
  - "#pragma directive [C#]"
ms.assetid: 5b7944cd-d402-46a1-ad8f-feffb2d83673
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
---
# #pragma (C# Reference)
`#pragma` gives the compiler special instructions for the compilation of the file in which it appears. The instructions must be supported by the compiler. In other words, you cannot use `#pragma` to create custom preprocessing instructions. The Microsoft C# compiler supports the following two `#pragma` instructions:  
  
 [#pragma warning](../../../csharp/language-reference/preprocessor-directives/preprocessor-pragma-warning.md)  
  
 [#pragma checksum](../../../csharp/language-reference/preprocessor-directives/preprocessor-pragma-checksum.md)  
  
## Syntax  
  
```csharp
#pragma pragma-name pragma-arguments  
```  
  
#### Parameters  
 `pragma-name`  
 The name of a recognized pragma.  
  
 `pragma-arguments`  
 Pragma-specific arguments.  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Preprocessor Directives](../../../csharp/language-reference/preprocessor-directives/index.md)  
 [#pragma warning](../../../csharp/language-reference/preprocessor-directives/preprocessor-pragma-warning.md)  
 [#pragma checksum](../../../csharp/language-reference/preprocessor-directives/preprocessor-pragma-checksum.md)
