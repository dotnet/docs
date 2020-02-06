---
title: Core.ClassAttribute Class (F#)
description: Core.ClassAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3e65f435-ad69-4461-9294-d305b1a6d158 
---

# Core.ClassAttribute Class (F#)

Adding this attribute to a type causes it to be represented using a Common Language Infrastructure (CLI) class.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class, AllowMultiple = false)>]
[<Sealed>]
type ClassAttribute =
class
new ClassAttribute : unit -> ClassAttribute
end
```

## Remarks
You can also use the short form of the name, `Class`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/326d2514-999e-4fe1-b03b-c7b62f8299a9)|Creates an instance of the attribute.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)