---
title: String.iteri Function (F#)
description: String.iteri Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 0f2e5e0c-86da-4c71-ad5e-7151c351d2d1 
---

# String.iteri Function (F#)

Applies a specified function to each character and corresponding index in the string.

**Namespace/Module Path:** Microsoft.FSharp.Core.String

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
String.iteri : (int -> char -> unit) -> string -> unit

// Usage:
String.iteri action str
```

#### Parameters
*action*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt;**[char](https://msdn.microsoft.com/library/3627f475-985b-4b4e-94d2-14f217c04958)**-&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)


The function to apply to each character and index of the string.


*str*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The input string.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input string is null.|


## Remarks
This function is named `IterateIndexed` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fsstrings/snippet9.fs)]

**Output**

```
0 T
1 I
2 M
3 E
0 S
1 P
2 A
3 C
4 E
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.String Module &#40;F&#35;&#41;](Core.String-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)