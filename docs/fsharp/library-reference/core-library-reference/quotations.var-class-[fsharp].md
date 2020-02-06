---
title: Quotations.Var Class (F#)
description: Quotations.Var Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2a97f550-543a-429d-8a3f-86d06ac9a5e1
---

# Quotations.Var Class (F#)

Represents information at the binding site of a variable.

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<Sealed>]
type Var =
class
interface IComparable
new Var : string * Type * bool option -> Var
static member Global : string * Type -> Var
member this.IsMutable :  bool
member this.Name :  string
member this.Type :  Type
end
```

## Remarks
This type is named `FSharpVar` in compiled assemblies. If you are accessing the type from a language other than F#, or through reflection, use this name.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/15bacd28-8c79-42e2-b630-6ed7e594ef04)|Creates a new variable with the given name, type and mutability|

## Instance Members


|Member|Description|
|------|-----------|
|[IsMutable](https://msdn.microsoft.com/library/cfb14a06-c27d-4fa4-bce2-66d3115e02af)|Indicates if the variable represents a mutable storage location|
|[Name](https://msdn.microsoft.com/library/d015c23a-36ba-4006-843f-137d9f78f4c8)|The declared name of the variable|
|[Type](https://msdn.microsoft.com/library/aa5d5836-fdba-4942-acb8-bf7cbd7a18c3)|The type associated with the variable|

## Static Members


|Member|Description|
|------|-----------|
|[Global](https://msdn.microsoft.com/library/2c46e73b-199e-42b2-aeca-8bd363cee8ef)|Fetches or creates a new variable with the given name and type from a global pool of shared variables indexed by name and type.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
