---
title: Core.<'T> Type (F#)
description: Core.<'T> Type (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 47184ff3-e399-45ce-aff3-d44fdc98e669 
---

# Core.<'T> Type (F#)

Two dimensional arrays, typically zero-based.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type [,]<'T> =
class
end
```

## Remarks
Use the functions in the [Array2D module](https://msdn.microsoft.com/library/ae1a9746-7817-4430-bcdb-a79c2411bbd3) to create and manipulate values of this type, or the notation `arr.[x,y]` to get or set array values. Non-zero-based arrays can also be created using methods on the `System.Array` type. For more information on arrays, see [Arrays &#40;F&#35;&#41;](Arrays-%5BFSharp%5D.md).


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)

[Arrays &#40;F&#35;&#41;](Arrays-%5BFSharp%5D.md)