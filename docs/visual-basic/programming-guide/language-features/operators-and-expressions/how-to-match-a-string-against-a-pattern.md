---
title: "How to: Match a String against a Pattern (Visual Basic)"
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
  - "pattern matching"
  - "strings [Visual Basic], comparing"
  - "string comparison [Visual Basic], operators"
  - "Visual Basic code, operators"
  - "pattern matching [Visual Basic], string comparison"
  - "string comparison [Visual Basic]"
  - "Like operator [Visual Basic], pattern matching"
  - "pattern matching, empty strings"
  - "operators [Visual Basic], comparison"
ms.assetid: 19a83804-b5af-4739-928b-ac93e64e457f
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Match a String against a Pattern (Visual Basic)
If you want to find out if an expression of the [String Data Type](../../../../visual-basic/language-reference/data-types/string-data-type.md) satisfies a pattern, then you can use the [Like Operator](../../../../visual-basic/language-reference/operators/like-operator.md).  
  
 `Like` takes two operands. The left operand is a string expression, and the right operand is a string containing the pattern to be used for matching. `Like` returns a `Boolean` value indicating whether the string expression satisfies the pattern.  
  
 You can match each character in the string expression against a specific character, a wildcard character, a character list, or a character range. The positions of the specifications in the pattern string correspond to the positions of the characters to be matched in the string expression.  
  
### To match a character in the string expression against a specific character  
  
-   Put the specific character directly in the pattern string. Certain special characters must be enclosed in brackets (`[ ]`). For more information, see [Like Operator](../../../../visual-basic/language-reference/operators/like-operator.md).  
  
     The following example tests whether `myString` consists exactly of the single character `H`.  
  
     [!code-vb[VbVbalrOperators#70](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-match-a-string-against-a-pattern_1.vb)]  
  
### To match a character in the string expression against a wildcard character  
  
-   Put a question mark (`?`) in the pattern string. Any valid character in this position makes a successful match.  
  
     The following example tests whether `myString` consists of the single character `W` followed by exactly two characters of any values.  
  
     [!code-vb[VbVbalrOperators#71](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-match-a-string-against-a-pattern_2.vb)]  
  
### To match a character in the string expression against a list of characters  
  
-   Put brackets (`[ ]`) in the pattern string, and inside the brackets put the list of characters. Do not separate the characters with commas or any other separator. Any single character in the list makes a successful match.  
  
     The following example tests whether `myString` consists of any valid character followed by exactly one of the characters `A`, `C`, or `E`.  
  
     [!code-vb[VbVbalrOperators#72](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-match-a-string-against-a-pattern_3.vb)]  
  
     Note that this match is case-sensitive.  
  
### To match a character in the string expression against a range of characters  
  
-   Put brackets (`[ ]`) in the pattern string, and inside the brackets put the lowest and highest characters in the range, separated by a hyphen (`–`). Any single character within the range makes a successful match.  
  
     The following example tests whether `myString` consists of the characters `num` followed by exactly one of the characters `i`, `j`, `k`, `l`, `m`, or `n`.  
  
     [!code-vb[VbVbalrOperators#73](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-match-a-string-against-a-pattern_4.vb)]  
  
     Note that this match is case-sensitive.  
  
## Matching Empty Strings  
 `Like` treats the sequence `[]` as a zero-length string (`""`). You can use `[]` to test whether the entire string expression is empty, but you cannot use it to test if a particular position in the string expression is empty. If an empty position is one of the options you need to test for, you can use `Like` more than once.  
  
#### To match a character in the string expression against a list of characters or no character  
  
1.  Call the `Like` operator twice on the same string expression, and connect the two calls with either the [Or Operator](../../../../visual-basic/language-reference/operators/or-operator.md) or the [OrElse Operator](../../../../visual-basic/language-reference/operators/orelse-operator.md).  
  
2.  In the pattern string for the first `Like` clause, include the character list, enclosed in brackets (`[ ]`).  
  
3.  In the pattern string for the second `Like` clause, do not put any character at the position in question.  
  
     The following example tests the seven-digit telephone number `phoneNum` for exactly three numeric digits, followed by a space, a hyphen (`–`), a period (`.`), or no character at all, followed by exactly four numeric digits.  
  
     [!code-vb[VbVbalrOperators#74](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-match-a-string-against-a-pattern_5.vb)]  
  
## See Also  
 [Comparison Operators](../../../../visual-basic/language-reference/operators/comparison-operators.md)  
 [Operators and Expressions](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/index.md)  
 [Like Operator](../../../../visual-basic/language-reference/operators/like-operator.md)  
 [String Data Type](../../../../visual-basic/language-reference/data-types/string-data-type.md)
