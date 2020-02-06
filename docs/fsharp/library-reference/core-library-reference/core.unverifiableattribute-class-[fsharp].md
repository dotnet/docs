---
title: Core.UnverifiableAttribute Class (F#)
description: Core.UnverifiableAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fd026440-6f2a-4139-a978-1357ae8a2bb0 
---

# Core.UnverifiableAttribute Class (F#)

This attribute is used to tag values whose use will result in the generation of unverifiable code. These values are inevitably marked `inline` to ensure that the unverifiable constructs are not present in the actual code for the F# library, but are rather copied to the source code of the caller.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Method ||| AttributeTargets.Property, AllowMultiple = false)>]
[<Sealed>]
type UnverifiableAttribute =
class
new UnverifiableAttribute : unit -> UnverifiableAttribute
end
```

## Remarks
You can also use the short form of the name, `Unverifiable`.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/f2a9ec1c-74b0-4d7d-a5ed-8ec1c13cccae)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)