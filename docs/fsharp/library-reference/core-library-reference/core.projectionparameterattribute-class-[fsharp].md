---
title: Core.ProjectionParameterAttribute Class (F#)
description: Core.ProjectionParameterAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: bf85098c-e3b2-4329-9696-0964063e3740 
---

# Core.ProjectionParameterAttribute Class (F#)

Indicates that, when a custom operator is used in a computation expression, a parameter is automatically parameterized by the variable space of the computation expression.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)>]
[<Sealed>type ProjectionParameterAttribute =  class
     new ProjectionParameterAttribute : unit -> ProjectionParameterAttribute 
end
```

## Remarks
You can also use the short form of the name, `ProjectionParameter`.


## Constructors


|Member|Description|
|--|---|
|[new](https://msdn.microsoft.com/library/633c5709-495a-4467-82fe-c2e4bd7c1aa4)|Creates an instance of the attribute.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)