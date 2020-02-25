---
title: InteractiveSession.FloatingPointFormat Property (F#)
description: InteractiveSession.FloatingPointFormat Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1bf7896e-afc0-4126-9450-1d8ae9ce24d7 
---

# InteractiveSession.FloatingPointFormat Property (F#)

Gets or sets the floating point format used in the output of the interactive session.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)


## Syntax

```fsharp
// Signatures:
member this.FloatingPointFormat :  string
member this.FloatingPointFormat : string with set :  string

// Usage:
interactiveSession.FloatingPointFormat
interactiveSession.FloatingPointFormat <- floatingPointFormat
```

#### Parameters
*floatingPointFormat*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


A format code to use for floating point output in the F# Interactive Session.


## Remarks
The possible format codes are described in [Core.Printf Module &#40;F&#35;&#41;](Core.Printf-Module-%5BFSharp%5D.md). The default value is `g10`.


## Platforms
Windows 7, Windows Vista SP2, Windows XP SP3, Windows XP x64 SP2, Windows Server 2008 R2, Windows Server 2008 SP2, Windows Server 2003 SP2


## Version Information
**F# Runtime**

Supported in: 2.0, 4.0

## See Also
[Interactive.InteractiveSession Class &#40;F&#35;&#41;](Interactive.InteractiveSession-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Compiler.Interactive Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Compiler.Interactive-Namespace-%5BFSharp%5D.md)