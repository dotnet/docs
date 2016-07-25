---
title: Core.ExperimentalAttribute Class (F#)
description: Core.ExperimentalAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ade9a335-d5c5-4be1-a559-eb99d0522d44 
---

# Core.ExperimentalAttribute Class (F#)

This attribute is used to tag values that are part of an experimental library feature.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.All, AllowMultiple = false)>]
[<Sealed>]
type ExperimentalAttribute =
class
new ExperimentalAttribute : string -> ExperimentalAttribute
member this.Message :  string
end
```

## Remarks
You can also use the short form of the name, `Experimental`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/a5e39013-4d7d-43fa-ba96-74c9f4d7b3f7)|Creates an instance of the attribute|

## Instance Members


|Member|Description|
|------|-----------|
|[Message](https://msdn.microsoft.com/library/b804ac7a-5d25-440e-9038-b80634d0f1ef)|Indicates the warning message to be emitted when F# source code uses this construct.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)