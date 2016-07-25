---
title: Core.PrintfFormat<'Printer,'State,'Residue,'Result> Class (F#)
description: Core.PrintfFormat<'Printer,'State,'Residue,'Result> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ee4f6170-87c3-43fe-9938-a383d382023d 
---

# Core.PrintfFormat<'Printer,'State,'Residue,'Result> Class (F#)

Type of a formatting expression.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type PrintfFormat<'Printer,'State,'Residue,'Result> =
class
new PrintfFormat : string -> PrintfFormat<'Printer,'State,'Residue,'Result>
member this.Value :  string
end
```

## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/50bab7ac-6c04-4aa0-b9f5-20237360a6be)|Construct a format string|

## Instance Members


|Member|Description|
|------|-----------|
|[Value](https://msdn.microsoft.com/library/b86720ee-e24f-4050-a48a-14dab8fba7c9)|The raw text of the format string.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)