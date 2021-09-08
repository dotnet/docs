---
description: "Miscellaneous C# Compiler Options. These options provide general options to the compiler."
title: "C# Compiler Options that don't fit other categories"
ms.date: 03/12/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "ResponseFiles compiler option [C#]"
  - "NoLogo compiler option [C#]"
  - "NoConfig compiler option [C#]"
---
# Miscellaneous C# Compiler Options

The following options control miscellaneous compiler behavior. The new MSBuild syntax is shown in **Bold**. The older *csc.exe* syntax is shown in `code style`.

- **ResponseFiles** / `-@`: Read response file for more options.
- **NoLogo** / `-nologo` : Suppress compiler copyright message.
- **NoConfig** / `-noconfig`: Don't auto include *CSC.RSP* file.

## ResponseFiles

The **ResponseFiles** option lets you specify a file that contains compiler options and source code files to compile.

```xml
<ResponseFiles>response_file</ResponseFiles>
```

The `response_file` specifies the file that lists compiler options or source code files to compile. The compiler options and source code files will be processed by the compiler as if they had been specified on the command line. To specify more than one response file in a compilation, specify multiple response file options. In a response file, multiple compiler options and source code files can appear on one line. A single compiler option specification must appear on one line (can't span multiple lines). Response files can have comments that begin with the # symbol. Specifying compiler options from within a response file is just like issuing those commands on the command line. The compiler processes the command options as they're read. Command-line arguments can override previously listed options in response files. Conversely, options in a response file will override options listed previously on the command line or in other response files. C# provides the csc.rsp file, which is located in the same directory as the csc.exe file. For more information about the response file format, see [**NoConfig**](#noconfig). This compiler option cannot be set in the Visual Studio development environment, nor can it be changed programmatically. The following are a few lines from a sample response file:

```console
# build the first output file
-target:exe -out:MyExe.exe source1.cs source2.cs
```

## NoLogo

The **NoLogo** option suppresses display of the sign-on banner when the compiler starts up and display of informational messages during compiling.

```xml
<NoLogo>true</NoLogo>
```

## NoConfig

The **NoConfig** option tells the compiler not to compile with the *csc.rsp* file.

```xml
<NoConfig>true</NoConfig>
```

The *csc.rsp* file references all the assemblies shipped with .NET Framework. The actual references that the Visual Studio .NET development environment includes depend on the project type. You can modify the *csc.rsp* file and specify additional compiler options that should be included in every compilation. If you don't want the compiler to look for and use the settings in the *csc.rsp* file, specify **NoConfig**. This compiler option is unavailable in Visual Studio and cannot be changed programmatically.
