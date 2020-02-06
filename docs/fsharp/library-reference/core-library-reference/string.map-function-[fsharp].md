---
title: String.map Function (F#)
description: String.map Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 91077ef6-fb1a-48e5-9755-5c85df98a20a 
---

# String.map Function (F#)

Creates a new string whose characters are the results of applying a specified function to each of the characters of the input string.

**Namespace/Module Path:** Microsoft.FSharp.Core.String

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
String.map : (char -> char) -> string -> string

// Usage:
String.map mapping str
```

#### Parameters
*mapping*
Type: [char](https://msdn.microsoft.com/library/3627f475-985b-4b4e-94d2-14f217c04958)**-&gt;**[char](https://msdn.microsoft.com/library/3627f475-985b-4b4e-94d2-14f217c04958)


The function to apply to the characters of the string.


*str*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The input string.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input string is null.|

## Return Value

The resulting string.

## Remarks

This function is named `Map` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fsstrings/snippet7.fs)]

**Output**

```
The quick sly fox jumped over the lazy brown dog.
Gur dhvpx fyl sbk whzcrq bire gur ynml oebja qbt.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library VersionsF# Core Library Versions**

Supported in: 2.0, 4.0, Portable2.0, 4.0, Portable

## See Also
[Core.String Module &#40;F&#35;&#41;](Core.String-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)