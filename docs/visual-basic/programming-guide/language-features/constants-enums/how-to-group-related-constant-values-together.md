---
description: "Learn more about: How to: Group Related Constant Values Together (Visual Basic)"
title: "How to: Group Related Constant Values Together"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "enumerations [Visual Basic], constants"
  - "constants [Visual Basic], grouping together"
ms.assetid: 09d61da5-c940-4126-a79f-ba93c36653dc
---
# How to: Group Related Constant Values Together (Visual Basic)

An enumeration is the best way to group related constants together. You create an enumeration with the `Enum` statement in the declarations section of a class or a module. For more information, see [How to: Declare an Enumeration](how-to-declare-enumerations.md).  
  
### To group related constant values  
  
1. Write a declaration that includes a code access level, the `Enum` keyword, and a valid name. This example creates the `Private` enumeration, `temperatureValues`.  
  
     [!code-vb[VbEnumsTask#21](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#21)]  
  
2. Define the constants in the enumeration. This example creates the `Public` enumeration `temperatureValues` and assigns its values.  
  
     [!code-vb[VbEnumsTask#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#1)]  
  
## See also

- [Enumerations and Name Qualification](enumerations-and-name-qualification.md)
- [How to: Refer to an Enumeration Member](how-to-refer-to-an-enumeration-member.md)
- [When to Use an Enumeration](when-to-use-an-enumeration.md)
- [Constants Overview](constants-overview.md)
- [Constant and Literal Data Types](constant-and-literal-data-types.md)
- [Constants and Enumerations](../../../language-reference/constants-and-enumerations.md)
