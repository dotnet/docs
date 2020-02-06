---
title: Quotations.Expr<'T> Class (F#)
description: Quotations.Expr<'T> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a224007c-0b48-4f94-9b98-4355e2bac574
---

# Quotations.Expr<'T> Class (F#)

Type-carrying quoted expressions. Expressions are generated either by quotations in source text or programmatically

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type Expr<'T> =
class
member this.Raw :  Expr
end
```

## Remarks
This type is named `FSharpExpr` in the assembly. If you are accessing the type from a language other than F#, or through reflection, use this name.


## Instance Members


|Member|Description|
|------|-----------|
|[Raw](https://msdn.microsoft.com/library/47fb94f1-e77f-4c68-aabc-2b0ba40d59c2)|Gets the raw expression associated with this type-carrying expression|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
