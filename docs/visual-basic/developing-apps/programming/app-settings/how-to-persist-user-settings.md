---
title: "How to: Persist User Settings in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "My.Settings object [Visual Basic], persisting user settings"
  - "persistence [Visual Basic], persisting user settings [Visual Basic]"
  - "user settings [Visual Basic], persisting"
ms.assetid: 0e5e6415-b6e2-4602-9be0-a65fa167d007
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Persist User Settings in Visual Basic
You can use the `My.Settings.Save` method to persist changes to the user settings.  
  
 Typically, applications are designed to persist the changes to the user settings when the application shuts down. This is because saving the settings can take, depending on several factors, several seconds.  
  
 For more information, see [My.Settings Object](../../../../visual-basic/language-reference/objects/my-settings-object.md).  
  
> [!NOTE]
>  Although you can change and save the values of user-scope settings at run time, application-scope settings are read-only and cannot be changed programmatically. You can change application-scope settings when creating the application, through the **Project Designer**, or by editing the application's configuration file. For more information, see [Managing Application Settings (.NET)](/visualstudio/ide/managing-application-settings-dotnet).  
  
## Example  
 This example changes the value of the `LastChanged` user setting and saves that change by calling the `My.Settings.Save` method.  
  
 [!code-vb[VbVbalrMyResources#5](../../../../visual-basic/developing-apps/programming/app-settings/codesnippet/VisualBasic/how-to-persist-user-settings_1.vb)]  
  
 For this example to work, your application must have a `LastChanged` user setting, of type `Date`. For more information, see [Managing Application Settings (.NET)](/visualstudio/ide/managing-application-settings-dotnet).  
  
## See Also  
 [My.Settings Object](../../../../visual-basic/language-reference/objects/my-settings-object.md)  
 [How to: Read Application Settings in Visual Basic](../../../../visual-basic/developing-apps/programming/app-settings/how-to-read-application-settings.md)  
 [How to: Change User Settings in Visual Basic](../../../../visual-basic/developing-apps/programming/app-settings/how-to-change-user-settings.md)  
 [How to: Create Property Grids for User Settings in Visual Basic](../../../../visual-basic/developing-apps/programming/app-settings/how-to-create-property-grids-for-user-settings.md)  
 [Managing Application Settings (.NET)](/visualstudio/ide/managing-application-settings-dotnet)
