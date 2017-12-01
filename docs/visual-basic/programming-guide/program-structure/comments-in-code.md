---
title: "Comments in Code (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
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
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# Comments in Code (Visual Basic)
As you read the code examples, you often encounter the comment symbol (`'`). This symbol tells the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler to ignore the text following it, or the *comment*. Comments are brief explanatory notes added to code for the benefit of those reading it.  
  
 It is good programming practice to begin all procedures with a brief comment describing the functional characteristics of the procedure (what it does). This is for your own benefit and the benefit of anyone else who examines the code. You should separate the implementation details (how the procedure does it) from comments that describe the functional characteristics. When you include implementation details in the description, remember to update them when you update the function.  
  
 Comments can follow a statement on the same line, or occupy an entire line. Both are illustrated in the following code.  
  
 [!code-vb[VbVbcnConventions#16](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/comments-in-code_1.vb)]  
  
 If your comment requires more than one line, use the comment symbol on each line, as the following example illustrates.  
  
 [!code-vb[VbVbcnConventions#17](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/comments-in-code_2.vb)]  
  
## Commenting Guidelines  
 The following table provides general guidelines for what types of comments can precede a section of code. These are suggestions; [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] does not enforce rules for adding comments. Write what works best, both for you and for anyone else who reads your code.  
  
|||  
|---|---|  
|Comment type|Comment description|  
|Purpose|Describes what the procedure does (not how it does it)|  
|Assumptions|Lists each external variable, control, open file, or other element accessed by the procedure|  
|Effects|Lists each affected external variable, control, or file, and the effect it has (only if it is not obvious)|  
|Inputs|Specifies the purpose of the argument|  
|Returns|Explains the values returned by the procedure|  
  
 Remember the following points:  
  
-   Every important variable declaration should be preceded by a comment describing the use of the variable being declared.  
  
-   Variables, controls, and procedures should be named clearly enough that commenting is needed only for complex implementation details.  
  
-   Comments cannot follow a line-continuation sequence on the same line.  
  
 You can add or remove comment symbols for a block of code by selecting one or more lines of code and choosing the **Comment** (![VisualBasicWinAppCodeEditorCommentButton](../../../visual-basic/programming-guide/program-structure/media/vacommentbutton.gif "vaCommentButton")) and **Uncomment** (![VisualStudioWinAppProjectUncommentButton](../../../visual-basic/programming-guide/program-structure/media/vauncommentbutton.gif "vaUncommentButton")) buttons on the **Edit** toolbar.  
  
> [!NOTE]
>  You can also add comments to your code by preceding the text with the `REM` keyword. However, the `'` symbol and the **Comment**/**Uncomment** buttons are easier to use and require less space and memory.  
  
## See Also  
 [Documenting Your Code With XML Comments](http://msdn.microsoft.com/magazine/dd722812.aspx)  
 [How to: Create XML Documentation](../../../visual-basic/programming-guide/program-structure/how-to-create-xml-documentation.md)  
 [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/recommended-xml-tags-for-documentation-comments.md)  
 [Program Structure and Code Conventions](../../../visual-basic/programming-guide/program-structure/program-structure-and-code-conventions.md)  
 [REM Statement](../../../visual-basic/language-reference/statements/rem-statement.md)
