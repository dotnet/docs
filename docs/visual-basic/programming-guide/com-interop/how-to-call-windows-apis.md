---
title: "How to: Call Windows APIs (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "API calls [Visual Basic]"
  - "Windows API, calling"
  - "API calls [Visual Basic], platform invoke"
  - "calls [Visual Basic], stored procedures"
ms.assetid: 27d75f0a-54ab-4ee1-b91d-43513a19b12d
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Call Windows APIs (Visual Basic)
This example defines and calls the `MessageBox` function in user32.dll and then passes a string to it.  
  
## Example  
 [!code-vb[VbVbalrInterop#1](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/how-to-call-windows-apis_1.vb)]  
  
## Compiling the Code  
 This example requires:  
  
-   A reference to the <xref:System> namespace.  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
-   The method is not static, is abstract, or has been previously defined. The parent type is an interface, or the length of *name* or *dllName* is zero. (<xref:System.ArgumentException>)  
  
-   The *name* or *dllName* is `Nothing`. (<xref:System.ArgumentNullException>)  
  
-   The containing type has been previously created using `CreateType`. (<xref:System.InvalidOperationException>)  
  
## See Also  
 [A Closer Look at Platform Invoke](http://msdn.microsoft.com/library/ba9dd55b-2eaa-45cd-8afd-75cb8d64d243)  
 [Platform Invoke Examples](../../../framework/interop/platform-invoke-examples.md)  
 [Consuming Unmanaged DLL Functions](../../../framework/interop/consuming-unmanaged-dll-functions.md)  
 [Defining a Method with Reflection Emit](http://msdn.microsoft.com/library/84fd3bf6-628f-41aa-83d9-b990cf926e81)  
 [Walkthrough: Calling Windows APIs](../../../visual-basic/programming-guide/com-interop/walkthrough-calling-windows-apis.md)  
 [COM Interop](../../../visual-basic/programming-guide/com-interop/index.md)
