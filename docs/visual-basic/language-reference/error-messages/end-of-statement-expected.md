---
title: "End of statement expected"
ms.date: 07/20/2015
f1_keywords: 
  - "bc30205"
  - "vbc30205"
helpviewer_keywords: 
  - "BC30205"
ms.assetid: 53c7f825-a737-4b76-a1fa-f67745b8bd40
---
# End of statement expected
The statement is syntactically complete, but an additional programming element follows the element that completes the statement. A line terminator is required at the end of every statement.
  
 A line terminator divides the characters of a Visual Basic source file into lines. Examples of line terminators are the Unicode carriage return character (&HD), the Unicode linefeed character (&HA), and the Unicode carriage return character followed by the Unicode linefeed character. For more information about line terminators, see the [Visual Basic Language Specification](~/_vblang/spec/lexical-grammar.md#line-terminators).
  
 **Error ID:** BC30205
  
## To correct this error
  
1.  Check to see if two different statements have inadvertently been put on the same line.
  
2.  Insert a line terminator after the element that completes the statement.
  
## See also

- [How to: Break and Combine Statements in Code](../../../visual-basic/programming-guide/program-structure/how-to-break-and-combine-statements-in-code.md)
- [Statements](../../../visual-basic/programming-guide/language-features/statements.md)
