---
title: Operators.hash<'T> Function (F#)
description: Operators.hash<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f2e0b10d-681f-4b06-aa67-dd99828533c5
---

# Operators.hash<'T> Function (F#)

A generic hash function, designed to return equal hash values for items that are equal according to the `=` operator. By default it will use structural hashing for F# union, record and tuple types, hashing the complete contents of the type. The exact behavior of the function can be adjusted on a type-by-type basis by implementing `System.Object.GetHashCode` for each type.

**Namespace/Module Path**: Microsoft.FSharp.Core.Operators

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
hash : 'T -> int (requires equality)

// Usage:
hash obj
```

#### Parameters
*obj*
Type: **'T**


The input object.

## Return Value

The computed hash.

## Remarks
This function is named `Hash` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following examples shows the use of the hash function to generate hashes for a variety of data types.

[!code-fsharp[Main](snippets/fssamples101/snippet1010.fs)]

**Output:**

```
hash(1) : 1
hash(2) : 2
hash("1") : -842352753
hash("2") : -842352754
hash("abb") : 2103075711
hash("aBc") : 539088922
hash(&lt;null&gt;) : 0
hash(Some 1) : -1640531462
hash(Some 0) : -1640531463
hash([1; 2; 3]) : 1956583134
hash([1; 2; 3; 4; 5; 6; 7; 8]) : 922428386
hash([1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11]) : 1771492728
hash([1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14; 15]) : -926589492
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
