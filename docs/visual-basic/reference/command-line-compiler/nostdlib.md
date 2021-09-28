---
description: "Learn more about: -nostdlib (Visual Basic)"
title: "-nostdlib"
ms.date: 03/13/2018
helpviewer_keywords: 
  - "nostdlib compiler option [Visual Basic]"
  - "-nostdlib compiler option [Visual Basic]"
  - "/nostdlib compiler option [Visual Basic]"
ms.assetid: 140381b8-dc96-4ad5-ae11-792c9ed0be4d
---
# -nostdlib (Visual Basic)

Causes the compiler not to automatically reference the standard libraries.  
  
## Syntax  
  
```console  
-nostdlib  
```  
  
## Remarks  

 The `-nostdlib` option removes the automatic reference to the System.dll assembly and prevents the compiler from reading the Vbc.rsp file. The Vbc.rsp file, which is located in the same directory as the Vbc.exe file, references the commonly used .NET Framework assemblies and imports the `System` and `Microsoft.VisualBasic` namespaces.  
  
> [!NOTE]
> The Mscorlib.dll and Microsoft.VisualBasic.dll assemblies are always referenced.  
  
> [!NOTE]
> The `-nostdlib` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.  
  
## Example  

 The following code compiles `T2.vb` without referencing the standard libraries. You must set the `_MYTYPE` conditional-compilation constant to the string "Empty" to remove the `My` object.  
  
```console
vbc -nostdlib -define:_MYTYPE=\"Empty\" T2.vb  
```  
  
## See also

- [-noconfig](noconfig.md)
- [Visual Basic Command-Line Compiler](index.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
- [Customizing Which Objects are Available in My](../../developing-apps/customizing-extending-my/customizing-which-objects-are-available-in-my.md)
