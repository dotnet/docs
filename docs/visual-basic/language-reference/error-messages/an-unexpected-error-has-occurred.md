---
title: "An unexpected error has occurred because an operating system resource required for single instance startup cannot be acquired | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net

ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbrAppModel_CantGetMemoryMappedFile"
dev_langs: 
  - "VB"
ms.assetid: 0d9f2a30-ff72-4355-8060-744f22339359
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# An unexpected error has occurred because an operating system resource required for single instance startup cannot be acquired
The application could not acquire a necessary operating system resource. Some of the possible causes for this problem are:  
  
-   The application does not have permissions to create named operating-system objects.  
  
-   The common language runtime does not have permissions to create memory-mapped files.  
  
-   The application needs to access an operating-system object, but another process is using it.  
  
## To correct this error  
  
1.  Check that the application has sufficient permissions to create named operating-system objects.  
  
2.  Check that the common language runtime has sufficient permissions to create memory-mapped files.  
  
3.  Restart the computer to clear any process that may be using the resource needed to connect to the original instance application.  
  
4.  Note the circumstances under which the error occurred, and call Microsoft Product Support Services  
  
## See Also  
 [Application Page, Project Designer (Visual Basic)](https://docs.microsoft.com/visualstudio/ide/reference/application-page-project-designer-visual-basic)   
 [Debugger Basics](https://docs.microsoft.com/visualstudio/debugger/debugger-basics)   
 [Talk to Us](https://docs.microsoft.com/visualstudio/ide/talk-to-us)