---
title: "Use &#39;FileGetObject&#39; instead of &#39;FileGet&#39; when using argument of type &#39;Object&#39; | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 090b8088-895a-482a-9362-606596bac304
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Use &#39;FileGetObject&#39; instead of &#39;FileGet&#39; when using argument of type &#39;Object&#39;
The `FileGet` method includes an argument of type `Object`. `FileGetObject` should be used in place of `FileGet` to avoid ambiguities.  
  
 Notice that the functionality offered by `My.Computer.Filesystem` offers greater ease of use and performance than either `FileGet` or `FileGetObject`.  
  
### To correct this error  
  
1.  Replace `FileGet` with `FileGetObject`.  
  
2.  Cast the `Object` argument to a more specific type.  
  
## See Also  
 [NOT IN BUILD: FileGetObject Function](http://msdn.microsoft.com/en-us/3eda786b-d1ee-4b44-9dd7-0ea6bff072c0)   
 [My.Computer.FileSystem Object](../../visual-basic/language-reference/objects/my-computer-filesystem-object.md)