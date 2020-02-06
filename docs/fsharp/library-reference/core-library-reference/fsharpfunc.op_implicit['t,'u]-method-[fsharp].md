---
title: FSharpFunc.op_Implicit<'T,'U> Method (F#)
description: FSharpFunc.op_Implicit<'T,'U> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 14f7726e-555c-40b7-8042-c6d438a43936 
---

# FSharpFunc.op_Implicit<'T,'U> Method (F#)

Convert an value of type `System.Converter` to a F# first class function value or vice versa.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
static member op_Implicit : Converter<'T,'U> -> 'T -> 'U
static member op_Implicit : ('T -> 'U) -> Converter<'T,'U>

// Usage:
FSharpFunc.op_Implicit (converter)
FSharpFunc.op_Implicit (func)
```

#### Parameters
*converter*
Type: **System.Converter&#96;2****&lt;'T,'U&gt;**


The input **System.Converter&#96;2** instance.


*func*
Type: **'T -&gt; 'U**


An input function to be converted to a **System.Converter&#96;2** instance..

## Return Value

The result of the conversion.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0


## See Also
[Core.FSharpFunc&#60;'T,'U&#62; Class &#40;F&#35;&#41;](Core.FSharpFunc%5B%27T%2C%27U%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)