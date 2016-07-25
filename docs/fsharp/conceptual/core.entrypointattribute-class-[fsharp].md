---
title: Core.EntryPointAttribute Class (F#)
description: Core.EntryPointAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8d1e2656-8b6e-4f18-aa06-fd5429b5c8ec 
---

# Core.EntryPointAttribute Class (F#)

Adding this attribute to a function indicates it is the entry point for an application. If this absent is not specified for an EXE then the initialization implicit in the module bindings in the last file in the compilation sequence are used as the entry point.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Method, AllowMultiple = false)>]
[<Sealed>]
type EntryPointAttribute =
class
new EntryPointAttribute : unit -> EntryPointAttribute
end
```

## Remarks
You can also use the short form of the name, `EntryPoint`.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/48ccf8e2-f6af-431d-8a90-bd2870df5c43)|Creates an instance of the attribute.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)

[Entry Point &#40;F&#35;&#41;](Entry-Point-%5BFSharp%5D.md)