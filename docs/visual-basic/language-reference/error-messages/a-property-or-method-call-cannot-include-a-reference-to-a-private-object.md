---
title: "A property or method call cannot include a reference to a private object, either as an argument or as a return value"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbrID98"
ms.assetid: 059b43e1-202d-4fa2-806b-7bad63c1e7ca
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# A property or method call cannot include a reference to a private object, either as an argument or as a return value
Among the possible causes of this error are:  
  
-   A client invoked a property or method of an out-of-process component and attempted to pass a reference to a private object as one of the arguments.  
  
-   An out-of-process component invoked a call-back method on its client and attempted to pass a reference to a private object.  
  
-   An out-of-process component attempted to pass a reference to a private object as an argument of an event it was raising.  
  
-   A client attempted to assign a private object reference to a `ByRef` argument of an event it was handling.  
  
## To correct this error  
  
1.  Remove the reference.  
  
## See Also  
 [Private](../../../visual-basic/language-reference/modifiers/private.md)
