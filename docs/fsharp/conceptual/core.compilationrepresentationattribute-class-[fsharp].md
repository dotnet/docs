---
title: Core.CompilationRepresentationAttribute Class (F#)
description: Core.CompilationRepresentationAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 44612a50-42b0-46c2-9533-9760c4196a19 
---

# Core.CompilationRepresentationAttribute Class (F#)

This attribute is used to adjust the runtime representation for a type. For example, it may be used to note that the `null` representation may be used for a type. This affects how some constructs are compiled.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.All, AllowMultiple = false)>]
[<Sealed>]
type CompilationRepresentationAttribute =
class
new CompilationRepresentationAttribute : CompilationRepresentationFlags -> CompilationRepresentationAttribute
member this.Flags :  CompilationRepresentationFlags
end
```

## Remarks
You can also use the short form of the name, `CompilationRepresentation`.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/d7a5352e-f198-40c3-a999-4d4782fa2ee8)|Creates an instance of the attribute|

## Instance Members

|Member|Description|
|------|-----------|
|[Flags](https://msdn.microsoft.com/library/9ac4bd35-a1d8-4053-b9c6-6a4b16c30729)|Indicates one or more adjustments to the compiled representation of an F# type or member|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)