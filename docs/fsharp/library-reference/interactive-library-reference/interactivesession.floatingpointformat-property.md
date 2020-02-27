---
title: InteractiveSession.FloatingPointFormat Property
description: InteractiveSession.FloatingPointFormat Property
ms.date: 02/26/2020
---

# InteractiveSession.FloatingPointFormat Property

Gets or sets the floating point format used in the output of the interactive session.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)

## Syntax

```fsharp
// Signatures:
member this.FloatingPointFormat :  string
member this.FloatingPointFormat : string with set :  string

// Usage:
interactiveSession.FloatingPointFormat
interactiveSession.FloatingPointFormat <- floatingPointFormat
```

#### Parameters
*floatingPointFormat*
Type: [string](../core-library-reference/core.string-type-abbreviation-[fsharp].md)

A format code to use for floating point output in the F# Interactive Session.

## Remarks
The possible format codes are described in [Core.Printf Module](../core-library-reference/core.printf-module-[fsharp].md). The default value is `g10`.

## See Also
[Interactive.InteractiveSession Class](Interactive.InteractiveSession-Class.md)

[Microsoft.FSharp.Compiler.Interactive Namespace](index.md)
