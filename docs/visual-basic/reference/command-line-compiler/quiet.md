---
description: "Learn more about: -quiet"
title: "-quiet"
ms.date: 07/20/2015
f1_keywords:
  - "-quiet"
  - "quiet"
helpviewer_keywords:
  - "-quiet compiler option [Visual Basic]"
  - "/quiet compiler option [Visual Basic]"
  - "quiet compiler option [Visual Basic]"
ms.assetid: 5d77fa23-4c50-4708-8535-649912b098e8
---
# -quiet

Prevents the compiler from displaying code for syntax-related errors and warnings.

## Syntax

```console
-quiet
```

## Remarks

By default, `-quiet` is not in effect. When the compiler reports a syntax-related error or warning, it also outputs the line from source code. For applications that parse compiler output, it may be more convenient for the compiler to output only the text of the diagnostic.

In the following example, `Module1` outputs an error that includes source code when compiled without `-quiet`.

```vb
Module Module1
    Sub Main()
        x()
    End Sub
End Module
```

Output:

```console
C:\projects\vb2.vb(3) : error BC30451: 'x' is not declared. It may be inaccessible due to its protection level.

        x()
        ~
```

Compiled with `-quiet`, the compiler outputs only the following:

```console
E:\test\t2.vb(3) : error BC30451: Name 'x' is not declared.
```

> [!NOTE]
> The `-quiet` option is not available from within the Visual Studio development environment; it is available only when compiling from the command line.

## Example

The following code compiles `T2.vb` and does not display code for syntax-related compiler diagnostics:

```console
vbc -quiet t2.vb
```

## See also

- [Visual Basic Command-Line Compiler](index.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
