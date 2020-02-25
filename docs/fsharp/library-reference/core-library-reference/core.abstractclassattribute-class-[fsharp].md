---
title: Core.AbstractClassAttribute Class (F#)
description: Core.AbstractClassAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 414aa660-5329-4b94-aa78-7c4471bdbe1d 
---

# Core.AbstractClassAttribute Class (F#)

Adding this attribute to class definition makes it abstract, which means it need not implement all its methods. Instances of abstract classes may not be constructed directly.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class, AllowMultiple = false)>]
[<Sealed>]
type AbstractClassAttribute =
class
new AbstractClassAttribute : unit -> AbstractClassAttribute
end
```

## Remarks
You can also use the short form of the name, `AbstractClass`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/03ec8ff5-d154-49c4-b798-c062a4bfd892)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)