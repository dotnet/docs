---
title: "Working with .resx Files Programmatically"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "resource files, .resx files"
  - ".resx files"
ms.assetid: 168f941a-2b84-43f8-933f-cf4a8548d824
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Working with .resx Files Programmatically
Because XML resource (.resx) files must consist of well-defined XML, including a header that must follow a specific schema followed by data in name/value pairs, you may find that creating these files manually is error-prone. As an alternative, you can create .resx files programmatically by using types and members in the .NET Framework Class Library. You can also use the .NET Framework Class Library to retrieve resources that are stored in .resx files. This topic explains how you can use the types and members in the <xref:System.Resources> namespace to work with .resx files.  
  
 Note that this article discusses working with XML (.resx) files that contain resources. For information on working with binary resource files that have been embedded in assemblies, see the <xref:System.Resources.ResourceManager> topic.  
  
> [!WARNING]
>  There are also ways to work with .resx files other than programmatically. When you add a resource file to a Visual Studio project, Visual Studio provides an interface for creating and maintaining a .resx file, and automatically converts the .resx file to a .resources file at compile time. You can also use a text editor to manipulate a .resx file directly. However, to avoid corrupting the file, be careful not to modify any binary information that is stored in the file.  
  
## Creating a .resx File  
 You can use the <xref:System.Resources.ResXResourceWriter?displayProperty=nameWithType> class to create a .resx file programmatically, by following these steps:  
  
1.  Instantiate a <xref:System.Resources.ResXResourceWriter> object by calling the <xref:System.Resources.ResXResourceWriter.%23ctor%28System.String%29?displayProperty=nameWithType> method and supplying the name of the .resx file. The file name must include the .resx extension. If you instantiate the <xref:System.Resources.ResXResourceWriter> object in a `using` block, you do not explicitly have to call the <xref:System.Resources.ResXResourceWriter.Close%2A?displayProperty=nameWithType> method in step 3.  
  
2.  Call the <xref:System.Resources.ResXResourceWriter.AddResource%2A?displayProperty=nameWithType> method for each resource you want to add to the file. Use the overloads of this method to add string, object, and binary (byte array) data. If the resource is an object, it must be serializable.  
  
3.  Call the <xref:System.Resources.ResXResourceWriter.Close%2A?displayProperty=nameWithType> method to generate the resource file and to release all resources. If the <xref:System.Resources.ResXResourceWriter> object was created within a `using` block, resources are written to the .resx file and the resources used by the <xref:System.Resources.ResXResourceWriter> object are released at the end of the `using` block.  
  
 The resulting .resx file has the appropriate header and a `data` tag for each resource added by the <xref:System.Resources.ResXResourceWriter.AddResource%2A?displayProperty=nameWithType> method.  
  
