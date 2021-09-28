---
description: "Learn more about: How to: Break and Combine Statements in Code (Visual Basic)"
title: "How to: Break and Combine Statements in Code"
ms.date: 07/20/2015
f1_keywords:
  - "vb._"
helpviewer_keywords:
  - "colons (:)"
  - "line continuation"
  - "_ line-continuation character"
  - ": line separator character"
  - "Visual Basic code, line breaks in"
  - "Visual Basic code, line breaks"
  - "Visual Basic code, line continuation"
  - "long lines of code"
  - "line terminator"
  - "line-continuation sequence"
  - "underscores [Visual Basic], in code"
  - "statements [Visual Basic], line continuation in"
  - "line breaks [Visual Basic], in code"
  - "line-continuation character [Visual Basic]"
  - "Visual Basic code, line continuation in"
  - "statements [Visual Basic], line breaks in"
ms.assetid: dea01dad-a8ac-484a-bb3a-8c45a1b1eccc
---
# How to: Break and Combine Statements in Code (Visual Basic)

When writing your code, you might at times create lengthy statements that necessitate horizontal scrolling in the Code Editor. Although this doesn't affect the way your code runs, it makes it difficult for you or anyone else to read the code as it appears on the monitor. In such cases, you should consider breaking the single long statement into several lines.

## To break a single statement into multiple lines

Use the line-continuation character, which is an underscore (`_`), at the point at which you want the line to break. The underscore must be immediately preceded by a space and immediately followed by a line terminator (carriage return) or (starting with version 16.0) a comment followed by a carriage return.

  > [!NOTE]
  > In some cases, if you omit the line-continuation character, the Visual Basic compiler will implicitly continue the statement on the next line of code. For a list of syntax elements for which you can omit the line-continuation character, see "Implicit Line Continuation" in [Statements](../language-features/statements.md).

  In the following example, the statement is broken into four lines with line-continuation characters terminating all but the last line.

  [!code-vb[VbVbcnConventions#20](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnConventions/VB/Class1.vb#20)]

  Using this sequence makes your code easier to read, both online and when printed.

  The line-continuation character must be the last character on a line. You can't follow it with anything else on the same line.

  Some limitations exist as to where you can use the line-continuation character; for example, you can't use it in the middle of an argument name. You can break an argument list with the line-continuation character, but the individual names of the arguments must remain intact.

  You can't continue a comment by using a line-continuation character. The compiler doesn't examine the characters in a comment for special meaning. For a multiple-line comment, repeat the comment symbol (`'`) on each line.

 Although placing each statement on a separate line is the recommended method, Visual Basic also allows you to place multiple statements on the same line.

## To place multiple statements on the same line

Separate the statements with a colon (`:`), as in the following example:

  [!code-vb[VbVbcnConventions#10](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnConventions/VB/Class1.vb#10)]

## See also

- [Program Structure and Code Conventions](program-structure-and-code-conventions.md)
- [Statements](../language-features/statements.md)
