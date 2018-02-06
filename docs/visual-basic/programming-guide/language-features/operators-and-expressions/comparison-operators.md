---
title: "Comparison Operators in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "comparison operators [Visual Basic], comparing strings"
  - "comparison operators [Visual Basic], comparing objects"
  - "strings [Visual Basic], comparing"
  - "comparison operators [Visual Basic]"
  - "string comparison [Visual Basic], operators"
  - "objects [Visual Basic], comparing"
  - "numbers [Visual Basic], comparing"
  - "Visual Basic code, operators"
  - "string comparison [Visual Basic]"
  - "numeric values [Visual Basic], comparing"
  - "comparison operators [Visual Basic], comparing numeric values"
  - "operators [Visual Basic], comparison"
ms.assetid: 0b570339-5407-474f-8421-e183a8b303ee
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# Comparison Operators in Visual Basic
Comparison operators compare two expressions and return a `Boolean` value that represents the relationship of their values. There are operators for comparing numeric values, operators for comparing strings, and operators for comparing objects. All three types of operators are discussed herein.  
  
## Comparing Numeric Values  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compares numeric values using six numeric comparison operators. Each operator takes as operands two expressions that evaluate to numeric values. The following table lists the operators and shows examples of each.  
  
|Operator|Condition tested|Examples|  
|--------------|----------------------|--------------|  
|`=` (Equality)|Is the value of the first expression equal to the value of the second?|`23`   `=`   `33    ' False`<br /><br /> `23`   `=`   `23    ' True`<br /><br /> `23`   `=`   `12    ' False`|  
|`<>` (Inequality)|Is the value of the first expression unequal to the value of the second?|`23`   `<>`   `33    ' True`<br /><br /> `23`   `<>`   `23    ' False`<br /><br /> `23`   `<>`   `12    ' True`|  
|`<` (Less than)|Is the value of the first expression less than the value of the second?|`23`   `<`   `33    ' True`<br /><br /> `23`   `<`   `23    ' False`<br /><br /> `23`   `<`   `12    ' False`|  
|`>` (Greater than)|Is the value of the first expression greater than the value of the second?|`23`   `>`   `33    ' False`<br /><br /> `23`   `>`   `23    ' False`<br /><br /> `23`   `>`   `12    ' True`|  
|`<=` (Less than or equal to)|Is the value of the first expression less than or equal to the value of the second?|`23`   `<=`   `33    ' True`<br /><br /> `23`   `<=`   `23    ' True`<br /><br /> `23`   `<=`   `12    ' False`|  
|`>=` (Greater than or equal to)|Is the value of the first expression greater than or equal to the value of the second?|`23`   `>=`   `33    ' False`<br /><br /> `23`   `>=`   `23    ' True`<br /><br /> `23`   `>=`   `12    ' True`|  
  
## Comparing Strings  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compares strings using the [Like Operator](../../../../visual-basic/language-reference/operators/like-operator.md) as well as the numeric comparison operators. The `Like` operator allows you to specify a pattern. The string is then compared against the pattern, and if it matches, the result is `True`. Otherwise, the result is `False`. The numeric operators allow you to compare `String` values based on their sort order, as the following example shows.  
  
 `"73" < "9"`  
  
 `' The result of the preceding comparison is True.`  
  
 The result in the preceding example is `True` because the first character in the first string sorts before the first character in the second string. If the first characters were equal, the comparison would continue to the next character in both strings, and so on. You can also test equality of strings using the equality operator, as the following example shows.  
  
 `"734" = "734"`  
  
 `' The result of the preceding comparison is True.`  
  
 If one string is a prefix of another, such as "aa" and "aaa", the longer string is considered to be greater than the shorter string. The following example illustrates this.  
  
 `"aaa" > "aa"`  
  
 `' The result of the preceding comparison is True.`  
  
 The sort order is based on either a binary comparison or a textual comparison depending on the setting of `Option Compare`. For more information see [Option Compare Statement](../../../../visual-basic/language-reference/statements/option-compare-statement.md).  
  
## Comparing Objects  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compares two object reference variables with the [Is Operator](../../../../visual-basic/language-reference/operators/is-operator.md) and the [IsNot Operator](../../../../visual-basic/language-reference/operators/isnot-operator.md). You can use either of these operators to determine if two reference variables refer to the same object instance. The following example illustrates this.  
  
 [!code-vb[VbVbalrOperators#65](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/comparison-operators_1.vb)]  
  
 In the preceding example, `x Is y` evaluates to `True`, because both variables refer to the same instance. Contrast this result with the following example.  
  
 [!code-vb[VbVbalrOperators#66](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/comparison-operators_2.vb)]  
  
 In the preceding example, `x Is y` evaluates to `False`, because although the variables refer to objects of the same type, they refer to different instances of that type.  
  
 When you want to test for two objects not pointing to the same instance, the `IsNot` operator lets you avoid a grammatically clumsy combination of `Not` and `Is`. The following example illustrates this.  
  
 [!code-vb[VbVbalrOperators#67](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/comparison-operators_3.vb)]  
  
 In the preceding example, `If a IsNot b` is equivalent to `If Not a Is b`.  
  
### Comparing Object Type  
 You can test whether an object is of a particular type with the `TypeOf`...`Is` expression. The syntax is as follows:  
  
 `TypeOf <objectexpression> Is <typename>`  
  
 When `typename` specifies an interface type, then the `TypeOf`...`Is` expression returns `True` if the object implements the interface type. When `typename` is a class type, then the expression returns `True` if the object is an instance of the specified class or of a class that derives from the specified class. The following example illustrates this.  
  
 [!code-vb[VbVbalrOperators#68](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/comparison-operators_4.vb)]  
  
 In the preceding example, the `TypeOf x Is Control` expression evaluates to `True` because the type of `x` is `Button`, which inherits from `Control`.  
  
 For more information, see [TypeOf Operator](../../../../visual-basic/language-reference/operators/typeof-operator.md).  
  
## See Also  
 [Value Comparisons](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/value-comparisons.md)  
 [Comparison Operators](../../../../visual-basic/language-reference/operators/comparison-operators.md)  
 [Operators](../../../../visual-basic/language-reference/operators/index.md)  
 [Arithmetic Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/arithmetic-operators.md)  
 [Concatenation Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/concatenation-operators.md)  
 [Logical and Bitwise Operators in Visual Basic](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/logical-and-bitwise-operators.md)
