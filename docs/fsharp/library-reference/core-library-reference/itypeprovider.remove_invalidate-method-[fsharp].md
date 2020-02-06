---
title: ITypeProvider.remove_Invalidate Method (F#)
description: ITypeProvider.remove_Invalidate Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f8e97e46-f197-4302-84cc-0ba92b077289 
---

# ITypeProvider.remove_Invalidate Method (F#)

Removes an event handler for the [`Invalidate`](https://msdn.microsoft.com/library/5a8d95dc-e462-4f07-90e4-9b8dfb82d100) event.

**Namespace/Module Path**: Microsoft.FSharp.Core.CompilerServices

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.remove_Invalidate : EventHandler -> unit

// Usage:
iTypeProvider.remove_Invalidate ()
```

#### Parameters
*handler*
Type: **System.EventHandler**


The event handler to remove.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0Supported in: 4.0, Portable

## See Also
[CompilerServices.ITypeProvider Interface &#40;F&#35;&#41;](CompilerServices.ITypeProvider-Interface-%5BFSharp%5D.md)

[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)