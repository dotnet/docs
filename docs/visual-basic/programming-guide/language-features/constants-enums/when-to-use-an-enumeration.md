---
title: "When to Use an Enumeration (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "enumerations [Visual Basic]"
ms.assetid: e6e47b5b-3ed9-452d-a481-9c3fed88519a
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# When to Use an Enumeration (Visual Basic)
Enumerations offer an easy way to work with sets of related constants. An enumeration, or `Enum`, is a symbolic name for a set of values. Enumerations are treated as data types, and you can use them to create sets of constants for use with variables and properties.  
  
## When to Use an Enumeration  
 Whenever a procedure accepts a limited set of variables, consider using an enumeration. Enumerations make for clearer and more readable code, particularly when meaningful names are used.  
  
 The benefits of using enumerations include:  
  
-   Reduces errors caused by transposing or mistyping numbers.  
  
-   Makes it easy to change values in the future.  
  
-   Makes code easier to read, which means it is less likely that errors will creep into it.  
  
-   Ensures forward compatibility. With enumerations, your code is less likely to fail if in the future someone changes the values corresponding to the member names.  
  
## Naming Enumerations  
 Use a naming convention for enumeration members. When [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] encounters an enumeration member name, an exception may be thrown if other referenced type libraries contain the same name. Use a unique prefix that identifies the values from your application or component.  
  
 When referring to a member of an enumeration, you must qualify the member name with the enumeration name or else use the `Imports` statement. For more information, see [Enumerations and Name Qualification](../../../../visual-basic/programming-guide/language-features/constants-enums/enumerations-and-name-qualification.md).  
  
## Predefined Enumerations  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] provides a number of predefined enumerations, such as `FirstDayOfWeek` and `MsgBoxResult`, to facilitate your code. For a list of these see [Constants and Enumerations](../../../../visual-basic/language-reference/constants-and-enumerations.md).  
  
## See Also  
 [How to: Declare an Enumeration](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-declare-enumerations.md)  
 [How to: Refer to an Enumeration Member](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-refer-to-an-enumeration-member.md)  
 [Enumerations and Name Qualification](../../../../visual-basic/programming-guide/language-features/constants-enums/enumerations-and-name-qualification.md)  
 [How to: Iterate Through An Enumeration in Visual Basic](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-iterate-through-an-enumeration.md)  
 [How to: Determine the String Associated with an Enumeration Value](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-determine-the-string-associated-with-an-enumeration-value.md)  
 [Enum Statement](../../../../visual-basic/language-reference/statements/enum-statement.md)  
 [Constants and Enumerations](../../../../visual-basic/language-reference/constants-and-enumerations.md)
