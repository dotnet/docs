---
title: "Error creating assembly manifest: <error message>"
ms.date: 07/20/2015
f1_keywords: 
  - "bc30140"
  - "vbc30140"
helpviewer_keywords: 
  - "BC30140"
ms.assetid: 1beb5aa0-7b79-4c85-946b-5c2d0a41d1d2
---
# Error creating assembly manifest: \<error message>
The Visual Basic compiler calls the Assembly Linker (Al.exe, also known as Alink) to generate an assembly with a manifest. The linker has reported an error in the pre-emission stage of creating the assembly.  
  
 This can occur if there are problems with the key file or the key container specified. To fully sign an assembly, you must provide a valid key file that contains information about the public and private keys. To delay sign an assembly, you must select the **Delay sign only** check box and provide a valid key file that contains information about the public key information. The private key is not necessary when an assembly is delay-signed. For more information, see [How to: Sign an Assembly with a Strong Name](../../../standard/assembly/sign-strong-name.md).  
  
 **Error ID:** BC30140  
  
## To correct this error  
  
1. Examine the quoted error message and consult the topic [Al.exe](../../../framework/tools/al-exe-assembly-linker.md). for error AL1019 further explanation and advice  
  
2. If the error persists, gather information about the circumstances and notify Microsoft Product Support Services.  
  
## See also

- [How to: Sign an Assembly with a Strong Name](../../../standard/assembly/sign-strong-name.md)
- [Signing Page, Project Designer](/visualstudio/ide/reference/signing-page-project-designer)
- [Al.exe](../../../framework/tools/al-exe-assembly-linker.md)
- [Talk to Us](/visualstudio/ide/feedback-options)
