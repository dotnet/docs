---
title: Array.head<'T> Function (F#)
description: Array.head<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: erikschierboom
manager: danielfe
ms.date: 03/12/2017
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3c376852-11f0-4286-9210-6d8a719ae626
---

# Array.head<'T> Function (F#)

Returns the first element of the array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.head : 'T[] -> 'T

// Usage:
Array.head array
```

#### Parameters
*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the array is empty.|

## Return Value

The first element of the array.

## Remarks
Raises `System.ArgumentException` if *array* is empty

This function is named `Head` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable


## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)