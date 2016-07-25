---
title: Core.SealedAttribute Class (F#)
description: Core.SealedAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1d1d3d6f-fa96-4fc7-8f27-35bcdb55fecd 
---

# Core.SealedAttribute Class (F#)

Adding this attribute to class definition makes it sealed, which means it may not be extended or implemented.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class, AllowMultiple = false)>]
type SealedAttribute =
class
new SealedAttribute : bool -> SealedAttribute
new SealedAttribute : unit -> SealedAttribute
member this.Value :  bool
end
```

## Remarks
You can also use the short form of the name, `Sealed`.

## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/66f6b40c-09b0-492d-8ed8-167263d1778a)|Creates an instance of the attribute|

## Instance Members

|Member|Description|
|------|-----------|
|[Value](https://msdn.microsoft.com/library/d80cc203-6a09-441a-812e-e78d17e121f9)|The value of the attribute, indicating whether the type is sealed or not.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)