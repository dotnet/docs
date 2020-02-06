---
title: Core.RequireQualifiedAccessAttribute Class (F#)
description: Core.RequireQualifiedAccessAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fa9725cd-6491-485d-b428-50dcfc7eab84 
---

# Core.RequireQualifiedAccessAttribute Class (F#)

This attribute is used to indicate that references to the elements of a module, record or union type require explicit qualified access.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class, AllowMultiple = false)>]
[<Sealed>]
type RequireQualifiedAccessAttribute =
class
new RequireQualifiedAccessAttribute : unit -> RequireQualifiedAccessAttribute
end
```

## Remarks
You can also use the short form of the name, `RequireQualifiedAccess` attribute.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/f34a984b-9c25-412c-84d9-3710c5b78d8b)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)