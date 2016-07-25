---
title: Core.ReflectedDefinitionAttribute Class (F#)
description: Core.ReflectedDefinitionAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6820e105-e772-4452-946a-67f4fc53fb34 
---

# Core.ReflectedDefinitionAttribute Class (F#)

Add this attribute to the let-binding for the definition of a top-level value to make the quotation expression that implements the value available for use at runtime. Add this attribute to a type or module to make it apply recursively to all the values in the module or all the members of the type.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Method ||| AttributeTargets.Property ||| AttributeTargets.Constructor, AllowMultiple = false)>]
[<Sealed>]
type ReflectedDefinitionAttribute =
class
new ReflectedDefinitionAttribute : unit -> ReflectedDefinitionAttribute
end
```

## Remarks
You can also use the short form of the name, `ReflectedDefinition`.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/36354705-c302-4452-91f0-1d39c3b49114)|Creates an instance of the attribute|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)