---
title: InteractiveSession.PrintWidth Property
description: InteractiveSession.PrintWidth Property
ms.date: 02/26/2020
---

# InteractiveSession.PrintWidth Property

Gets or sets the print width, that is, the number of characters to print per line, in an F# interactive session.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)

## Syntax

```fsharp
// Signatures:
member this.PrintWidth :  int
member this.PrintWidth : int with set :  int

// Usage:
interactiveSession.PrintWidth
interactiveSession.PrintWidth <- printWidth
```

#### Parameters
*printWidth*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The print width to set.

## Remarks
The default value is 78.

## See Also
[Interactive.InteractiveSession Class](Interactive.InteractiveSession-Class.md)

[Microsoft.FSharp.Compiler.Interactive Namespace](index.md)
