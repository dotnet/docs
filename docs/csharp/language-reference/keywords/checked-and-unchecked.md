---
title: "Checked and Unchecked (C# Reference) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "operators [C#], checked and unchecked"
  - "exceptions [C#], overflow checking"
  - "checked statement [C#]"
  - "overflow checking [C#]"
  - "unchecked statement [C#]"
  - "statements [C#], checked and unchecked"
ms.assetid: a84bc877-2c7f-4396-8735-1ce97c42f35e
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# Checked and Unchecked (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

C# statements can execute in either checked or unchecked context. In a checked context, arithmetic overflow raises an exception. In an unchecked context, arithmetic overflow is ignored and the result is truncated.  
  
-   [checked](../../../csharp/language-reference/keywords/checked.md) Specify checked context.  
  
-   [unchecked](../../../csharp/language-reference/keywords/unchecked.md) Specify unchecked context.  
  
 If neither `checked` nor `unchecked` is specified, the default context depends on external factors such as compiler options.  
  
 The following operations are affected by the overflow checking:  
  
-   Expressions using the following predefined operators on integral types:  
  
     `++` `--` - (unary)   `+` -   `*` `/`  
  
-   Explicit numeric conversions between integral types.  
  
 The [/checked](../../../csharp/language-reference/compiler-options/checked-csharp-compiler-options.md) compiler option lets you specify checked or unchecked context for all integer arithmetic statements that are not explicitly in the scope of a `checked` or `unchecked` keyword.  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Statement Keywords](../../../csharp/language-reference/keywords/statement-keywords.md)