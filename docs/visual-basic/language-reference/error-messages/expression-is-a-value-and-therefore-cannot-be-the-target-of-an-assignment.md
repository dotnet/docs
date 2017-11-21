---
title: "Expression is a value and therefore cannot be the target of an assignment"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30068"
  - "vbc30068"
helpviewer_keywords: 
  - "BC30068"
ms.assetid: d65141e1-f31e-4ac5-a3b8-0b2e02a71ebf
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# Expression is a value and therefore cannot be the target of an assignment
A statement attempts to assign a value to an expression. You can assign a value only to a writable variable, property, or array element at run time. The following example illustrates how this error can occur.  
  
```  
Dim yesterday As Integer  
ReadOnly maximum As Integer = 45  
yesterday + 1 = DatePart(DateInterval.Day, Now)  
' The preceding line is an ERROR because of an expression on the left.  
maximum = 50  
' The preceding line is an ERROR because maximum is declared ReadOnly.  
```  
  
 Similar examples could apply to properties and array elements.  
  
 **Indirect Access.** Indirect access through a value type can also generate this error. Consider the following code example, which attempts to set the value of <xref:System.Drawing.Point> by accessing it indirectly through <xref:System.Windows.Forms.Control.Location%2A>.  
  
```  
' Assume this code runs inside Form1.  
Dim exitButton As New System.Windows.Forms.Button()  
exitButton.Text = "Exit this form"  
exitButton.Location.X = 140  
' The preceding line is an ERROR because of no storage for Location.  
```  
  
 The last statement of the preceding example fails because it creates only a temporary allocation for the <xref:System.Drawing.Point> structure returned by the <xref:System.Windows.Forms.Control.Location%2A> property. A structure is a value type, and the temporary structure is not retained after the statement runs. The problem is resolved by declaring and using a variable for <xref:System.Windows.Forms.Control.Location%2A>, which creates a more permanent allocation for the <xref:System.Drawing.Point> structure. The following example shows code that can replace the last statement of the preceding example.  
  
```  
Dim exitLocation as New System.Drawing.Point(140, exitButton.Location.Y)  
exitButton.Location = exitLocation  
```  
  
 **Error ID:** BC30068  
  
## To correct this error  
  
-   If the statement assigns a value to an expression, replace the expression with a single writable variable, property, or array element.  
  
-   If the statement makes indirect access through a value type (usually a structure), create a variable to hold the value type.  
  
-   Assign the appropriate structure (or other value type) to the variable.  
  
-   Use the variable to access the property to assign it a value.  
  
## See Also  
 [Operators and Expressions](../../../visual-basic/programming-guide/language-features/operators-and-expressions/index.md)  
 [Statements](../../../visual-basic/programming-guide/language-features/statements.md)  
 [Troubleshooting Procedures](../../../visual-basic/programming-guide/language-features/procedures/troubleshooting-procedures.md)
