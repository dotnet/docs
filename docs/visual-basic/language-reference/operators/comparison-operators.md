---
title: "Comparison Operators (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.<>"
  - "vb.>="
  - "vb.<="
  - "vb.>"
  - "vb.<"
helpviewer_keywords: 
  - "greater than or equal to operator [Visual Basic]"
  - ">= operator [Visual Basic]"
  - "= operator [Visual Basic]"
  - "< operator [Visual Basic]"
  - "less than operator [Visual Basic]"
  - "relational operators [Visual Basic], syntax"
  - "Like operator [Visual Basic]"
  - "<> operator [Visual Basic]"
  - "> operator [Visual Basic]"
  - "equal operator [Visual Basic]"
  - "less than or equal to operator [Visual Basic]"
  - "symbols, operators"
  - "greater than operator [Visual Basic]"
  - "comparing values [Visual Basic]"
  - "operators [Visual Basic], relational"
  - "string comparison [Visual Basic]"
  - "not equal to comparison operator [Visual Basic]"
  - "<= operator [Visual Basic]"
  - "operators [Visual Basic], comparison"
  - "Is operator [Visual Basic]"
  - "comparison operators [Visual Basic], Visual Basicl"
ms.assetid: d6cb12a8-e52e-46a7-8aaf-f804d634a825
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
---
# Comparison Operators (Visual Basic)
The following are the comparison operators defined in Visual Basic.  
  
 `<` operator  
  
 `<=` operator  
  
 `>` operator  
  
 `>=` operator  
  
 `=` operator  
  
 `<>` operator  
  
 [Is Operator](../../../visual-basic/language-reference/operators/is-operator.md)  
  
 [IsNot Operator](../../../visual-basic/language-reference/operators/isnot-operator.md)  
  
 [Like Operator](../../../visual-basic/language-reference/operators/like-operator.md)  
  
 These operators compare two expressions to determine whether or not they are equal, and if not, how they differ. `Is`, `IsNot`, and `Like` are discussed in detail on separate Help pages. The relational comparison operators are discussed in detail on this page.  
  
## Syntax  
  
```  
      result = expression1 comparisonoperator expression2  
result = object1 [Is | IsNot] object2  
result = string Like pattern  
```  
  
## Parts  
 `result`  
 Required. A `Boolean` value representing the result of the comparison.  
  
 `expression`  
 Required. Any expression.  
  
 `comparisonoperator`  
 Required. Any relational comparison operator.  
  
 `object1`, `object2`  
 Required. Any reference object names.  
  
 `string`  
 Required. Any `String` expression.  
  
 `pattern`  
 Required. Any `String` expression or range of characters.  
  
## Remarks  
 The following table contains a list of the relational comparison operators and the conditions that determine whether `result` is `True` or `False`.  
  
|Operator|`True` if|`False` if|  
|--------------|---------------|----------------|  
|`<` (Less than)|`expression1` < `expression2`|`expression1` >= `expression2`|  
|`<=` (Less than or equal to)|`expression1` <= `expression2`|`expression1` > `expression2`|  
|`>` (Greater than)|`expression1` > `expression2`|`expression1` <= `expression2`|  
|`>=` (Greater than or equal to)|`expression1` >= `expression2`|`expression1` < `expression2`|  
|`=` (Equal to)|`expression1` = `expression2`|`expression1` <> `expression2`|  
|`<>` (Not equal to)|`expression1` <> `expression2`|`expression1` = `expression2`|  
  
> [!NOTE]
>  The [= Operator](../../../visual-basic/language-reference/operators/assignment-operator.md) is also used as an assignment operator.  
  
 The `Is` operator, the `IsNot` operator, and the `Like` operator have specific comparison functionalities that differ from the operators in the preceding table.  
  
## Comparing Numbers  
 When you compare an expression of type `Single` to one of type `Double`, the `Single` expression is converted to `Double`. This behavior is opposite to the behavior found in Visual Basic 6.  
  
 Similarly, when you compare an expression of type `Decimal` to an expression of type `Single` or `Double`, the `Decimal` expression is converted to `Single` or `Double`. For `Decimal` expressions, any fractional value less than 1E-28 might be lost. Such fractional value loss may cause two values to compare as equal when they are not. For this reason, you should take care when using equality (`=`) to compare two floating-point variables. It is safer to test whether the absolute value of the difference between the two numbers is less than a small acceptable tolerance.  
  
