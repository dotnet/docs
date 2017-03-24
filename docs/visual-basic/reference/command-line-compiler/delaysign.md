---
title: "-delaysign | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "delaysign compiler option [Visual Basic]"
  - "/delaysign compiler option [Visual Basic]"
  - "-delaysign compiler option [Visual Basic]"
ms.assetid: c76e61a4-1884-4252-9fb2-377f99caa690
caps.latest.revision: 19
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# /delaysign
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Specifies whether the assembly will be fully or partially signed.  
  
## Syntax  
  
```  
/delaysign[+ | -]  
```  
  
## Arguments  
 `+` &#124; `-`  
 Optional. Use `/delaysign-` if you want a fully signed assembly. Use `/delaysign+` if you want to place the public key in the assembly and reserve space for the signed hash. The default is `/delaysign-`.  
  
## Remarks  
 The `/delaysign` option has no effect unless used with [/keyfile](../../../visual-basic/reference/command-line-compiler/keyfile.md) or [/keycontainer](../../../visual-basic/reference/command-line-compiler/keycontainer.md).  
  
 When you request a fully signed assembly, the compiler hashes the file that contains the manifest (assembly metadata) and signs that hash with the private key. The resulting digital signature is stored in the file that contains the manifest. When an assembly is delay signed, the compiler does not compute and store the signature but reserves space in the file so the signature can be added later.  
  
 For example, by using `/delaysign+`, a developer in an organization can distribute unsigned test versions of an assembly that testers can register with the global assembly cache and use. When work on the assembly is completed, the person responsible for the organization's private key can fully sign the assembly. This compartmentalization protects the organization's private key from disclosure, while allowing all developers to work on the assemblies.  
  
 See [Creating and Using Strong-Named Assemblies](../Topic/Creating%20and%20Using%20Strong-Named%20Assemblies.md) for more information on signing an assembly.  
  
### To set /delaysign in the Visual Studio integrated development environment  
  
1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**. For more information, see [Introduction to the Project Designer](http://msdn.microsoft.com/en-us/898dd854-c98d-430c-ba1b-a913ce3c73d7).  
  
2.  Click the **Signing** tab.  
  
3.  Set the value in the **Delay sign only** box.  
  
## See Also  
 [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)   
 [/keyfile](../../../visual-basic/reference/command-line-compiler/keyfile.md)   
 [/keycontainer](../../../visual-basic/reference/command-line-compiler/keycontainer.md)   
 [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)