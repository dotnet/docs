---
title: "Unable to emit assembly: &lt;error message&gt;"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc30145"
  - "bc30145"
helpviewer_keywords: 
  - "BC30145"
ms.assetid: 2e7eb2b9-eda6-4bdb-95cc-72c7f0be7528
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# Unable to emit assembly: &lt;error message&gt;
The [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler calls the Assembly Linker (Al.exe, also known as Alink) to generate an assembly with a manifest, with the linker reporting an error in the emission stage of creating the assembly.  
  
 **Error ID:** BC30145  
  
## To correct this error  
  
1.  Examine the quoted error message and consult the topic [Al.exe](../../../framework/tools/al-exe-assembly-linker.md). for further explanation and advice.  
  
2.  Try signing the assembly manually, using either the [Al.exe](../../../framework/tools/al-exe-assembly-linker.md) or the [Sn.exe (Strong Name Tool)](../../../framework/tools/sn-exe-strong-name-tool.md).  
  
3.  If the error persists, gather information about the circumstances and notify Microsoft Product Support Services.  
  
### To sign the assembly manually  
  
1.  Use the [Sn.exe (Strong Name Tool)][Sn.exe (Strong Name Tool)](../../../framework/tools/sn-exe-strong-name-tool.md)) to create a public/private key pair file.  
  
     This file has a .snk extension.  
  
2.  Delete the COM reference that is generating the error from your project.  
  
3.  From the Windows **Start** menu, point to **Programs**, point to **Microsoft Visual Studio 2008**, point to **Visual Studio Tools**, and then click **Visual Studio 2008 Command Prompt**.  
  
4.  Move to the directory where you want to place your assembly wrapper.  
  
5.  Type the following code.  
  
    ```  
    tlbimp <path to COM reference file> /out:<output assembly name> /keyfile:<path to .snk file>  
    ```  
  
     An example of the code you might enter would be the following.  
  
    ```  
    tlbimp c:\windows\system32\msi.dll /out:Interop.WindowsInstaller.dll /keyfile:"c:\documents and settings\mykey.snk"  
    ```  
  
     Use double quotation marks (") if a path or file contains spaces.  
  
6.  In [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)], add a .NET Assembly reference to the file you just created.  
  
## See Also  
 
 [Al.exe](../../../framework/tools/al-exe-assembly-linker.md).  
 [Sn.exe (Strong Name Tool)][Sn.exe (Strong Name Tool)](../../../framework/tools/sn-exe-strong-name-tool.md))  
 [How to: Create a Public-Private Key Pair](../../../framework/app-domains/how-to-create-a-public-private-key-pair.md)  
 [Talk to Us](/visualstudio/ide/talk-to-us)
