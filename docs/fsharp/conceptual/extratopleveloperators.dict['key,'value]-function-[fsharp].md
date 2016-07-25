---
title: ExtraTopLevelOperators.dict<'Key,'Value> Function (F#)
description: ExtraTopLevelOperators.dict<'Key,'Value> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 85d077b7-daa4-4756-939b-1669e01925a8 
---

# ExtraTopLevelOperators.dict<'Key,'Value> Function (F#)

Builds a read-only lookup table from a sequence of key/value pairs. The key objects are indexed using generic hashing and equality.

**Namespace/Module Path**: Microsoft.FSharp.Core.ExtraTopLevelOperators

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
dict : seq<'Key * 'Value> -> IDictionary<'Key,'Value> (requires equality)

// Usage:
dict keyValuePairs
```

#### Parameters
*keyValuePairs*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'Key &#42; 'Value&gt;**

## Return Value

An object that implements `System.Collections.Generic.IDictionary` that represents the given collection.

## Remarks
This function is named `CreateDictionary` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fscorelib2/snippet1.fs)]

**The output is as follows.**

```
The dictionary is read only.
Value for key 5: 25
Key: 1 Value: 1
Key: 2 Value: 4
Key: 3 Value: 9
Key: 4 Value: 16
Key: 5 Value: 25
Key: 6 Value: 36
Key: 7 Value: 49
Key: 8 Value: 64
Key: 9 Value: 81
Key: 10 Value: 100
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.ExtraTopLevelOperators Module &#40;F&#35;&#41;](Core.ExtraTopLevelOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)