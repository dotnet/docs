---
title: "Encoding cannot be set to Nothing | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
ms.assetid: 59f7c731-8291-4a85-bf51-c225e48cdc84
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
# Encoding cannot be set to Nothing
An attempt to read from or write to a file has failed because the parameter `encoding` has been set to `Nothing` but requires a valid value.  
  
 <xref:System.Text.Encoding> is used to determine what encoding to use when writing to a file. The default is UTF-8.  
  
## To correct this error  
  
-   Supply a valid value for the `encoding` parameter.  
  
## See Also  
 [File Encodings](../../visual-basic/developing-apps/programming/drives-directories-files/file-encodings.md)   
 [Reading from Files](../../visual-basic/developing-apps/programming/drives-directories-files/reading-from-files.md)   
 [Writing to Files](../../visual-basic/developing-apps/programming/drives-directories-files/writing-to-files.md)   
 [My.Computer.FileSystem.ReadAllText Method](https://msdn.microsoft.com/library/ks09bsaw(v=vs.90).aspx)   
 [My.Computer.FileSystem.WriteAllText Method](https://msdn.microsoft.com/library/27t17sxs(v=vs.90).aspx)
