---
title: Core.CustomOperationAttribute Class (F#)
description: Core.CustomOperationAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 526c0ac1-cc47-43d2-91c5-477f9bc90856 
---

# Core.CustomOperationAttribute Class (F#)

Indicates that a member on a computation builder type is a custom query operator, and indicates the name of that operator.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Method, AllowMultiple = false)>]
[<Sealed>]
type 
CustomOperationAttribute
 =
 class
  new CustomOperationAttribute : string -> CustomOperationAttribute
  member this.AllowIntoPattern : bool with get, set
  member this.IsLikeGroupJoin : bool with get, set
  member this.IsLikeJoin : bool with get, set
  member this.IsLikeZip : bool with get, set
  member this.MaintainsVariableSpace : bool with get, set
  member this.MaintainsVariableSpaceUsingBind : bool with get, set
  member this.Name : string
  member this.IsLikeGroupJoin : bool with get, set
  member this.IsLikeJoin : bool with get, set
  member this.IsLikeZip : bool with get, set
  member this.JoinConditionWord : string with get, set
  member this.MaintainsVariableSpace : bool with get, set
  member this.MaintainsVariableSpaceUsingBind  : bool with get, set
 end
```

## Remarks
You can also use the short form of the name, `CustomOperation`.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/90acbcd3-d7be-4610-b099-7001470eee86)|Creates an instance of the attribute|

## Instance Members

|Member|Description|
|------|-----------|
|[AllowIntoPattern](https://msdn.microsoft.com/library/931ed911-2da0-4a8c-9138-dcce14d0bfdc) : [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5) with get, set|Indicates if the custom operation supports the use of **into** immediately after the use of the operation in a query or other computation expression to consume the results of the operation.|
|[IsLikeGroupJoin](https://msdn.microsoft.com/library/81cecf4a-54d4-419c-81d2-3a04337b6952) : [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5) with get, set|Indicates if the custom operation is an operation similar to a group join in a sequence computation, in that it supports two inputs and a correlation constraint, and generates a group.|
|[IsLikeJoin](https://msdn.microsoft.com/library/fac774ad-967c-4513-9388-d58b05f5d453) : [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5) with get, set|Indicates if the custom operation is an operation similar to a join in a sequence computation, in that it supports two inputs and a correlation constraint.|
|[IsLikeZip](https://msdn.microsoft.com/library/db80d57f-c065-4fa9-905e-6ca67896a45a) : [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5) with get, set|Indicates if the custom operation is an operation similar to a zip in a sequence computation, in that it supports two inputs.|
|[JoinConditionWord](https://msdn.microsoft.com/library/b51fda1d-1379-4069-9268-2ce5de1d73f0) : string|Indicates the name used for the "on" part of the custom query operator for join-like operators.|
|[MaintainsVariableSpace](https://msdn.microsoft.com/library/c901a2d3-03a7-4a89-97a4-646397a2f3cf) : [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5) with get, set|Indicates if the custom operation maintains the variable space of the query of computation expression.|
|[MaintainsVariableSpaceUsingBind](https://msdn.microsoft.com/library/0ec961ee-9605-41a3-af0f-b06820bbd076) : [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5) with get, set|Indicates if the custom operation maintains the variable space of the query of computation expression through the use of a bind operation.|
|[Name](https://msdn.microsoft.com/library/afe5f92f-f58d-4465-b73a-7705ba037126) : [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)|The name of the custom operation when used in a query or other computation expression.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)