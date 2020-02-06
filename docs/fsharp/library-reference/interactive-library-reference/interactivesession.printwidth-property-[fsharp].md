---
title: InteractiveSession.PrintWidth Property (F#)
description: InteractiveSession.PrintWidth Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3a392a1b-3c96-4ff6-b6f4-2eff12609148 
---

# InteractiveSession.PrintWidth Property (F#)

Gets or sets the print width, that is, the number of characters to print per line, in an F# interactive session.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)


## Syntax

```fsharp
// Signatures:
member this.PrintWidth :  int
member this.PrintWidth : int with set :  int

// Usage:
interactiveSession.PrintWidth
interactiveSession.PrintWidth <- printWidth
```

#### Parameters
*printWidth*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The print width to set.

## Remarks
The default value is 78.


## Platforms
Windows 7, Windows Vista SP2, Windows XP SP3, Windows XP x64 SP2, Windows Server 2008 R2, Windows Server 2008 SP2, Windows Server 2003 SP2


## Version Information
**F# Runtime**

Supported in: 2.0, 4.0

## See Also
[Interactive.InteractiveSession Class &#40;F&#35;&#41;](Interactive.InteractiveSession-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Compiler.Interactive Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Compiler.Interactive-Namespace-%5BFSharp%5D.md)