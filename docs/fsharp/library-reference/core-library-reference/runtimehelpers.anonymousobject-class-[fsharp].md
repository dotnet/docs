---
title: RuntimeHelpers.AnonymousObject Class (F#)
description: RuntimeHelpers.AnonymousObject Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9632bbde-f02a-4085-8368-ef007f64bb98
---

# RuntimeHelpers.AnonymousObject Class (F#)

A type that represents an aggregate object. This type supports the infrastructure for F# query expressions and is for internal use only.

**Namespace/Module Path**: Microsoft.FSharp.Linq.RuntimeHelpers

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type [AnonymousObject](https://msdn.microsoft.com/library/e7deda0a-f18d-44a0-a5b9-2c7e34107f5f)<'T1 ... 'T8> =
class
new AnonymousObject : unit -> AnonymousObject<'T1 ... 'T8>
member this.Item1 : 'T1 with get, set  member this.Item2 : 'T2 with get, set  ...
end
```

## Remarks
This type is overloaded by arity. There are eight separate generic types with the same name, each with a different number of generic type parameters, depending on the number of items in the aggregate.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/5f258a32-5612-47a1-a485-37979174b230)|Creates a new instance of the type.|

## Instance Members


|Member|Description|
|------|-----------|
|[Item1 to Item8](https://msdn.microsoft.com/library/1506fdce-e768-4e79-9d65-d2fd902b4ba0)|Provides access to the aggregated objects.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable


## See Also
[Microsoft.FSharp.Linq.RuntimeHelpers Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq.RuntimeHelpers-Namespace-%5BFSharp%5D.md)

[Query Expressions (F#)](https://msdn.microsoft.com/library/ff72235c-3ad8-4215-8679-2754484823db)
