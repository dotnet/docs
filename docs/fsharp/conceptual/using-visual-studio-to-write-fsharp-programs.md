---
title: Using Visual Studio to Write F# Programs
description: Using Visual Studio to Write F# Programs
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1f728ece-c725-4731-b166-77cd88cb6ae8 
---

# Using Visual Studio to Write F# Programs

The Visual Studio Integrated Development Environment (IDE) includes support for F#, including code editing, IntelliSense, debugging, and features that assist in packaging and deploying applications. Visual F# supports many of the features supported in other .NET Framework languages.


## Scripts and Projects Compared
There are two basic styles of development that Visual F# supports: scripts and projects. You can use an F# script when you just want to run a small amount of code that you do not want to make into a permanent application. You use a project when you are creating a more permanent application.

To create and run an F# script, you do not need to create a project. To create an F# script, on the **File** menu, point to **New** and then click **File**. In the **New File** dialog box, select **Script** in the **Installed Templates** list, and then select **F# Script File**. Scripts are designed for execution with F# Interactive (fsi.exe). For more information, see [F&#35; Interactive &#40;fsi.exe&#41; Reference](FSharp-Interactive-%5Bfsi.exe%5D-Reference.md).


## Projects and Solutions
Projects include a collection of files that produce a single assembly. Projects are designed for compilation with fsc.exe and can be run in the Visual Studio debugger. The assembly that is produced can be an executable file or a library (DLL). A project consists of source files all written in the same programming language. A *solution* is a collection of projects. Projects in a solution can be written in different languages. For example, you can have a Visual Basic or C# user interface for your application, which is one project, and an F# library as another project. One of these projects will be the startup project: the one that is set to run when you start the application.

To create an F# project, on the **File** menu, point to **New** and then click **Project**. In the **New Project** dialog box, select a project template. Visual Studio provides templates that enable you to create projects that already have all the basic elements and settings that support applications and libraries.

When you deploy your applications to run on computers other than your development computer, you must specify a deployment option, and make sure that the F# runtime is included in the deployment. For a full description of deployment options, see [Deploying Applications, Services, and Components](https://msdn.microsoft.com/library/wtzawcsz.aspx).


## Round-Tripping Projects in Visual Studio
You can open and work with F# projects that were created in Visual Studio 2013 or Visual Studio 2012 in either version of Visual Studio, without making any modifications. The only exception is that, the first time that you open a Visual Studio 2012 project in Visual Studio 2013, Visual Studio makes a small change to enable the project to be used in both versions. This capability is known as round-tripping.

You can specify which version of the F# runtime (and core library) you want to target on the **Application** tab of the project’s properties. Choose **F# 3.0** if you’re creating a library that must run in many contexts or you want to participate in project round-tripping. If you choose **F# 3.0**, you won't be able to use any of the language features that are new in F# 3.1, such as named union cases and enhanced array slicing. If you change the target runtime to **F# 3.1**, you can’t reopen the project in Visual Studio 2012.


## Creating Applications That Have User Interfaces
Other languages support visual designers that enable you to create UIs for applications. F# programs can directly target the .NET Framework libraries, such as WPF, Windows Forms, or ASP.NET, that enable you to create UIs for applications in F#, but Visual Studio 2012 does not provide a visual designer to help you create interfaces. A typical scenario is to create a multiple-language solution with one Visual Basic or C# application project that contains the UI, and also have one or more F# library projects.


## F# Projects
The order of files is significant in F# projects. Files in an F# project are processed in order by the F# compiler. The F# compiler requires that you define all constructs before you start to use them; therefore, the files that include the definition of any F# construct must appear earlier in the list of files in the project than the files that use that construct. You also must avoid circular dependencies that span multiple files. To make it easier to move files around in a project, F# provides commands that enable you to move files up or down in the file list in **Solution Explorer**. You can access these commands by right-clicking the files in the file list or using the keyboard shortcuts, which are displayed on the menu.


## F# Files in F# Projects
The following table summarizes some the file types that you can use in F# projects.



|File type and extension|Description|
|-----------------------|-----------|
|Implementation file (.fs)|Used for F# code.|
|Signature file (.fsi)|Used to specify the public signatures of modules and types in an F# implementation file. For more information, see [Signatures &#40;F&#35;&#41;](Signatures-%5BFSharp%5D.md).|
|Script (.fsx)|Used to include informal testing code in F# without adding the test code to your application, and without creating a separate project for it. By default, script files are not included in the build of a project even when they are part of a project.|

## Portable Libraries in F# #
You use the F# Library, the F# Portable Library, or the F# Portable Library (Legacy) project template when you create a DLL and the F# Application project when you create an executable file. You should use the F# Portable Library project if your library will be consumed by applications that use the Windows Runtime, such as a Windows Store app, or another platform that uses the .NET Framework 4.5. Use the F# Portable Library (legacy) project template if your library will be consumed by portable applications, such as Windows Store, Xamarin.iOS or Xamarin.Android apps, that can run on the .NET Framework 4.


>[!WARNING] 
If your Visual C# app uses an F# portable library or legacy portable library, you must add a reference in your Visual C# project to the appropriate version of the F# Core Library (FSharp.Core.dll). To add a reference in your C# project, you must browse to the same version of FSharp.Core.dll that your F# library uses. To obtain the path, choose the FSharp.Core node in the **References** section of your F# project in **Solution Explorer** and then view the **Full Path** property in the **Properties** window.


## Related Topics


|Title|Description|
|-----|-----------|
|[F&#35; Development Environment Features](FSharp-Development-Environment-Features.md)|Lists Visual Studio features and indicates which are supported in Visual F#.|
|[Configuring Projects &#40;F&#35;&#41;](Configuring-Projects-%5BFSharp%5D.md)|Provides information about project settings in Visual F#.|
|[Project Properties Reference](https://msdn.microsoft.com/library/16satcwx.aspx)|Provides links to topics that describe Visual Studio dialog boxes that pertain to projects. F# project support is a subset of the Visual Studio support.|
|[Visual F&#35;](Visual-FSharp.md)|Introduces Visual F# and provides links to relevant topics.|
|[Walkthrough: Using Visual F&#35; to Create, Debug, and Deploy an Application](Walkthrough-Using-Visual-FSharp-to-Create%2C-Debug%2C-and-Deploy-an-Application.md)|Provides step-by-step instructions for developing applications in Visual F#.|
|[Debugging F&#35;](https://msdn.microsoft.com/library/ee843932.aspx)|Provides information about debugging in F#.|
|[Visual F&#35; Guided Tour](Visual-FSharp-Guided-Tour.md)|Provides links to introductory tutorials for some aspects of programming in F#|