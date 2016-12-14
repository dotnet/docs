---
title: "Command-line Building With csc.exe | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "builds [C#]"
  - "command line [C#]"
ms.assetid: 66e70056-dd20-453c-a9b3-507e0478b015
caps.latest.revision: 28
author: "BillWagner"
ms.author: "wiwagn"
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
# Command-line Building With csc.exe
You can invoke the C# compiler by typing the name of its executable file (csc.exe) at a command prompt.  
  
 If you use the **Visual Studio Command Prompt** window, all the necessary environment variables are set for you. In Windows 7, you can access that window from the **Start** menu by opening the Microsoft Visual Studio *Version*\Visual Studio Tools folder. In Windows 8, the Visual Studio Command Prompt is called the **Developer Command Prompt for VS2012**, and you can find it by searching from the Start screen.  
  
 If you use a standard Command Prompt window, you must adjust your path before you can invoke csc.exe from any subdirectory on your computer. You also must run vsvars32.bat to set the appropriate environment variables to support command-line builds. For more information about vsvars32.bat, including instructions for how to find and run it, see [How to: Set Environment Variables for the Visual Studio Command Line](../../../csharp/language-reference/compiler-options/how-to-set-environment-variables-for-the-visual-studio-command-line.md).  
  
 If you're working on a computer that has only the [!INCLUDE[winsdklong](../../../csharp/language-reference/compiler-options/includes/winsdklong_md.md)], you can use the C# compiler at the **SDK Command Prompt**, which you open from the **Microsoft .NET Framework SDK** menu option.  
  
 You can also use MSBuild to build C# programs programmatically. For more information, see [MSBuild](https://docs.microsoft.com/visualstudio/msbuild/msbuild1).  
  
 The csc.exe executable file usually is located in the Microsoft.NET\Framework\\*Version* folder under the Windows directory. Its location might vary depending on the exact configuration of a particular computer. If more than one version of the .NET Framework is installed on your computer, you'll find multiple versions of this file. For more information about such installations, see [Determining Which Version of the .NET Framework Is Installed](http://msdn.microsoft.com/en-us/1a87cc6a-1c4b-4c38-b878-faa9b3beae3c).  
  
> [!TIP]
>  When you build a project by using the Visual Studio IDE, you can display the **csc** command and its associated compiler options in the **Output** window. To display this information, follow the instructions in [How to: View, Save, and Configure Build Log Files](http://msdn.microsoft.com/library/75d38b76-26d6-4f43-bbe7-cbacd7cc81e7) to change the verbosity level of the log data to **Normal** or **Detailed**. After you rebuild your project, search the **Output** window for **csc** to find the invocation of the C# compiler.  
  
 **In this topic**  
  
-   [Rules for Command-Line Syntax](#vcconcommand-linebuildinganchor1)  
  
-   [Sample Command Lines](#vcconcommand-linebuildinganchor2)  
  
-   [Differences Between C# Compiler and C++ Compiler Output](#vcconcommand-linebuildinganchor3)  
  
##  <a name="vcconcommand-linebuildinganchor1"></a> Rules for Command-Line Syntax for the C# Compiler  
 The C# compiler uses the following rules when it interprets arguments given on the operating system command line:  
  
-   Arguments are delimited by white space, which is either a space or a tab.  
  
-   The caret character (^) is not recognized as an escape character or delimiter. The character is handled by the command-line parser in the operating system before it is passed to the argv array in the program.  
  
-   A string enclosed in double quotation marks ("string") is interpreted as a single argument, regardless of white space that is contained within. A quoted string can be embedded in an argument.  
  
-   A double quotation mark preceded by a backslash (\\") is interpreted as a literal double quotation mark character (").  
  
-   Backslashes are interpreted literally, unless they immediately precede a double quotation mark.  
  
-   If an even number of backslashes is followed by a double quotation mark, one backslash is put in the argv array for every pair of backslashes, and the double quotation mark is interpreted as a string delimiter.  
  
-   If an odd number of backslashes is followed by a double quotation mark, one backslash is put in the argv array for every pair of backslashes, and the double quotation mark is "escaped" by the remaining backslash. This causes a literal double quotation mark (") to be added in argv.  
  
##  <a name="vcconcommand-linebuildinganchor2"></a> Sample Command Lines for the C# Compiler  
  
-   Compiles File.cs producing File.exe:  
  
    ```  
    csc File.cs   
    ```  
  
-   Compiles File.cs producing File.dll:  
  
    ```  
    csc /target:library File.cs  
    ```  
  
-   Compiles File.cs and creates My.exe:  
  
    ```  
    csc /out:My.exe File.cs  
    ```  
  
-   Compiles all the C# files in the current directory, with optimizations on and defines the DEBUG symbol. The output is File2.exe:  
  
    ```  
    csc /define:DEBUG /optimize /out:File2.exe *.cs  
    ```  
  
-   Compiles all the C# files in the current directory producing a debug version of File2.dll. No logo and no warnings are displayed:  
  
    ```  
    csc /target:library /out:File2.dll /warn:0 /nologo /debug *.cs  
    ```  
  
-   Compiles all the C# files in the current directory to Something.xyz (a DLL):  
  
    ```  
    csc /target:library /out:Something.xyz *.cs  
    ```  
  
##  <a name="vcconcommand-linebuildinganchor3"></a> Differences Between C# Compiler and C++ Compiler Output  
 There are no object (.obj) files created as a result of invoking the C# compiler; output files are created directly. As a result of this, the C# compiler does not need a linker.  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [C# Compiler Options Listed Alphabetically](../../../csharp/language-reference/compiler-options/listed-alphabetically.md)   
 [C# Compiler Options Listed by Category](../../../csharp/language-reference/compiler-options/listed-by-category.md)   
 [Main() and Command-Line Arguments](../../../csharp/programming-guide/main-and-command-args/main-and-command-line-arguments.md)   
 [Command-Line Arguments](../../../csharp/programming-guide/main-and-command-args/command-line-arguments.md)   
 [How to: Display Command Line Arguments](../../../csharp/programming-guide/main-and-command-args/how-to-display-command-line-arguments.md)   
 [How to: Access Command-Line Arguments Using foreach](../../../csharp/programming-guide/main-and-command-args/how-to-access-command-line-arguments-using-foreach.md)   
 [Main() Return Values](../../../csharp/programming-guide/main-and-command-args/main-return-values.md)