---
title: "System event log cannot be deleted"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
ms.assetid: 26ca8819-4ce5-49c6-98f3-27fe9e2e8e3d
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# System event log cannot be deleted
An attempt has been made to delete the system event log, which cannot be deleted. The system log tracks system events such as system startup and hardware failures.  
  
## To correct this error  
  
-   Consider having your application write to an application or custom log, rather than the system event log.  
  
-   Do not attempt to delete the system event log.  
  
## See Also  
 [Administering Event Logs](http://msdn.microsoft.com/library/35f53238-bdd2-417b-acd8-2fd9f7397f18)  
 [How to: Create and Remove Custom Event Logs](http://msdn.microsoft.com/library/af9b7da0-80c7-46ac-b7f7-897063ddd503)
