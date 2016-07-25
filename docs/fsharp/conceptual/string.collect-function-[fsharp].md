---
title: String.collect Function (F#)
description: String.collect Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f964776c-a587-41a2-9cd5-d0cb1f70e75d 
---

# String.collect Function (F#)

Builds a new string whose characters are the results of applying a specified function to each of the characters of the input string and concatenating the resulting strings.

**Namespace/Module Path:** Microsoft.FSharp.Core.String

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
String.collect : (char -> string) -> string -> string

// Usage:
String.collect mapping str
```

#### Parameters
*mapping*
Type: [char](https://msdn.microsoft.com/library/3627f475-985b-4b4e-94d2-14f217c04958)**-&gt;**[string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The function to produce a string from each character of the input string.


*str*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The input string.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input string is null.|

## Return Value

The concatenated string.

## Remarks
This function is named `Collect` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code shows how to use String.collect.

[!code-fsharp[Main](snippets/fsstrings/snippet1.fs)]

**Output**

```
H e l l o   W o r l d !
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.String Module &#40;F&#35;&#41;](Core.String-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)