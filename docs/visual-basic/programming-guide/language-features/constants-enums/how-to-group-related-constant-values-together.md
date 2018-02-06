---
title: "How to: Group Related Constant Values Together (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "enumerations [Visual Basic], constants"
  - "constants [Visual Basic], grouping together"
ms.assetid: 09d61da5-c940-4126-a79f-ba93c36653dc
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Group Related Constant Values Together (Visual Basic)
An enumeration is the best way to group related constants together. You create an enumeration with the `Enum` statement in the declarations section of a class or a module. For more information, see [How to: Declare an Enumeration](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-declare-enumerations.md).  
  
### To group related constant values  
  
1.  Write a declaration that includes a code access level, the `Enum` keyword, and a valid name. This example creates the `Private` enumeration, `temperatureValues`.  
  
     [!code-vb[VbEnumsTask#21](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/how-to-group-related-constant-values-together_1.vb)]  
  
2.  Define the constants in the enumeration. This example creates the `Public` enumeration `temperatureValues` and assigns its values.  
  
     [!code-vb[VbEnumsTask#1](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/how-to-group-related-constant-values-together_2.vb)]  
  
## See Also  
 [Enumerations and Name Qualification](../../../../visual-basic/programming-guide/language-features/constants-enums/enumerations-and-name-qualification.md)  
 [How to: Refer to an Enumeration Member](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-refer-to-an-enumeration-member.md)  
 [When to Use an Enumeration](../../../../visual-basic/programming-guide/language-features/constants-enums/when-to-use-an-enumeration.md)  
 [Constants Overview](../../../../visual-basic/programming-guide/language-features/constants-enums/constants-overview.md)  
 [Constant and Literal Data Types](../../../../visual-basic/programming-guide/language-features/constants-enums/constant-and-literal-data-types.md)  
 [Constants and Enumerations](../../../../visual-basic/language-reference/constants-and-enumerations.md)
