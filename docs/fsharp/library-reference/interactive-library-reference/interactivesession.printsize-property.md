---
title: InteractiveSession.PrintSize Property
description: InteractiveSession.PrintSize Property
ms.date: 02/26/2020
---

# InteractiveSession.PrintSize Property

Gets or sets the total print size, the maximum number of characters to print when displaying data, in the interactive session.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)

## Syntax

```fsharp
// Signatures:
member this.PrintSize :  int
member this.PrintSize : int with set :  int

// Usage:
interactiveSession.PrintSize
interactiveSession.PrintSize <- printSize
```

#### Parameters
*printSize*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The print size to set.

## Remarks
The default value is 10000.

## See Also
[Interactive.InteractiveSession Class](Interactive.InteractiveSession-Class.md)

[Microsoft.FSharp.Compiler.Interactive Namespace](index.md)
