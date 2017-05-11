---
title: "-keyfile (C# Compiler Options) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/keyfile"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "/keyfile compiler option [C#]"
  - "-keyfile compiler option [C#]"
  - "keyfile compiler option [C#]"
ms.assetid: 0815f9de-ace4-4e98-b4c6-13c55dea40c2
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
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
# /keyfile (C# Compiler Options)
Specifies the filename containing the cryptographic key.  
  
## Syntax  
  
```  
/keyfile:file  
```  
  
## Arguments  
  
|Term|Definition|  
|----------|----------------|  
|`file`|The name of the file containing the strong name key.|  
  
## Remarks  
 When this option is used, the compiler inserts the public key from the specified file into the assembly manifest and then signs the final assembly with the private key. To generate a key file, type sn -k `file` at the command line.  
  
 If you compile with **/target:module**, the name of the key file is held in the module and incorporated into the assembly that is created when you compile an assembly with [/addmodule](../../../csharp/language-reference/compiler-options/addmodule-compiler-option.md).  
  
 You can also pass your encryption information to the compiler with [/keycontainer](../../../csharp/language-reference/compiler-options/keycontainer-compiler-option.md). Use [/delaysign](../../../csharp/language-reference/compiler-options/delaysign-compiler-option.md) if you want a partially signed assembly.  
  
 In case both /keyfile and /keycontainer are specified (either by command line option or by custom attribute) in the same compilation, the compiler will first try the key container. If that succeeds, then the assembly is signed with the information in the key container. If the compiler does not find the key container, it will try the file specified with /keyfile. If that succeeds, the assembly is signed with the information in the key file and the key information will be installed in the key container (similar to sn -i) so that on the next compilation, the key container will be valid.  
  
 Note that a key file might contain only the public key.  
  
 For more information, see [Creating and Using Strong-Named Assemblies](https://msdn.microsoft.com/library/xwb8f617) and [Delay Signing an Assembly](../../../framework/app-domains/delay-sign-assembly.md).  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the **Properties** page for the project.  
  
2.  Click the **Signing** property page.  
  
3.  Modify the **Choose a strong name key file** property.  
  
 You can programmatically access this compiler option with <xref:VSLangProj.ProjectProperties.AssemblyOriginatorKeyFile%2A>.  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)