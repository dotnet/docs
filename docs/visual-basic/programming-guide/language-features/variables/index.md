---
title: "Variables in Visual Basic"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "variables [Visual Basic]"
  - "values [Visual Basic], storing"
ms.assetid: 4cfaa06d-4ae3-4307-897b-cf599dc24caa
---
# Variables in Visual Basic
You often have to store values when you perform calculations with Visual Basic. For example, you might want to calculate several values, compare them, and perform different operations on them, depending on the result of the comparison. You have to retain the values if you want to compare them.  
  
## Usage  
 Visual Basic, just like most programming languages, uses variables for storing values. A *variable* has a name (the word that you use to refer to the value that the variable contains). A variable also has a data type (which determines the kind of data that the variable can store). A variable can represent an array if it has to store an indexed set of closely related data items.  
  
 Local type inference enables you to declare variables without explicitly stating a data type. Instead, the compiler infers the type of the variable from the type of the initialization expression. For more information, see [Local Type Inference](../../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md) and [Option Infer Statement](../../../../visual-basic/language-reference/statements/option-infer-statement.md).  
  
## Assigning Values  
 You use assignment statements to perform calculations and assign the result to a variable, as the following example shows.  
  
 [!code-vb[VbVbalrVariables#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrVariables/VB/Class1.vb#1)]  
  
> [!NOTE]
> The equal sign (`=`) in this example is an assignment operator, not an equality operator. The value is being assigned to the variable `applesSold`.  
  
 For more information, see [How to: Move Data Into and Out of a Variable](../../../../visual-basic/programming-guide/language-features/variables/how-to-move-data-into-and-out-of-a-variable.md).  
  
## Variables and Properties  
 Like a variable, a *property* represents a value that you can access. However, it is more complex than a variable. A property uses code blocks that control how to set and retrieve its value. For more information, see [Differences Between Properties and Variables in Visual Basic](../../../../visual-basic/programming-guide/language-features/procedures/differences-between-properties-and-variables.md).  
  
## See also

- [Variable Declaration](../../../../visual-basic/programming-guide/language-features/variables/variable-declaration.md)
- [Object Variables](../../../../visual-basic/programming-guide/language-features/variables/object-variables.md)
- [Troubleshooting Variables](../../../../visual-basic/programming-guide/language-features/variables/troubleshooting-variables.md)
- [How to: Move Data Into and Out of a Variable](../../../../visual-basic/programming-guide/language-features/variables/how-to-move-data-into-and-out-of-a-variable.md)
- [Differences Between Properties and Variables in Visual Basic](../../../../visual-basic/programming-guide/language-features/procedures/differences-between-properties-and-variables.md)
- [Local Type Inference](../../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)
