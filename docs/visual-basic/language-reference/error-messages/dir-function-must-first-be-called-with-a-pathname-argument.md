---
title: "&#39;Dir&#39; function must first be called with a &#39;PathName&#39; argument"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbrDIR_IllegalCall"
ms.assetid: 7b5d149f-be91-4ac3-8262-86a360894e7d
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
---
# &#39;Dir&#39; function must first be called with a &#39;PathName&#39; argument
An initial call to the `Dir` function does not include the `PathName` argument. The first call to `Dir` must include a `PathName`, but subsequent calls to `Dir` do not need to include parameters to retrieve the next item.  
  
## To correct this error  
  
1.  Supply a `PathName` argument in the function call.  
  
## See Also  
 <xref:Microsoft.VisualBasic.FileSystem.Dir%2A>
