---
title: "&#39;Dir&#39; function must first be called with a &#39;PathName&#39; argument"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrDIR_IllegalCall"
ms.assetid: 7b5d149f-be91-4ac3-8262-86a360894e7d
---
# &#39;Dir&#39; function must first be called with a &#39;PathName&#39; argument
An initial call to the `Dir` function does not include the `PathName` argument. The first call to `Dir` must include a `PathName`, but subsequent calls to `Dir` do not need to include parameters to retrieve the next item.  
  
## To correct this error  
  
1.  Supply a `PathName` argument in the function call.  
  
## See also
- <xref:Microsoft.VisualBasic.FileSystem.Dir%2A>
