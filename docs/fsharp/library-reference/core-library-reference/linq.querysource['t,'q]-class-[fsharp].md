---
title: Linq.QuerySource<'T,'Q> Class (F#)
description: Linq.QuerySource<'T,'Q> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6c3c004f-a7a5-4da9-b73d-e3a3fcce9843 
---

# Linq.QuerySource<'T,'Q> Class (F#)

A partial input or result in an F# query.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<NoComparison>]
[<NoEquality>]
[<Sealed>]
type [QuerySource](https://msdn.microsoft.com/library/873589c1-c5dc-47d9-8abf-fee7258dfb00)<'T,'Q> =
class
new QuerySource : seq<'T> -> QuerySource<'T,'Q>
member this.Source : seq<'T>
end
```

## Remarks
This type is used to implement the query expression functionality and should not be used directly.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/9ca12119-7ff2-4e0a-b1cc-ac32dfcbb2f6)|Create a new `QuerySource` object from an enumerable sequence.|

## Instance Members


|Member|Description|
|------|-----------|
|[Source](https://msdn.microsoft.com/library/583e52c0-530f-4f0c-aac4-31c6721d6548): seq&lt;'T&gt;|The enumerable sequence that is associated with a query.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable


## See Also
[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)