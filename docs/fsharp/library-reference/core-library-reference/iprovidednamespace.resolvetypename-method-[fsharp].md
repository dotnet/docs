---
title: IProvidedNamespace.ResolveTypeName Method (F#)
description: IProvidedNamespace.ResolveTypeName Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 72af4bb7-375f-436c-a40f-c75e3b3c8eba 
---

# IProvidedNamespace.ResolveTypeName Method (F#)

Compilers call this method to query a type provider for a type name.

**Namespace/Module Path**: Microsoft.FSharp.Core.CompilerServices

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.ResolveTypeName : string -> Type

// Usage:
iProvidedNamespace.ResolveTypeName (typeName)
```

#### Parameters
*typeName*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)

## Remarks
Resolver should return a type called `name` in namespace `NamespaceName` or `null` if the type is unknown.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[CompilerServices.IProvidedNamespace Interface &#40;F&#35;&#41;](CompilerServices.IProvidedNamespace-Interface-%5BFSharp%5D.md)