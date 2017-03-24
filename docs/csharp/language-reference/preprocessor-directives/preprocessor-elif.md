---
title: "#elif (C# Reference) | Microsoft Docs"
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
  - "#elif"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "#elif directive [C#]"
ms.assetid: 731d78df-08e0-4d51-b8c8-f193c27de13f
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# #elif (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

`#elif` lets you create a compound conditional directive. The `#elif` expression will be evaluated if neither the preceding [#if](../../../csharp/language-reference/preprocessor-directives/preprocessor-if.md) nor any preceding, optional, `#elif` directive expressions evaluate to `true`. If a `#elif` expression evaluates to `true`, the compiler evaluates all the code between the `#elif` and the next conditional directive. For example:  
  
```  
#define VC7  
//...  
#if debug  
    Console.Writeline("Debug build");  
#elif VC7  
    Console.Writeline("Visual Studio 7");  
#endif  
```  
  
 You can use the operators `==` (equality), `!=` (inequality), `&&` (and), and `||` (or), to evaluate multiple symbols. You can also group symbols and operators with parentheses.  
  
## Remarks  
 `#elif` is equivalent to using:  
  
```  
#else  
#if  
```  
  
 Using `#elif` is simpler, because each `#if` requires a [#endif](../../../csharp/language-reference/preprocessor-directives/preprocessor-endif.md), whereas a `#elif` can be used without a matching `#endif`.  
  
 See [#if](../../../csharp/language-reference/preprocessor-directives/preprocessor-if.md) for an example of how to use `#elif`.  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Preprocessor Directives](../../../csharp/language-reference/preprocessor-directives/index.md)