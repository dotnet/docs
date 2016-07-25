---
title: Core.GeneralizableValueAttribute Class (F#)
description: Core.GeneralizableValueAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4582ae4c-9d38-49c6-8d8b-2c7b8c8a39ad 
---

# Core.GeneralizableValueAttribute Class (F#)

Adding this attribute to a non-function value with generic parameters indicates that uses of the construct can give rise to generic code through type inference.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Method, AllowMultiple = false)>]
[<Sealed>]
type GeneralizableValueAttribute =
class
new GeneralizableValueAttribute : unit -> GeneralizableValueAttribute
end
```

## Remarks
You can also use the short form of the name, `GeneralizableValue`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/2aea746e-5873-4edf-ac41-97d34e7185c8)|Creates an instance of the attribute.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)