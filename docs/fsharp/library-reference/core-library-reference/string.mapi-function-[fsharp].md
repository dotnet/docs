---
title: String.mapi Function (F#)
description: String.mapi Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ff014a44-e6a4-4aac-95ef-21e12e1bc58c 
---

# String.mapi Function (F#)

Creates a new string whose characters are the results of applying a specified function to each character and index of the input string.

**Namespace/Module Path:** Microsoft.FSharp.Core.String

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
String.mapi : (int -> char -> char) -> string -> string

// Usage:
String.mapi mapping str
```

#### Parameters
*mapping*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt;**[char](https://msdn.microsoft.com/library/3627f475-985b-4b4e-94d2-14f217c04958)**-&gt;**[char](https://msdn.microsoft.com/library/3627f475-985b-4b4e-94d2-14f217c04958)


The function to apply to each character and index of the string.


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
This function is named `MapIndexed` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code shows how to use `String.mapi`.

```fsharp
let replaceNth n newChar inputString =
    let result = String.mapi (fun i c -> if i = n then newChar else c) inputString
    printfn "%s" result
    result
printfn "MASK"
"MASK" |> replaceNth 0 'B'
|> replaceNth 3 'H'
|> replaceNth 2 'T'
|> replaceNth 1 'O'
|> replaceNth 0 'M'
|> replaceNth 1 'A'
|> replaceNth 2 'S'
|> replaceNth 3 'K'
```

**Output**

```
MASK
BASK
BASH
BATH
BOTH
MOTH
MATH
MASH
MASK
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library VersionsF# Core Library Versions**

Supported in: 2.0, 4.0, Portable2.0, 4.0, Portable

## See Also
[Core.String Module &#40;F&#35;&#41;](Core.String-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)