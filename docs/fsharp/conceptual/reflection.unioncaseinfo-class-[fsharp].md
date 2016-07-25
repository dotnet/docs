---
title: Reflection.UnionCaseInfo Class (F#)
description: Reflection.UnionCaseInfo Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4ca4502a-e466-4184-8e2d-54af625653bf
---

# Reflection.UnionCaseInfo Class (F#)

Represents a case of a discriminated union type.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<Sealed>]
type UnionCaseInfo =
class
member this.GetCustomAttributes : Type -> obj []
member this.GetCustomAttributes : unit -> obj []  member this.GetCustomAttributesData : unit -> IList<CustomAttributeData>
member this.GetFields : unit -> PropertyInfo []
member this.DeclaringType :  Type
member this.Name :  string
member this.Tag :  int
end
```

## Remarks

## Instance Members


|Member|Description|
|------|-----------|
|[DeclaringType](https://msdn.microsoft.com/library/c96263e9-4b74-4e3b-bda1-23831f3527a6)|The type in which the case occurs.|
|[GetCustomAttributes](https://msdn.microsoft.com/library/ce087bae-8d3b-4d64-b9a5-0b37e6af2b64)|Returns the custom attributes associated with the case matching the given attribute type.|
|[GetCustomAttributesData](https://msdn.microsoft.com/library/8d3748a9-50fd-4bf0-bcfd-d7481658102c)|Returns the custom attributes data associated with the case.|
|[GetFields](https://msdn.microsoft.com/library/4536b002-c238-4bb4-9bb0-39caaaa76c96)|The fields associated with the case, represented by a `System.Reflection.PropertyInfo`.|
|[Name](https://msdn.microsoft.com/library/cf541d4b-18d6-4d87-ae3b-10512c9b2252)|The name of the case.|
|[Tag](https://msdn.microsoft.com/library/d3bafe1e-8dd4-40c8-9d72-43ebcf9e1e45)|The integer tag for the case.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)
