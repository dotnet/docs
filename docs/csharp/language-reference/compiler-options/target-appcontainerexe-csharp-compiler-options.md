---
title: "-target:appcontainerexe (C# Compiler Options) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
ms.assetid: e7e62229-23ea-4e53-bef5-380d951bf95f
caps.latest.revision: 13
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /target:appcontainerexe (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

If you use the **/target:appcontainerexe** compiler option, the compiler creates a Windows executable (.exe) file that must be run in an app container. This option is equivalent to [/target:winexe](../../../csharp/language-reference/compiler-options/target-winexe-csharp-compiler-options.md) but is designed for [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps.  
  
## Syntax  
  
```  
/target:appcontainerexe  
```  
  
## Remarks  
 To require the app to run in an app container, this option sets a bit in the [Portable Executable](http://go.microsoft.com/fwlink/p/?LinkId=236960) (PE) file. When that bit is set, an error occurs if the CreateProcess method tries to launch the executable file outside an app container.  
  
 Unless you use the [/out](../../../csharp/language-reference/compiler-options/out-csharp-compiler-options.md) option, the output file name takes the name of the input file that contains the [Main](../../../csharp/programming-guide/main-and-command-args/main-and-command-line-arguments.md) method.  
  
 When you specify this option at a command prompt, all files until the next **/out** or **/target** option are used to create the executable file.  
  
### To set this compiler option in the IDE  
  
1.  In **Solution Explorer**, open the shortcut menu for your project, and then choose **Properties**.  
  
2.  On the **Application** tab, in the **Output type** list, choose **Windows Store App**.  
  
     This option is available only for [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app templates.  
  
 For information about how to set this compiler option programmatically, see <xref:VSLangProj80.ProjectProperties3.OutputType%2A>.  
  
## Example  
 The following command compiles `filename.cs` into a Windows executable file that can be run only in an app container.  
  
```  
csc /target:appcontainerexe filename.cs  
```  
  
## See Also  
 [/target (C# Compiler Options)](../../../csharp/language-reference/compiler-options/target-csharp-compiler-options.md)   
 [/target:winexe (C# Compiler Options)](../../../csharp/language-reference/compiler-options/target-winexe-csharp-compiler-options.md)   
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)