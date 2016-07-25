---
title: Core.AutoOpenAttribute Constructor (F#)
description: Core.AutoOpenAttribute Constructor (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fe4a32eb-7201-4542-9577-d3a3162d62ec 
---

# Core.AutoOpenAttribute Constructor (F#)

Creates an attribute used to mark a namespace or module path to be automatically opened when an assembly is referenced.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
new AutoOpenAttribute : string -> AutoOpenAttribute
new AutoOpenAttribute : unit -> AutoOpenAttribute

// Usage:
new AutoOpenAttribute (path)
new AutoOpenAttribute ()
```

#### Parameters
*path*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The namespace or module to be automatically opened when an assembly is referenced or an enclosing module opened.

## Return Value

A new `AutoOpenAttribute` instance.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.AutoOpenAttribute Class &#40;F&#35;&#41;](Core.AutoOpenAttribute-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)