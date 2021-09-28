---
description: "Learn more about: -keycontainer"
title: "-keycontainer"
ms.date: 03/10/2018
helpviewer_keywords: 
  - "-keycontainer compiler option [Visual Basic]"
  - "keycontainer compiler option [Visual Basic]"
  - "/keycontainer compiler option [Visual Basic]"
ms.assetid: 6a9bc861-1752-4db1-9f64-b5252f0482cc
---
# -keycontainer

Specifies a key container name for a key pair to give an assembly a strong name.  
  
## Syntax  
  
```console  
-keycontainer:container  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`container`|Required. Container file that contains the key. Enclose the file name in quotation marks ("") if the name contains a space.|  
  
## Remarks  

 The compiler creates the sharable component by inserting a public key into the assembly manifest and by signing the final assembly with the private key. To generate a key file, type `sn -k file` at the command line. The `-i` option installs the key pair into a container. For more information, see [Sn.exe (Strong Name Tool)](../../../framework/tools/sn-exe-strong-name-tool.md)).  
  
 If you compile with `-target:module`, the name of the key file is held in the module and incorporated into the assembly that is created when you compile an assembly with [-addmodule](addmodule.md).  
  
 You can also specify this option as a custom attribute (<xref:System.Reflection.AssemblyKeyNameAttribute>) in the source code for any Microsoft intermediate language (MSIL) module.  
  
 You can also pass your encryption information to the compiler with [-keyfile](keyfile.md). Use [-delaysign](delaysign.md) if you want a partially signed assembly.  
  
 See [Creating and Using Strong-Named Assemblies](../../../standard/assembly/create-use-strong-named.md) for more information on signing an assembly.  
  
> [!NOTE]
> The `-keycontainer` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  

 The following code compiles source file `Input.vb` and specifies a key container.  
  
```console  
vbc -keycontainer:key1 input.vb  
```  
  
## See also

- [Assemblies in .NET](../../../standard/assembly/index.md)
- [Visual Basic Command-Line Compiler](index.md)
- [-keyfile](keyfile.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
