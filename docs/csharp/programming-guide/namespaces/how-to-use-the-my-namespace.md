---
title: "How to use the My namespace - C# Programming Guide"
description: Learn how to us the 'My' namespace. The 'My' namespace gives easy and intuitive access to a number of .NET classes.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "C# language, My namespace access"
ms.assetid: e7152414-0ea5-4c8e-bf02-c8d5bbe45ff4
---
# How to use the My namespace (C# Programming Guide)

The <xref:Microsoft.VisualBasic.MyServices> namespace (`My` in Visual Basic) provides easy and intuitive access to a number of .NET classes, enabling you to write code that interacts with the computer, application, settings, resources, and so on. Although originally designed for use with Visual Basic, the `MyServices` namespace can be used in C# applications.  
  
 For more information about using the `MyServices` namespace from Visual Basic, see [Development with My](../../../visual-basic/developing-apps/development-with-my/index.md).  
  
## Add a reference

 Before you can use the `MyServices` classes in your solution, you must add a reference to the Visual Basic library.  
  
### Add a reference to the Visual Basic library  
  
1. In **Solution Explorer**, right-click the **References** node, and select **Add Reference**.  
  
2. When the **References** dialog box appears, scroll down the list, and select Microsoft.VisualBasic.dll.  
  
     You might also want to include the following line in the `using` section at the start of your program.  
  
     [!code-csharp[csProgGuideNamespaces#18](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideNamespaces/CS/Namespaces3.cs#18)]  
  
## Example  

 This example calls various static methods contained in the `MyServices` namespace. For this code to compile, a reference to Microsoft.VisualBasic.DLL must be added to the project.  
  
 [!code-csharp[csProgGuideNamespaces#19](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideNamespaces/CS/Namespaces3.cs#19)]  
  
 Not all the classes in the `MyServices` namespace can be called from a C# application: for example, the <xref:Microsoft.VisualBasic.MyServices.FileSystemProxy> class is not compatible. In this particular case, the static methods that are part of <xref:Microsoft.VisualBasic.FileIO.FileSystem>, which are also contained in VisualBasic.dll, can be used instead. For example, here is how to use one such method to duplicate a directory:  
  
 [!code-csharp[csProgGuideNamespaces#20](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideNamespaces/CS/Namespaces3.cs#20)]  
  
## See also

- [C# Programming Guide](../index.md)
- [Namespaces](../../fundamentals/types/namespaces.md)
- [Using Namespaces](./using-namespaces.md)
