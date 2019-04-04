---
title: "-moduleassemblyname"
ms.date: 03/13/2018
helpviewer_keywords: 
  - "moduleassemblyname compiler option [Visual Basic]"
  - "/moduleassemblyname compiler option [Visual Basic]"
  - "-moduleassemblyname compiler option [Visual Basic]"
ms.assetid: 013a57b6-f425-4dd3-b333-512d72c42f55
---
# -moduleassemblyname
Specifies the name of the assembly that this module will be a part of.  
  
## Syntax  
  
```  
-moduleassemblyname:assembly_name  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`assembly_name`|The name of the assembly that this module will be a part of.|  
  
## Remarks  
 The compiler processes the `-moduleassemblyname` option only if the `-target:module` option has been specified. This causes the compiler to create a module. The module created by the compiler is valid only for the assembly specified with the `-moduleassemblyname` option. If you place the module in a different assembly, run-time errors will occur.  
  
 The `-moduleassemblyname` option is needed only when the following are true:  
  
-   A data type in the module needs access to a `Friend` type in a referenced assembly.  
  
-   The referenced assembly has granted friend assembly access to the assembly into which the module will be built.  
  
 For more information about creating a module, see [/target (Visual Basic)](../../../visual-basic/reference/command-line-compiler/target.md). For more information about friend assemblies, see [Friend Assemblies](../../../standard/assembly/friend-assemblies.md).  
  
> [!NOTE]
>  The `-moduleassemblyname` option is not available from within the Visual Studio development environment; it is available only when you compile from a command prompt.  
  
## See also

- [How to: Build a Multifile Assembly](../../../framework/app-domains/how-to-build-a-multifile-assembly.md)
- [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)
- [-target (Visual Basic)](../../../visual-basic/reference/command-line-compiler/target.md)
- [-main](../../../visual-basic/reference/command-line-compiler/main.md)
- [-reference (Visual Basic)](../../../visual-basic/reference/command-line-compiler/reference.md)
- [-addmodule](../../../visual-basic/reference/command-line-compiler/addmodule.md)
- [Assemblies in .NET](../../../standard/assembly/index.md)
- [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)
- [Friend Assemblies](../../../standard/assembly/friend-assemblies.md)
