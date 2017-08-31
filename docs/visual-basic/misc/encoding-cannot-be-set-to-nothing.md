---
title: "Encoding cannot be set to Nothing | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 59f7c731-8291-4a85-bf51-c225e48cdc84
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Encoding cannot be set to Nothing
An attempt to read from or write to a file has failed because the parameter `encoding` has been set to `Nothing` but requires a valid value.  
  
 <xref:System.Text.Encoding> is used to determine what encoding to use when writing to a file. The default is UTF-8.  
  
### To correct this error  
  
-   Supply a valid value for the `encoding` parameter.  
  
## See Also  
 [File Encodings](../../visual-basic/developing-apps/programming/drives-directories-files/file-encodings.md)   
 [Reading from Files](../../visual-basic/developing-apps/programming/drives-directories-files/reading-from-files.md)   
 [Writing to Files](../../visual-basic/developing-apps/programming/drives-directories-files/writing-to-files.md)   
 [My.Computer.FileSystem.ReadAllText Method](http://msdn.microsoft.com/en-us/3a7ac8be-fb1d-4087-bc65-167d6754d57f)   
 [My.Computer.FileSystem.WriteAllText Method](http://msdn.microsoft.com/en-us/f507460c-87d9-4504-b74f-3ff825c7d5c4)