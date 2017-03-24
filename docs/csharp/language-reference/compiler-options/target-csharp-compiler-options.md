---
title: "-target (C# Compiler Options) | Microsoft Docs"
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
  - "/target"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "target compiler options [C#]"
  - "/target compiler options [C#]"
  - "assemblies [C#], compiling"
  - "-target compiler options [C#]"
ms.assetid: a18bbd8e-bbf7-49e7-992c-717d0eb1f76f
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /target (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The **/target** compiler option can be specified in one of four forms:  
  
 [/target:appcontainerexe](../../../csharp/language-reference/compiler-options/target-appcontainerexe-csharp-compiler-options.md)  
 To create an .exe file for [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps.  
  
 [/target:exe](../../../csharp/language-reference/compiler-options/target-exe-csharp-compiler-options.md)  
 To create an .exe file.  
  
 [/target:library](../../../csharp/language-reference/compiler-options/target-library-csharp-compiler-options.md)  
 To create a code library.  
  
 [/target:module](../../../csharp/language-reference/compiler-options/target-module-csharp-compiler-options.md)  
 To create a module.  
  
 [/target:winexe](../../../csharp/language-reference/compiler-options/target-winexe-csharp-compiler-options.md)  
 To create a Windows program.  
  
 [/target:winmdobj](../../../csharp/language-reference/compiler-options/target-winmdobj-csharp-compiler-options.md)  
 To create an intermediate .winmdobj file.  
  
 Unless you specify **/target:module**, **/target** causes a .NET Framework assembly manifest to be placed in an output file. For more information, see [Assemblies in the Common Language Runtime](../Topic/Assemblies%20in%20the%20Common%20Language%20Runtime.md) and [Common Attributes](../Topic/Common%20Attributes%20\(C%23%20and%20Visual%20Basic\).md).  
  
 The assembly manifest is placed in the first .exe output file in the compilation or in the first DLL, if there is no .exe output file. For example, in the following command line, the manifest will be placed in `1.exe`:  
  
```  
csc /out:1.exe t1.cs /out:2.netmodule t2.cs  
```  
  
 The compiler creates only one assembly manifest per compilation. Information about all files in a compilation is placed in the assembly manifest. All output files except those created with **/target:module** can contain an assembly manifest. When producing multiple output files at the command line, only one assembly manifest can be created and it must go into the first output file specified on the command line. No matter what the first output file is (**/target:exe**, **/target:winexe**, **/target:library** or **/target:module**), any other output files produced in the same compilation must be modules (**/target:module**).  
  
 If you create an assembly, you can indicate that all or part of your code is CLS compliant with the <xref:System.CLSCompliantAttribute> attribute.  
  
```  
// target_clscompliant.cs  
[assembly:System.CLSCompliant(true)]   // specify assembly compliance  
  
[System.CLSCompliant(false)]   // specify compliance for an element  
public class TestClass  
{  
    public static void Main() {}  
}  
```  
  
 For more information about setting this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.OutputType%2A>.  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)   
 [/subsystemversion (C# Compiler Options)](../../../csharp/language-reference/compiler-options/subsystemversion-csharp-compiler-options.md)