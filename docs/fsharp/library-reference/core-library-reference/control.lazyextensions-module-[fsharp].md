---
title: Control.LazyExtensions Module (F#)
description: Control.LazyExtensions Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2d9a3d04-7e97-4110-b5dc-6c75a80d1d6f 
---

# Control.LazyExtensions Module (F#)

Extensions related to `Lazy` values.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AutoOpen>]
module LazyExtensions
```

## Extension Members


|Extension Member|Description|
|----------------|-----------|
|[Create](https://msdn.microsoft.com/library/b3ac5a61-f87d-4332-b45c-f56712693b77)<br />**: Lazy&lt;'T&gt;**|Creates a lazy computation that evaluates to the result of the given function when forced.|
|[CreateFromValue](https://msdn.microsoft.com/library/a4cd810a-36cd-418c-b022-e1e737d1665d)<br />**: Lazy&lt;'T&gt;**|Creates a lazy computation that evaluates to the given value when forced.|
|[Force](https://msdn.microsoft.com/library/0e18f26b-baa9-4254-98b4-beb858ea7730)<br />**: unit -&gt; 'T**|Forces the execution of this value and returns its result. Same as **System.Lazy&#96;1.Value**. Mutual exclusion is used to prevent other threads from also computing the value.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)

[Lazy Computations &#40;F&#35;&#41;](Lazy-Computations-%5BFSharp%5D.md)