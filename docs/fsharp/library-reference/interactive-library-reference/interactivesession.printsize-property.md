---
title: InteractiveSession.PrintSize Property
description: InteractiveSession.PrintSize Property
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 02/26/2020
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5a7116db-e754-4f54-b065-ecaba694d41e 
---

# InteractiveSession.PrintSize Property

Gets or sets the total print size, the maximum number of characters to print when displaying data, in the interactive session.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)


## Syntax

```fsharp
// Signatures:
member this.PrintSize :  int
member this.PrintSize : int with set :  int

// Usage:
interactiveSession.PrintSize
interactiveSession.PrintSize <- printSize
```

#### Parameters
*printSize*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The print size to set.

## Remarks
The default value is 10000.


## Platforms
Windows 7, Windows Vista SP2, Windows XP SP3, Windows XP x64 SP2, Windows Server 2008 R2, Windows Server 2008 SP2, Windows Server 2003 SP2


## Version Information
**F# Runtime**

Supported in: 2.0, 4.0

## See Also
[Interactive.InteractiveSession Class](Interactive.InteractiveSession-Class.md)

[Microsoft.FSharp.Compiler.Interactive Namespace](index.md)