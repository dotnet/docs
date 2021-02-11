---
description: "C# Compiler Options"
title: "C# Compiler Options"
ms.date: 02/12/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "compiler options [C#]"
  - "csc.exe"
  - "cl.exe compiler, C# options"
  - "Visual C# compiler"
  - "Visual C#, compiler options"
ms.assetid: d3403556-1816-4546-a782-e8223a772e44
---
# C# Compiler Options

This section describes the options interpreted by the C# compiler. There are two different ways to set compiler options in .NET projects:

- ***Specify option in your \*.csproj file***: You can add XML elements for any compiler option in your *\*.csproj* file. The element name is the same as the compiler option. The value of the XML element sets the value of the compiler option. For more details on setting options in project files see the article [MSBuild properties for .NET SDK Projects](../../../core/project-sdk/msbuild-props.md).
- ***Using the Visual Studio Property pages***: Visual Studio provides property pages to edit build properties. You can learn more about them see the article [Manage project and solution properties - Windows](https://docs.microsoft.com/visualstudio/ide/managing-project-and-solution-properties#c-visual-basic-and-f-projects) or [Manage project and solution properties - Mac](https://docs.microsoft.com/visualstudio/mac/managing-solutions-and-project-properties).

## .NET Framework projects

> [!IMPORTANT]
> This section applies to .NET Framework projects only.

You can invoke the C# compiler by typing the name of its executable file (*csc.exe*) at a command prompt.

For .NET Framework projects, you can also run `csc.exe` from the command line. Every compiler option is available in two forms: **-option** and **/option**. In .NET Framework web projects, you specify options for compiling code behind in the *web.config* file. For more information, see [\<compiler> Element](../../../framework/configure-apps/file-schema/compiler/compiler-element.md).

If you use the **Developer Command Prompt for Visual Studio** window, all the necessary environment variables are set for you. For information on how to access this tool, see the [Developer Command Prompt for Visual Studio](../../../framework/tools/developer-command-prompt-for-vs.md) topic.

The *csc.exe* executable file usually is located in the Microsoft.NET\Framework\\*\<Version>* folder under the *Windows* directory. Its location might vary depending on the exact configuration of a particular computer. If more than one version of the .NET Framework is installed on your computer, you'll find multiple versions of this file. For more information about such installations, see [How to: determine which versions of the .NET Framework are installed](../../../framework/migration-guide/how-to-determine-which-versions-are-installed.md).
