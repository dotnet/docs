---
title: Core.DefaultValueAttribute Class (F#)
description: Core.DefaultValueAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5033241c-8f88-4eb9-b9f8-9ddaf916cc58 
---

# Core.DefaultValueAttribute Class (F#)

Adding this attribute to a field declaration means that the field is not initialized. During type checking a constraint is asserted that the field type supports `null`. If the [`Check`](https://msdn.microsoft.com/library/3a317377-d5ac-45d8-85f7-5262a2f7029f) value is `false` then the constraint is not asserted.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Field, AllowMultiple = false)>]
[<Sealed>]
type DefaultValueAttribute =
class
new DefaultValueAttribute : bool -> DefaultValueAttribute
new DefaultValueAttribute : unit -> DefaultValueAttribute
member this.Check :  bool
end
```

## Remarks
This attribute is intended to be used on explicit fields in classes and structures. It shouldn't be used on records. For more information, see [Records &#40;F&#35;&#41;](Records-%5BFSharp%5D.md) and [Explicit Fields: The val Keyword &#40;F&#35;&#41;](Explicit-Fields-The-val-Keyword-%5BFSharp%5D.md).

The .NET Framework namespace `System.ComponentModel` defines an attribute that has the same name:  `System.ComponentModel.DefaultValueAttribute`. Therefore, you must fully qualify the F# attribute if you open the `System.ComponentModel` namespace.

You can also use the short form of the name, `DefaultValue`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/14c22e07-b5a8-40fe-9363-30d397b09c44)|Creates an instance of the attribute|

## Instance Members


|Member|Description|
|------|-----------|
|[Check](https://msdn.microsoft.com/library/3a317377-d5ac-45d8-85f7-5262a2f7029f)|Indicates if a constraint is asserted that the field type supports 'null'|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)