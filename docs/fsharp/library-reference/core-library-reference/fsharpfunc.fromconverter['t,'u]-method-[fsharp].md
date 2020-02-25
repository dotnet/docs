---
title: FSharpFunc.FromConverter<'T,'U> Method (F#)
description: FSharpFunc.FromConverter<'T,'U> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ee75e089-b166-4baa-8a77-95aa2f92a3cd 
---

# FSharpFunc.FromConverter<'T,'U> Method (F#)

Convert a value of type `System.Converter` to a F# first class function value.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member FromConverter : Converter<'T,'U> -> 'T -> 'U

// Usage:
FSharpFunc.FromConverter (converter)
```

#### Parameters
*converter*
Type: **System.Converter&#96;2****&lt;'T,'U&gt;**


The input **System.Converter&#96;2** instance.

## Return Value

An F# function of the same type.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0

## See Also
[Core.FSharpFunc&#60;'T,'U&#62; Class &#40;F&#35;&#41;](Core.FSharpFunc%5B%27T%2C%27U%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)