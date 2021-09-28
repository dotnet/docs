---
description: "Learn more about: Variable uses an Automation type not supported in Visual Basic"
title: "Variable uses an Automation type not supported"
ms.date: 07/20/2015
f1_keywords:
  - "vbrID458"
ms.assetid: bde4f4da-493b-452c-b6e4-1d370edba4cd
---

# Variable uses an Automation type not supported in Visual Basic

You tried to use a variable defined in a type library or object library that has a data type not supported by Visual Basic.

## To correct this error

- Use a variable of a type recognized by Visual Basic.

     -or-

- If you encounter this error while using `FileGet` or `FileGetObject`, make sure the file you are trying to use was written to with `FilePut` or `FilePutObject`.

## See also

- [Data Types](../data-types/index.md)
