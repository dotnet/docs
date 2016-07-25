---
title: Core.EqualityConditionalOnAttribute Class (F#)
description: Core.EqualityConditionalOnAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 7f1381a7-dbe7-4767-8e1b-0cf2d5b9c6a6 
---

# Core.EqualityConditionalOnAttribute Class (F#)

This attribute is used to indicate a generic container type satisfies the F# equality constraint only if a generic argument also satisfies this constraint. For example, adding this attribute to parameter `'T` on a type definition `C<'T>` means that a type `C<X>` only supports equality if the type `X` also supports equality and all other conditions for `C<X>` to support equality are also met. The type `C<'T>` can still be used with other type arguments, but a type such as `C<(int -> int)>` will not support equality because the type `(int -> int)` is an F# function type and does not support equality.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.GenericParameter, AllowMultiple = false)>]
[<Sealed>]
type EqualityConditionalOnAttribute =
class
new EqualityConditionalOnAttribute : unit -> EqualityConditionalOnAttribute
end
```

## Remarks
This attribute will be ignored if it is used on the generic parameters of functions or methods.

You can also use the short form of the name, `EqualityConditionalOn`.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/7fd67389-8d84-4376-bc9c-fc02ab507305)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)