---
title: Reflection.FSharpReflectionExtensions Module (F#)
description: Reflection.FSharpReflectionExtensions Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 43fcb4f6-a35e-4376-86d2-bd19c83ec4a9
---

# Reflection.FSharpReflectionExtensions Module (F#)

A module of extension members that provides versions of certain F# reflection APIs for use with the .NET portable library.

**Namespace/Module Path:** Microsoft.FSharp.Reflection.FSharpReflectionExtensions

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module FSharpReflectionExtensions =  type FSharpType with    static member GetExceptionFields : Type * ?bool -> PropertyInfo []
static member GetRecordFields : Type * ?bool -> PropertyInfo []
static member GetUnionCases : Type * ?bool -> UnionCaseInfo []
static member IsExceptionRepresentation : Type * ?bool -> bool
static member IsRecord : Type * ?bool -> bool
static member IsUnion : Type * ?bool -> bool
type FSharpValue with    static member GetExceptionFields : obj * ?bool -> obj []
static member GetRecordFields : obj * ?bool -> obj []
static member GetUnionFields : obj * Type * ?bool -> UnionCaseInfo * obj []
static member MakeRecord : Type * obj [] * ?bool -> obj
static member MakeUnion : UnionCaseInfo * obj [] * ?bool -> obj
static member PreComputeRecordConstructor : Type * ?bool -> obj [] -> obj
static member PreComputeRecordConstructorInfo : Type * ?bool -> ConstructorInfo
static member PreComputeRecordFieldReader : PropertyInfo -> obj -> obj
static member PreComputeRecordReader : Type * ?bool -> obj -> obj []
static member PreComputeUnionConstructor : UnionCaseInfo * ?bool -> obj [] -> obj
static member PreComputeUnionConstructorInfo : UnionCaseInfo * ?bool -> MethodInfo
static member PreComputeUnionReader : UnionCaseInfo * ?bool -> obj -> obj []
static member PreComputeUnionTagMemberInfo : Type * ?bool -> MemberInfo
static member PreComputeUnionTagReader : Type * ?bool -> obj -> int
```

## Remarks
The .NET portable library does not have the `System.Reflection.BindingFlags` type, so these methods provide alternative versions of certain methods on the [FSharpType](https://msdn.microsoft.com/library/e3304409-1849-4058-957a-872a376e3663) and [FSharpValue](https://msdn.microsoft.com/library/37ecfa9f-1f47-4957-bb2c-a2664e9a68d0) types that take a `bool` as a parameter instead of `System.Reflection.BindingFlags`. For other methods, use the [FSharpType](https://msdn.microsoft.com/library/e3304409-1849-4058-957a-872a376e3663) and [FSharpValue](https://msdn.microsoft.com/library/37ecfa9f-1f47-4957-bb2c-a2664e9a68d0) types directly.


## Extension Members


|Extension Member|Description|
|----------------|-----------|
|[FSharpType.GetExceptionFields](https://msdn.microsoft.com/library/7fb355e6-b345-4c7d-bea0-9af302f60148)|Reads all the fields from an F# exception declaration, in declaration order.|
|[FSharpType.GetRecordFields](https://msdn.microsoft.com/library/266635db-ea29-481f-9cb7-b7f72b754497)|Reads all the fields from a record value, in declaration order.|
|[FSharpType.GetUnionCases](https://msdn.microsoft.com/library/a1d0f854-48ac-4e61-a80b-2db11d7d2c1a)|Gets the cases of a union type.|
|[FSharpType.IsExceptionRepresentation](https://msdn.microsoft.com/library/6ca9be2b-2f54-40b4-90a0-3c5dc623f116)|Returns true if the given type is a representation of an F# exception declaration.|
|[FSharpType.IsRecord](https://msdn.microsoft.com/library/bb3b2a3b-51b5-4a8b-82fe-d61282becead)|Returns true if the type is a representation of an F# record type.|
|[FSharpType.IsUnion](https://msdn.microsoft.com/library/529743e4-c456-429f-934f-ab8610166abb)|Returns true if the given type is a representation of an F# union type or the runtime type of a value of that type.|
|[FSharpValue.GetExceptionFields](https://msdn.microsoft.com/library/84b30bf9-35cf-4d04-9ec0-9bdeb5bf6e85)|Reads all the fields from a value built using an instance of an F# exception declaration.|
|[FSharpValue.GetRecordFields](https://msdn.microsoft.com/library/e328a079-cfd4-4d88-bc17-4523f8a708bf)|Reads all the fields from a record value.|
|[FSharpValue.GetUnionFields](https://msdn.microsoft.com/library/ba1e1a92-cfd1-4f70-9316-ffe940e1bca0)|Identify the union case and its fields for an object.|
|[FSharpValue.MakeRecord](https://msdn.microsoft.com/library/ad2aac30-6120-4cc9-a5cf-046ca43d53b9)|Creates an instance of a record type.|
|[FSharpValue.MakeUnion](https://msdn.microsoft.com/library/70e0087b-3f79-4b1e-93a2-82514ecae0f7)|Create a union case value.|
|[FSharpValue.PreComputeRecordConstructor](https://msdn.microsoft.com/library/e4029ded-7adb-4ee4-9fad-2f8a7d25f908)|Precompute a function for constructing a record value.|
|[FSharpValue.PreComputeRecordConstructorInfo](https://msdn.microsoft.com/library/301602a5-664d-4c93-9875-f795c6c0b3e4)|Get a ConstructorInfo for a record type.|
|[FSharpValue.PreComputeRecordReader](https://msdn.microsoft.com/library/e0bbaa8b-746f-422f-9b54-9ef60ad6418b)|Precompute a function for reading all the fields from a record. The fields are returned in the same order as the fields reported by a call to Microsoft.FSharp.Reflection.Type.GetInfo for this type.|
|[FSharpValue.PreComputeUnionConstructor](https://msdn.microsoft.com/library/feaae316-29f9-437d-b063-0f6f775ee96b)|Precomputes a function for constructing a discriminated union value for a particular union case.|
|[FSharpValue.PreComputeUnionConstructorInfo](https://msdn.microsoft.com/library/bfe97595-394d-44e8-b4e8-4f6faf00ff10)|A method that constructs objects of the given case.|
|[FSharpValue.PreComputeUnionReader](https://msdn.microsoft.com/library/3229aed9-fb5c-4c94-ae83-7a730776ff2e)|Precomputes a function for reading all the fields for a particular discriminator case of a union type.|
|[FSharpValue.PreComputeUnionTagMemberInfo](https://msdn.microsoft.com/library/bde85ca4-fa0b-44a1-b893-0d5bbf6b6d9f)FSharpValue.PreComputeUnionTagMemberInfo|Precompute a property or static method for reading an integer representing the case tag of a union type.|
|[FSharpValue.PreComputeUnionTagReader](https://msdn.microsoft.com/library/ca2f8c2b-59ec-4cc8-a307-cca468325de9)|Precompute an optimized function to read the tags of the given union type.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)

[Reflection.FSharpType Class &#40;F&#35;&#41;](Reflection.FSharpType-Class-%5BFSharp%5D.md)

[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)
