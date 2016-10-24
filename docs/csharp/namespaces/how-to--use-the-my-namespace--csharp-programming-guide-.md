---
title: "How to: Use the My Namespace (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "C# language, My namespace access"
ms.assetid: e7152414-0ea5-4c8e-bf02-c8d5bbe45ff4
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# How to: Use the My Namespace (C# Programming Guide)
The <xref:Microsoft.VisualBasic.MyServices> namespace (`My` in Visual Basic) provides easy and intuitive access to a number of .NET Framework classes, enabling you to write code that interacts with the computer, application, settings, resources, and so on. Although originally designed for use with Visual Basic, the `MyServices` namespace can be used in C# applications.  
  
 For more information about using the `MyServices` namespace from Visual Basic, see [Development with My](../Topic/Development%20with%20My%20\(Visual%20Basic\).md).  
  
## Adding a Reference  
 Before you can use the `MyServices` classes in your solution, you must add a reference to the Visual Basic library.  
  
#### To add a reference to the Visual Basic library  
  
1.  In **Solution Explorer**, right-click the **References** node, and select **Add Reference**.  
  
2.  When the **References** dialog box appears, scroll down the list, and select Microsoft.VisualBasic.dll.  
  
     You might also want to include the following line in the `using` section at the start of your program.  
  
     [!code[csProgGuideNamespaces#18](../namespaces/codesnippet/CSharp/how-to--use-the-my-namespace--csharp-programming-guide-_1.cs)]  
  
## Example  
 This example calls various static methods contained in the `MyServices` namespace. For this code to compile, a reference to Microsoft.VisualBasic.DLL must be added to the project.  
  
 [!code[csProgGuideNamespaces#19](../namespaces/codesnippet/CSharp/how-to--use-the-my-namespace--csharp-programming-guide-_2.cs)]  
  
 Not all the classes in the `MyServices` namespace can be called from a C# application: for example, the <xref:Microsoft.VisualBasic.MyServices.FileSystemProxy> class is not compatible. In this particular case, the static methods that are part of <xref:Microsoft.VisualBasic.FileIO.FileSystem>, which are also contained in VisualBasic.dll, can be used instead. For example, here is how to use one such method to duplicate a directory:  
  
 [!code[csProgGuideNamespaces#20](../namespaces/codesnippet/CSharp/how-to--use-the-my-namespace--csharp-programming-guide-_3.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Namespaces](../namespaces/namespaces--csharp-programming-guide-.md)   
 [Using Namespaces](../namespaces/using-namespaces--csharp-programming-guide-.md)