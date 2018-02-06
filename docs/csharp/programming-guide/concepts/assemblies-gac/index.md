---
title: "Assemblies and the Global Assembly Cache (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 149f5ca5-5b34-4746-9542-1ae43b2d0256
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Assemblies and the Global Assembly Cache (C#)
Assemblies form the fundamental unit of deployment, version control, reuse, activation scoping, and security permissions for a .NET-based application. Assemblies take the form of an executable (.exe) file or dynamic link library (.dll) file, and are the building blocks of the .NET Framework. They provide the common language runtime with the information it needs to be aware of type implementations. You can think of an assembly as a collection of types and resources that form a logical unit of functionality and are built to work together.  
  
 Assemblies can contain one or more modules. For example, larger projects may be planned in such a way that several individual developers work on separate modules, all coming together to create a single assembly. For more information about modules, see the topic [How to: Build a Multifile Assembly](../../../../../docs/framework/app-domains/how-to-build-a-multifile-assembly.md).  
  
 Assemblies have the following properties:  
  
-   Assemblies are implemented as .exe or .dll files.  
  
-   You can share an assembly between applications by putting it in the global assembly cache. Assemblies must be strong-named before they can be included in the global assembly cache. For more information, see [Strong-Named Assemblies](../../../../../docs/framework/app-domains/strong-named-assemblies.md).  
  
-   Assemblies are only loaded into memory if they are required. If they are not used, they are not loaded. This means that assemblies can be an efficient way to manage resources in larger projects.  
  
-   You can programmatically obtain information about an assembly by using reflection. For more information, see [Reflection (C#)](../../../../csharp/programming-guide/concepts/reflection.md).  
  
-   If you want to load an assembly only to inspect it, use a method such as <xref:System.Reflection.Assembly.ReflectionOnlyLoadFrom%2A>.  
  
## Assembly Manifest  
 Within every assembly is an *assembly manifest*. Similar to a table of contents, the assembly manifest contains the following:  
  
-   The assembly's identity (its name and version).  
  
-   A file table describing all the other files that make up the assembly, for example, any other assemblies you created that your .exe or .dll file relies on, or even bitmap or Readme files.  
  
-   An *assembly reference list*, which is a list of all external dependencies—.dlls or other files your application needs that may have been created by someone else. Assembly references contain references to both global and private objects. Global objects reside in the global assembly cache, an area available to other applications. Private objects must be in a directory at either the same level as or below the directory in which your application is installed.  
  
 Because assemblies contain information about content, versioning, and dependencies, the applications you create with C# do not rely on Windows registry values to function properly. Assemblies reduce .dll conflicts and make your applications more reliable and easier to deploy. In many cases, you can install a .NET-based application simply by copying its files to the target computer.  
  
 For more information see [Assembly Manifest](../../../../../docs/framework/app-domains/assembly-manifest.md).  
  
## Adding a Reference to an Assembly  
 To use an assembly, you must add a reference to it. Next, you use the [using directive](../../../../csharp/language-reference/keywords/using-directive.md) to choose the namespace of the items you want to use. Once an assembly is referenced and imported, all the accessible classes, properties, methods, and other members of its namespaces are available to your application as if their code were part of your source file.  
  
 In C#, you can also use two versions of the same assembly in a single application. For more information, see [extern alias](../../../../csharp/language-reference/keywords/extern-alias.md).  
  
## Creating an Assembly  
 Compile your application by clicking **Build** on the **Build** menu or by building it from the command line using the command-line compiler. For details about building assemblies from the command line, see [Command-line Building With csc.exe](../../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md).  
  
> [!NOTE]
>  To build an assembly in Visual Studio, on the **Build** menu choose **Build**.  
  
## See Also  
 [C# Programming Guide](../../../../csharp/programming-guide/index.md)  
 [Assemblies in the Common Language Runtime](../../../../../docs/framework/app-domains/assemblies-in-the-common-language-runtime.md)  
 [Friend Assemblies (C#)](friend-assemblies.md)  
 [How to: Share an Assembly with Other Applications (C#)](how-to-share-an-assembly-with-other-applications.md)  
 [How to: Load and Unload Assemblies (C#)](how-to-load-and-unload-assemblies.md)  
 [How to: Determine If a File Is an Assembly (C#)](how-to-determine-if-a-file-is-an-assembly.md)  
 [How to: Create and Use Assemblies Using the Command Line (C#)](how-to-create-and-use-assemblies-using-the-command-line.md)  
 [Walkthrough: Embedding Types from Managed Assemblies in Visual Studio (C#)](walkthrough-embedding-types-from-managed-assemblies-in-visual-studio.md)  
 [Walkthrough: Embedding Type Information from Microsoft Office Assemblies in Visual Studio (C#)](walkthrough-embedding-type-information-from-microsoft-office-assemblies.md)
