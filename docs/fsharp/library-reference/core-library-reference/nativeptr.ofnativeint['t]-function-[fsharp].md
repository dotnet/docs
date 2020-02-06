---
title: NativePtr.ofNativeInt<'T> Function (F#)
description: NativePtr.ofNativeInt<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 947c486f-549a-4592-9137-739eca87bf72
---

# NativePtr.ofNativeInt<'T> Function (F#)

Returns a typed native pointer for a given machine address.

**Namespace/Module Path:** Microsoft.FSharp.NativeInterop.NativePtr

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
NativePtr.ofNativeInt : nativeint -> nativeptr<'T> (requires unmanaged)

// Usage:
NativePtr.ofNativeInt address
```

#### Parameters
*address*
Type: [nativeint](https://msdn.microsoft.com/library/f8478c3e-fff5-4f10-82cf-4bedfe305f7b)


The pointer address.

## Return Value

A typed pointer.

## Remarks
This function is named `OfNativeIntInlined` in compiled assemblies. If you are accessing the member from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[NativeInterop.NativePtr Module &#40;F&#35;&#41;](NativeInterop.NativePtr-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.NativeInterop Namespace &#40;F&#35;&#41;](Microsoft.FSharp.NativeInterop-Namespace-%5BFSharp%5D.md)
