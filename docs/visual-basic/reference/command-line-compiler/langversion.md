---
description: "Learn more about: -langversion (Visual Basic)"
title: "-langversion"
ms.date: 03/10/2018
helpviewer_keywords: 
  - "/langversion compiler option [Visual Basic]"
  - "langversion compiler option [Visual Basic]"
  - "-langversion compiler option [Visual Basic]"
ms.custom: "updateeachrelease" 
ms.assetid: 59b7b0c8-2dde-4e9b-94e7-0237f7e0bafb
---
# -langversion (Visual Basic)

Causes the compiler to accept only syntax that is included in the specified Visual Basic language version.  
  
## Syntax  
  
```console  
-langversion:version  
```  
  
## Arguments

 `version`\
 Required. The language version to be used during the compilation. Accepted values are `9`, `10`, `11`, `12`, `14`, `15`, `15.3`, `15.5`, `16`, `16.9`, `default`, and `latest`.

 Any of the whole numbers may also be specified using `.0` as the minor version, for example, `11.0`.

 You can see the list of all possible values by specifying `-langversion:?` on the command line.

## Remarks

The `-langversion` option specifies what syntax the compiler accepts. For example, if you specify that the language version is 9.0, the compiler generates errors for syntax that is valid only in version 10.0 and later.

You can use this option when you develop applications that target different versions of .NET Framework. For example, if you are targeting .NET Framework 3.5, you could use this option to ensure that you do not use syntax from language version 10.0.

You can set `-langversion` directly only by using the command line. For more information, see [Targeting a Specific .NET Framework Version](/visualstudio/ide/visual-studio-multi-targeting-overview).

## Example

The following code compiles `sample.vb` for Visual Basic 9.0.

```console
vbc -langversion:9.0 sample.vb
```

## See also

- [Visual Basic Command-Line Compiler](index.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
