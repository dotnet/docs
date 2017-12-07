---
title: Configuring projects (F#)
description: Learn how to use the Project Designer when you work with F# projects in Visual Studio.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 8b2ed206-34e4-4256-a6ce-0c2499561165 
---
# Configuring Projects in Visual Studio

> [!NOTE]
This article is not up to date with the latest Visual Studio.  It will be updated.

This topic includes information about how to use the **Project Designer** when you work with F# projects. Working with F# projects is not significantly different from working with Visual Basic or C# projects. You can often use the general Visual Studio project documentation as your primary reference when you use F#. This topic provides links to relevant information in the Visual Studio documentation for settings that are shared with the other Visual Studio languages, and also describes the settings specific to F#.

## Project Designer
The **Project Designer** and its general use are described fully in the topic [Introduction to the Project Designer](https://msdn.microsoft.com/library/898dd854-c98d-430c-ba1b-a913ce3c73d7) in the Visual Studio documentation. The **Project Designer** consists of several pages grouped by related functionality. The pages available for F# projects are mostly a subset of those available for other languages. The pages supported in F# are described in the following table. The pages that are not available relate to features that are not available in F#, or that are available only by changing a command-line option. The pages that are available in F# resemble the C# pages most closely, so a link is provided to the relevant C# **Project Designer** page.

|Project Designer page|Related links|Description|
|---------------------|-------------|-----------|
|`Application`|[Application Page, Project Designer &#40;C&#35;&#41;](https://msdn.microsoft.com/library/ms247046.aspx)|Enables you to specify application-level settings and properties, such as whether you are creating a library or an executable file, what version of the .NET Framework the application is targeting, and information about where the resource files that the application uses are stored.|
|`Build`|[Build Page, Project Designer &#40;C&#35;&#41;](https://msdn.microsoft.com/library/kb4wyys2.aspx)|Enables you to control how the code is compiled.|
|`Build Events`|[Build Events Page, Project Designer &#40;C&#35;&#41;](https://msdn.microsoft.com/library/kb4wyys2.aspx)|Enables you to specify commands to run before or after a compilation.|
|`Debug`|[Debug Page, Project Designer](https://msdn.microsoft.com/library/2wcdezs5.aspx)|Enables you to control how the application runs during debugging. This includes what command-line to use and what your application's starting directory is, and any special debugging modes you want to enable, such as native code and SQL.|
|`Reference Paths`|[Managing references in a project](/visualstudio/ide/managing-references-in-a-project)|Enables you to specify where to search for assemblies that the code depends on.|

## F#-Specific Settings
The following table summarizes settings that are specific to F#:

|Project Designer page|Setting|Description|
|---------------------|-------|-----------|
|`Build`|`Generate tail calls`|If selected, enables the use of the tail Microsoft intermediate language (MSIL) instruction. This causes the stack frame to be reused for tail recursive functions. Equivalent to the `--tailcalls` compiler option.|
|`Build`|`Other flags`|Allows you to specify additional compiler command-line options.|

## See Also
 [Get Started with F# in Visual Studio](../get-started/get-started-visual-studio.md)  
 [Compiler Options](../language-reference/compiler-options.md)  
 [Introduction to the Project Designer](https://msdn.microsoft.com/library/898dd854-c98d-430c-ba1b-a913ce3c73d7(v=vs.100))
