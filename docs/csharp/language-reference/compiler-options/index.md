---
description: "C# Compiler Options. Learn the options that control the behavior of the C# compiler."
title: "C# Compiler Options"
ms.date: 09/01/2021
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
# C# compiler options

This section describes the options interpreted by the C# compiler. Options are grouped into separate articles based on what they control, for example, language features, code generation, and output. Use the table of contents to navigate amongst them.

## How to set options

There are two different ways to set compiler options in .NET projects:

- ***In your \*.csproj file***

  You can add MSBuild properties for any compiler option in your *\*.csproj* file in XML format. The property name is the same as the compiler option. The value of the property sets the value of the compiler option. For example, the following project file snippet sets the `LangVersion` property.

  ```xml
  <PropertyGroup>
    <LangVersion>preview</LangVersion>
  </PropertyGroup>
  ```

  For more information on setting options in project files, see the article [MSBuild properties for .NET SDK Projects](../../../core/project-sdk/msbuild-props.md).

- ***Using the Visual Studio Property pages***

  Visual Studio provides property pages to edit build properties. To learn more about them, see [Manage project and solution properties - Windows](/visualstudio/ide/managing-project-and-solution-properties#c-visual-basic-and-f-projects) or [Manage project and solution properties - Mac](/visualstudio/mac/managing-solutions-and-project-properties).

### .NET Framework projects

> [!IMPORTANT]
> This section applies to .NET Framework projects only.

In addition to the mechanisms described above, you can set compiler options using two additional methods for .NET Framework projects:

- **Command line arguments for .NET Framework projects**: .NET Framework projects use *csc.exe* instead of `dotnet build` to build projects. You can specify command line arguments to *csc.exe* for .NET Framework projects.
- **Compiled ASP.NET pages**: .NET Framework projects use a section of the *web.config* file for compiling pages. For the new build system, and ASP.NET Core projects, options are taken from the project file.

The word for some compiler options changed from *csc.exe* and .NET Framework projects to the new MSBuild system. The new syntax is used throughout this section. Both versions are listed at the top of each page. For *csc.exe*, any arguments are listed following the option and a colon. For example, the `-doc` option would be:

```console
-doc:DocFile.xml
```

You can invoke the C# compiler by typing the name of its executable file (*csc.exe*) at a command prompt.

For .NET Framework projects, you can also run *csc.exe* from the command line. Every compiler option is available in two forms: **-option** and **/option**. In .NET Framework web projects, you specify options for compiling code-behind in the *web.config* file. For more information, see [\<compiler> Element](../../../framework/configure-apps/file-schema/compiler/compiler-element.md).

If you use the **Developer Command Prompt for Visual Studio** window, all the necessary environment variables are set for you. For information on how to access this tool, see [Developer Command Prompt for Visual Studio](/visualstudio/ide/reference/command-prompt-powershell).

The *csc.exe* executable file is usually located in the Microsoft.NET\Framework\\*\<Version>* folder under the *Windows* directory. Its location might vary depending on the exact configuration of a particular computer. If more than one version of .NET Framework is installed on your computer, you'll find multiple versions of this file. For more information about such installations, see [How to: determine which versions of the .NET Framework are installed](../../../framework/migration-guide/how-to-determine-which-versions-are-installed.md).
