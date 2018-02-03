---
title: "Command-line build with csc.exe"
ms.date: 04/19/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "builds [C#]"
  - "command line [C#]"
ms.assetid: 66e70056-dd20-453c-a9b3-507e0478b015
caps.latest.revision: 28
author: "BillWagner"
ms.author: "wiwagn"
---
# Command-line build with csc.exe
You can invoke the C# compiler by typing the name of its executable file (*csc.exe*) at a command prompt.

If you use the **Developer Command Prompt for Visual Studio** window, all the necessary environment variables are set for you. For information on how to access this tool, see the [Developer Command Prompt for Visual Studio](../../../framework/tools/developer-command-prompt-for-vs.md) topic. 

If you use a standard Command Prompt window, you must adjust your path before you can invoke *csc.exe* from any subdirectory on your computer. You also must run *vsvars32.bat* to set the appropriate environment variables to support command-line builds. For more information about *vsvars32.bat*, including instructions for how to find and run it, see [How to: Set Environment Variables for the Visual Studio Command Line](../../../csharp/language-reference/compiler-options/how-to-set-environment-variables-for-the-visual-studio-command-line.md).

If you're working on a computer that has only the [!INCLUDE[winsdklong](~/includes/winsdklong-md.md)], you can use the C# compiler at the **SDK Command Prompt**, which you open from the **Microsoft .NET Framework SDK** menu option.

You can also use MSBuild to build C# programs programmatically. For more information, see [MSBuild](/visualstudio/msbuild/msbuild).

The *csc.exe* executable file usually is located in the Microsoft.NET\Framework\\*\<Version>* folder under the *Windows* directory. Its location might vary depending on the exact configuration of a particular computer. If more than one version of the .NET Framework is installed on your computer, you'll find multiple versions of this file. For more information about such installations, see [How to: determine which versions of the .NET Framework are installed](../../../framework/migration-guide/how-to-determine-which-versions-are-installed.md).

> [!TIP]
>  When you build a project by using the Visual Studio IDE, you can display the **csc** command and its associated compiler options in the **Output** window. To display this information, follow the instructions in [How to: View, Save, and Configure Build Log Files](/visualstudio/ide/how-to-view-save-and-configure-build-log-files#to-change-the-amount-of-information-included-in-the-build-log) to change the verbosity level of the log data to **Normal** or **Detailed**. After you rebuild your project, search the **Output** window for **csc** to find the invocation of the C# compiler.

 **In this topic**

- [Rules for command-line syntax](#-rules-for-command-line-syntax-for-the-c-compiler)

- [Sample command lines](#sample-command-lines-for-the-c-compiler)

- [Differences between C# compiler and C++ compiler output](#differences-between-c-compiler-and-c-compiler-output)

## Rules for command-line syntax for the C# compiler

The C# compiler uses the following rules when it interprets arguments given on the operating system command line:

- Arguments are delimited by white space, which is either a space or a tab.

- The caret character (^) is not recognized as an escape character or delimiter. The character is handled by the command-line parser in the operating system before it's passed to the `argv` array in the program.

- A string enclosed in double quotation marks ("string") is interpreted as a single argument, regardless of white space that is contained within. A quoted string can be embedded in an argument.

- A double quotation mark preceded by a backslash (\\") is interpreted as a literal double quotation mark character (").

- Backslashes are interpreted literally, unless they immediately precede a double quotation mark.

- If an even number of backslashes is followed by a double quotation mark, one backslash is put in the `argv` array for every pair of backslashes, and the double quotation mark is interpreted as a string delimiter.

- If an odd number of backslashes is followed by a double quotation mark, one backslash is put in the `argv` array for every pair of backslashes, and the double quotation mark is "escaped" by the remaining backslash. This causes a literal double quotation mark (") to be added in `argv`.

## Sample command lines for the C# compiler

- Compiles *File.cs* producing *File.exe*:

```console
csc File.cs 
```

- Compiles *File.cs* producing *File.dll*:

```console
csc -target:library File.cs
```

- Compiles *File.cs* and creates *My.exe*:

```console
csc -out:My.exe File.cs
```

- Compiles all the C# files in the current directory with optimizations enabled and defines the DEBUG symbol. The output is *File2.exe*:

```console
csc -define:DEBUG -optimize -out:File2.exe *.cs
```

- Compiles all the C# files in the current directory producing a debug version of *File2.dll*. No logo and no warnings are displayed:

```console
csc -target:library -out:File2.dll -warn:0 -nologo -debug *.cs
```

- Compiles all the C# files in the current directory to *Something.xyz* (a DLL):

```console
csc -target:library -out:Something.xyz *.cs
```

## Differences between C# compiler and C++ compiler output
There are no object (*.obj*) files created as a result of invoking the C# compiler; output files are created directly. As a result of this, the C# compiler does not need a linker.

## See also
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [C# Compiler Options Listed Alphabetically](../../../csharp/language-reference/compiler-options/listed-alphabetically.md)  
 [C# Compiler Options Listed by Category](../../../csharp/language-reference/compiler-options/listed-by-category.md)  
 [Main() and Command-Line Arguments](../../../csharp/programming-guide/main-and-command-args/index.md)  
 [Command-Line Arguments](../../../csharp/programming-guide/main-and-command-args/command-line-arguments.md)  
 [How to: Display Command-Line Arguments](../../../csharp/programming-guide/main-and-command-args/how-to-display-command-line-arguments.md)  
 [How to: Access Command-Line Arguments Using foreach](../../../csharp/programming-guide/main-and-command-args/how-to-access-command-line-arguments-using-foreach.md)  
 [Main() Return Values](../../../csharp/programming-guide/main-and-command-args/main-return-values.md)
