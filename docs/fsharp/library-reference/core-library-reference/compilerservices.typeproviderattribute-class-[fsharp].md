---
title: CompilerServices.TypeProviderAttribute Class (F#)
description: CompilerServices.TypeProviderAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 452e9b92-fec1-48d0-9439-27ca36ba54c5 
---

# CompilerServices.TypeProviderAttribute Class (F#)

Place on a class that implements the [`ITypeProvider`](https://msdn.microsoft.com/library/2c2b0571-843d-4a7d-95d4-0a7510ed5e2f) interface to extend the compiler.

**Namespace/Module Path**: Microsoft.FSharp.Core.CompilerServices

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(4, AllowMultiple = false)>]
type [TypeProviderAttribute](https://msdn.microsoft.com/library/bdf7b036-7490-4ace-b79f-c5f1b1b37947) =
class
new TypeProviderAttribute : unit -> TypeProviderAttribute
end
```

## Remarks
You can also use the short form of the name, `TypeProvider`.

## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/87a0c691-4d56-4c67-b718-0eceff4e2d72)|Creates an instance of the attribute.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)