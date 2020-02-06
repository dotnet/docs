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
ms.assetid: b7e5e3b1-3109-4ae2-ab29-f272092bc0a4 
---

# Core.<'T> Type (F#)

Four dimensional arrays, typically zero-based. Non-zero-based arrays can be created using methods on the `System.Array` type.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type [,,,]<'T> =
class
end
```

## Remarks
Use the values in the [Array4D module](https://msdn.microsoft.com/library/9fdbd023-7c17-4a68-a405-8a1b826ac032) to manipulate values of this type, or the notation `arr.[x1,x2,x3,x4]` to get and set array values.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)

[Arrays &#40;F&#35;&#41;](Arrays-%5BFSharp%5D.md)