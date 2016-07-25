---
title: Core.AutoOpenAttribute Class (F#)
description: Core.AutoOpenAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d48500f4-6fdf-4224-8a78-1a26a28ab5ce 
---

# Core.AutoOpenAttribute Class (F#)

This attribute is used for two purposes. When applied to an assembly, it must be given a string argument, and this argument must indicate a valid module or namespace in that assembly. Source code files compiled with a reference to this assembly are processed in an environment where the given path is automatically opened.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Assembly, AllowMultiple = true)>]
[<Sealed>]
type AutoOpenAttribute =
class
new AutoOpenAttribute : string -> AutoOpenAttribute
new AutoOpenAttribute : unit -> AutoOpenAttribute
member this.Path :  string
end
```

## Remarks
When applied to a module within an assembly, then the attribute must not be given any arguments. When the enclosing namespace is opened in user source code, the module is also implicitly opened.

You can also use the short form of the name, `AutoOpen`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/d9c945f1-074f-401d-a9c1-1949e3f8170f)|Creates an attribute used to mark a namespace or module path to be automatically opened when an assembly is referenced|

## Instance Members


|Member|Description|
|------|-----------|
|[Path](https://msdn.microsoft.com/library/477b0567-21ae-4704-8ea5-361ceb360c0f)|Indicates the namespace or module to be automatically opened when an assembly is referenced or an enclosing module opened.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)