---
title: "How to: Check Connection Status in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Web connections [Visual Basic]"
  - "IsAvailable property [Visual Basic], about IsAvailable"
  - "connections [Visual Basic], checking status"
  - "connection status [Visual Basic]"
ms.assetid: 4d9ee8ab-9a6f-4279-ace4-b75afc976a74
caps.latest.revision: 26
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Check Connection Status in Visual Basic
The <xref:Microsoft.VisualBasic.Devices.Network.IsAvailable> property can be used to determine whether the computer has a working network or Internet connection.  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
### To check whether a computer has a working connection  
  
-   Determine whether the `IsAvailable` property is `True` or `False`. The following code checks the property's status and reports it:  
  
     [!code-vb[VbResourceTasks#3](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/how-to-check-connection-status_1.vb)]  
  
     This code example is also available as an IntelliSense code snippet. In the code snippet picker, it is located in **Connectivity and Networking**. For more information, see [Code Snippets](/visualstudio/ide/code-snippets).  
  
## See Also  
 <xref:Microsoft.VisualBasic.Devices.Network?displayProperty=nameWithType>  
 <xref:Microsoft.VisualBasic.Devices.Network.IsAvailable>
