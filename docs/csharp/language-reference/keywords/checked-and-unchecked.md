---
title: "Checked and Unchecked - C# Reference"
ms.custom: seodec18

ms.date: 05/15/2018
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
C# statements can execute in either checked or unchecked context. In a checked context, arithmetic overflow raises an exception. In an unchecked context, arithmetic overflow is ignored and the result is truncated by discarding any high-order bits that don't fit in the destination type.  
  
-   [checked](checked.md) Specify checked context.  
  
-   [unchecked](unchecked.md) Specify unchecked context.  
  
 The following operations are affected by the overflow checking:  
  
-   Expressions using the following predefined operators on integral types:  
  
     `++`, `--`, unary `-`, `+`, `-`, `*`, `/`  
  
-   Explicit numeric conversions between integral types, or from `float` or `double` to an integral type.  
  
 If neither `checked` nor `unchecked` is specified, the default context for non-constant expressions (expressions that are evaluated at run time) is defined by the value of the [-checked](../compiler-options/checked-compiler-option.md) compiler option. By default the value of that option is unset and arithmetic operations are executed in an unchecked context.
 
 For constant expressions (expressions that can be fully evaluated at compile time), the default context is always checked. Unless a constant expression is explicitly placed in an unchecked context, overflows that occur during the compile-time evaluation of the expression cause compile-time errors.
  
## See also

- [C# Reference](../index.md)  
- [C# Programming Guide](../../programming-guide/index.md)  
- [C# Keywords](index.md)  
- [Statement Keywords](statement-keywords.md)
