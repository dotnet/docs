---
title: CompilerServices.GeneratedSequenceBase<'T> Class (F#)
description: CompilerServices.GeneratedSequenceBase<'T> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4758bce7-b81f-4db9-aef2-64013e7b2938 
---

# CompilerServices.GeneratedSequenceBase<'T> Class (F#)

The F# compiler emits implementations of this type for compiled sequence expressions.

**Namespace/Module Path:** Microsoft.FSharp.Core.CompilerServices

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AbstractClass>]
type GeneratedSequenceBase<'T> =
class
interface IEnumerator
interface IEnumerator
interface IEnumerable
interface IEnumerable
new GeneratedSequenceBase : unit -> GeneratedSequenceBase<'T>
abstract this.Close : unit -> unit
abstract this.GenerateNext : byref<IEnumerable<'T>> -> int
abstract this.GetFreshEnumerator : unit -> IEnumerator<'T>
abstract this.CheckClose :  bool
abstract this.LastGenerated :  'T
end
```

## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/c4c0088e-9cc3-48c1-b56a-daea63852da5)|The F# compiler emits implementations of this type for compiled sequence expressions.|

## Instance Members

|Member|Description|
|------|-----------|
|[CheckClose](https://msdn.microsoft.com/library/7080b2ce-73f0-4457-b255-d02c8915ac05)|The F# compiler emits implementations of this type for compiled sequence expressions.|
|[Close](https://msdn.microsoft.com/library/17171809-449d-4311-97a2-50f77ebd2518)|The F# compiler emits implementations of this type for compiled sequence expressions.|
|[GenerateNext](https://msdn.microsoft.com/library/9c6e1da1-a6ad-4fc3-887f-e6ea063d9864)|The F# compiler emits implementations of this type for compiled sequence expressions.|
|[GetFreshEnumerator](https://msdn.microsoft.com/library/5ba71cbc-66e3-4062-b687-2b93ada2cb98)|The F# compiler emits implementations of this type for compiled sequence expressions.|
|[LastGenerated](https://msdn.microsoft.com/library/a5f67d10-60ef-4ce7-ac2e-2fb01964d621)|The F# compiler emits implementations of this type for compiled sequence expressions.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)