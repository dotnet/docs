---
description: "Learn more about: Constant and Literal Data Types (Visual Basic)"
title: "Constant and Literal Data Types"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "declaring constants [Visual Basic], literal data types"
  - "data types [Visual Basic], declaring"
  - "constants [Visual Basic], declaring"
  - "explicit declarations"
  - "literals [Visual Basic], coercing data type"
  - "declarations [Visual Basic], data types"
ms.assetid: 057206d2-3a5b-40b9-b3af-57446f9b52fa
---
# Constant and Literal Data Types (Visual Basic)

A literal is a value that is expressed as itself rather than as a variable's value or the result of an expression, such as the number 3 or the string "Hello". A constant is a meaningful name that takes the place of a literal and retains this same value throughout the program, as opposed to a variable, whose value may change.  
  
 When [Option Infer](../../../language-reference/statements/option-infer-statement.md) is `Off` and [Option Strict](../../../language-reference/statements/option-strict-statement.md) is `On`, you must declare all constants explicitly with a data type. In the following example, the data type of `MyByte` is explicitly declared as data type `Byte`:  
  
 [!code-vb[VbVbalrConstants#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrConstants/VB/Class1.vb#1)]  
  
 When `Option Infer` is `On` or `Option Strict` is `Off`, you can declare a constant without specifying a data type with an `As` clause. The compiler determines the type of the constant from the type of the expression. A numeric integer literal is cast by default to the `Integer` data type. The default data type for floating-point numbers is `Double`, and the keywords `True` and `False` specify a `Boolean` constant.  
  
## Literals and Type Coercion  

 In some cases, you might want to force a literal to a particular data type; for example, when assigning a particularly large integral literal value to a variable of type `Decimal`. The following example produces an error:  
  
```vb  
Dim myDecimal as Decimal  
myDecimal = 100000000000000000000   ' This causes a compiler error.  
```  
  
 The error results from the representation of the literal. The `Decimal` data type can hold a value this large, but the literal is implicitly represented as a `Long`, which cannot.  
  
 You can coerce a literal to a particular data type in two ways: by appending a type character to it, or by placing it within enclosing characters. A type character or enclosing characters must immediately precede and/or follow the literal, with no intervening space or characters of any kind.  
  
 To make the previous example work, you can append the `D` type character to the literal, which causes it to be represented as a `Decimal`:  
  
 [!code-vb[VbVbalrConstants#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrConstants/VB/Class1.vb#2)]  
  
 The following example demonstrates correct usage of type characters and enclosing characters:  
  
 [!code-vb[VbVbalrConstants#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrConstants/VB/Class1.vb#3)]  
  
 The following table shows the enclosing characters and type characters available in Visual Basic.  
  
|Data type|Enclosing character|Appended type character|  
|---|---|---|  
|`Boolean`|(none)|(none)|  
|`Byte`|(none)|(none)|  
|`Char`|"|C|  
|`Date`|#|(none)|  
|`Decimal`|(none)|D or @|  
|`Double`|(none)|R or #|  
|`Integer`|(none)|I or %|  
|`Long`|(none)|L or &|  
|`Short`|(none)|S|  
|`Single`|(none)|F or !|  
|`String`|"|(none)|  
  
## See also

- [User-Defined Constants](user-defined-constants.md)
- [How to: Declare A Constant](how-to-declare-a-constant.md)
- [Constants Overview](constants-overview.md)
- [Option Strict Statement](../../../language-reference/statements/option-strict-statement.md)
- [Option Explicit Statement](../../../language-reference/statements/option-explicit-statement.md)
- [Enumerations Overview](enumerations-overview.md)
- [How to: Declare an Enumeration](how-to-declare-enumerations.md)
- [Enumerations and Name Qualification](enumerations-and-name-qualification.md)
- [Data Types](../../../language-reference/data-types/index.md)
- [Constants and Enumerations](../../../language-reference/constants-and-enumerations.md)
