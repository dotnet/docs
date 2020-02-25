---
title: ITypeProvider.GetInvokerExpression Method (F#)
description: ITypeProvider.GetInvokerExpression Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: eaa9b5c3-fcb8-4a73-8bb7-2caaa88c32c3 
---

# ITypeProvider.GetInvokerExpression Method (F#)

Called by the compiler to ask for an `Expression` tree to replace the given MethodBase with.

**Namespace/Module Path**: Microsoft.FSharp.Core.CompilerServices

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.GetInvokerExpression : MethodBase * Quotations.Expr [] -> Quotations.Expr

// Usage:
iTypeProvider.GetInvokerExpression (syntheticMethodBase, parameters)
```

#### Parameters
*syntheticMethodBase*
Type: **System.Reflection.MethodBase**


MethodBase that was given to the compiler by a type returned by a GetType(s) call.


*parameters*
Type: [Quotations.Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65) []


Expressions that represent the parameters to this call.

## Return Value
An `Expression` tree that the compiler will use in place of the given method base.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0Supported in: 4.0, Portable

## See Also
[CompilerServices.ITypeProvider Interface &#40;F&#35;&#41;](CompilerServices.ITypeProvider-Interface-%5BFSharp%5D.md)

[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)