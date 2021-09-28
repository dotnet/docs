---
description: "Learn more about: Rapid Application Development with My.Resources and My.Settings (Visual Basic)"
title: "Rapid Application Development with My.Resources and My.Settings"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "My.Settings object [Visual Basic], developing applications"
  - "rapid application development (RAD), My.Resources"
  - "rapid application development (RAD), My.Settings"
  - "My.Resources object [Visual Basic], developing applications"
ms.assetid: 68284ab1-b685-4814-a2a4-01ae40445ff8
---
# Rapid Application Development with My.Resources and My.Settings (Visual Basic)

The `My.Resources` object provides access to the application's resources and allows you to dynamically retrieve resources for your application.  
  
## Retrieving Resources  

 A number of resources such as audio files, icons, images, and strings can be retrieved through the `My.Resources` object. For example, you can access the application's culture-specific resource files. The following example sets the icon of the form to the icon named `Form1Icon` stored in the application's resource file.  
  
 [!code-vb[VbVbcnMy#7](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMy/VB/Class1.vb#7)]  
  
 The `My.Resources` object exposes only global resources. It does not provide access to resource files associated with forms. Access the form resources from the form.  
  
 Similarly, the `My.Settings` object provides access to the application's settings and allows you to dynamically store and retrieve property settings and other information for your application. For more information, see [My.Resources Object](../../language-reference/objects/my-resources-object.md) and [My.Settings Object](../../language-reference/objects/my-settings-object.md).  
  
## See also

- [My.Resources Object](../../language-reference/objects/my-resources-object.md)
- [My.Settings Object](../../language-reference/objects/my-settings-object.md)
- [Accessing Application Settings](../programming/app-settings/index.md)