### Floating-point Imprecision  
 When you work with floating-point numbers, keep in mind that they do not always have a precise representation in memory. This could lead to unexpected results from certain operations, such as value comparison and the [Mod Operator](../../../visual-basic/language-reference/operators/mod-operator.md). For more information, see [Troubleshooting Data Types](../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md).  
  
## Comparing Strings  
 When you compare strings, the string expressions are evaluated based on their alphabetical sort order, which depends on the `Option Compare` setting.  
  
 `Option Compare Binary` bases string comparisons on a sort order derived from the internal binary representations of the characters. The sort order is determined by the code page. The following example shows a typical binary sort order.  
  
 `A < B < E < Z < a < b < e < z < À < Ê < Ø < à < ê < ø`  
  
 `Option Compare Text` bases string comparisons on a case-insensitive, textual sort order determined by your application's locale. When you set `Option Compare Text` and sort the characters in the preceding example, the following text sort order applies:  
  
 `(A=a) < (À= à) < (B=b) < (E=e) < (Ê= ê) < (Ø = ø) < (Z=z)`  
  
### Locale Dependence  
 When you set `Option Compare Text`, the result of a string comparison can depend on the locale in which the application is running. Two characters might compare as equal in one locale but not in another. If you are using a string comparison to make important decisions, such as whether to accept an attempt to log on, you should be alert to locale sensitivity. Consider either setting `Option Compare Binary` or calling the <xref:Microsoft.VisualBasic.Strings.StrComp%2A>, which takes the locale into account.  
  
## Typeless Programming with Relational Comparison Operators  
 The use of relational comparison operators with `Object` expressions is not allowed under `Option Strict On`. When `Option Strict` is `Off`, and either `expression1` or `expression2` is an `Object` expression, the run-time types determine how they are compared. The following table shows how the expressions are compared and the result from the comparison, depending on the runtime type of the operands.  
  
|If operands are|Comparison is|  
|---------------------|-------------------|  
|Both `String`|Sort comparison based on string sorting characteristics.|  
|Both numeric|Objects converted to `Double`, numeric comparison.|  
|One numeric and one `String`|The `String` is converted to a `Double` and numeric comparison is performed. If the `String` cannot be converted to `Double`, an <xref:System.InvalidCastException> is thrown.|  
|Either or both are reference types other than `String`|An <xref:System.InvalidCastException> is thrown.|  
  
 Numeric comparisons treat `Nothing` as 0. String comparisons treat `Nothing` as `""` (an empty string).  
  
## Overloading  
 The relational comparison operators (`<`. `<=`, `>`, `>=`, `=`, `<>`) can be *overloaded*, which means that a class or structure can redefine their behavior when an operand has the type of that class or structure. If your code uses any of these operators on such a class or structure, be sure you understand the redefined behavior. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
 Notice that the [= Operator](../../../visual-basic/language-reference/operators/assignment-operator.md) can be overloaded only as a relational comparison operator, not as an assignment operator.  
  
## Example  
 The following example shows various uses of relational comparison operators, which you use to compare expressions. Relational comparison operators return a `Boolean` result that represents whether or not the stated expression evaluates to `True`. When you apply the `>` and `<` operators to strings, the comparison is made using the normal alphabetical sorting order of the strings. This order can be dependent on your locale setting. Whether the sort is case-sensitive or not depends on the [Option Compare](../../../visual-basic/language-reference/statements/option-compare-statement.md) setting.  
  
 [!code-vb[VbVbalrOperators#1](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/comparison-operators_1.vb)]  
  
 In the preceding example, the first comparison returns `False` and the remaining comparisons return `True`.  
  
## See Also  
 <xref:System.InvalidCastException>  
 [= Operator](../../../visual-basic/language-reference/operators/assignment-operator.md)  
 [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)  
 [Troubleshooting Data Types](../../../visual-basic/programming-guide/language-features/data-types/troubleshooting-data-types.md)  
 [Comparison Operators in Visual Basic](../../../visual-basic/programming-guide/language-features/operators-and-expressions/comparison-operators.md)
