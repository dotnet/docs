---
title: "System event log cannot be deleted | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
ms.assetid: 26ca8819-4ce5-49c6-98f3-27fe9e2e8e3d
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# System event log cannot be deleted
An attempt has been made to delete the system event log, which cannot be deleted. The system log tracks system events such as system startup and hardware failures.  
  
## To correct this error  
  
-   Consider having your application write to an application or custom log, rather than the system event log.  
  
-   Do not attempt to delete the system event log.  
  
## See Also  
 [Administering Event Logs](https://msdn.microsoft.com/library/4f69axw4(v=vs.100).aspx)   
 [How to: Create and Remove Custom Event Logs](https://msdn.microsoft.com/library/49dwckkz(v=vs.100).aspx)
