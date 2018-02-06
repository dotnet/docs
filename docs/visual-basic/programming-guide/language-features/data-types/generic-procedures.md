---
title: "Generic Procedures in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "generic methods [Visual Basic], type inference"
  - "generics [Visual Basic], type inference"
  - "procedures [Visual Basic], generic"
  - "generic procedures"
  - "type inference, generics"
  - "generic methods [Visual Basic]"
  - "type inference"
  - "generics [Visual Basic], procedures"
  - "generic procedures [Visual Basic], type inference"
ms.assetid: 95577b28-137f-4d5c-a149-919c828600e5
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# Generic Procedures in Visual Basic
A *generic procedure*, also called a *generic method*, is a procedure defined with at least one type parameter. This allows the calling code to tailor the data types to its requirements each time it calls the procedure.  
  
 A procedure is not generic simply by virtue of being defined inside a generic class or a generic structure. To be generic, the procedure must take at least one type parameter, in addition to any normal parameters it might take. A generic class or structure can contain nongeneric procedures, and a nongeneric class, structure, or module can contain generic procedures.  
  
 A generic procedure can use its type parameters in its normal parameter list, in its return type if it has one, and in its procedure code.  
  
## Type Inference  
 You can call a generic procedure without supplying any type arguments at all. If you call it this way, the compiler attempts to determine the appropriate data types to pass to the procedure's type arguments. This is called *type inference*. The following code shows a call in which the compiler infers that it should pass type `String` to the type parameter `t`.  
  
 [!code-vb[VbVbalrDataTypes#15](../../../../visual-basic/language-reference/data-types/codesnippet/VisualBasic/generic-procedures_1.vb)]  
  
 If the compiler cannot infer the type arguments from the context of your call, it reports an error. One possible cause of such an error is an array rank mismatch. For example, suppose you define a normal parameter as an array of a type parameter. If you call the generic procedure supplying an array of a different rank (number of dimensions), the mismatch causes type inference to fail. The following code shows a call in which a two-dimensional array is passed to a procedure that expects a one-dimensional array.  
  
 `Public Sub demoSub(Of t)(ByVal arg() As t)`  
  
 `End Sub`  
  
 `Public Sub callDemoSub()`  
  
 `Dim twoDimensions(,) As Integer`  
  
 `demoSub(twoDimensions)`  
  
 `End Sub`  
  
 You can invoke type inference only by omitting all the type arguments. If you supply one type argument, you must supply them all.  
  
 Type inference is supported only for generic procedures. You cannot invoke type inference on generic classes, structures, interfaces, or delegates.  
  
## Example  
  
### Description  
 The following example defines a generic `Function` procedure to find a particular element in an array. It defines one type parameter and uses it to construct the two parameters in the parameter list.  
  
### Code  
 [!code-vb[VbVbalrDataTypes#14](../../../../visual-basic/language-reference/data-types/codesnippet/VisualBasic/generic-procedures_2.vb)]  
  
### Comments  
 The preceding example requires the ability to compare `searchValue` against each element of `searchArray`. To guarantee this ability, it constrains the type parameter `T` to implement the <xref:System.IComparable%601> interface. The code uses the <xref:System.IComparable%601.CompareTo%2A> method instead of the `=` operator, because there is no guarantee that a type argument supplied for `T` supports the `=` operator.  
  
 You can test the `findElement` procedure with the following code.  
  
 [!code-vb[VbVbalrDataTypes#13](../../../../visual-basic/language-reference/data-types/codesnippet/VisualBasic/generic-procedures_3.vb)]  
  
 The preceding calls to `MsgBox` display "0", "1", and "-1" respectively.  
  
## See Also  
 [Generic Types in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/generic-types.md)  
 [How to: Define a Class That Can Provide Identical Functionality on Different Data Types](../../../../visual-basic/programming-guide/language-features/data-types/how-to-define-a-class-that-can-provide-identical-functionality.md)  
 [How to: Use a Generic Class](../../../../visual-basic/programming-guide/language-features/data-types/how-to-use-a-generic-class.md)  
 [Procedures](../../../../visual-basic/programming-guide/language-features/procedures/index.md)  
 [Procedure Parameters and Arguments](../../../../visual-basic/programming-guide/language-features/procedures/procedure-parameters-and-arguments.md)  
 [Type List](../../../../visual-basic/language-reference/statements/type-list.md)  
 [Parameter List](../../../../visual-basic/language-reference/statements/parameter-list.md)
