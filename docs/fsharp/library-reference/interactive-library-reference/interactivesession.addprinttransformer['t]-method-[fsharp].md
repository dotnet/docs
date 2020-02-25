---
title: InteractiveSession.AddPrintTransformer<'T> Method (F#)
description: InteractiveSession.AddPrintTransformer<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: aff3b713-cdbd-44be-b83f-83fcf51c4ec0 
---

# InteractiveSession.AddPrintTransformer<'T> Method (F#)

Registers a print transformer that controls the output of the interactive session.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)


## Syntax

```fsharp
// Signature:
member this.AddPrintTransformer : InteractiveSession -> ('T -> obj) -> unit

// Usage:
interactiveSession.AddPrintTransformer ()
```

#### Parameters
Type: **'T -&gt;**obj

## Platforms
Windows 7, Windows Vista SP2, Windows XP SP3, Windows XP x64 SP2, Windows Server 2008 R2, Windows Server 2008 SP2, Windows Server 2003 SP2


## Version Information
**F# Runtime**

Supported in: 2.0, 4.0

## See Also
[Interactive.InteractiveSession Class &#40;F&#35;&#41;](Interactive.InteractiveSession-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Compiler.Interactive Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Compiler.Interactive-Namespace-%5BFSharp%5D.md)