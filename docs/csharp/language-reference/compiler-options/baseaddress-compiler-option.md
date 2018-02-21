---
title: "-baseaddress (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/dllbase"
helpviewer_keywords: 
  - "baseaddress compiler option [C#]"
  - "-baseaddress compiler option [C#]"
  - "/baseaddress compiler option [C#]"
ms.assetid: ce13c965-dfe4-4433-94f5-63b476e3a608
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
---
# -baseaddress (C# Compiler Options)
The **-baseaddress** option lets you specify the preferred base address at which to load a DLL. For more information about when and why to use this option, see [Larry Osterman's WebLog](https://blogs.msdn.microsoft.com/larryosterman/2004/07/06/why-should-i-even-bother-to-use-dlls-in-my-system/).  
  
## Syntax  
  
```console  
-baseaddress:address  
```  
  
## Arguments  
 `address`  
 The base address for the DLL. This address can be specified as a decimal, hexadecimal, or octal number.  
  
## Remarks  
 The default base address for a DLL is set by the .NET Framework common language runtime.  
  
 Be aware that the lower-order word in this address will be rounded. For example, if you specify 0x11110001, it will be rounded to 0x11110000.  
  
 To complete the signing process for a DLL, use SN.EXE with the -R option.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Build** property page.  
  
3.  Click the **Advanced** button.  
  
4.  Modify the **DLL Base Address** property.  
  
     To set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.BaseAddress%2A>.  
  
## See Also  
 <xref:System.Diagnostics.ProcessModule.BaseAddress%2A?displayProperty=nameWithType>  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
