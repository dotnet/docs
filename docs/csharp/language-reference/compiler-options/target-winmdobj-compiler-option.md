---
title: "-target:winmdobj (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 1819a045-659d-498a-9457-c466e902986f
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
---
# -target:winmdobj (C# Compiler Options)
If you use the **-target:winmdobj** compiler option, the compiler creates an intermediate .winmdobj file that you can convert to a Windows Runtime binary (.winmd) file. The .winmd file can then be consumed by JavaScript and C++ programs, in addition to managed language programs.  
  
## Syntax  
  
```console  
-target:winmdobj  
```  
  
## Remarks  
 The **winmdobj** setting signals to the compiler that an intermediate module is required. In response, Visual Studio compiles the C# class library as a .winmdobj file. The .winmdobj file can then be fed through the <xref:Microsoft.Build.Tasks.WinMDExp> export tool to produce a Windows metadata (.winmd) file. The .winmd file contains both the code from the original library and the WinMD metadata that is used by JavaScript or C++ and by the Windows Runtime.  
  
 The output of a file that’s compiled by using the **-target:winmdobj** compiler option is designed to be used only as input for the WimMDExp export tool; the .winmdobj file itself isn’t referenced directly.  
  
 Unless you use the [-out](../../../csharp/language-reference/compiler-options/out-compiler-option.md) option, the output file name takes the name of the first input file. A [Main](../../../csharp/programming-guide/main-and-command-args/index.md) method isn’t required.  
  
 If you specify the -target:winmdobj option at a command prompt, all files until the next **-out** or [-target:module](../../../csharp/language-reference/compiler-options/target-module-compiler-option.md) option are used to create the Windows program.  
  
### To set this compiler option in the Visual Studio IDE for a Windows Store app  
  
1.  In **Solution Explorer**, open the shortcut menu for your project, and then choose **Properties**.  
  
2.  Choose the **Application** tab.  
  
3.  In the **Output type** list, choose **WinMD File**.  
  
     The **WinMD File** option is available only for [!INCLUDE[win8_appname_long](~/includes/win8-appname-long-md.md)] app templates.  
  
 For information about how to set this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.OutputType%2A>.  
  
## Example  
 The following command compiles `filename.cs` into an intermediate .winmdobj file.  
  
```console  
csc -target:winmdobj filename.cs  
```  
  
## See Also  
 [-target (C# Compiler Options)](../../../csharp/language-reference/compiler-options/target-compiler-option.md)  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)
