---
title: "How to: Refer to an Enumeration Member (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "enumerations [Visual Basic], referring to"
  - "values [Visual Basic], associating constant values with names"
  - "enumeration members"
  - "constants [Visual Basic], enumerated"
ms.assetid: bbb5c3cc-7cdb-4814-8d6a-a6d91546ed1e
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Refer to an Enumeration Member (Visual Basic)
Enumerations provide a convenient way to work with sets of related constants and to associate constant values with names. For example, you can declare an enumeration for a set of integer constants associated with the days of the week, and then use the names of the days rather than their integer values in your code.  
  
 You can avoid using fully qualified names with the `Imports` statement. For more information, see [Enumerations and Name Qualification](../../../../visual-basic/programming-guide/language-features/constants-enums/enumerations-and-name-qualification.md).  
  
### To refer to an enumeration member  
  
-   Qualify the member name with the enumeration. For example, the following example assigns the `Saturday` member of the `FirstDayOfWeek` enumeration to the variable `DayValue`.  
  
     [!code-vb[VbEnumsTask#19](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/how-to-refer-to-an-enumeration-member_1.vb)]  
  
## See Also  
 [How to: Declare an Enumeration](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-declare-enumerations.md)  
 [Enumerations and Name Qualification](../../../../visual-basic/programming-guide/language-features/constants-enums/enumerations-and-name-qualification.md)  
 [How to: Iterate Through An Enumeration in Visual Basic](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-iterate-through-an-enumeration.md)  
 [How to: Determine the String Associated with an Enumeration Value](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-determine-the-string-associated-with-an-enumeration-value.md)  
 [When to Use an Enumeration](../../../../visual-basic/programming-guide/language-features/constants-enums/when-to-use-an-enumeration.md)
