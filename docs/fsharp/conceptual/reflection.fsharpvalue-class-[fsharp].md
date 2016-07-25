---
title: Reflection.FSharpValue Class (F#)
description: Reflection.FSharpValue Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fea6080a-5dc6-41bf-b57c-e6f6c549dd4b
---

# Reflection.FSharpValue Class (F#)

Contains operations associated with constructing and analyzing values associated with F# types such as records, unions and tuples.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AbstractClass>]
[<Sealed>]
type FSharpValue =
class
static member GetExceptionFields : obj * ?BindingFlags -> obj []
static member GetRecordField : obj * PropertyInfo -> obj
static member GetRecordFields : obj * ?BindingFlags -> obj []
static member GetTupleField : obj * int -> obj
static member GetTupleFields : obj -> obj []
static member GetUnionFields : obj * Type * ?BindingFlags -> UnionCaseInfo * obj []
static member MakeFunction : Type * (obj -> obj) -> obj
static member MakeRecord : Type * obj [] * ?BindingFlags -> obj
static member MakeTuple : obj [] * Type -> obj
static member MakeUnion : UnionCaseInfo * obj [] * ?BindingFlags -> obj
static member PreComputeRecordConstructor : Type * ?BindingFlags -> obj [] -> obj
static member PreComputeRecordConstructorInfo : Type * ?BindingFlags -> ConstructorInfo
static member PreComputeRecordFieldReader : PropertyInfo -> obj -> obj
static member PreComputeRecordReader : Type * ?BindingFlags -> obj -> obj []
static member PreComputeTupleConstructor : Type -> obj [] -> obj
static member PreComputeTupleConstructorInfo : Type -> ConstructorInfo * Type option
static member PreComputeTuplePropertyInfo : Type * int -> PropertyInfo * Type * int option
static member PreComputeTupleReader : Type -> obj -> obj []
static member PreComputeUnionConstructor : UnionCaseInfo * ?BindingFlags -> obj [] -> obj
static member PreComputeUnionConstructorInfo : UnionCaseInfo * ?BindingFlags -> MethodInfo
static member PreComputeUnionReader : UnionCaseInfo * ?BindingFlags -> obj -> obj []
static member PreComputeUnionTagMemberInfo : Type * ?BindingFlags -> MemberInfo
static member PreComputeUnionTagReader : Type * ?BindingFlags -> obj -> int
end
```

## Static Members

|Member|Description|
|------|-----------|
|[GetExceptionFields](https://msdn.microsoft.com/library/84b30bf9-35cf-4d04-9ec0-9bdeb5bf6e85)|Reads all the fields from a value built using an instance of an F# exception declaration.|
|[GetRecordField](https://msdn.microsoft.com/library/6dacc2db-7425-45c0-bb04-77b84dd0452a)|Reads a field from a record value.|
|[GetRecordFields](https://msdn.microsoft.com/library/e328a079-cfd4-4d88-bc17-4523f8a708bf)|Reads all the fields from a record value.|
|[GetTupleField](https://msdn.microsoft.com/library/db833e2d-be73-40b8-af89-bc273e40fa06)|Reads a field from a tuple value.|
|[GetTupleFields](https://msdn.microsoft.com/library/872a1830-3992-4503-b17c-10c995903e87)|Reads all fields from a tuple.|
|[GetUnionFields](https://msdn.microsoft.com/library/ba1e1a92-cfd1-4f70-9316-ffe940e1bca0)|Identify the union case and its fields for an object.|
|[MakeFunction](https://msdn.microsoft.com/library/369b5863-d689-4adb-a4e9-756cc39731b4)|Creates a typed function from object from a dynamic function implementation.|
|[MakeRecord](https://msdn.microsoft.com/library/ad2aac30-6120-4cc9-a5cf-046ca43d53b9)|Creates an instance of a record type.|
|[MakeTuple](https://msdn.microsoft.com/library/88678b0e-3669-4872-8f8f-c5343c4decfc)|Creates an instance of a tuple type.|
|[MakeUnion](https://msdn.microsoft.com/library/70e0087b-3f79-4b1e-93a2-82514ecae0f7)|Create a union case value.|
|[PreComputeRecordConstructor](https://msdn.microsoft.com/library/e4029ded-7adb-4ee4-9fad-2f8a7d25f908)|Precompute a function for constructing a record value.|
|[PreComputeRecordConstructorInfo](https://msdn.microsoft.com/library/301602a5-664d-4c93-9875-f795c6c0b3e4)|Get a `System.Reflection.ConstructorInfo` for a record type.|
|[PreComputeRecordFieldReader](https://msdn.microsoft.com/library/bddde908-a749-493c-859c-b41f8fc04646)|Precompute a function for reading a particular field from a record.|
|[PreComputeRecordReader](https://msdn.microsoft.com/library/e0bbaa8b-746f-422f-9b54-9ef60ad6418b)|Precompute a function for reading all the fields from a record. The fields are returned in the same order as the fields reported by a call to Microsoft.FSharp.Reflection.Type.GetInfo for this type.|
|[PreComputeTupleConstructor](https://msdn.microsoft.com/library/003ce5e8-0263-49a7-a949-5b5ad2db373b)|Precomputes a function for reading the values of a particular tuple type.|
|[PreComputeTupleConstructorInfo](https://msdn.microsoft.com/library/846fd770-b6a2-47b0-a295-cfa5cd86b7c4)|Gets a method that constructs objects of the given tuple type. For small tuples, no additional type will be returned.|
|[PreComputeTuplePropertyInfo](https://msdn.microsoft.com/library/521a6f3f-6774-4392-8a81-6b15d72c3d9c)|Gets information that indicates how to read a field of a tuple.|
|[PreComputeTupleReader](https://msdn.microsoft.com/library/da980eb2-1ebd-466c-8c3f-f241549961db)|Precomputes a function for reading the values of a particular tuple type.|
|[PreComputeUnionConstructor](https://msdn.microsoft.com/library/feaae316-29f9-437d-b063-0f6f775ee96b)|Precomputes a function for constructing a discriminated union value for a particular union case.|
|[PreComputeUnionConstructorInfo](https://msdn.microsoft.com/library/bfe97595-394d-44e8-b4e8-4f6faf00ff10)|A method that constructs objects of the given case.|
|[PreComputeUnionReader](https://msdn.microsoft.com/library/3229aed9-fb5c-4c94-ae83-7a730776ff2e)|Precomputes a function for reading all the fields for a particular discriminator case of a union type.|
|[PreComputeUnionTagMemberInfo](https://msdn.microsoft.com/library/bde85ca4-fa0b-44a1-b893-0d5bbf6b6d9f)|Precomputes a property or static method for reading an integer representing the case tag of a union type.|
|[PreComputeUnionTagReader](https://msdn.microsoft.com/library/ca2f8c2b-59ec-4cc8-a307-cca468325de9)|Precomputes a function that reads the tags of a union type.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)
