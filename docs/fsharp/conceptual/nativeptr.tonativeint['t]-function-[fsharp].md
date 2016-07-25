---
title: NativePtr.toNativeInt<'T> Function (F#)
description: NativePtr.toNativeInt<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c00cede6-ae1f-4408-afe8-721cb724c8bb
---

# NativePtr.toNativeInt<'T> Function (F#)

Returns a machine address for a given typed native pointer.

**Namespace/Module Path:** Microsoft.FSharp.NativeInterop.NativePtr

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
NativePtr.toNativeInt : nativeptr<'T> -> nativeint (requires unmanaged)

// Usage:
NativePtr.toNativeInt address
```

#### Parameters
*address*
Type: [nativeptr](https://msdn.microsoft.com/library/6e74c8e5-f2ff-4e56-ab05-c337b0618d73)**&lt;'T&gt;**


The input pointer.

## Return Value

The machine address.

## Remarks

This function is named `ToNativeIntInlined` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[NativeInterop.NativePtr Module &#40;F&#35;&#41;](NativeInterop.NativePtr-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.NativeInterop Namespace &#40;F&#35;&#41;](Microsoft.FSharp.NativeInterop-Namespace-%5BFSharp%5D.md)
