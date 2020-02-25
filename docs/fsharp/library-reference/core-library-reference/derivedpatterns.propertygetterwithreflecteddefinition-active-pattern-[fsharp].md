---
title: DerivedPatterns.PropertyGetterWithReflectedDefinition Active Pattern (F#)
description: DerivedPatterns.PropertyGetterWithReflectedDefinition Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9450d836-11d1-47a8-a5ea-a0fe19eadfee 
---

# DerivedPatterns.PropertyGetterWithReflectedDefinition Active Pattern (F#)

Recognizes property get accessors or values in modules that have an associated `ReflectedDefinition`.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.DerivedPatterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |PropertyGetterWithReflectedDefinition|_| ) : (propertyInfo:PropertyInfo) -> Expr option
```

#### Parameters
*propertyInfo*
Type: **System.Reflection.PropertyInfo**


The description of the property.

## Return Value

The expression of the method definition if it is found; otherwise, `None`.

## Remarks
This function is named `PropertyGetterWithReflectedDefinitionPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.DerivedPatterns Module &#40;F&#35;&#41;](Quotations.DerivedPatterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)