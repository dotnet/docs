---
title: "Enumerations and Name Qualification (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "declarations [Visual Basic], enumerations"
  - "Imports statement [Visual Basic], namespace declarations"
  - "declaring namespaces [Visual Basic], enumerations"
  - "name collisions"
  - "ambiguous names [Visual Basic], enumerations"
  - "enumerations [Visual Basic], name qualification"
  - "names [Visual Basic], avoiding conflicts"
  - "namespaces [Visual Basic], declaring"
  - "naming conflicts, enumerations"
  - "naming conflicts, qualifying names"
  - "declaring enumerations"
  - "references [Visual Basic], enumeration members"
  - "naming conventions [Visual Basic], naming conflicts"
  - "declarations [Visual Basic], namespaces"
ms.assetid: 08ba2738-df52-4140-bc55-f57c871c9b73
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
---
# Enumerations and Name Qualification (Visual Basic)
Normally, when referring to a member of an enumeration, you must qualify the member name with the enumeration name. For example, to refer to the `Sunday` member of your `Days` enumeration, you would use the following syntax:  
  
 [!code-vb[VbEnumsTask#18](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/enumerations-and-name-qualification_1.vb)]  
  
## Using the Imports Statement  
 You can avoid using fully qualified names by adding an `Imports` statement to the namespace declarations section of your code, as in the following example:  
  
 [!code-vb[VbEnumsTask#22](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/enumerations-and-name-qualification_2.vb)]  
  
 An `Imports` statement imports namespace names from referenced projects and assemblies and from within the same project as the module in which the statement appears. Once this statement is added, you can refer to your enumeration members without qualification, as in the following example:  
  
 [!code-vb[VbEnumsTask#24](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/enumerations-and-name-qualification_3.vb)]  
  
 By organizing sets of related constants in enumerations, you can use the same constant names in different contexts. For example, you can use the same names for the weekday constants in the `Days` and `WorkDays` enumerations. If you use the `Imports` statement with your enumerations, you must be careful to avoid ambiguous references. Consider the following example:  
  
 [!code-vb[VbEnumsTask#22](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/enumerations-and-name-qualification_2.vb)]  
  
 [!code-vb[VbEnumsTask#25](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/enumerations-and-name-qualification_4.vb)]  
  
 Assuming that `Monday` is a member of both the `Days` enumeration and the `Workdays` enumeration, this code generates a compiler error. To avoid ambiguous references when referring to an individual constant, qualify the constant name with its enumeration. The following code refers to the `Saturday` constants in the `Days` and `WorkDays` enumerations.  
  
 [!code-vb[VbEnumsTask#32](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/enumerations-and-name-qualification_5.vb)]  
  
## See Also  
 [Constants and Enumerations](../../../../visual-basic/language-reference/constants-and-enumerations.md)  
 [How to: Declare an Enumeration](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-declare-enumerations.md)  
 [How to: Refer to an Enumeration Member](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-refer-to-an-enumeration-member.md)  
 [How to: Iterate Through An Enumeration in Visual Basic](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-iterate-through-an-enumeration.md)  
 [How to: Determine the String Associated with an Enumeration Value](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-determine-the-string-associated-with-an-enumeration-value.md)  
 [When to Use an Enumeration](../../../../visual-basic/programming-guide/language-features/constants-enums/when-to-use-an-enumeration.md)  
 [Constant and Literal Data Types](../../../../visual-basic/programming-guide/language-features/constants-enums/constant-and-literal-data-types.md)  
 [Enum Statement](../../../../visual-basic/language-reference/statements/enum-statement.md)  
 [Imports Statement (.NET Namespace and Type)](../../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md)  
 [Data Types](../../../../visual-basic/language-reference/data-types/data-type-summary.md)
