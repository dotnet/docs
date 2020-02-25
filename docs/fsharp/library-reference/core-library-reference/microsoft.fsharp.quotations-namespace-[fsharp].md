---
title: Microsoft.FSharp.Quotations Namespace (F#)
description: Microsoft.FSharp.Quotations Namespace (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 7f4f263a-0f39-4bcd-a724-d322cf0552ba
---

# Microsoft.FSharp.Quotations Namespace (F#)

This namespace contains functionality for working with code programmatically.

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
namespace Microsoft.FSharp.Quotations
```

## Remarks
For more information and examples, see [Code Quotations &#40;F&#35;&#41;](Code-Quotations-%5BFSharp%5D.md).


## Modules

|Module|Description|
|------|-----------|
|module [DerivedPatterns](https://msdn.microsoft.com/library/d2434a6e-ae7b-4f3d-b567-c162938bc9cd)|Contains a set of derived F# active patterns to analyze F# expression objects|
|module [ExprShape](https://msdn.microsoft.com/library/7685150e-2432-4d39-9338-57292eff18de)|Active patterns for traversing, visiting, rebuilding and transforming expressions in a generic way|
|module [Patterns](https://msdn.microsoft.com/library/093944a9-c752-403a-8983-5fcd5dbf92a4)|Contains a set of primitive F# active patterns to analyze F# expression objects|

## Type Definitions

|Type|Description|
|----|-----------|
|type [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)|Quoted expressions annotated with **System.Type** values.|
|type [Expr&lt;'T&gt;](https://msdn.microsoft.com/library/975ca4d3-ac2b-46db-9f01-23cf8b190c6e)|Type-carrying quoted expressions. Expressions are generated either by quotations in source text or programmatically|
|type [Var](https://msdn.microsoft.com/library/2b1237f9-d897-4bcf-872a-4a297db3f7b5)|Information at the binding site of a variable|

## See Also
[F&#35; Core Library Reference](FSharp-Core-Library-Reference.md)
