---
title: Array.distinct<'T> Function (F#)
description: Array.distinct<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: liboz
manager: danielfe
ms.date: 7/20/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 46f7d775-a72b-4de7-902c-9eb4b8b44b1b
---

# Array.distinct<'T> Function (F#)

Returns an array that contains no duplicate entries according to generic hash and equality comparisons on the entries. If an element occurs multiple times in the array then the later occurrences are discarded.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.distinct : 'T [] -> 'T [] (requires equality)

// Usage:
Array.distinct source
```

#### Parameters
*source*
Type: **'T [[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)**

The input array.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input array is null|

## Return Value
The result array.

## Remarks
This function is named `Distinct` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following example demonstrates the use of Array.distinct. The example generates the binary representation of a number as a array. It then determines that the only unique numbers are 0 and 1.

[!code-fsharp[Main](snippets/fsarrays/snippet74.fs)]

**Output**
```
[|1; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|]
[|1; 0|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
