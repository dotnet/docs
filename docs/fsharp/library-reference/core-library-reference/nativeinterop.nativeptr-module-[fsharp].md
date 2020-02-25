---
title: NativeInterop.NativePtr Module (F#)
description: NativeInterop.NativePtr Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b9073ed7-d66b-430a-8891-4620be9b7c8f
---

# NativeInterop.NativePtr Module (F#)

Contains operations on native pointers. Use of these operators may result in the generation of unverifiable code.

**Namespace/Module Path:** Microsoft.FSharp.NativeInterop

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module NativePtr
```

## Values


|Value|Description|
|-----|-----------|
|[add](https://msdn.microsoft.com/library/851d713a-4b8d-42d6-961a-930355b038fe)<br />**: nativeptr&lt;'T&gt; -&gt; int -&gt; nativeptr&lt;'T&gt;**|Returns a typed native pointer by adding an offset to the given input pointer.|
|[get](https://msdn.microsoft.com/library/eb9ac3e5-eef2-4914-aedf-7c60c7edccf2)<br />**: nativeptr&lt;'T&gt; -&gt; int -&gt; 'T**|Dereferences the typed native pointer computed by adding an offset to the given input pointer.|
|[ofNativeInt](https://msdn.microsoft.com/library/e813513b-cf42-41e9-ba08-e1a4def9fe8c)<br />**: nativeint -&gt; nativeptr&lt;'T&gt;**|Returns a typed native pointer for a given machine address.|
|[read](https://msdn.microsoft.com/library/b6c4dacc-45dc-48eb-89f5-2507ded6de01)<br />**: nativeptr&lt;'T&gt; -&gt; 'T**|Dereferences the given typed native pointer.|
|[set](https://msdn.microsoft.com/library/f232c376-3e92-4557-958d-f6c70aa739e0)<br />**: nativeptr&lt;'T&gt; -&gt; int -&gt; 'T -&gt; unit**|Assigns a value into the memory location referenced by the typed native pointer computed by adding an offset to the given input pointer.|
|[stackalloc](https://msdn.microsoft.com/library/a2c2855f-e4ff-4d10-b15a-e0fc3fecbb3d)<br />**: int -&gt; nativeptr&lt;'T&gt;**|Allocates a region of memory on the stack.|
|[toNativeInt](https://msdn.microsoft.com/library/4202403f-6639-483c-8ab6-5455cea041ad)<br />**: nativeptr&lt;'T&gt; -&gt; nativeint**|Returns a machine address for a given typed native pointer.|
|[write](https://msdn.microsoft.com/library/c65eae26-60a8-4168-92cd-00ae36c9456a)<br />**: nativeptr&lt;'T&gt; -&gt; 'T -&gt; unit**|Assigns a value into the memory location referenced by the given typed native pointer.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.NativeInterop Namespace &#40;F&#35;&#41;](Microsoft.FSharp.NativeInterop-Namespace-%5BFSharp%5D.md)
