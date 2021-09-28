---
description: "Learn more about: <<= Operator (Visual Basic)"
title: "<<= Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.<<="
helpviewer_keywords: 
  - "operator <<="
  - "assignment statements [Visual Basic], compound"
  - "<<= operator [Visual Basic]"
  - "statements [Visual Basic], compound assignment"
  - "operator<<="
  - "compound assignment statements [Visual Basic]"
ms.assetid: 8ad26613-faff-4e2f-89ee-63feee33bfda
---
# \<\<= Operator (Visual Basic)

Performs an arithmetic left shift on the value of a variable or property and assigns the result back to the variable or property.  
  
## Syntax  
  
```vb  
variableorproperty <<= amount  
```  
  
## Parts  

 `variableorproperty`  
 Required. Variable or property of an integral type (`SByte`, `Byte`, `Short`, `UShort`, `Integer`, `UInteger`, `Long`, or `ULong`).  
  
 `amount`  
 Required. Numeric expression of a data type that widens to `Integer`.  
  
## Remarks  

 The element on the left side of the `<<=` operator can be a simple scalar variable, a property, or an element of an array. The variable or property cannot be [ReadOnly](../modifiers/readonly.md).  
  
 The `<<=` operator first performs an arithmetic left shift on the value of the variable or property. The operator then assigns the result of that operation back to that variable or property.  
  
 Arithmetic shifts are not circular, which means the bits shifted off one end of the result are not reintroduced at the other end. In an arithmetic left shift, the bits shifted beyond the range of the result data type are discarded, and the bit positions vacated on the right are set to zero.  
  
## Overloading  

 The [<< Operator](left-shift-operator.md) can be *overloaded*, which means that a class or structure can redefine its behavior when an operand has the type of that class or structure. Overloading the `<<` operator affects the behavior of the `<<=` operator. If your code uses `<<=` on a class or structure that overloads `<<`, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  

 The following example uses the `<<=` operator to shift the bit pattern of an `Integer` variable left by the specified amount and assign the result to the variable.  
  
 [!code-vb[VbVbalrOperators#13](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#13)]  
  
## See also

- [<< Operator](left-shift-operator.md)
- [Assignment Operators](assignment-operators.md)
- [Bit Shift Operators](bit-shift-operators.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [Statements](../../programming-guide/language-features/statements.md)
