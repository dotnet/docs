---
title: "Error creating assembly manifest: &lt;error message&gt; | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "bc30140"
  - "vbc30140"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30140"
ms.assetid: 1beb5aa0-7b79-4c85-946b-5c2d0a41d1d2
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent

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
# Error creating assembly manifest: &lt;error message&gt;
The [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler calls the Assembly Linker (Al.exe, also known as Alink) to generate an assembly with a manifest. The linker has reported an error in the pre-emission stage of creating the assembly.  
  
 This can occur if there are problems with the key file or the key container specified. To fully sign an assembly, you must provide a valid key file that contains information about the public and private keys. To delay sign an assembly, you must select the **Delay sign only** check box and provide a valid key file that contains information about the public key information. The private key is not necessary when an assembly is delay-signed. For more information, see [How to: Sign an Assembly (Visual Studio)](https://msdn.microsoft.com/library/ms247123.aspx).  
  
 **Error ID:** BC30140  
  
## To correct this error  
  
1.  Examine the quoted error message and consult the topic [Al.exe Tool Errors and Warnings](https://msdn.microsoft.com/library/kchwc1f1.aspx) for error AL1019 further explanation and advice  
  
2.  If the error persists, gather information about the circumstances and notify Microsoft Product Support Services.  
  
## See Also  
 [How to: Sign an Assembly (Visual Studio)](https://msdn.microsoft.com/library/ms247123.aspx)   
 [Signing Page, Project Designer](/visualstudio/ide/reference/signing-page-project-designer)   
 [Al.exe (Assembly Linker)](https://msdn.microsoft.com/library/c405shex)   
 [Al.exe Tool Errors and Warnings](https://msdn.microsoft.com/library/kchwc1f1.aspx)   
 [Talk to Us](/visualstudio/ide/talk-to-us)
