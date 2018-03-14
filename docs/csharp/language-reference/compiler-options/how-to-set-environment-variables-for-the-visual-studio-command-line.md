---
title: "How to: Set Environment Variables for the Visual Studio Command Line"
ms.date: "09/29/2017"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "cs.build.commandline"
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
---
# How to: Set Environment Variables for the Visual Studio Command Line

The VsDevCmd.bat file sets the appropriate environment variables to enable command-line builds. For more information about VsDevCmd.bat, see [Knowledge Base article Q248802](https://support.microsoft.com/help/248802/you-receive-the-out-of-environment-space-error-message-when-you-execut).  

> [!NOTE]
> The VsDevCmd.bat file is a new file delivered with Visual Studio 2017. Visual Studio 2015 and earlier versions used VSVARS32.bat for the same purpose. This file was stored in \Program Files\Microsoft Visual Studio\\*Version*\Common7\Tools or Program Files (x86)\Microsoft Visual Studio\\*Version*\Common7\Tools.
  
If the current version of Visual Studio is installed on a computer that also has an earlier version of Visual Studio, you should not run VsDevCmd.bat and VSVARS32.BAT from different versions in the same Command Prompt window. Instead, you should run the command for each version in its own window.
  
### To run VsDevCmd.BAT  
  
1.  From the **Start** menu, open the **Developer Command Prompt for VS 2017**.  It's in the **Visual Studio 2017** folder.
  
2.  Change to the \Program Files\Microsoft Visual Studio\\*Version*\\*Offering*\Common7\Tools or \Program Files (x86)\Microsoft Visual Studio\\*Version*\\*Offering*\Common7\Tools subdirectory of your installation.  (*Version* is *2017* for the current version. *Offering* is one of *Enterprise*, *Professional* or *Community*.)
  
3.  Run VsDevCmd.bat by typing **VsDevCmd**.  
  
    > [!CAUTION]
    >  VsDevCmd.bat can vary from computer to computer. Do not replace a missing or damaged VsDevCmd.bat file with a VsDevCmd.bat from another computer. Instead, rerun setup to replace the missing file.  
  
## See Also  
 [Command-line Building With csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md)
