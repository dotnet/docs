---
title: Core.FSharpFunc<'T,'U> Class (F#)
description: Core.FSharpFunc<'T,'U> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5ba3fc4b-9f6e-4547-8424-fb17e0575abc 
---

# Core.FSharpFunc<'T,'U> Class (F#)

The .NET Framework type used to represent F# function values. This type is not typically used directly, though may be used from other .NET Framework languages.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AbstractClass>]
type FSharpFunc<'T,'U> =
class
new FSharpFunc : unit -> FSharpFunc<'T,'U>
static member FromConverter : Converter<'T,'U> -> 'T -> 'U
abstract this.Invoke : 'T -> 'U
static member InvokeFast : FSharpFunc<'T,('U -> 'V)> * 'T * 'U -> 'V
static member InvokeFast : FSharpFunc<'T,('U -> 'V -> 'W)> * 'T * 'U * 'V -> 'W
static member InvokeFast : FSharpFunc<'T,('U -> 'V -> 'W -> 'X)> * 'T * 'U * 'V * 'W -> 'X
static member InvokeFast : FSharpFunc<'T,('U -> 'V -> 'W -> 'X -> 'Y)> * 'T * 'U * 'V * 'W * 'X -> 'Y
static member ToConverter : ('T -> 'U) -> Converter<'T,'U>
static member op_Implicit : Converter<'T,'U> -> 'T -> 'U
static member op_Implicit : ('T -> 'U) -> Converter<'T,'U>
end
```

## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/749963c3-ee72-4f1c-a544-6cabaa26cc2d)|Construct an instance of an F# first class function value|

## Instance Members


|Member|Description|
|------|-----------|
|[Invoke](https://msdn.microsoft.com/library/8ae1ed15-b7c0-4817-82e7-c55efdf59dd7)|Invoke an F# first class function value with one argument|

## Static Members


|Member|Description|
|------|-----------|
|[FromConverter](https://msdn.microsoft.com/library/3ad2b6db-7471-400d-93aa-59238dea2f18)|Convert an value of type **System.Converter&#96;2** to a F# first class function value|
|[InvokeFast](https://msdn.microsoft.com/library/551dec69-8dab-48e4-b33d-861b3a9c37e4)|Invoke an F# first class function value with two curried arguments. In some cases this will result in a more efficient application than applying the arguments successively.|
|[InvokeFast](https://msdn.microsoft.com/library/e80d7e55-7a2f-4a21-88af-098e22b5d5d7)|Invoke an F# first class function value with three curried arguments. In some cases this will result in a more efficient application than applying the arguments successively.|
|[InvokeFast](https://msdn.microsoft.com/library/bbaf542c-8d63-440f-b552-5520f09749d8)|Invoke an F# first class function value with four curried arguments. In some cases this will result in a more efficient application than applying the arguments successively.|
|[InvokeFast](https://msdn.microsoft.com/library/e5be5153-743b-48e3-9a14-10b053c0576c)|Invoke an F# first class function value with five curried arguments. In some cases this will result in a more efficient application than applying the arguments successively.|
|[op_Implicit](https://msdn.microsoft.com/library/c2051648-4743-4c60-a4d8-056336abf9ba)|Convert an value of type **System.Converter&#96;2** to a F# first class function value|
|[ToConverter](https://msdn.microsoft.com/library/52fb0fb5-8581-4e48-9425-b7819a547d86)|Convert an F# first class function value to a value of type **System.Converter&#96;2**.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)