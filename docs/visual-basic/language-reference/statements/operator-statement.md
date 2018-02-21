---
title: "Operator Statement"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.operator"
helpviewer_keywords: 
  - "operators [Visual Basic]"
  - "procedures [Visual Basic], operator"
  - "Narrowing keyword [Visual Basic], conversion operators"
  - "Visual Basic code, operators"
  - "Widening keyword [Visual Basic], conversion operators"
  - "syntax [Visual Basic], Operator procedures"
  - "operators [Visual Basic], overloading"
  - "overloaded operators [Visual Basic]"
  - "operator overloading"
  - "operator procedures"
  - "Operator statement [Visual Basic]"
  - "CType function [Visual Basic], Operator statement"
ms.assetid: b12ec4af-1ad7-4a17-865b-c5ee96320ae5
caps.latest.revision: 28
author: dotnet-bot
ms.author: dotnetcontent
---
# Operator Statement
Declares the operator symbol, operands, and code that define an operator procedure on a class or structure.  
  
## Syntax  
  
```  
[ <attrlist> ] Public [ Overloads ] Shared [ Shadows ] [ Widening | Narrowing ]   
Operator operatorsymbol ( operand1 [, operand2 ]) [ As [ <attrlist> ] type ]  
    [ statements ]  
    [ statements ]  
    Return returnvalue  
    [ statements ]  
End Operator  
```  
  
## Parts  
 `attrlist`  
 Optional. See [Attribute List](../../../visual-basic/language-reference/statements/attribute-list.md).  
  
 `Public`  
 Required. Indicates that this operator procedure has [Public](../../../visual-basic/language-reference/modifiers/public.md) access.  
  
 `Overloads`  
 Optional. See [Overloads](../../../visual-basic/language-reference/modifiers/overloads.md).  
  
 `Shared`  
 Required. Indicates that this operator procedure is a [Shared](../../../visual-basic/language-reference/modifiers/shared.md) procedure.  
  
 `Shadows`  
 Optional. See [Shadows](../../../visual-basic/language-reference/modifiers/shadows.md).  
  
 `Widening`  
 Required for a conversion operator unless you specify `Narrowing`. Indicates that this operator procedure defines a [Widening](../../../visual-basic/language-reference/modifiers/widening.md) conversion. See "Widening and Narrowing Conversions" on this Help page.  
  
 `Narrowing`  
 Required for a conversion operator unless you specify `Widening`. Indicates that this operator procedure defines a [Narrowing](../../../visual-basic/language-reference/modifiers/narrowing.md) conversion. See "Widening and Narrowing Conversions" on this Help page.  
  
 `operatorsymbol`  
 Required. The symbol or identifier of the operator that this operator procedure defines.  
  
 `operand1`  
 Required. The name and type of the single operand of a unary operator (including a conversion operator) or the left operand of a binary operator.  
  
 `operand2`  
 Required for binary operators. The name and type of the right operand of a binary operator.  
  
 `operand1` and `operand2` have the following syntax and parts:  
  
 `[ ByVal ] operandname [ As operandtype ]`  
  
|Part|Description|  
|----------|-----------------|  
|`ByVal`|Optional, but the passing mechanism must be [ByVal](../../../visual-basic/language-reference/modifiers/byval.md).|  
|`operandname`|Required. Name of the variable representing this operand. See [Declared Element Names](../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md).|  
|`operandtype`|Optional unless `Option Strict` is `On`. Data type of this operand.|  
  
 `type`  
 Optional unless `Option Strict` is `On`. Data type of the value the operator procedure returns.  
  
 `statements`  
 Optional. Block of statements that the operator procedure runs.  
  
 `returnvalue`  
 Required. The value that the operator procedure returns to the calling code.  
  
 `End` `Operator`  
 Required. Terminates the definition of this operator procedure.  
  
## Remarks  
 You can use `Operator` only in a class or structure. This means the *declaration context* for an operator cannot be a source file, namespace, module, interface, procedure, or block. For more information, see [Declaration Contexts and Default Access Levels](../../../visual-basic/language-reference/statements/declaration-contexts-and-default-access-levels.md).  
  
 All operators must be `Public Shared`. You cannot specify `ByRef`, `Optional`, or `ParamArray` for either operand.  
  
 You cannot use the operator symbol or identifier to hold a return value. You must use the `Return` statement, and it must specify a value. Any number of `Return` statements can appear anywhere in the procedure.  
  
 Defining an operator in this way is called *operator overloading*, whether or not you use the `Overloads` keyword. The following table lists the operators you can define.  
  
