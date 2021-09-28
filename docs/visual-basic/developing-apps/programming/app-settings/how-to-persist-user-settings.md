---
description: "Learn more about: How to: Persist User Settings in Visual Basic"
title: "How to: Persist User Settings"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "My.Settings object [Visual Basic], persisting user settings"
  - "persistence [Visual Basic], persisting user settings [Visual Basic]"
  - "user settings [Visual Basic], persisting"
ms.assetid: 0e5e6415-b6e2-4602-9be0-a65fa167d007
---
# How to: Persist User Settings in Visual Basic

You can use the `My.Settings.Save` method to persist changes to the user settings.  
  
 Typically, applications are designed to persist the changes to the user settings when the application shuts down. This is because saving the settings can take, depending on several factors, several seconds.  
  
 For more information, see [My.Settings Object](../../../language-reference/objects/my-settings-object.md).  
  
> [!NOTE]
> Although you can change and save the values of user-scope settings at run time, application-scope settings are read-only and cannot be changed programmatically. You can change application-scope settings when creating the application, through the **Project Designer**, or by editing the application's configuration file. For more information, see [Managing Application Settings (.NET)](/visualstudio/ide/managing-application-settings-dotnet).  
  
## Example  

 This example changes the value of the `LastChanged` user setting and saves that change by calling the `My.Settings.Save` method.  
  
 [!code-vb[VbVbalrMyResources#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyResources/VB/Form1.vb#5)]  
  
 For this example to work, your application must have a `LastChanged` user setting, of type `Date`. For more information, see [Managing Application Settings (.NET)](/visualstudio/ide/managing-application-settings-dotnet).  
  
## See also

- [My.Settings Object](../../../language-reference/objects/my-settings-object.md)
- [How to: Read Application Settings in Visual Basic](how-to-read-application-settings.md)
- [How to: Change User Settings in Visual Basic](how-to-change-user-settings.md)
- [How to: Create Property Grids for User Settings in Visual Basic](how-to-create-property-grids-for-user-settings.md)
- [Managing Application Settings (.NET)](/visualstudio/ide/managing-application-settings-dotnet)
