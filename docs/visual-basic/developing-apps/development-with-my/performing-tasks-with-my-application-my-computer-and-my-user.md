---
title: "Performing Tasks with My.Application, My.Computer, and My.User (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "My.Application object [Visual Basic], developing applications"
  - "rapid application development (RAD), My.Application"
  - "rapid application development (RAD), My.Computer"
  - "rapid application development (RAD), My.User"
  - "My.Computer object [Visual Basic], developing applications"
  - "My.User object [Visual Basic], developing applications"
ms.assetid: c8af61bd-4dd3-4a0f-9af5-795b594b240b
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
---
# Performing Tasks with My.Application, My.Computer, and My.User (Visual Basic)
The three central `My` objects that provide access to information and commonly used functionality are `My.Application` (<xref:Microsoft.VisualBasic.ApplicationServices.ApplicationBase>), `My.Computer` (<xref:Microsoft.VisualBasic.Devices.Computer>), and `My.User` (<xref:Microsoft.VisualBasic.ApplicationServices.User>). You can use these objects to access information that is related to the current application, the computer that the application is installed on, or the current user of the application, respectively.  
  
## My.Application, My.Computer, and My.User  
 The following examples demonstrate how information can be retrieved using `My`.  
  
 [!code-vb[VbVbcnMy#1](../../../visual-basic/developing-apps/development-with-my/codesnippet/VisualBasic/performing-tasks-with-my-application-my-computer-and-my-user_1.vb)]  
  
 [!code-vb[VbVbcnMy#2](../../../visual-basic/developing-apps/development-with-my/codesnippet/VisualBasic/performing-tasks-with-my-application-my-computer-and-my-user_2.vb)]  
  
 In addition to retrieving information, the members exposed through these three objects also allow you to execute methods related to that object. For instance, you can access a variety of methods to manipulate files or update the registry through `My.Computer`.  
  
 File I/O is significantly easier and faster with `My`, which includes a variety of methods and properties for manipulating files, directories, and drives. The <xref:Microsoft.VisualBasic.FileIO.TextFieldParser> object allows you to read from large structured files that have delimited or fixed-width fields. This example opens the `TextFieldParser``reader` and uses it to read from `C:\TestFolder1\test1.txt`.  
  
 [!code-vb[VbVbalrTextFieldParser#23](../../../visual-basic/developing-apps/development-with-my/codesnippet/VisualBasic/performing-tasks-with-my-application-my-computer-and-my-user_3.vb)]  
  
 `My.Application` allows you to change the culture for your application. The following example demonstrates how this method can be called.  
  
 [!code-vb[VbVbcnMy#3](../../../visual-basic/developing-apps/development-with-my/codesnippet/VisualBasic/performing-tasks-with-my-application-my-computer-and-my-user_4.vb)]  
  
## See Also  
 <xref:Microsoft.VisualBasic.ApplicationServices.ApplicationBase>  
 <xref:Microsoft.VisualBasic.Devices.Computer>  
 <xref:Microsoft.VisualBasic.ApplicationServices.User>  
 [How My Depends on Project Type](../../../visual-basic/developing-apps/development-with-my/how-my-depends-on-project-type.md)
