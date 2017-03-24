---
title: "How to: Set Environment Variables for the Visual Studio Command Line | Microsoft Docs"
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
  - "cs.build.commandline"
dev_langs: 
  - "CSharp"
  - "CSharp"
helpviewer_keywords: 
  - "csc.exe, command-line builds"
  - "Visual C#, command-line builds"
  - "command-line compilers, Visual C#"
  - "Vsvars32.bat"
  - "builds [C#], command-line"
  - "compilers, invoking from command line"
  - "Vcvars32.bat file"
  - "command line [C#], building from"
  - "Visual C# compiler, enabling"
  - "compiling source code, from command line"
ms.assetid: 7ec09480-5612-4f6a-8d00-ad90ea9bca5d
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Set Environment Variables for the Visual Studio Command Line
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The vsvars32.bat file sets the appropriate environment variables to enable command-line builds. For more information about vsvars32.bat, see [Knowledge Base article Q248802](http://go.microsoft.com/fwlink/?LinkId=225042).  
  
 If the current version of Visual Studio is installed on a computer that also has an earlier version of Visual Studio, you should not run vsvars32.bat or vcvars32.bat from different versions in the same Command Prompt window.  
  
### To run VSVARS32.BAT  
  
1.  From the **Start** menu, open the **Developer Command Prompt for VS2012**.  
  
2.  Change to the Program Files\Microsoft Visual Studio *Version*\Common7\Tools or Program Files (x86)\Microsoft Visual Studio *Version*\Common7\Tools subdirectory of your installation.  
  
3.  Run VSVARS32.bat by typing **VSVARS32**.  
  
    > [!CAUTION]
    >  VSVARS32.bat can vary from computer to computer. Do not replace a missing or damaged VSVARS32.bat file with a VSVARS32.bat from another computer. Instead, rerun setup to replace the missing file.  
  
## See Also  
 [Command-line Building With csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md)