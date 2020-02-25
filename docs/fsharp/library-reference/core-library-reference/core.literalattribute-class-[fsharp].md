---
title: Core.LiteralAttribute Class (F#)
description: Core.LiteralAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3239d188-f1b7-46b1-b5b8-a4bfa742004c 
---

# Core.LiteralAttribute Class (F#)

Adding this attribute to a value causes it to be compiled as a .NET Framework constant literal.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Field, AllowMultiple = false)>]
[<Sealed>]
type LiteralAttribute =
class
new LiteralAttribute : unit -> LiteralAttribute
end
```

## Remarks
You can also use the short form of the name, `Literal`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/5d2f5a66-196a-4a6f-9003-4257a1316f2a)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)