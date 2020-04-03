---
title: Operators.( ^ ) Function (F#)
description: Operators.( ^ ) Function (F#)
ms.date: 02/26/2020
---

# Operators.( ^ ) Function (F#)

> Note: This operator is used primarily for OCAML interop. To concatenate two strings in normal F# code, use the `+` operator.

Concatenate two strings. The operator [-](https://msdn.microsoft.com/library/67b8d50f-5675-4bdc-bd41-807181aca5aa) should be used instead.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

## Syntax

```fsharp
// Signature:
( ^ ) : string -> string -> string

// Usage:
s1 ^ s2
```

#### Parameters
*s1*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)

*s2*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)

## Remarks
This operator is provided for compatibility with other versions of ML, and generates a warning when used unless you use the `--mlcompatibility` compiler option. For more information, see [Compiler Options](../../language-reference/options.md).

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)