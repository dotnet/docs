---
title: "Only the first eight characters of a custom log name are significant | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
ms.assetid: db2a0252-9ddd-4e93-a239-6a690cc09557
caps.latest.revision: 10
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
# Only the first eight characters of a custom log name are significant
When checking event log names for uniqueness, only the first eight characters are considered. A conflict may result from event logs that share their first eight characters.  
  
## To correct this error  
  
-   Give the event log a name in which the first eight characters are unique.  
  
## See Also  
 [How to: Create and Remove Custom Event Logs](http://msdn.microsoft.com/en-us/af9b7da0-80c7-46ac-b7f7-897063ddd503)   
 [Administering Event Logs](http://msdn.microsoft.com/en-us/35f53238-bdd2-417b-acd8-2fd9f7397f18)