---
title: ITypeProvider.add_Invalidate Method (F#)
description: ITypeProvider.add_Invalidate Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1467ab3c-2f09-4b82-b102-0aabdae86427 
---

# ITypeProvider.add_Invalidate Method (F#)

Add an event handler to the [`Invalidate`](https://msdn.microsoft.com/library/5a8d95dc-e462-4f07-90e4-9b8dfb82d100) event.

**Namespace/Module Path**: Microsoft.FSharp.Core.CompilerServices

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.add_Invalidate : EventHandler -> unit

// Usage:
iTypeProvider.add_Invalidate ()
```

#### Parameters
*handler*
Type: **System.EventHandler**


The event handler to add.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[CompilerServices.ITypeProvider Interface &#40;F&#35;&#41;](CompilerServices.ITypeProvider-Interface-%5BFSharp%5D.md)

[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)