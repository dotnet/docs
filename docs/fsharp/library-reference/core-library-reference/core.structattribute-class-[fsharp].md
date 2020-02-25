---
title: Core.StructAttribute Class (F#)
description: Core.StructAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3aeae0f2-84b8-4cad-a38e-de4e0746a3af 
---

# Core.StructAttribute Class (F#)

Adding this attribute to a type causes it to be represented using a .NET Framework structure.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Struct, AllowMultiple = false)>]
[<Sealed>]
type StructAttribute =
class
new StructAttribute : unit -> StructAttribute
end
```

## Remarks
You can also use the short form of the name, `Struct`.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/2122d591-eb68-4d21-a21c-d538a05eeff7)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)

[Structures &#40;F&#35;&#41;](Structures-%5BFSharp%5D.md)