---
title: "Unable to emit assembly: &lt;error message&gt; | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "vbc30145"
  - "bc30145"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30145"
ms.assetid: 2e7eb2b9-eda6-4bdb-95cc-72c7f0be7528
caps.latest.revision: 11
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Unable to emit assembly: &lt;error message&gt;
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] compiler calls the Assembly Linker (Al.exe, also known as Alink) to generate an assembly with a manifest, with the linker reporting an error in the emission stage of creating the assembly.  
  
 **Error ID:** BC30145  
  
### To correct this error  
  
1.  Examine the quoted error message and consult the topic [Al.exe Tool Errors and Warnings](http://msdn.microsoft.com/en-us/7f125d49-0a03-47a6-9ba9-d61a679a7d4b) for further explanation and advice.  
  
2.  Try signing the assembly manually, using either the [Al.exe (Assembly Linker)](../Topic/Al.exe%20\(Assembly%20Linker\).md) or the [Sn.exe (Strong Name Tool)](../Topic/Sn.exe%20\(Strong%20Name%20Tool\).md).  
  
3.  If the error persists, gather information about the circumstances and notify Microsoft Product Support Services.  
  
### To sign the assembly manually  
  
1.  Use the [Sn.exe (Strong Name Tool)](../Topic/Sn.exe%20\(Strong%20Name%20Tool\).md) to create a public/private key pair file.  
  
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
  
6.  In [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], add a .NET Assembly reference to the file you just created.  
  
## See Also  
 [Al.exe (Assembly Linker)](../Topic/Al.exe%20\(Assembly%20Linker\).md)   
 [Al.exe Tool Errors and Warnings](http://msdn.microsoft.com/en-us/7f125d49-0a03-47a6-9ba9-d61a679a7d4b)   
 [Sn.exe (Strong Name Tool)](../Topic/Sn.exe%20\(Strong%20Name%20Tool\).md)   
 [How to: Create a Public-Private Key Pair](../Topic/How%20to:%20Create%20a%20Public-Private%20Key%20Pair.md)   
 [Talk to Us](/visual-studio/ide/talk-to-us)