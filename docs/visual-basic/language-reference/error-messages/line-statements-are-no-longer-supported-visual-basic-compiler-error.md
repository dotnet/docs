---
description: "Learn more about: BC30830: 'Line' statements are no longer supported"
title: "'Line' statements are no longer supported (Visual Basic Compiler Error)"
ms.date: 07/20/2015
f1_keywords:
  - "bc30830"
  - "vbc30830"
helpviewer_keywords:
  - "BC30830"
ms.assetid: 4734bc1d-882e-4555-b498-1f1ec0399d16
---
# BC30830: 'Line' statements are no longer supported

Line statements are no longer supported. File I/O functionality is available as `Microsoft.VisualBasic.FileSystem.LineInput` and graphics functionality is available as `System.Drawing.Graphics.DrawLine`.

 **Error ID:** BC30830

## To correct this error

- If performing file access, use `Microsoft.VisualBasic.FileSystem.LineInput`.

- If performing graphics, use `System.Drawing.Graphics.Drawline`.

## See also

- <xref:System.IO>
- <xref:System.Drawing>
- [File Access with Visual Basic](../../developing-apps/programming/drives-directories-files/file-access.md)
