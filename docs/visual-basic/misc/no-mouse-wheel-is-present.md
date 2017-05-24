---
title: "No mouse wheel is present | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbrMouse_NoWheelIsPresent"
ms.assetid: e924ffba-4af1-4247-9a6f-d19a03738f62
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
# No mouse wheel is present
The `My.Computer.Mouse.WheelScrollLines` property was called, but the mouse has no scroll wheel.  
  
## To correct this error  
  
-   Check the `My.Computer.Mouse.WheelExists` property to see if the mouse has a scroll wheel before calling the `My.Computer.Mouse.WheelScrollLines` property.  
  
     -or-  
  
-   Install a mouse with a scroll wheel on the computer.  
  
## See Also  
 [My.Computer.Mouse.WheelScrollLines Property](http://msdn.microsoft.com/en-us/67600f96-25d7-4dd9-946a-b46e1fc6a57f)   
 [My.Computer.Mouse.WheelExists Property](http://msdn.microsoft.com/en-us/332d44f7-0b66-4eaa-b4ce-d7f161bfbd07)   
 [Exception and Error Handling in Visual Basic](http://msdn.microsoft.com/en-us/3e351e73-cf23-40ab-8b60-05794160529e)