---
title: "Main() Return Values (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "Main method [C#], return values"
ms.assetid: c2f5a1d8-1676-4bea-bc7e-44a97e72d5bc
caps.latest.revision: 20
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
# Main() Return Values (C# Programming Guide)
The `Main` method can return `void`:  
  
 [!code-cs[csProgGuideMain#12](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/main-return-values_1.cs)]  
  
 It can also return an `int`:  
  
 [!code-cs[csProgGuideMain#13](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/main-return-values_2.cs)]  
  
 If the return value from `Main` is not used, returning `void` allows for slightly simpler code. However, returning an integer enables the program to communicate status information to other programs or scripts that invoke the executable file. The following example shows how the return value from `Main` can be accessed.  
  
## Example  
 In this example, a batch file is used to run a program and test the return value of the `Main` function. When a program is executed in Windows, any value returned from the `Main` function is stored in an environment variable called `ERRORLEVEL`. A batch file can determine the outcome of execution by inspecting the `ERRORLEVEL` variable. Traditionally, a return value of zero indicates successful execution. The following example is a simple program that returns zero from the `Main` function. The zero indicates that the program ran successfully. Save the program as MainReturnValTest.cs.  
  
 [!code-cs[csProgGuideMain#14](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/main-return-values_3.cs)]  
  
## Example  
 Because this example uses a batch file, it is best to compile the code from a command prompt. Follow the instructions in [How to: Set Environment Variables for the Visual Studio Command Line](../../../csharp/language-reference/compiler-options/how-to-set-environment-variables-for-the-visual-studio-command-line.md) to enable command-line builds, or use the Visual Studio Command Prompt, available from the **Start** menu under **Visual Studio Tools**. From the command prompt, navigate to the folder in which you saved the program. The following command compiles MainReturnValTest.cs and produces the executable file MainReturnValTest.exe.  
  
 `csc MainReturnValTest.cs`  
  
 Next, create a batch file to run MainReturnValTest.exe and to display the result. Paste the following code into a text file and save it as `test.bat` in the folder that contains MainReturnValTest.cs and MainReturnValTest.exe. Run the batch file by typing `test` at the command prompt.  
  
 Because the code returns zero, the batch file will report success. However, if you change MainReturnValTest.cs to return a non-zero value and then re-compile the program, subsequent execution of the batch file will report failure.  
  
```  
rem test.bat  
@echo off  
MainReturnValTest  
@if "%ERRORLEVEL%" == "0" goto good  
  
:fail  
    echo Execution Failed  
    echo return value = %ERRORLEVEL%  
    goto end  
  
:good  
    echo Execution succeeded  
    echo Return value = %ERRORLEVEL%  
    goto end  
  
:end  
```  
  
## Sample Output  
 `Execution succeeded`  
  
 `Return value = 0`  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Reference](../../../csharp/language-reference/index.md)   
 [Main() and Command-Line Arguments](../../../csharp/programming-guide/main-and-command-args/index.md)   
 [How to: Display Command Line Arguments](../../../csharp/programming-guide/main-and-command-args/how-to-display-command-line-arguments.md)   
 [How to: Access Command-Line Arguments Using foreach](../../../csharp/programming-guide/main-and-command-args/how-to-access-command-line-arguments-using-foreach.md)