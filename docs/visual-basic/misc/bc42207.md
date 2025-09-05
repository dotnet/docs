---
description: "Learn more about: Assembly reference '<reference>' is invalid and cannot be resolved"
title: "Assembly reference '<reference>' is invalid and cannot be resolved"
ms.date: 07/20/2015
f1_keywords:
  - "vbc42207"
  - "bc42207"
helpviewer_keywords:
  - "BC42207"
ms.assetid: c6129559-7273-4abe-b2f1-deea05d242c9
---
# Assembly reference '\<reference>' is invalid and cannot be resolved

**Error ID:** BC42207

## To correct this error

- Verify that the assembly reference path is correct and the assembly file exists:

   ```vb
   ' Check the assembly reference in project settings
   ' Ensure the file path is valid and accessible
   ```

- Confirm that the referenced assembly is compiled for a compatible target framework.
- Check that the assembly is not corrupted by trying to reference it in a new test project.
- If the assembly requires dependencies, ensure they are also available and properly referenced.
- Update the assembly reference to point to the correct version or location of the assembly.

## See also

- [Visual Basic Command-Line Compiler](../reference/command-line-compiler/index.md)
- [-moduleassemblyname](../reference/command-line-compiler/moduleassemblyname.md)
