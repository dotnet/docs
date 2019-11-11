---
title: "How to: Change User Settings in Visual Basic"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "user settings [Visual Basic], changing in Visual Basic"
  - "user settings"
  - "My.Settings object [Visual Basic], changing user settings"
  - "examples [Visual Basic], changing user settings"
ms.assetid: 41250181-c594-4854-9988-8183b9eb03cf
---
# How to: Change User Settings in Visual Basic

You can change a user setting by assigning a new value to the setting's property on the `My.Settings` object.  
  
 The `My.Settings` object exposes each setting as a property. The property name is the same as the setting name, and the property type is the same as the setting type. The setting's **Scope** determines if the property is read-only: The property for an **Application**-scope setting is read-only, while the property for a **User**-scope setting is read-write. For more information, see [My.Settings Object](../../../../visual-basic/language-reference/objects/my-settings-object.md).  
  
> [!NOTE]
> Although you can change and save the values of user-scope settings at run time, application-scope settings are read-only and cannot be changed programmatically. You can change application-scope settings when you create the application by using the **Project Designer** or by editing the application's configuration file. For more information, see [Managing Application Settings (.NET)](/visualstudio/ide/managing-application-settings-dotnet).  
  
## Example  

 This example changes the value of the `Nickname` user setting.  
  
 [!code-vb[VbVbalrMyResources#7](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyResources/VB/Form1.vb#7)]  
  
 For this example to work, your application must have a `Nickname` user setting, of type `String`.  
  
 The application saves the user settings when the application shuts down. To save the settings immediately, call the `My.Settings.Save` method. For more information, see [How to: Persist User Settings in Visual Basic](../../../../visual-basic/developing-apps/programming/app-settings/how-to-persist-user-settings.md).  
  
## See also

- [My.Settings Object](../../../../visual-basic/language-reference/objects/my-settings-object.md)
- [How to: Read Application Settings in Visual Basic](../../../../visual-basic/developing-apps/programming/app-settings/how-to-read-application-settings.md)
- [How to: Persist User Settings in Visual Basic](../../../../visual-basic/developing-apps/programming/app-settings/how-to-persist-user-settings.md)
- [How to: Create Property Grids for User Settings in Visual Basic](../../../../visual-basic/developing-apps/programming/app-settings/how-to-create-property-grids-for-user-settings.md)
- [Managing Application Settings (.NET)](/visualstudio/ide/managing-application-settings-dotnet)
