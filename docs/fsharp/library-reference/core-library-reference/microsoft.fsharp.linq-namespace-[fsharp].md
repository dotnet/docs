---
title: Microsoft.FSharp.Linq Namespace (F#)
description: Microsoft.FSharp.Linq Namespace (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e25aab78-4048-458e-ab55-7780cec67e9f
---

# Microsoft.FSharp.Linq Namespace (F#)

This namespace includes types that support F# query expressions. This includes functions and operators for working with nullable values frequently encountered when working with databases, and the types that are used to implement the query expressions language feature. For more information, see [Query Expressions &#40;F&#35;&#41;](Query-Expressions-%5BFSharp%5D.md).

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
namespace Microsoft.FSharp.Linq
```

## Namespaces

|Namespace|Description|
|---------|-----------|
|namespace Microsoft.FSharp.Linq.QueryRunExtensions|Contains modules and functions that support the F# query syntax.|

## Modules

|Module|Description|
|------|-----------|
|module [Nullable](https://msdn.microsoft.com/library/e7a4ea13-28cc-462e-bc3a-33131ace976e)|Functions for converting nullable values.|
|module [NullableOperators](https://msdn.microsoft.com/library/2c3633c5-3f31-4d62-a9f8-272ad6b19007)|Operators for working with nullable values.|

## Type Definitions


|Type|Description|
|----|-----------|
|type [QueryBuilder](https://msdn.microsoft.com/library/1fb66a8e-b815-4aa3-9fab-82f671337fbc)|The type used to support the F# query syntax.|
|type [QuerySource&lt;'T,'Q&gt;](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)|A partial input or result in an F# query.|

## See Also
[F&#35; Core Library Reference](FSharp-Core-Library-Reference.md)

[Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md)
