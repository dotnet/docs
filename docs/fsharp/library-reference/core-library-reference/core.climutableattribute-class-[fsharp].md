---
title: Core.CLIMutableAttribute Class (F#)
description: Core.CLIMutableAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 08187e59-4b87-4592-bdd6-158698c5f61f 
---

# Core.CLIMutableAttribute Class (F#)

Adding this attribute to a record type causes it to be compiled to a Common Language Infrastructure (CLI) representation with a default constructor with property getters and setters.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class, AllowMultiple = false)>][<Sealed>]type [CLIMutableAttribute](https://msdn.microsoft.com/library/571d62f3-5fb5-4088-a9d8-9d2fa61efdb7) = class  new CLIMutableAttribute : unit -> CLIMutableAttribute end
```

## Remarks
You can also use the short form of the name, `CLIMutable`.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/0d2f14f4-6400-4a34-9033-c27c608f1556)|Creates an instance of the attribute.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)