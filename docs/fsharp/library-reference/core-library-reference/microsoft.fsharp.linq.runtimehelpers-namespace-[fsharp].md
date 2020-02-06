---
title: Microsoft.FSharp.Linq.RuntimeHelpers Namespace (F#)
description: Microsoft.FSharp.Linq.RuntimeHelpers Namespace (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: aebd78dd-3871-4d00-bc7b-2f1bf975fea0
---

# Microsoft.FSharp.Linq.RuntimeHelpers Namespace (F#)

This module contains infrastructure types for query expressions.

**Namespace/Module Path**: Microsoft.FSharp.Linq.RuntimeHelpers

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
namespace Microsoft.FSharp.Linq.RuntimeHelpers
```

## Modules

|Module|Description|
|------|-----------|
|module [LeafExpressionConverter](https://msdn.microsoft.com/library/4c452e96-3036-4f0e-9008-72abe94c4ad6)|Contains functions that help implement F# query expressions.|

## Type Definitions

|Type|Description|
|----|-----------|
|type [Grouping&lt;'K,'T&gt;](https://msdn.microsoft.com/library/4a6ac4d6-5b30-44bb-b34d-c6773f86dedf)|Reconstructs a grouping after applying a mutable to immutable mapping transformation on a result of a query.|
|type [MutableTuple](https://msdn.microsoft.com/library/e7deda0a-f18d-44a0-a5b9-2c7e34107f5f)|Implements a tuple as a mutable variable. This type supports the infrastructure for F# query expressions.|

## See Also
[F&#35; Core Library Reference](FSharp-Core-Library-Reference.md)
