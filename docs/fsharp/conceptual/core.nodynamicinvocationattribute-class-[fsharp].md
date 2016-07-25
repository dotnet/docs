---
title: Core.NoDynamicInvocationAttribute Class (F#)
description: Core.NoDynamicInvocationAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2a786610-e174-4016-9d94-ebda378bde7a 
---

# Core.NoDynamicInvocationAttribute Class (F#)

This attribute is used to tag values that may not be dynamically invoked at runtime. This is typically added to inline functions whose implementations include unverifiable code. It causes the method body emitted for the inline function to raise an exception if dynamically invoked, rather than including the unverifiable code in the generated assembly.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Method ||| AttributeTargets.Property, AllowMultiple = false)>]
[<Sealed>]
type NoDynamicInvocationAttribute =
class
new NoDynamicInvocationAttribute : unit -> NoDynamicInvocationAttribute
end
```

## Remarks
You can also use the short form of the name, `NoDynamicInvocation`.

## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/9ac6fef9-028d-47f7-aef6-86ee3a13298d)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)