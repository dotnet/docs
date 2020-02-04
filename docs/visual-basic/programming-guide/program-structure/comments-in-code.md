---
title: "Comments in Code"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "Uncomment button"
  - "REM statement [Visual Basic]"
  - "comments [Visual Basic], in code"
  - "comments [Visual Basic], Visual Basic code"
  - "Comment button"
  - "buttons [Visual Basic], Uncomment"
  - "buttons [Visual Basic], Comment"
  - "code comments [Visual Basic], Visual Basic"
  - "Visual Basic code, comments"
  - "comments"
  - "code comments"
ms.assetid: 90136fba-22eb-49f9-ba81-63db629b4a47
---
# Comments in Code (Visual Basic)
As you read the code examples, you often encounter the comment symbol (`'`). This symbol tells the Visual Basic compiler to ignore the text following it, or the *comment*. Comments are brief explanatory notes added to code for the benefit of those reading it.  
  
 It is good programming practice to begin all procedures with a brief comment describing the functional characteristics of the procedure (what it does). This is for your own benefit and the benefit of anyone else who examines the code. You should separate the implementation details (how the procedure does it) from comments that describe the functional characteristics. When you include implementation details in the description, remember to update them when you update the function.  
  
 Comments can follow a statement on the same line, or occupy an entire line. Both are illustrated in the following code.  
  
 [!code-vb[VbVbcnConventions#16](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnConventions/VB/Class1.vb#16)]  
  
 If your comment requires more than one line, use the comment symbol on each line, as the following example illustrates.  
  
 [!code-vb[VbVbcnConventions#17](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnConventions/VB/Class1.vb#17)]  
  
## Commenting Guidelines  
 The following table provides general guidelines for what types of comments can precede a section of code. These are suggestions; Visual Basic does not enforce rules for adding comments. Write what works best, both for you and for anyone else who reads your code.  
  
|||  
|---|---|  
|Comment type|Comment description|  
|Purpose|Describes what the procedure does (not how it does it)|  
|Assumptions|Lists each external variable, control, open file, or other element accessed by the procedure|  
|Effects|Lists each affected external variable, control, or file, and the effect it has (only if it is not obvious)|  
|Inputs|Specifies the purpose of the argument|  
|Returns|Explains the values returned by the procedure|  
  
 Remember the following points:  
  
- Every important variable declaration should be preceded by a comment describing the use of the variable being declared.  
  
- Variables, controls, and procedures should be named clearly enough that commenting is needed only for complex implementation details.  
  
- Comments cannot follow a line-continuation sequence on the same line.  
  
 You can add or remove comment symbols for a block of code by selecting one or more lines of code and choosing the **Comment** (![The Visual Basic Comment button in Visual Studio.](./media/comments-in-code/visual-basic-comment-button.gif)) and **Uncomment** (![The Visual Basic Uncomment button in Visual Studio.](./media/comments-in-code/visual-basic-uncomment-button.gif)) buttons on the **Edit** toolbar.  
  
> [!NOTE]
> You can also add comments to your code by preceding the text with the `REM` keyword. However, the `'` symbol and the **Comment**/**Uncomment** buttons are easier to use and require less space and memory.  
  
## See also

- [Basic Instincts - Documenting Your Code With XML Comments](https://docs.microsoft.com/archive/msdn-magazine/2009/may/documenting-your-code-with-xml-comments)
- [How to: Create XML Documentation](../../../visual-basic/programming-guide/program-structure/how-to-create-xml-documentation.md)
- [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/index.md)
- [Program Structure and Code Conventions](../../../visual-basic/programming-guide/program-structure/program-structure-and-code-conventions.md)
- [REM Statement](../../../visual-basic/language-reference/statements/rem-statement.md)
