---
title: "Derived classes cannot raise base class events"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc30029"
  - "bc30029"
helpviewer_keywords: 
  - "BC30029"
ms.assetid: 63afa1c6-2f93-4512-a2f0-372455979771
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# Derived classes cannot raise base class events
An event can be raised only from the declaration space in which it is declared. Therefore, a class cannot raise events from any other class, even one from which it is derived.  
  
 **Error ID:** BC30029  
  
## To correct this error  
  
-   Move the `Event` statement or the `RaiseEvent` statement so they are in the same class.  
  
## See Also  
 [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md)  
 [RaiseEvent Statement](../../../visual-basic/language-reference/statements/raiseevent-statement.md)
