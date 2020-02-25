---
title: NativePtr.add<'T> Function (F#)
description: NativePtr.add<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 143184ff-eb26-4041-bdc1-92160e347c4e
---

# NativePtr.add<'T> Function (F#)

Returns a typed native pointer by adding an offset to the given input pointer.

**Namespace/Module Path:** Microsoft.FSharp.NativeInterop.NativePtr

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
NativePtr.add : nativeptr<'T> -> int -> nativeptr<'T> (requires unmanaged)

// Usage:
NativePtr.add address index
```

#### Parameters
*address*
Type: [nativeptr](https://msdn.microsoft.com/library/6e74c8e5-f2ff-4e56-ab05-c337b0618d73)**&lt;'T&gt;**


The input pointer.


*index*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index by which to offset the pointer.

## Return Value

A typed pointer.

## Remarks
The pointer address is offset by `index * sizeof<'T>`.

This function is named `AddPointerInlined` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[NativeInterop.NativePtr Module &#40;F&#35;&#41;](NativeInterop.NativePtr-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.NativeInterop Namespace &#40;F&#35;&#41;](Microsoft.FSharp.NativeInterop-Namespace-%5BFSharp%5D.md)
