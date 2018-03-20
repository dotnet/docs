---
title: "-baseaddress"
ms.date: 08/09/2018
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "/baseaddress"
  - "baseaddress"
helpviewer_keywords: 
  - "-baseaddress compiler option [Visual Basic]"
  - "/baseaddress compiler option [Visual Basic]"
  - "baseaddress compiler option [Visual Basic]"
ms.assetid: c982bcf2-46e5-47a2-bc8f-a5cc32b7dc47
author: dotnet-bot
ms.author: dotnetcontent
---
# -baseaddress
Specifies a default base address when creating a DLL.  
  
## Syntax  
  
```  
-baseaddress:address  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`address`|Required. The base address for the DLL. This address must be specified as a hexadecimal number.|  
  
## Remarks  
 The default base address for a DLL is set by the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)].  
  
 Be aware that the lower-order word in this address is rounded. For example, if you specify 0x11110001, it is rounded to 0x11110000.  
  
 To complete the signing process for a DLL, use the `–R` option of the Strong Naming tool (Sn.exe).  
  
 This option is ignored if the target is not a DLL.  
  
|To set -baseaddress in the Visual Studio IDE|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**. <br />2.  Click the **Compile** tab.<br />3.  Click **Advanced**.<br />4.  Modify the value in the **DLL base address:** box. **Note:**      The **DLL base address:** box is read-only unless the target is a DLL.|  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)  
 [-target (Visual Basic)](../../../visual-basic/reference/command-line-compiler/target.md)  
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)  
 [Sn.exe (Strong Name Tool)][Sn.exe (Strong Name Tool)](../../../framework/tools/sn-exe-strong-name-tool.md))
