---
description: "Learn more about: Default Object Instances Provided by My.Forms and My.WebServices (Visual Basic)"
title: "Default Object Instances Provided by My.Forms and My.WebServices"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "My.WebServices object [Visual Basic], developing applications"
  - "My.Forms object [Visual Basic], developing applications"
  - "rapid application development (RAD), My.Forms"
  - "rapid application development (RAD), My.WebServices"
ms.assetid: de930027-9108-4f0c-b97c-5e7db4d6ef79
---
# Default Object Instances Provided by My.Forms and My.WebServices (Visual Basic)

The [My.Forms](../../language-reference/objects/my-forms-object.md) and [My.WebServices](../../language-reference/objects/my-webservices-object.md) objects provide access to forms, data sources, and XML Web services used by your application. They provide access through collections of *default instances* of each of these objects.  
  
## Default Instances  

 A default instance is an instance of the class that is provided by the runtime and does not need to be declared and instantiated using the `Dim` and `New` statements. The following example demonstrates how you might have declared and instantiated an instance of a <xref:System.Windows.Forms.Form> class called `Form1`, and how you are now able to get a default instance of this <xref:System.Windows.Forms.Form> class through `My.Forms`.  
  
 [!code-vb[VbVbcnMy#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMy/VB/Class1.vb#5)]  
  
 [!code-vb[VbVbcnMy#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMy/VB/Class1.vb#6)]  
  
 The `My.Forms` object returns a collection of default instances for every `Form` class that exists in your project. Similarly, `My.WebServices` provides a default instance of the proxy class for every Web service that you have created a reference to in your application.  
  
## See also

- [My.Forms Object](../../language-reference/objects/my-forms-object.md)
- [My.WebServices Object](../../language-reference/objects/my-webservices-object.md)
- [How My Depends on Project Type](how-my-depends-on-project-type.md)
