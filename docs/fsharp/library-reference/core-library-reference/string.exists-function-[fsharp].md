---
title: String.exists Function (F#)
description: String.exists Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 896c8113-fd2b-40aa-b5df-58c588709f81 
---

# String.exists Function (F#)

Tests if any character of the string satisfies the given predicate.

**Namespace/Module Path:** Microsoft.FSharp.Core.String

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
String.exists : (char -> bool) -> string -> bool

// Usage:
String.exists predicate str
```

#### Parameters
*predicate*
Type: [char](https://msdn.microsoft.com/library/3627f475-985b-4b4e-94d2-14f217c04958)**-&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test each character of the string.


*str*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The input string.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input string is null.|

## Return Value

Returns true if any character returns true for the predicate and false otherwise.

## Remarks
This function is named `Exists` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

```fsharp
let containsUppercase string1 =
    if (String.exists (fun c -> System.Char.IsUpper(c)) string1) then
        printfn "The string \"%s\" contains uppercase characters." string1
    else
        printfn "The string \"%s\" does not contain uppercase characters." string1
containsUppercase "Hello World!"
containsUppercase "no"
```

**Output**
```
The string "Hello World!" contains uppercase characters.
The string "no" does not contain uppercase characters.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Core.String Module &#40;F&#35;&#41;](Core.String-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)