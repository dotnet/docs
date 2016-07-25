---
title: Stream.AsyncRead Extension Method (F#)
description: Stream.AsyncRead Extension Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 773bd38a-22c0-492b-a1d0-b27112003160 
---

# Stream.AsyncRead Extension Method (F#)

Returns an asynchronous computation that will read from the stream into the given buffer.

**Namespace/Module Path:** Microsoft.FSharp.Control.CommonExtensions

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
type System.IO.Stream with
member AsyncRead : byte [] * ?int * ?int -> Async<int>
type System.IO.Stream with
member AsyncRead : int -> Async<byte []>

// Usage:
stream.AsyncRead (buffer)
stream.AsyncRead (count)
```

#### Parameters
*buffer*
Type: [byte](https://msdn.microsoft.com/library/17a98430-283a-4ff6-a475-e6999577179d)[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The buffer to read into.


*offset*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


An optional offset as a number of bytes in the stream.


*count*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


An optional number of bytes to read from the stream.


## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the sum of *offset* and *count* is longer than the buffer length.|
|[ArgumentOutOfRangeException](https://msdn.microsoft.com/library/system.argumentoutofrangeexception.aspx)|Thrown when *offset* or *count* is negative.|

## Remarks
This member is named `AsyncRead` in compiled assemblies. If you are accessing the method from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0




## See Also
[Control.CommonExtensions Module &#40;F&#35;&#41;](Control.CommonExtensions-Module-%5BFSharp%5D.md)

