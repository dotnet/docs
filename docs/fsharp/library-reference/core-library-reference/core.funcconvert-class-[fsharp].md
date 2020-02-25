---
title: Core.FuncConvert Class (F#)
description: Core.FuncConvert Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 66a1c50f-04be-4e73-b892-471fcbb354df 
---

# Core.FuncConvert Class (F#)

Helper functions for converting F# first class function values to and from .NET Framework representations of functions using delegates.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AbstractClass>]
[<Sealed>]
type FuncConvert =
class
static member FuncFromTupled : ('T1 * 'T2 * 'T3 * 'T4 * 'T5 -> 'U) -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'T5 -> 'U
static member FuncFromTupled : ('T1 * 'T2 * 'T3 * 'T4 -> 'U) -> 'T1 -> 'T2 -> 'T3 -> 'T4 -> 'U
static member FuncFromTupled : ('T1 * 'T2 * 'T3 -> 'U) -> 'T1 -> 'T2 -> 'T3 -> 'U
static member FuncFromTupled : ('T1 * 'T2 -> 'U) -> 'T1 -> 'T2 -> 'U
static member ToFSharpFunc : Converter<'T,'U> -> 'T -> 'U
static member ToFSharpFunc : Action<'T> -> 'T -> unit
end
```

## Static Members

|Member|Description|
|------|-----------|
|[FuncFromTupled](https://msdn.microsoft.com/library/98f6866f-d4dc-44b9-94ea-23972a55f94e)|A utility function to convert function values from tupled to curried form.|
|[FuncFromTupled](https://msdn.microsoft.com/library/0b0bd5cb-0312-4694-937c-495347eae1d1)|A utility function to convert function values from tupled to curried form.|
|[FuncFromTupled](https://msdn.microsoft.com/library/aca946f4-6490-4799-9cf8-eb1b87265687)|A utility function to convert function values from tupled to curried form.|
|[FuncFromTupled](https://msdn.microsoft.com/library/b70499a2-1728-41e6-8682-cb7aa030e75e)|A utility function to convert function values from tupled to curried form.|
|[ToFSharpFunc](https://msdn.microsoft.com/library/1352ba11-7edc-4038-8173-de73133ad490)|Convert the given **System.Converter&#96;2** delegate object to an F# function value.|
|[ToFSharpFunc](https://msdn.microsoft.com/library/ca2f654a-14bd-4348-a73d-2c0e0645abf6)|Convert the given **System.Action&#96;1** delegate object to an F# function value.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)