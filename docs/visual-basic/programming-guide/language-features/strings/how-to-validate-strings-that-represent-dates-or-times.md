---
title: "How to: Validate Strings That Represent Dates or Times (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "strings [Visual Basic], validating"
  - "String data type [Visual Basic], validation"
ms.assetid: ae7d4b29-3436-4032-bdbf-4650eb1c8e19
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Validate Strings That Represent Dates or Times (Visual Basic)
The following code example sets a `Boolean` value that indicates whether a string represents a valid date or time.  
  
## Example  
 [!code-vb[VbVbcnRegEx#2](../../../../visual-basic/programming-guide/language-features/strings/codesnippet/VisualBasic/how-to-validate-strings-that-represent-dates-or-times_1.vb)]  
  
## Compiling the Code  
 Replace `("01/01/03")` and `"9:30 PM"` with the date and time you want to validate. You can replace the string with another hard-coded string, with a `String` variable, or with a method that returns a string, such as `InputBox`.  
  
## Robust Programming  
 Use this method to validate the string before trying to convert the `String` to a `DateTime` variable. By checking the date or time first, you can avoid generating an exception at run time.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Information.IsDate%2A>  
 <xref:Microsoft.VisualBasic.Interaction.InputBox%2A>  
 [Validating Strings in Visual Basic](../../../../visual-basic/programming-guide/language-features/strings/validating-strings.md)
