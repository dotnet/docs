---
title: Map.Item<'Key,'Value> Property (F#)
description: Map.Item<'Key,'Value> Property (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 673c9017-f245-4b08-80c0-bdd3978fa3da
---

# Map.Item<'Key,'Value> Property (F#)

Lookup an element in the map. Raise `System.Collections.Generic.KeyNotFoundException` if no binding exists in the map.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Item ('Key) : 'Value (requires comparison)

// Usage:
map.[key]
```

#### Parameters
*key*
Type: **'Key**


The input key.

## Exceptions
|Exception|Condition|
|----|----|
|[KeyNotFoundException](https://msdn.microsoft.com/library/system.collections.generic.keynotfoundexception.aspx)|Thrown when the key is not found.|

## Return Value

The value mapped to the key.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map&#60;'Key,'Value&#62; Class &#40;F&#35;&#41;](Collections.Map%5B%27Key%2C%27Value%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
