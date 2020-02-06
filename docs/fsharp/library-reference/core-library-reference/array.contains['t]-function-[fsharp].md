---
title: Array.contains<'T> Function (F#)
description: Array.contains<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: liboz
manager: danielfe
ms.date: 07/06/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3fe49df1-e2c5-4a11-8210-100b2294e94f
---

# Array.contains<'T> Function (F#)

Evaluates to `true` if the given element is in the input array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.contains : 'T -> 'T [] -> bool

// Usage:
Array.contains element source
```

#### Parameters
*element*
Type: **'T**

The element to find.

*source*
Type: **'T** [[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input array is null.|

## Return Value

Evaluates to `true` if the given element is in the input array. Otherwise, it will return **false**.

## Remarks
This function is named `Contains` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use Array.contains.

[!code-fsharp[Main](snippets/fsarrays/snippet511.fs)]

**Output**

```
true
false
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also

[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
