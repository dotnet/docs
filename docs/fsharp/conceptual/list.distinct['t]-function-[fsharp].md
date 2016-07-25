---
title: List.distinct<'T> Function (F#)
description: List.distinct<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: liboz
manager: danielfe
ms.date: 7/20/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ea0e0598-c63d-4973-8e73-4e3544c6e47d
---

# List.distinct<'T> Function (F#)

Returns a list that contains no duplicate entries according to generic hash and equality comparisons on the entries. If an element occurs multiple times in the list then the later occurrences are discarded.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
List.distinct : 'T list -> 'T list (requires equality)

// Usage:
List.distinct source
```

#### Parameters
*source*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)

The input list.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input list is null|

## Return Value
The result list.

## Remarks
This function is named `Distinct` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following example demonstrates the use of List.distinct. The example generates the binary representation of a number as a list. It then determines that the only unique numbers are 0 and 1.

[!code-fsharp[Main](snippets/fslists/snippet70.fs)]

**Output**
```
[1; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
[1; 0]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
