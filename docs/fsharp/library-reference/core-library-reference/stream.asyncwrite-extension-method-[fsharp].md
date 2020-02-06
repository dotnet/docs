---
title: Stream.AsyncWrite Extension Method (F#)
description: Stream.AsyncWrite Extension Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2b29e5ac-e061-4593-894b-09692d34d4a3 
---

# Stream.AsyncWrite Extension Method (F#)

Returns an asynchronous computation that will write the given bytes to the stream.

**Namespace/Module Path:** Microsoft.FSharp.Control.CommonExtensions

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
type System.IO.Stream with
member AsyncWrite : byte [] * ?int * ?int -> Async<unit>

// Usage:
stream.AsyncWrite (buffer)
```

#### Parameters
*buffer*
Type: [byte](https://msdn.microsoft.com/library/17a98430-283a-4ff6-a475-e6999577179d)[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The buffer to write from.


*offset*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


An optional offset as the number of bytes in the stream.


*count*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


An optional number of bytes to write to the stream.


## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when *offset* or *count* is longer than the buffer length.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0




## See Also
[Control.CommonExtensions Module &#40;F&#35;&#41;](Control.CommonExtensions-Module-%5BFSharp%5D.md)

