---
title: "Use &#39;FileGetObject&#39; instead of &#39;FileGet&#39; when using argument of type &#39;Object&#39;"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
ms.assetid: 090b8088-895a-482a-9362-606596bac304
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# Use &#39;FileGetObject&#39; instead of &#39;FileGet&#39; when using argument of type &#39;Object&#39;
The `FileGet` method includes an argument of type `Object`. `FileGetObject` should be used in place of `FileGet` to avoid ambiguities.  
  
 Notice that the functionality offered by `My.Computer.Filesystem` offers greater ease of use and performance than either `FileGet` or `FileGetObject`.  
  
## To correct this error  
  
1.  Replace `FileGet` with `FileGetObject`.  
  
2.  Cast the `Object` argument to a more specific type.  
  
## See Also  
   
 [My.Computer.FileSystem](xref:Microsoft.VisualBasic.FileIO.FileSystem)
