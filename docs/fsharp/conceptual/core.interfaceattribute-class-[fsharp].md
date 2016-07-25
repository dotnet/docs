---
title: Core.InterfaceAttribute Class (F#)
description: Core.InterfaceAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 12770c37-c850-42c0-bab5-7bbea7c2ac41 
---

# Core.InterfaceAttribute Class (F#)

Adding this attribute to a type causes it to be represented using a .NET Framework interface.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)>]
[<Sealed>]
type InterfaceAttribute =
class
new InterfaceAttribute : unit -> InterfaceAttribute
end
```

## Remarks
You can also use the short form of the name, `Interface`.

## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/588f6489-bac9-469b-a595-b3741e5bae27)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)