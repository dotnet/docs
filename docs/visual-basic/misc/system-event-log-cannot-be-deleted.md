---
title: "System event log cannot be deleted | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 26ca8819-4ce5-49c6-98f3-27fe9e2e8e3d
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
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
  
### To correct this error  
  
-   Consider having your application write to an application or custom log, rather than the system event log.  
  
-   Do not attempt to delete the system event log.  
  
## See Also  
 [Administering Event Logs](http://msdn.microsoft.com/en-us/35f53238-bdd2-417b-acd8-2fd9f7397f18)   
 [How to: Create and Remove Custom Event Logs](http://msdn.microsoft.com/en-us/af9b7da0-80c7-46ac-b7f7-897063ddd503)