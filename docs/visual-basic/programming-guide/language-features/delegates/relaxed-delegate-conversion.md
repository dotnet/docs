---
description: "Learn more about: Relaxed Delegate Conversion (Visual Basic)"
title: "Relaxed Delegate Conversion"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "relaxed delegate conversion [Visual Basic]"
  - "delegates [Visual Basic], relaxed conversion"
  - "conversions [Visual Basic], relaxed delegate"
ms.assetid: 64f371d0-5416-4f65-b23b-adcbf556e81c
---
# Relaxed Delegate Conversion (Visual Basic)

Relaxed delegate conversion enables you to assign subs and functions to delegates or handlers even when their signatures are not identical. Therefore, binding to delegates becomes consistent with the binding already allowed for method invocations.  
  
## Parameters and Return Type  

 In place of exact signature match, relaxed conversion requires that the following conditions be met when `Option Strict` is set to `On`:  
  
- A widening conversion must exist from the data type of each delegate parameter to the data type of the corresponding parameter of the assigned function or `Sub`. In the following example, the delegate `Del1` has one parameter, an `Integer`. Parameter `m` in the assigned lambda expressions must have a data type for which there is a widening conversion from `Integer`, such as `Long` or `Double`.  
  
     [!code-vb[VbVbalrRelaxedDelegates#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module1.vb#1)]  
  
     [!code-vb[VbVbalrRelaxedDelegates#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module1.vb#2)]  
  
     Narrowing conversions are permitted only when `Option Strict` is set to `Off`.  
  
     [!code-vb[VbVbalrRelaxedDelegates#8](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module2.vb#8)]  
  
- A widening conversion must exist in the opposite direction from the return type of the assigned function or `Sub` to the return type of the delegate. In the following examples, the body of each assigned lambda expression must evaluate to a data type that widens to `Integer` because the return type of `del1` is `Integer`.  
  
     [!code-vb[VbVbalrRelaxedDelegates#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module1.vb#3)]  
  
 If `Option Strict` is set to `Off`, the widening restriction is removed in both directions.  
  
 [!code-vb[VbVbalrRelaxedDelegates#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module2.vb#4)]  
  
## Omitting Parameter Specifications  

 Relaxed delegates also allow you to completely omit parameter specifications in the assigned method:  
  
 [!code-vb[VbVbalrRelaxedDelegates#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module1.vb#5)]  
  
 [!code-vb[VbVbalrRelaxedDelegates#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module1.vb#6)]  
  
 Note that you cannot specify some parameters and omit others.  
  
 [!code-vb[VbVbalrRelaxedDelegates#15](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module1.vb#15)]  
  
 The ability to omit parameters is helpful in a situation such as defining an event handler, where several complex parameters are involved. The arguments to some event handlers are not used. Instead, the handler directly accesses the state of the control on which the event is registered, and ignores the arguments. Relaxed delegates allow you to omit the arguments in such declarations when no ambiguities result. In the following example, the fully specified method `OnClick` can be rewritten as `RelaxedOnClick`.  
  
```vb  
Sub OnClick(ByVal sender As Object, ByVal e As EventArgs) Handles b.Click  
    MessageBox.Show("Hello World from" + b.Text)  
End Sub  
  
Sub RelaxedOnClick() Handles b.Click  
    MessageBox.Show("Hello World from" + b.Text)  
End Sub  
```  
  
## AddressOf Examples  

 Lambda expressions are used in the previous examples to make the type relationships easy to see. However, the same relaxations are permitted for delegate assignments that use `AddressOf`, `Handles`, or `AddHandler`.  
  
 In the following example, functions `f1`, `f2`, `f3`, and `f4` can all be assigned to `Del1`.  
  
 [!code-vb[VbVbalrRelaxedDelegates#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module1.vb#1)]  
  
 [!code-vb[VbVbalrRelaxedDelegates#7](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module1.vb#7)]  
  
 [!code-vb[VbVbalrRelaxedDelegates#9](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module1.vb#9)]  
  
 The following example is valid only when `Option Strict` is set to `Off`.  
  
 [!code-vb[VbVbalrRelaxedDelegates#14](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module2.vb#14)]  
  
## Dropping Function Returns  

 Relaxed delegate conversion enables you to assign a function to a `Sub` delegate, effectively ignoring the return value of the function. However, you cannot assign a `Sub` to a function delegate. In the following example, the address of function `doubler` is assigned to `Sub` delegate `Del3`.  
  
 [!code-vb[VbVbalrRelaxedDelegates#10](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module1.vb#10)]  
  
 [!code-vb[VbVbalrRelaxedDelegates#11](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrRelaxedDelegates/VB/Module1.vb#11)]  
  
## See also

- [Lambda Expressions](../procedures/lambda-expressions.md)
- [Widening and Narrowing Conversions](../data-types/widening-and-narrowing-conversions.md)
- [Delegates](index.md)
- [How to: Pass Procedures to Another Procedure in Visual Basic](how-to-pass-procedures-to-another-procedure.md)
- [Local Type Inference](../variables/local-type-inference.md)
- [Option Strict Statement](../../../language-reference/statements/option-strict-statement.md)
