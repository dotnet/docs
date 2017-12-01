---
title: "Events of shared WithEvents variables cannot be handled by non-shared methods"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30594"
  - "vbc30594"
helpviewer_keywords: 
  - "BC30594"
ms.assetid: 5b9fceb4-ab11-41bb-ad3b-6f1a9da8ae7e
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# Events of shared WithEvents variables cannot be handled by non-shared methods
A variable declared with the `Shared` modifier is a shared variable. A shared variable identifies exactly one storage location. A variable declared with the `WithEvents` modifier asserts that the type to which the variable belongs handles the set of events the variable raises. When a value is assigned to the variable, the property created by the `WithEvents` declaration unhooks any existing event handler and hooks up the new event handler via the `Add` method.  
  
 **Error ID:** BC30594  
  
## To correct this error  
  
-   Declare your event handler `Shared`.  
  
## See Also  
 [Shared](../../../visual-basic/language-reference/modifiers/shared.md)  
 [WithEvents](../../../visual-basic/language-reference/modifiers/withevents.md)
