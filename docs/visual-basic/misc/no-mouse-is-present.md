---
title: "No mouse is present"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbrMouse_NoMouseIsPresent"
ms.assetid: 4472fd57-4217-4463-9d3c-dc4a8fe88f1b
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# No mouse is present
One of the properties of the `My.Computer.Mouse` object was called, but the computer has no mouse or mouse port installed.  
  
## To correct this error  
  
-   Add a `Try...Catch` block around the call to the property of the `My.Computer.Mouse` object.  
  
     — or —  
  
-   Install a mouse on the computer.  
  
## See Also  
 [My.Computer.Mouse](xref:Microsoft.VisualBasic.Devices.Mouse)  
 [Exception and Error Handling in Visual Basic](http://msdn.microsoft.com/library/3e351e73-cf23-40ab-8b60-05794160529e)  
 [Try...Catch...Finally Statement](../../visual-basic/language-reference/statements/try-catch-finally-statement.md)
