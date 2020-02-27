---
title: InteractiveSession.FormatProvider Property
description: InteractiveSession.FormatProvider Property
ms.date: 02/26/2020
---

# InteractiveSession.FormatProvider Property

Gets or sets the format provider used in the output of the interactive session.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)

## Syntax

```fsharp
// Signatures:
member this.FormatProvider :  IFormatProvider
member this.FormatProvider : IFormatProvider with set :  IFormatProvider

// Usage:
interactiveSession.FormatProvider
interactiveSession.FormatProvider <- formatProvider
```

#### Parameters
*formatProvider*
Type: **System.IFormatProvider**

A format provider to use in the F# Interactive session.

## See Also
[Interactive.InteractiveSession Class](Interactive.InteractiveSession-Class.md)

[Microsoft.FSharp.Compiler.Interactive Namespace](index.md)
