---
description: "Learn more about: GoTo Statement"
title: "GoTo Statement"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.GoTo"
helpviewer_keywords: 
  - "GoTo statement [Visual Basic]"
  - "control flow [Visual Basic], branching"
  - "unconditional branching [Visual Basic]"
  - "branching [Visual Basic]"
  - "branching [Visual Basic], unconditional"
  - "branching [Visual Basic], conditional"
  - "conditional statements [Visual Basic], GoTo statement"
  - "GoTo statement [Visual Basic], syntax"
ms.assetid: 313274c2-8ab3-4b9c-9ba3-0fd6798e4f6d
---
# GoTo Statement

Branches unconditionally to a specified line in a procedure.  
  
## Syntax  
  
```vb  
GoTo line  
```  
  
## Part  

 `line`  
 Required. Any line label.  
  
## Remarks  

 The `GoTo` statement can branch only to lines in the procedure in which it appears. The line must have a line label that `GoTo` can refer to. For more information, see [How to: Label Statements](../../programming-guide/program-structure/how-to-label-statements.md).  
  
> [!NOTE]
> `GoTo` statements can make code difficult to read and maintain. Whenever possible, use a control structure instead. For more information, see [Control Flow](../../programming-guide/language-features/control-flow/index.md).  
  
 You cannot use a `GoTo` statement to branch from outside a `For`...`Next`, `For Each`...`Next`, `SyncLock`...`End SyncLock`, `Try`...`Catch`...`Finally`, `With`...`End With`, or `Using`...`End Using` construction to a label inside.  
  
## Branching and Try Constructions  

 Within a `Try`...`Catch`...`Finally` construction, the following rules apply to branching with the `GoTo` statement.  
  
|Block or region|Branching in from outside|Branching out from inside|  
|---------------------|-------------------------------|-------------------------------|  
|`Try` block|Only from a `Catch` block of the same construction <sup>1</sup>|Only to outside the whole construction|  
|`Catch` block|Never allowed|Only to outside the whole construction, or to the `Try` block of the same construction <sup>1</sup>|  
|`Finally` block|Never allowed|Never allowed|  
  
 <sup>1</sup> If one `Try`...`Catch`...`Finally` construction is nested within another, a `Catch` block can branch into the `Try` block at its own nesting level, but not into any other `Try` block. A nested `Try`...`Catch`...`Finally` construction must be contained completely in a `Try` or `Catch` block of the construction within which it is nested.  
  
 The following illustration shows one `Try` construction nested within another. Various branches among the blocks of the two constructions are indicated as valid or invalid.  
  
 ![Graphic diagram of branching in Try constructions](./media/goto-statement/try-construction-branching.gif)  
  
## Example  

 The following example uses the `GoTo` statement to branch to line labels in a procedure.  
  
 [!code-vb[VbVbalrStatements#31](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#31)]  
  
## See also

- [Do...Loop Statement](do-loop-statement.md)
- [For...Next Statement](for-next-statement.md)
- [For Each...Next Statement](for-each-next-statement.md)
- [If...Then...Else Statement](if-then-else-statement.md)
- [Select...Case Statement](select-case-statement.md)
- [Try...Catch...Finally Statement](try-catch-finally-statement.md)
- [While...End While Statement](while-end-while-statement.md)
- [With...End With Statement](with-end-with-statement.md)
