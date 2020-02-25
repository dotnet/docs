---
title: Core.ComparisonConditionalOnAttribute Class (F#)
description: Core.ComparisonConditionalOnAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2e47166a-8425-45f4-8e0c-105a85caa092 
---

# Core.ComparisonConditionalOnAttribute Class (F#)

Indicates that a generic type satisfies the comparison constraint if and only if the type argument satisfies this constraint.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.GenericParameter, AllowMultiple = false)>]
[<Sealed>]
type ComparisonConditionalOnAttribute =
class
new ComparisonConditionalOnAttribute : unit -> ComparisonConditionalOnAttribute
end
```

## Remarks
This attribute is used to indicate a generic container type satisfies the F# comparison constraint only if a generic argument also satisfies this constraint. For example, adding this attribute to parameter `'T` on a type definition `C<'T>` means that a type `C<X>` only supports comparison if the type X also supports comparison and all other conditions for `C<X>` to support comparison are also met. The type `C<'T>` can still be used with other type arguments, but a type such as `C<(int -> int)>` will not support comparison because the type `(int -> int)` is an F# function type and does not support comparison.

This attribute will be ignored if it is used on the generic parameters of functions or methods.

You can also use the short form of the name, `ComparisonConditionalOn`.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/bba363a1-dce7-4f58-82a9-f5edb3043b87)|Creates an instance of the attribute.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)