|Type|Operators|  
|----------|---------------|  
|Unary|`+`, `-`, `IsFalse`, `IsTrue`, `Not`|  
|Binary|`+`, `-`, `*`, `/`, `\`, `&`, `^`, `>>`, `<<`, `=`, `<>`, `>`, `>=`, `<`, `<=`, `And`, `Like`, `Mod`, `Or`, `Xor`|  
|Conversion (unary)|`CType`|  
  
 Note that the `=` operator in the binary list is the comparison operator, not the assignment operator.  
  
 When you define `CType`, you must specify either `Widening` or `Narrowing`.  
  
## Matched Pairs  
 You must define certain operators as matched pairs. If you define either operator of such a pair, you must define the other as well. The matched pairs are the following:  
  
-   `=` and `<>`  
  
-   `>` and `<`  
  
-   `>=` and `<=`  
  
-   `IsTrue` and `IsFalse`  
  
## Data Type Restrictions  
 Every operator you define must involve the class or structure on which you define it. This means that the class or structure must appear as the data type of the following:  
  
-   The operand of a unary operator.  
  
-   At least one of the operands of a binary operator.  
  
-   Either the operand or the return type of a conversion operator.  
  
 Certain operators have additional data type restrictions, as follows:  
  
-   If you define the `IsTrue` and `IsFalse` operators, they must both return the `Boolean` type.  
  
-   If you define the `<<` and `>>` operators, they must both specify the `Integer` type for the `operandtype` of `operand2`.  
  
 The return type does not have to correspond to the type of either operand. For example, a comparison operator such as `=` or `<>` can return `Boolean` even if neither operand is `Boolean`.  
  
## Logical and Bitwise Operators  
 The `And`, `Or`, `Not`, and `Xor` operators can perform either logical or bitwise operations in Visual Basic. However, if you define one of these operators on a class or structure, you can define only its bitwise operation.  
  
 You cannot define the `AndAlso` operator directly with an `Operator` statement. However, you can use `AndAlso` if you have fulfilled the following conditions:  
  
-   You have defined `And` on the same operand types you want to use for `AndAlso`.  
  
-   Your definition of `And` returns the same type as the class or structure on which you have defined it.  
  
-   You have defined the `IsFalse` operator on the class or structure on which you have defined `And`.  
  
 Similarly, you can use `OrElse` if you have defined `Or` on the same operands, with the return type of the class or structure, and you have defined `IsTrue` on the class or structure.  
  
## Widening and Narrowing Conversions  
 A *widening conversion* always succeeds at run time, while a *narrowing conversion* can fail at run time. For more information, see [Widening and Narrowing Conversions](../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md).  
  
 If you declare a conversion procedure to be `Widening`, your procedure code must not generate any failures. This means the following:  
  
-   It must always return a valid value of type `type`.  
  
-   It must handle all possible exceptions and other error conditions.  
  
-   It must handle any error returns from any procedures it calls.  
  
 If there is any possibility that a conversion procedure might not succeed, or that it might cause an unhandled exception, you must declare it to be `Narrowing`.  
  
## Example  
 The following code example uses the `Operator` statement to define the outline of a structure that includes operator procedures for the `And`, `Or`, `IsFalse`, and `IsTrue` operators. `And` and `Or` each take two operands of type `abc` and return type `abc`. `IsFalse` and `IsTrue` each take a single operand of type `abc` and return `Boolean`. These definitions allow the calling code to use `And`, `AndAlso`, `Or`, and `OrElse` with operands of type `abc`.  
  
 [!code-vb[VbVbalrStatements#44](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/operator-statement_1.vb)]  
  
## See Also  
 [IsFalse Operator](../../../visual-basic/language-reference/operators/isfalse-operator.md)  
 [IsTrue Operator](../../../visual-basic/language-reference/operators/istrue-operator.md)  
 [Widening](../../../visual-basic/language-reference/modifiers/widening.md)  
 [Narrowing](../../../visual-basic/language-reference/modifiers/narrowing.md)  
 [Widening and Narrowing Conversions](../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md)  
 [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md)  
 [How to: Define an Operator](../../../visual-basic/programming-guide/language-features/procedures/how-to-define-an-operator.md)  
 [How to: Define a Conversion Operator](../../../visual-basic/programming-guide/language-features/procedures/how-to-define-a-conversion-operator.md)  
 [How to: Call an Operator Procedure](../../../visual-basic/programming-guide/language-features/procedures/how-to-call-an-operator-procedure.md)  
 [How to: Use a Class that Defines Operators](../../../visual-basic/programming-guide/language-features/procedures/how-to-use-a-class-that-defines-operators.md)
