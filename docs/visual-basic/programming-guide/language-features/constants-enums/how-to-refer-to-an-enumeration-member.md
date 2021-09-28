---
description: "Learn more about: How to: Refer to an Enumeration Member (Visual Basic)"
title: "How to: Refer to an Enumeration Member"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "enumerations [Visual Basic], referring to"
  - "values [Visual Basic], associating constant values with names"
  - "enumeration members"
  - "constants [Visual Basic], enumerated"
ms.assetid: bbb5c3cc-7cdb-4814-8d6a-a6d91546ed1e
---
# How to: Refer to an Enumeration Member (Visual Basic)

Enumerations provide a convenient way to work with sets of related constants and to associate constant values with names. For example, you can declare an enumeration for a set of integer constants associated with the days of the week, and then use the names of the days rather than their integer values in your code.  
  
 You can avoid using fully qualified names with the `Imports` statement. For more information, see [Enumerations and Name Qualification](enumerations-and-name-qualification.md).  
  
### To refer to an enumeration member  
  
- Qualify the member name with the enumeration. For example, the following example assigns the `Saturday` member of the `FirstDayOfWeek` enumeration to the variable `DayValue`.  
  
     [!code-vb[VbEnumsTask#19](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#19)]  
  
## See also

- [How to: Declare an Enumeration](how-to-declare-enumerations.md)
- [Enumerations and Name Qualification](enumerations-and-name-qualification.md)
- [How to: Iterate Through An Enumeration in Visual Basic](how-to-iterate-through-an-enumeration.md)
- [How to: Determine the String Associated with an Enumeration Value](how-to-determine-the-string-associated-with-an-enumeration-value.md)
- [When to Use an Enumeration](when-to-use-an-enumeration.md)
