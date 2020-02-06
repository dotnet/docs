---
title: Core.DefaultValueAttribute Constructor (F#)
description: Core.DefaultValueAttribute Constructor (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9fab3fdb-15a0-420c-88a9-21cc0e4482d5 
---

# Core.DefaultValueAttribute Constructor (F#)

Creates an instance of the attribute.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
new DefaultValueAttribute : bool -> DefaultValueAttribute
new DefaultValueAttribute : unit -> DefaultValueAttribute

// Usage:
new DefaultValueAttribute (check)
new DefaultValueAttribute ()
```

#### Parameters
*check*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Indicates whether to assert that the field type supports **null**.


## Return Value

A new `DefaultValueAttribute` instance.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.DefaultValueAttribute Class &#40;F&#35;&#41;](Core.DefaultValueAttribute-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)