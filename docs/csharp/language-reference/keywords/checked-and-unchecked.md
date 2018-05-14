---
title: "Checked and Unchecked (C# Reference)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "operators [C#], checked and unchecked"
  - "exceptions [C#], overflow checking"
  - "checked statement [C#]"
  - "overflow checking [C#]"
  - "unchecked statement [C#]"
  - "statements [C#], checked and unchecked"
ms.assetid: a84bc877-2c7f-4396-8735-1ce97c42f35e
---
# Checked and Unchecked (C# Reference)
C# statements can execute in either checked or unchecked context. In a checked context, arithmetic overflow raises an exception. In an unchecked context, arithmetic overflow is ignored and the result is truncated.  
  
-   [checked](checked.md) Specify checked context.  
  
-   [unchecked](unchecked.md) Specify unchecked context.  
  
 The following operations are affected by the overflow checking:  
  
-   Expressions using the following predefined operators on integral types:  
  
     `++`, `--`, unary `-`, `+`, `-`, `*`, `/`  
  
-   Explicit numeric conversions between integral types.  
  
 If neither `checked` nor `unchecked` is specified, the default context is defined by the value of the [-checked](../compiler-options/checked-compiler-option.md) compiler option. That option lets you specify checked or unchecked context for all integer arithmetic statements that are not explicitly in the scope of a `checked` or `unchecked` keyword.  
  
## See Also  
 [C# Reference](../index.md)  
 [C# Programming Guide](../../programming-guide/index.md)  
 [C# Keywords](index.md)  
 [Statement Keywords](statement-keywords.md)
