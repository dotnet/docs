---
title: InteractiveSession.FormatProvider Property (F#)
description: InteractiveSession.FormatProvider Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ae150235-8aa0-488f-a059-8fb8888136d9 
---

# InteractiveSession.FormatProvider Property (F#)

Gets or sets the format provider used in the output of the interactive session.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)


## Syntax

```fsharp
// Signatures:
member this.FormatProvider :  IFormatProvider
member this.FormatProvider : IFormatProvider with set :  IFormatProvider

// Usage:
interactiveSession.FormatProvider
interactiveSession.FormatProvider <- formatProvider
```

#### Parameters
*formatProvider*
Type: **System.IFormatProvider**


A format provider to use in the F# Interactive session.

## Platforms
Windows 7, Windows Vista SP2, Windows XP SP3, Windows XP x64 SP2, Windows Server 2008 R2, Windows Server 2008 SP2, Windows Server 2003 SP2


## Version Information
**F# Runtime**

Supported in: 2.0, 4.0

## See Also
[Interactive.InteractiveSession Class &#40;F&#35;&#41;](Interactive.InteractiveSession-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Compiler.Interactive Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Compiler.Interactive-Namespace-%5BFSharp%5D.md)