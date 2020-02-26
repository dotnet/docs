---
title: Core.EntryPointAttribute Class (F#)
description: Core.EntryPointAttribute Class (F#)
ms.date: 02/26/2020
---

# Core.EntryPointAttribute Class (F#)

Adding this attribute to a function indicates it is the entry point for an application. If this absent is not specified for an EXE then the initialization implicit in the module bindings in the last file in the compilation sequence are used as the entry point.

**Namespace/Module Path:** Microsoft.FSharp.Core

## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.Method, AllowMultiple = false)>]
[<Sealed>]
type EntryPointAttribute =
class
new EntryPointAttribute : unit -> EntryPointAttribute
end
```

## Remarks
You can also use the short form of the name, `EntryPoint`.

## Constructors

|Member|Description|
|------|-----------|
|[new](core.entrypointattribute-constructor-[fsharp].md)|Creates an instance of the attribute.|

## See Also
[Microsoft.FSharp.Core Namespace](microsoft.fsharp.core-namespace-[fsharp].md)

[Entry Point F#](../../language-reference/functions/entry-point.md)
