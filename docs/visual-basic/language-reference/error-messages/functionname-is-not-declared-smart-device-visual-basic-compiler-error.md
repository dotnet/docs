---
description: "Learn more about: BC30766: '<functionname>' is not declared (Smart Device/Visual Basic Compiler Error)"
title: "'<functionname>' is not declared (Smart Device-Visual Basic Compiler Error)"
ms.date: 07/20/2015
f1_keywords:
  - "bc30766"
  - "vbc30766"
helpviewer_keywords:
  - "BC30766"
ms.assetid: 13918600-6087-40d7-8134-32aa9d3bfda4
---
# BC30766: '\<functionname>' is not declared (Smart Device/Visual Basic Compiler Error)

<`functionname`> is not declared. File I/O functionality is normally available in the `Microsoft.VisualBasic` namespace, but the targeted version of the .NET Compact Framework does not support it.

 **Error ID:** BC30766

## To correct this error

- Perform file operations with functions defined in the `System.IO` namespace.

## See also

- <xref:System.IO>
- [File Access with Visual Basic](../../developing-apps/programming/drives-directories-files/file-access.md)
