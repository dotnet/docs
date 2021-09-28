---
description: "Learn more about: ByVal (Visual Basic)"
title: "ByVal"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.ByVal"
  - "ByVal"
helpviewer_keywords: 
  - "ByVal keyword [Visual Basic], contexts"
  - "ByVal keyword [Visual Basic]"
ms.assetid: 1eaf4e58-b305-4785-9e3d-e416b9c75598
---
# ByVal (Visual Basic)

Specifies that an argument is passed [by value](../../programming-guide/language-features/procedures/passing-arguments-by-value-and-by-reference.md), so that the called procedure or property cannot change the value of a variable underlying the argument in the calling code. If no modifier is specified, ByVal is the default.

> [!NOTE]
> Because it is the default, you do not have to explicitly specify the `ByVal` keyword in method signatures. It tends to produce noisy code and often leads to the non-default `ByRef` keyword being overlooked.

## Remarks

 The `ByVal` modifier can be used in these contexts:

 [Declare Statement](../statements/declare-statement.md)

 [Function Statement](../statements/function-statement.md)
  
 [Operator Statement](../statements/operator-statement.md)
  
 [Property Statement](../statements/property-statement.md)
  
 [Sub Statement](../statements/sub-statement.md)

## Example

 The following example demonstrates the use of the `ByVal` parameter passing mechanism with a reference type argument. In the example, the argument is `c1`, an instance of class `Class1`. `ByVal` prevents the code in the procedures from changing the underlying value of the reference argument, `c1`, but does not protect the accessible fields and properties of `c1`.

 [!code-vb[VbVbalrKeywords#10](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrKeywords/VB/Class5.vb#10)]

## See also

- [Keywords](../keywords/index.md)
- [Passing Arguments by Value and by Reference](../../programming-guide/language-features/procedures/passing-arguments-by-value-and-by-reference.md)
