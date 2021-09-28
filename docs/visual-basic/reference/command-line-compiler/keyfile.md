---
description: "Learn more about: -keyfile"
title: "-keyfile"
ms.date: 03/10/2018
helpviewer_keywords:
  - "/keyfile compiler option [Visual Basic]"
  - "keyfile compiler option [Visual Basic]"
  - "-keyfile compiler option [Visual Basic]"
ms.assetid: ffa82a4b-517a-4c6c-9889-5bae7b534bb8
---
# -keyfile

Specifies a file containing a key or key pair to give an assembly a strong name.  
  
## Syntax  
  
```console
-keyfile:file  
```  
  
## Arguments  

 `file`  
 Required. File that contains the key. If the file name contains a space, enclose the name in quotation marks (" ").  
  
## Remarks  

 The compiler inserts the public key into the assembly manifest and then signs the final assembly with the private key. To generate a key file, type `sn -k file` at the command line. For more information, see [Sn.exe (Strong Name Tool)](../../../framework/tools/sn-exe-strong-name-tool.md)).  
  
 If you compile with `-target:module`, the name of the key file is held in the module and incorporated into the assembly that is created when you compile an assembly with [-addmodule](addmodule.md).  
  
 You can also pass your encryption information to the compiler with [-keycontainer](keycontainer.md). Use [-delaysign](delaysign.md) if you want a partially signed assembly.  
  
 You can also specify this option as a custom attribute (<xref:System.Reflection.AssemblyKeyFileAttribute>) in the source code for any Microsoft intermediate language module.  
  
 In case both `-keyfile` and [-keycontainer](keycontainer.md) are specified (either by command-line option or by custom attribute) in the same compilation, the compiler first tries the key container. If that succeeds, then the assembly is signed with the information in the key container. If the compiler does not find the key container, it tries the file specified with `-keyfile`. If this succeeds, the assembly is signed with the information in the key file, and the key information is installed in the key container (similar to `sn -i`) so that on the next compilation, the key container will be valid.  
  
 Note that a key file might contain only the public key.  
  
 See [Creating and Using Strong-Named Assemblies](../../../standard/assembly/create-use-strong-named.md) for more information on signing an assembly.  
  
> [!NOTE]
> The `-keyfile` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.

## Example

The following code compiles source file `Input.vb` and specifies a key file.

```console
vbc -keyfile:myfile.sn input.vb
```

## See also

- [Assemblies in .NET](../../../standard/assembly/index.md)
- [Visual Basic Command-Line Compiler](index.md)
- [-reference (Visual Basic)](reference.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
