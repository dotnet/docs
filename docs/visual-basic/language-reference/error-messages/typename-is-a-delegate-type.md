---
title: "&#39;&lt;typename&gt;&#39; is a delegate type"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc32008"
  - "vbc32008"
helpviewer_keywords: 
  - "BC32008"
ms.assetid: dc6abba0-a9ad-450f-8899-87265bc84abc
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# &#39;&lt;typename&gt;&#39; is a delegate type
'\<typename>' is a delegate type. Delegate construction permits only a single AddressOf expression as an argument list. Often an AddressOf expression can be used instead of a delegate construction.  
  
 A `New` clause creating an instance of a delegate class supplies an invalid argument list to the delegate constructor.  
  
 You can supply only a single `AddressOf` expression when creating a new delegate instance.  
  
 This error can result if you do not pass any arguments to the delegate constructor, if you pass more than one argument, or if you pass a single argument that is not a valid `AddressOf` expression.  
  
 **Error ID:** BC32008  
  
## To correct this error  
  
-   Use a single `AddressOf` expression in the argument list for the delegate class in the `New` clause.  
  
## See Also  
 [New Operator](../../../visual-basic/language-reference/operators/new-operator.md)  
 [AddressOf Operator](../../../visual-basic/language-reference/operators/addressof-operator.md)  
 [Delegates](../../../visual-basic/programming-guide/language-features/delegates/index.md)  
 [How to: Invoke a Delegate Method](../../../visual-basic/programming-guide/language-features/delegates/how-to-invoke-a-delegate-method.md)
