---
title: String.concat Function (F#)
description: String.concat Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: afbf970c-db97-4af3-84df-7244eb0e7bae 
---

# String.concat Function (F#)

Returns a new string made by concatenating the given strings with a separator.

**Namespace/Module Path:** Microsoft.FSharp.Core.String

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
String.concat : string -> seq<string> -> string

// Usage:
String.concat sep strings
```

#### Parameters
*sep*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The separator string to be inserted between the strings of the input sequence.


*strings*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;**[string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)**&gt;**


The sequence of strings to be concatenated.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input string is null.|

## Return Value

A new string consisting of the concatenated strings separated by the separation string.

## Remarks
This function is named `Concat` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fsstrings/snippet2.fs)]

**Output**

```
tomatoes, bananas, apples
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.String Module &#40;F&#35;&#41;](Core.String-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)