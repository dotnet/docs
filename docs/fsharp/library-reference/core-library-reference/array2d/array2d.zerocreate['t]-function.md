---
title: Array2D.zeroCreate<'T> Function (F#)
description: Array2D.zeroCreate<'T> Function (F#)
ms.assetid: 121e8a99-20c1-4622-abfc-d51b01828fed 
---

# Array2D.zeroCreate<'T> Function (F#)

Creates an array where the entries are initially [Unchecked.defaultof&lt;'T&gt;](https://msdn.microsoft.com/library/9ff97f2a-1bd4-4f4c-afbe-5886a74ab977).

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array2D

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array2D.zeroCreate : int -> int -> 'T [,]

// Usage:
Array2D.zeroCreate length1 length2
```

#### Parameters

*length1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The length of the first dimension of the array.

*length2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The length of the second dimension of the array.

## Return Value

Returns the created array.

## Remarks

This function is named `ZeroCreate` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Collections.Array2D Module](Collections.Array2D-Module.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)
