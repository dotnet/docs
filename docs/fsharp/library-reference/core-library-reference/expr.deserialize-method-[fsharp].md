---
title: Expr.Deserialize Method (F#)
description: Expr.Deserialize Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 452ff18f-fff5-4a8c-937f-d2fd48b62da5 
---

# Expr.Deserialize Method (F#)

This function is called automatically when quotation syntax (`<@ @>`) and related typed-expression quotations are used. The bytes are a pickled binary representation of an unlinked form of the quoted expression, and the `System.Type` argument is any type in the assembly where the quoted expression occurs, i.e. it helps scope the interpretation of the cross-assembly references in the bytes.

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member Deserialize : Type * Type list * Expr list * byte [] -> Expr

// Usage:
Expr.Deserialize (qualifyingType, spliceTypes, spliceExprs, bytes)
```

#### Parameters
*qualifyingType*
Type: **System.Type**


A type in the assembly where the quotation occurs.


*spliceTypes*
Type: **System.Type**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The list of spliced types.


*spliceExprs*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The list of spliced expressions.


*bytes*
Type: [byte](https://msdn.microsoft.com/library/17a98430-283a-4ff6-a475-e6999577179d)[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The serialized form of the quoted expression.

## Return Value

The resulting expression.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Expr Class &#40;F&#35;&#41;](Quotations.Expr-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)