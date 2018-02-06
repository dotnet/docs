---
title: "#endif (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "#endif"
helpviewer_keywords: 
  - "#endif directive [C#]"
ms.assetid: 6a5fca55-5aee-441f-86f6-1c99fbe9ec05
caps.latest.revision: 9
author: "BillWagner"
ms.author: "wiwagn"
---
# #endif (C# Reference)
`#endif` specifies the end of a conditional directive, which began with the [#if](../../../csharp/language-reference/preprocessor-directives/preprocessor-if.md) directive. For example,  
  
```csharp
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
