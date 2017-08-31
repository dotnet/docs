---
title: "-out (C# Compiler Options) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "/out"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "/out compiler option [C#]"
  - "out compiler option [C#]"
  - "-out compiler option [C#]"
ms.assetid: 70d91d01-7bd2-4aea-ba8b-4e9807e9caa5
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /out (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The **/out** option specifies the name of the output file.  
  
## Syntax  
  
```  
/out:filename  
```  
  
## Arguments  
 `filename`  
 The name of the output file created by the compiler.  
  
## Remarks  
 On the command line, it is possible to specify multiple output files for your compilation. The compiler expects to find one or more source code files following the **/out** option. Then, all source code files will be compiled into the output file specified by that **/out** option.  
  
 Specify the full name and extension of the file you want to create.  
  
 If you do not specify the name of the output file:  
  
-   An .exe will take its name from the source code file that contains the **Main** method.  
  
-   A .dll or .netmodule will take its name from the first source code file.  
  
 A source code file used to compile one output file cannot be used in the same compilation for the compilation of another output file.  
  
 When producing multiple output files in a command-line compilation, keep in mind that only one of the output files can be an assembly and that only the first output file specified (implicitly or explicitly with **/out**) can be the assembly.  
  
 Any modules produced as part of a compilation become files associated with any assembly also produced in the compilation. Use [ildasm.exe](../Topic/Ildasm.exe%20\(IL%20Disassembler\).md) to view the assembly manifest to see the associated files.  
  
 The /out compiler option is required in order for an exe to be the target of a friend assembly. For more information see [Friend Assemblies](../Topic/Friend%20Assemblies%20\(C%23%20and%20Visual%20Basic\).md).  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Application** property page.  
  
3.  Modify the **Assembly name** property.  
  
     To set this compiler option programmatically: the <xref:VSLangProj80.ProjectProperties3.OutputFileName%2A> is a read-only property, which is determined by a combination of the project type (exe, library, and so forth) and the assembly name. Modifying one or both of these properties will be necessary to set the output file name.  
  
## Example  
 Compile `t.cs` and create output file `t.exe`, as well as build `t2.cs` and create module output file `mymodule.netmodule`:  
  
```  
csc t.cs /out:mymodule.netmodule /target:module t2.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [Friend Assemblies](../Topic/Friend%20Assemblies%20\(C%23%20and%20Visual%20Basic\).md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)