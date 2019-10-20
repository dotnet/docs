---
title: "How to: Read Application Settings in Visual Basic"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "reading application settings"
  - "My.Settings object [Visual Basic], reading application settings"
  - "application settings [Visual Basic], reading"
ms.assetid: eb3428ef-115e-49a8-a878-e0613183fee0
---
# How to: Read Application Settings in Visual Basic

You can read a user setting by accessing the setting's property on the `My.Settings` object.  
  
 The `My.Settings` object exposes each setting as a property. The property name is the same as the setting name, and the property type is the same as the setting type. The setting's **Scope** indicates if the property is read-only; the property for an **Application** scope setting is read-only, while the property for a **User** scope setting is read-write. For more information, see [My.Settings Object](../../../../visual-basic/language-reference/objects/my-settings-object.md).  
  
## Example  

 This example displays the value of the `Nickname` setting.  
  
 [!code-vb[VbVbalrMyResources#14](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyResources/VB/Form1.vb#14)]  
  
 For this example to work, your application must have a `Nickname` setting, of type `String`. For more information, see [Managing Application Settings (.NET)](/visualstudio/ide/managing-application-settings-dotnet).  
  
## See also

- [My.Settings Object](../../../../visual-basic/language-reference/objects/my-settings-object.md)
- [How to: Change User Settings in Visual Basic](../../../../visual-basic/developing-apps/programming/app-settings/how-to-change-user-settings.md)
- [How to: Persist User Settings in Visual Basic](../../../../visual-basic/developing-apps/programming/app-settings/how-to-persist-user-settings.md)
- [How to: Create Property Grids for User Settings in Visual Basic](../../../../visual-basic/developing-apps/programming/app-settings/how-to-create-property-grids-for-user-settings.md)
- [Managing Application Settings (.NET)](/visualstudio/ide/managing-application-settings-dotnet)
