---
title: "Data Types in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "data types [Visual Basic], declaring"
  - "typing"
  - "data types [Visual Basic]"
  - "Visual Basic code, data types"
  - "data types [Visual Basic], improving speed with"
ms.assetid: 5e1b9aaf-c7ca-4b29-9b22-0e82ed8e85e2
caps.latest.revision: 28
author: dotnet-bot
ms.author: dotnetcontent
---
# Data Types in Visual Basic
The *data type* of a programming element refers to what kind of data it can hold and how it stores that data. Data types apply to all values that can be stored in computer memory or participate in the evaluation of an expression. Every variable, literal, constant, enumeration, property, procedure parameter, procedure argument, and procedure return value has a data type.  
  
## Declared Data Types  
 You define a programming element with a declaration statement, and you specify its data type with the `As` clause. The following table shows the statements you use to declare various elements.  
  
|Programming element|Data type declaration|  
|-------------------------|---------------------------|  
|Variable|In a [Dim Statement](../../../../visual-basic/language-reference/statements/dim-statement.md)<br /><br /> `Dim`   `amount As Double`<br /><br /> `Static`   `yourName As String`<br /><br /> `Public`   `billsPaid As Decimal = 0`|  
|Literal|With a literal type character; see "Literal Type Characters" in [Type Characters](../../../../visual-basic/programming-guide/language-features/data-types/type-characters.md)<br /><br /> `Dim searchChar As Char = "."`  `C`|  
|Constant|In a [Const Statement](../../../../visual-basic/language-reference/statements/const-statement.md)<br /><br /> `Const`   `modulus As Single = 4.17825F`|  
|Enumeration|In an [Enum Statement](../../../../visual-basic/language-reference/statements/enum-statement.md)<br /><br /> `Public`   `Enum`   `colors`|  
|Property|In a [Property Statement](../../../../visual-basic/language-reference/statements/property-statement.md)<br /><br /> `Property`   `region() As String`|  
|Procedure parameter|In a [Sub Statement](../../../../visual-basic/language-reference/statements/sub-statement.md), [Function Statement](../../../../visual-basic/language-reference/statements/function-statement.md), or [Operator Statement](../../../../visual-basic/language-reference/statements/operator-statement.md)<br /><br /> `Sub addSale(ByVal`   `amount`   `As Double)`|  
|Procedure argument|In the calling code; each argument is a programming element that has already been declared, or an expression containing declared elements<br /><br /> `subString = Left(`  `inputString`  `,`   `5`  `)`|  
|Procedure return value|In a [Function Statement](../../../../visual-basic/language-reference/statements/function-statement.md) or [Operator Statement](../../../../visual-basic/language-reference/statements/operator-statement.md)<br /><br /> `Function convert(ByVal b As Byte)`   `As String`|  
  
 For a list of Visual Basic data types, see [Data Types](../../../../visual-basic/language-reference/data-types/data-type-summary.md).  
  
## See Also  
 [Type Characters](../../../../visual-basic/programming-guide/language-features/data-types/type-characters.md)  
 [Elementary Data Types](../../../../visual-basic/programming-guide/language-features/data-types/elementary-data-types.md)  
 [Composite Data Types](../../../../visual-basic/programming-guide/language-features/data-types/composite-data-types.md)  
 [Generic Types in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/generic-types.md)  
 [Value Types and Reference Types](../../../../visual-basic/programming-guide/language-features/data-types/value-types-and-reference-types.md)  
 [Type Conversions in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/type-conversions.md)  
 [Structures](../../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [Tuples](tuples.md)     
 [Troubleshooting Data Types](../../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)  
 [Data Types](../../../../visual-basic/language-reference/data-types/data-type-summary.md)  
 [Efficient Use of Data Types](../../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)
