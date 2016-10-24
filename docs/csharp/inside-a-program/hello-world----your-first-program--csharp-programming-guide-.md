---
title: "Hello World -- Your First Program (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "get-started-article"
f1_keywords: 
  - "cs.program"
  - "vs.csharp.startpage.firstapplication"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "examples [C#], Hello World"
  - "Hello World example [C#]"
ms.assetid: 6493182a-b0b6-4539-a719-518a168cb730
caps.latest.revision: 39
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
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
# Hello World -- Your First Program (C# Programming Guide)
The following procedure creates a C# version of the traditional "Hello World!" program. The program displays the string `Hello World!`  
  
 For more examples of introductory concepts, see [Getting Started with Visual C# and Visual Basic](../Topic/Getting%20Started%20with%20Visual%20C%23%20and%20Visual%20Basic.md).  
  
 [!INCLUDE[note_settings_general](../assemblies-gac/includes/note_settings_general_md.md)]  
  
### To create and run a console application  
  
1.  Start Visual Studio.  
  
2.  On the menu bar, choose **File**, **New**, **Project**.  
  
     The **New Project** dialog box opens.  
  
3.  Expand **Installed**, expand **Templates**, expand **Visual C#**, and then choose **Console Application**.  
  
4.  In the **Name** box, specify a name for your project, and then choose the **OK** button.  
  
     The new project appears in **Solution Explorer**.  
  
5.  If Program.cs isn't open in the **Code Editor**, open the shortcut menu for **Program.cs** in **Solution Explorer**, and then choose **View Code**.  
  
6.  Replace the contents of Program.cs with the following code.  
  
     [!code[csProgGuide#21](../inside-a-program/codesnippet/CSharp/hello-world----your-first-program--csharp-programming-guide-_1.cs)]  
  
7.  Choose the F5 key to run the project. A Command Prompt window appears that contains the line `Hello World!`  
  
 Next, the important parts of this program are examined.  
  
## Comments  
 The first line contains a comment. The characters `//` convert the rest of the line to a comment.  
  
 [!code[csProgGuide#32](../inside-a-program/codesnippet/CSharp/hello-world----your-first-program--csharp-programming-guide-_2.cs)]  
  
 You can also comment out a block of text by enclosing it between the `/*` and `*/` characters. This is shown in the following example.  
  
 [!code[csProgGuide#33](../inside-a-program/codesnippet/CSharp/hello-world----your-first-program--csharp-programming-guide-_3.cs)]  
  
## Main Method  
 A C# console application must contain a `Main` method, in which control starts and ends. The `Main` method is where you create objects and execute other methods.  
  
 The `Main` method is a [static](../keywords/static--csharp-reference-.md) method that resides inside a class or a struct. In the previous "Hello World!" example, it resides in a class named `Hello`. You can declare the `Main` method in one of the following ways:  
  
-   It can return `void`.  
  
     [!code[csProgGuideMain#12](../inside-a-program/codesnippet/CSharp/hello-world----your-first-program--csharp-programming-guide-_4.cs)]  
  
-   It can also return an integer.  
  
     [!code[csProgGuideMain#13](../inside-a-program/codesnippet/CSharp/hello-world----your-first-program--csharp-programming-guide-_5.cs)]  
  
-   With either of the return types, it can take arguments.  
  
     [!code[csProgGuideMain#19](../inside-a-program/codesnippet/CSharp/hello-world----your-first-program--csharp-programming-guide-_6.cs)]  
  
     -or-  
  
     [!code[csProgGuideMain#18](../inside-a-program/codesnippet/CSharp/hello-world----your-first-program--csharp-programming-guide-_7.cs)]  
  
 The parameter of the `Main` method, `args`, is a `string` array that contains the command-line arguments used to invoke the program. Unlike in C++, the array does not include the name of the executable (exe) file.  
  
 For more information about how to use command-line arguments, see the examples in [Main() and Command-Line Arguments](../main-and-command-args/main---and-command-line-arguments--csharp-programming-guide-.md) and [How to: Create and Use Assemblies Using the Command Line](../Topic/How%20to:%20Create%20and%20Use%20Assemblies%20Using%20the%20Command%20Line%20\(C%23%20and%20Visual%20Basic\).md).  
  
 The call to <xref:System.Console.ReadKey*> at the end of the `Main` method prevents the console window from closing before you have a chance to read the output when you run your program in debug mode, by pressing F5.  
  
## Input and Output  
 C# programs generally use the input/output services provided by the run-time library of the .NET Framework. The statement `System.Console.WriteLine("Hello World!");` uses the <xref:System.Console.WriteLine*> method. This is one of the output methods of the <xref:System.Console> class in the run-time library. It displays its string parameter on the standard output stream followed by a new line. Other <xref:System.Console> methods are available for different input and output operations. If you include the `using System;` directive at the beginning of the program, you can directly use the <xref:System> classes and methods without fully qualifying them. For example, you can call `Console.WriteLine` instead of `System.Console.WriteLine`:  
  
 [!code[csProgGuide#1](../inside-a-program/codesnippet/CSharp/hello-world----your-first-program--csharp-programming-guide-_8.cs)]  
  
 [!code[csProgGuide#23](../inside-a-program/codesnippet/CSharp/hello-world----your-first-program--csharp-programming-guide-_9.cs)]  
  
 For more information about input/output methods, see <xref:System.IO>.  
  
## Command-Line Compilation and Execution  
 You can compile the "Hello World!" program by using the command line instead of the Visual Studio Integrated Development Environment (IDE).  
  
#### To compile and run from a command prompt  
  
1.  Paste the code from the preceding procedure into any text editor, and then save the file as a text file. Name the file `Hello.cs`. C# source code files use the extension `.cs`.  
  
2.  Perform one of the following steps to open a command-prompt window:  
  
    -   In Windows 8, on the **Start** screen, search for `Developer Command Prompt`, and then tap or choose **Developer Command Prompt for VS2012**.  
  
         A Developer Command Prompt window appears.  
  
    -   In Windows 7, open the **Start** menu, expand the folder for the current version of Visual Studio, open the shortcut menu for **Visual Studio Tools**, and then choose **Developer Command Prompt for VS2012**.  
  
         A Developer Command Prompt window appears.  
  
    -   Enable command-line builds from a standard Command Prompt window.  
  
         See [How to: Set Environment Variables for the Visual Studio Command Line](../compiler-options/how-to--set-environment-variables-for-the-visual-studio-command-line.md).  
  
3.  In the command-prompt window, navigate to the folder that contains your `Hello.cs` file.  
  
4.  Enter the following command to compile `Hello.cs`.  
  
     `csc Hello.cs`  
  
     If your program has no compilation errors, an executable file that is named `Hello.exe` is created.  
  
5.  In the command-prompt window, enter the following command to run the program:  
  
     `Hello`  
  
 For more information about the C# compiler and its options, see [C# Compiler Options](../compiler-options/csharp-compiler-options.md).  
  
## Featured Book Chapter  
 [Writing a C# Program](http://go.microsoft.com/fwlink/?LinkId=221227) in [Beginning Visual C# 2010](http://go.microsoft.com/fwlink/?LinkId=221214)  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Inside a C# Program](../inside-a-program/inside-a-csharp-program.md)   
 [Strings](../strings/strings--csharp-programming-guide-.md)   
 [\<paveover>C# Sample Applications](http://msdn.microsoft.com/en-us/9a9d7aaa-51d3-4224-b564-95409b0f3e15)   
 [C# Reference](../language-reference/csharp-reference.md)   
 [Main() and Command-Line Arguments](../main-and-command-args/main---and-command-line-arguments--csharp-programming-guide-.md)   
 [Getting Started with Visual C# and Visual Basic](../Topic/Getting%20Started%20with%20Visual%20C%23%20and%20Visual%20Basic.md)