---
title: Core.DefaultAugmentationAttribute Class (F#)
description: Core.DefaultAugmentationAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a6add182-f768-4e4b-a952-76cb27532fe1 
---

# Core.DefaultAugmentationAttribute Class (F#)

Adding this attribute to a discriminated union with value **false** turns off the generation of standard helper member tester, constructor and accessor members for the generated Common Language Infrastructure (CLI) class for that type.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class, AllowMultiple = false)>]
[<Sealed>]
type DefaultAugmentationAttribute =
class
new DefaultAugmentationAttribute : bool -> DefaultAugmentationAttribute
member this.Value :  bool
end
```

## Remarks
You can also use the short form of the name, `DefaultAugmentation`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/866905a2-58a8-4f9d-9d9a-3e0c19226440)|Creates an instance of the attribute|

## Instance Members


|Member|Description|
|------|-----------|
|[Value](https://msdn.microsoft.com/library/25fcdeae-c8ae-452b-b7b5-a8ab5afa20db)|The value of the attribute, indicating whether the type has a default augmentation or not|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)