---
title: System.AggregateException Class (F#)
description: System.AggregateException Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 53c8ac9b-7ea3-4f97-a1d7-f977ddb31d69 
---

# System.AggregateException Class (F#)

Represents one or more errors that occur during application execution.

**Namespace/Module Path**: System

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type AggregateException =
class
member this.InnerExceptions :  ReadOnlyCollection<exn>
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.AggregateException`.


## Instance Members

|Member|Description|
|------|-----------|
|[InnerExceptions](https://msdn.microsoft.com/library/2a59eae4-bb9e-40d1-88de-01bcb665248c)|Gets a read-only collection of the **Exception** instances that caused the current exception.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System Namespace &#40;F&#35;&#41;](System-Namespace-%5BFSharp%5D.md)