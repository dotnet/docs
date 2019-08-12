---
title: "-keycontainer (C# Compiler Options)"
ms.date: 05/16/2018
f1_keywords: 
  - "/keycontainer"
helpviewer_keywords: 
  - "/keycontainer compiler option [C#]"
  - "keycontainer compiler option [C#]"
  - "-keycontainer compiler option [C#]"
ms.assetid: b3982b6d-2382-4f7e-bebd-ce98eaa30763
---
# -keycontainer (C# Compiler Options)
Specifies the name of the cryptographic key container.  
  
## Syntax  
  
```console  
-keycontainer:string  
```  
  
## Arguments  
 `string`  
 The name of the strong name key container.  
  
## Remarks  
 When the **-keycontainer** option is used, the compiler creates a sharable component. The compiler inserts a public key from the specified container into the assembly manifest and signs the final assembly with the private key. To generate a key file, type `sn -k file` at the command line. `sn -i` installs the key pair into a container. This option is not supported when the compiler runs on CoreCLR. To sign an assembly when building on CoreCLR, use the [-keyfile](keyfile-compiler-option.md) option.
  
 If you compile with [-target:module](../../../csharp/language-reference/compiler-options/target-module-compiler-option.md), the name of the key file is held in the module and incorporated into the assembly when you compile this module into an assembly with [-addmodule](../../../csharp/language-reference/compiler-options/addmodule-compiler-option.md).  
  
 You can also specify this option as a custom attribute (<xref:System.Reflection.AssemblyKeyNameAttribute?displayProperty=nameWithType>) in the source code for any Microsoft intermediate language (MSIL) module.  
  
 You can also pass your encryption information to the compiler with [-keyfile](../../../csharp/language-reference/compiler-options/keyfile-compiler-option.md). Use [-delaysign](../../../csharp/language-reference/compiler-options/delaysign-compiler-option.md) if you want the public key added to the assembly manifest but want to delay signing the assembly until it has been tested.  
  
 For more information, see [Creating and Using Strong-Named Assemblies](../../../standard/assembly/strong-named-assemblies.md) and [Delay Signing an Assembly](../../../standard/assembly/delay-sign-assembly.md).  
  
### To set this compiler option in the Visual Studio development environment  
  
1. This compiler option is not available in the Visual Studio development environment.  
  
 You can programmatically access this compiler option with <xref:VSLangProj.ProjectProperties.AssemblyKeyContainerName%2A>.  
  
## See also

- [C# Compiler -keyfile option](keyfile-compiler-option.md)
- [C# Compiler Options](index.md)
- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
