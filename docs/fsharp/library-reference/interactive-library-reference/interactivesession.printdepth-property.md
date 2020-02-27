---
title: InteractiveSession.PrintDepth Property
description: InteractiveSession.PrintDepth Property
ms.date: 02/26/2020 
---

# InteractiveSession.PrintDepth Property

Gets or sets the print depth, or number of levels of recursive structures to print when displaying data, in the interactive session.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)

## Syntax

```fsharp
// Signatures:
member this.PrintDepth :  int
member this.PrintDepth : int with set :  int

// Usage:
interactiveSession.PrintDepth
interactiveSession.PrintDepth <- printDepth
```

#### Parameters
*printDepth*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

## Remarks
The default value is 100.

## See Also
[Interactive.InteractiveSession Class](Interactive.InteractiveSession-Class.md)

[Microsoft.FSharp.Compiler.Interactive Namespace](index.md)
