---
title: "&#39;&lt;eventname&gt;&#39; is an event, and cannot be called directly"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc32022"
  - "vbc32022"
helpviewer_keywords: 
  - "BC32022"
ms.assetid: 4dcfcb8d-a9fa-46a7-a034-29d9ff3a59b3
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# &#39;&lt;eventname&gt;&#39; is an event, and cannot be called directly
'<`eventname`>' is an event, and so cannot be called directly. Use a `RaiseEvent` statement to raise an event.  
  
 A procedure call specifies an event for the procedure name. An event handler is a procedure, but the event itself is a signaling device, which must be raised and handled.  
  
 **Error ID:** BC32022  
  
## To correct this error  
  
1.  Use a `RaiseEvent` statement to signal an event and invoke the procedure or procedures that handle it.  
  
## See Also  
 [RaiseEvent Statement](../../../visual-basic/language-reference/statements/raiseevent-statement.md)
