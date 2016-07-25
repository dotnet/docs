---
title: Core.StructuredFormatDisplayAttribute Class (F#)
description: Core.StructuredFormatDisplayAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: eb0034b0-f4e7-44ad-af59-d07c1913de9b 
---

# Core.StructuredFormatDisplayAttribute Class (F#)

This attribute is used to mark how a type is displayed by default when using `%A`[printf](https://msdn.microsoft.com/library/ea074733-6b5d-498c-ac88-7e4e0f8ded25) formatting patterns and other two-dimensional text-based display layouts. In this version of F# the only valid values are of the form `PreText {PropertyName} PostText`. The property name indicates a property to evaluate and to display instead of the object itself.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Interface ||| AttributeTargets.Struct ||| AttributeTargets.Delegate ||| AttributeTargets.Enum, AllowMultiple = false)>]
[<Sealed>]
type StructuredFormatDisplayAttribute =
class
new StructuredFormatDisplayAttribute : string -> StructuredFormatDisplayAttribute
member this.Value :  string
end
```

## Remarks
You can also use the short form of the name, `StructuredFormatDisplay`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/d6578534-f7cd-40b7-9219-9b71fe35f270)|Creates an instance of the attribute|

## Instance Members


|Member|Description|
|------|-----------|
|[Value](https://msdn.microsoft.com/library/71375b98-a109-4697-937f-1d906d72842d)|Indicates the text to display by default when objects of this type are displayed using **%A**[printf](https://msdn.microsoft.com/library/ea074733-6b5d-498c-ac88-7e4e0f8ded25) formatting patterns and other two-dimensional text-based display layouts.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)