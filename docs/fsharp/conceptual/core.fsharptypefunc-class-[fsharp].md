---
title: Core.FSharpTypeFunc Class (F#)
description: Core.FSharpTypeFunc Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3f977173-fbf1-4f6a-9e0f-3080c5f26cf6 
---

# Core.FSharpTypeFunc Class (F#)

The .NET Framework type used to represent F# first-class type function values. This type is for use by compiled F# code.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AbstractClass>]
type FSharpTypeFunc =
class
new FSharpTypeFunc : unit -> FSharpTypeFunc
abstract this.Specialize : unit -> obj
end
```

## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/4c7b22be-9988-4429-8a00-fa109cc92a5e)|Construct an instance of an F# first class type function value|

## Instance Members


|Member|Description|
|------|-----------|
|[Specialize](https://msdn.microsoft.com/library/f783f869-2202-429f-95c7-97dc074a688f)|Specialize the type function at a given type|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)