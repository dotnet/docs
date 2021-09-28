---
title: Source Line, File, and Path Identifiers
description: Learn how to use built-in F# identifier values that enable you to access the source line number, directory, and file name in your code.
ms.date: 05/16/2016
---
# Source Line, File, and Path Identifiers

The identifiers `__LINE__`, `__SOURCE_DIRECTORY__` and `__SOURCE_FILE__` are built-in values that enable you to access the source line number, directory and file name in your code.

## Syntax

```fsharp
__LINE__
__SOURCE_DIRECTORY__
__SOURCE_FILE__
```

## Remarks

Each of these values has type `string`.

The following table summarizes the source line, file, and path identifiers that are available in F#. These identifiers are not preprocessor macros; they are built-in values that are recognized by the compiler.

|Predefined identifier|Description|
|---------------------|-----------|
|`__LINE__`|Evaluates to the current line number, considering `#line` directives.|
|`__SOURCE_DIRECTORY__`|Evaluates to the current full path of the source directory, considering `#line` directives.|
|`__SOURCE_FILE__`|Evaluates to the current source file name, without its path, considering `#line` directives.|

For more information about the `#line` directive, see [Compiler Directives](compiler-directives.md).

## Example

The following code example demonstrates the use of these values.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet7401.fs)]

Output:

```console
Line: 4
Source Directory: C:\Users\username\Documents\Visual Studio 2017\Projects\SourceInfo\SourceInfo
Source File: Program.fs
```

## See also

- [Compiler Directives](compiler-directives.md)
- [F# Language Reference](index.md)
