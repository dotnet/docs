---
title: "#endif (C# Reference) | Microsoft Docs"
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
  - "#endif"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "#endif directive [C#]"
ms.assetid: 6a5fca55-5aee-441f-86f6-1c99fbe9ec05
caps.latest.revision: 9
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# #endif (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

`#endif` specifies the end of a conditional directive, which began with the [#if](../../../csharp/language-reference/preprocessor-directives/preprocessor-if.md) directive. For example,  
  
```  
  
      #define DEBUG  
// ...  
#if DEBUG  
    Console.WriteLine("Debug version");  
#endif  
```  
  
## Remarks  
 A conditional directive, beginning with a `#if` directive, must explicitly be terminated with a `#endif` directive. See [#if](../../../csharp/language-reference/preprocessor-directives/preprocessor-if.md) for an example of how to use `#endif`.  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Preprocessor Directives](../../../csharp/language-reference/preprocessor-directives/index.md)