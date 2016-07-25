---
title: Core.CustomEqualityAttribute Class (F#)
description: Core.CustomEqualityAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: deb08663-802f-4dfd-b876-ececfc6ecb61 
---

# Core.CustomEqualityAttribute Class (F#)

Indicates that a type has a user-defined implementation of equality.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Struct, AllowMultiple = false)>]
[<Sealed>]
type CustomEqualityAttribute =
class
new CustomEqualityAttribute : unit -> CustomEqualityAttribute
end
```

## Remarks
You can also use the short form of the name, `CustomEquality`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/ad3d4ebe-f35f-4e0a-9e13-556cf8f24c46)|Creates an instance of the attribute.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)