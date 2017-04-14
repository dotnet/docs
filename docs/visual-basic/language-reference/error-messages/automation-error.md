---
title: "Automation error | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbrID440"
dev_langs: 
  - "VB"
ms.assetid: 2c4be5c5-2f0d-4a2b-96fe-d1b24f08fc4c
caps.latest.revision: 9
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
# Automation error
An error occurred while executing a method or getting or setting a property of an object variable. The error was reported by the application that created the object.  
  
## To correct this error  
  
1.  Check the properties of the `Err` object to determine the source and nature of the error.  
  
2.  Use the `On Error Resume Next` statement immediately before the accessing statement, and then check for errors immediately after the accessing statement.  
  
## See Also  
 [Error Types](../../../visual-basic/programming-guide/language-features/error-types.md)   
 [Talk to Us](https://docs.microsoft.com/visualstudio/ide/talk-to-us)