> [!WARNING]
>  Do not use resource files to store passwords, security-sensitive information, or private data.  
  
 The following example creates a .resx file named CarResources.resx that stores six strings, an icon, and two application-defined objects (two `Automobile` objects). Note that the `Automobile` class, which is defined and instantiated in the example, is tagged with the <xref:System.SerializableAttribute> attribute.  
  
 [!code-csharp[Conceptual.Resources.ResX#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.resx/cs/create1.cs#1)]
 [!code-vb[Conceptual.Resources.ResX#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.resx/vb/create1.vb#1)]  
  
> [!IMPORTANT]
>  You can also use Visual Studio to create .resx files. At compile time, Visual Studio uses the [Resource File Generator (Resgen.exe)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md) to convert the .resx file to a binary resource (.resources) file, and also embeds it in either an application assembly or a satellite assembly.  
  
 You cannot embed a .resx file in a runtime executable or compile it into a satellite assembly. You must convert your .resx file into a binary resource (.resources) file by using the [Resource File Generator (Resgen.exe)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md). The resulting .resources file can then be embedded in an application assembly or a satellite assembly. For more information, see [Creating Resource Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md).  
  
## Enumerating Resources  
 In some cases, you may want to retrieve all resources, instead of a specific resource, from a .resx file. To do this, you can use the <xref:System.Resources.ResXResourceReader?displayProperty=nameWithType> class, which provides an enumerator for all resources in the .resx file. The <xref:System.Resources.ResXResourceReader?displayProperty=nameWithType> class implements <xref:System.Collections.IDictionaryEnumerator>, which returns a <xref:System.Collections.DictionaryEntry> object that represents a particular resource for each iteration of the loop. Its <xref:System.Collections.DictionaryEntry.Key%2A?displayProperty=nameWithType> property returns the resource's key, and its <xref:System.Collections.DictionaryEntry.Value%2A?displayProperty=nameWithType> property returns the resource's value.  
  
 The following example creates a <xref:System.Resources.ResXResourceReader> object for the CarResources.resx file created in the previous example and iterates through the resource file. It adds the two `Automobile` objects that are defined in the resource file to a <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> object, and it adds five of the six strings to a <xref:System.Collections.SortedList> object. The values in the <xref:System.Collections.SortedList> object are converted to a parameter array, which is used to display column headings to the console. The `Automobile` property values are also displayed to the console.  
  
 [!code-csharp[Conceptual.Resources.ResX#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.resx/cs/enumerate1.cs#2)]
 [!code-vb[Conceptual.Resources.ResX#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.resx/vb/enumerate1.vb#2)]  
  
## Retrieving a Specific Resource  
 In addition to enumerating the items in a .resx file, you can retrieve a specific resource by name by using the <xref:System.Resources.ResXResourceSet?displayProperty=nameWithType> class. The <xref:System.Resources.ResourceSet.GetString%28System.String%29?displayProperty=nameWithType> method retrieves the value of a named string resource. The <xref:System.Resources.ResourceSet.GetObject%28System.String%29?displayProperty=nameWithType> method retrieves the value of a named object or binary data. The method returns an object that must then be cast (in C#) or converted (in Visual Basic) to an object of the appropriate type.  
  
 The following example retrieves a form's caption string and icon by their resource names. It also retrieves the application-defined `Automobile` objects used in the previous example and displays them in a <xref:System.Windows.Forms.DataGridView> control.  
  
 [!code-csharp[Conceptual.Resources.ResX#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.resx/cs/retrieve1.cs#3)]
 [!code-vb[Conceptual.Resources.ResX#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.resx/vb/retrieve1.vb#3)]  
  
## Converting .resx Files to Binary .resources Files  
 Converting .resx files to embedded binary resource (.resources) files has significant advantages. Although .resx files are easy to read and maintain during application development, they are rarely included with finished applications. If they are distributed with an application, they exist as separate files apart from the application executable and its accompanying libraries. In contrast, .resources files are embedded in the application executable or its accompanying assemblies. In addition, for localized applications, relying on .resx files at run time places the responsibility for handling resource fallback on the developer. In contrast, if a set of satellite assemblies that contain embedded .resources files has been created, the common language runtime handles the resource fallback process.  
  
 To convert a .resx file to a .resources file, you use the [Resource File Generator (Resgen.exe)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md), which has the following basic syntax:  
  
 **Resgen.exe** *.resxFilename*  
  
 The result is a binary resource file that has the same root file name as the .resx file and a .resources file extension. This file can then be compiled into an executable or a library at compile time. If you are using the Visual Basic compiler, use the following syntax to embed a .resources file in an application's executable:  
  
 **vbc** *filename* **.vb -resource:** *.resourcesFilename*  
  
 If you are using C#, the syntax is as follows:  
  
 **csc** *filename* **.cs -resource:** *.resourcesFilename*  
  
 The .resources file can also be embedded in a satellite assembly by using [Assembly Linker (AL.exe)](../../../docs/framework/tools/al-exe-assembly-linker.md), which has the following basic syntax:  
  
 **al** *resourcesFilename* **-out:** *assemblyFilename*  
  
## See Also  
 [Creating Resource Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md)  
 [Resgen.exe (Resource File Generator)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md)  
 [Al.exe (Assembly Linker)](../../../docs/framework/tools/al-exe-assembly-linker.md)
