---
description: "Learn more about: Data Types in Visual Basic"
title: "Data Types"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "data types [Visual Basic], declaring"
  - "typing"
  - "data types [Visual Basic]"
  - "Visual Basic code, data types"
  - "data types [Visual Basic], improving speed with"
ms.assetid: 5e1b9aaf-c7ca-4b29-9b22-0e82ed8e85e2
ms.topic: article
---
# Data Types in Visual Basic

The *data type* of a programming element refers to what kind of data it can hold and how it stores that data. Data types apply to all values that can be stored in computer memory or participate in the evaluation of an expression. Every variable, literal, constant, enumeration, property, procedure parameter, procedure argument, and procedure return value has a data type.  
  
## Declared Data Types  

 You define a programming element with a declaration statement, and you specify its data type with the `As` clause. The following table shows the statements you use to declare various elements.  
  
|Programming element|Data type declaration|  
|-------------------------|---------------------------|  
|Variable|In a [Dim Statement](../../../language-reference/statements/dim-statement.md)<br /><br /> `Dim`   `amount As Double`<br /><br /> `Static`   `yourName As String`<br /><br /> `Public`   `billsPaid As Decimal = 0`|  
|Literal|With a literal type character; see "Literal Type Characters" in [Type Characters](type-characters.md)<br /><br /> `Dim searchChar As Char = "."`  `C`|  
|Constant|In a [Const Statement](../../../language-reference/statements/const-statement.md)<br /><br /> `Const`   `modulus As Single = 4.17825F`|  
|Enumeration|In an [Enum Statement](../../../language-reference/statements/enum-statement.md)<br /><br /> `Public`   `Enum`   `colors`|  
|Property|In a [Property Statement](../../../language-reference/statements/property-statement.md)<br /><br /> `Property`   `region() As String`|  
|Procedure parameter|In a [Sub Statement](../../../language-reference/statements/sub-statement.md), [Function Statement](../../../language-reference/statements/function-statement.md), or [Operator Statement](../../../language-reference/statements/operator-statement.md)<br /><br /> `Sub addSale(ByVal`   `amount`   `As Double)`|  
|Procedure argument|In the calling code; each argument is a programming element that has already been declared, or an expression containing declared elements<br /><br /> `subString = Left(`  `inputString`  `,`   `5`  `)`|  
|Procedure return value|In a [Function Statement](../../../language-reference/statements/function-statement.md) or [Operator Statement](../../../language-reference/statements/operator-statement.md)<br /><br /> `Function convert(ByVal b As Byte)`   `As String`|  
  
 For a list of Visual Basic data types, see [Data Types](../../../language-reference/data-types/index.md).  
  
## See also

- [Type Characters](type-characters.md)
- [Elementary Data Types](elementary-data-types.md)
- [Composite Data Types](composite-data-types.md)
- [Generic Types in Visual Basic](generic-types.md)
- [Value Types and Reference Types](value-types-and-reference-types.md)
- [Type Conversions in Visual Basic](type-conversions.md)
- [Structures](structures.md)
- [Tuples](tuples.md)
- [Troubleshooting Data Types](troubleshooting-data-types.md)
- [Data Types](../../../language-reference/data-types/index.md)
- [Efficient Use of Data Types](efficient-use-of-data-types.md)
