---
title: InteractiveSession.CommandLineArgs Property
description: InteractiveSession.CommandLineArgs Property
ms.date: 02/26/2020
---

# InteractiveSession.CommandLineArgs Property

The command line arguments after ignoring the arguments relevant to the interactive environment and replacing the first argument with the name of the last script file, if any.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)

## Syntax

```fsharp
// Signatures:
member this.CommandLineArgs :  string []
member this.CommandLineArgs : string [] with set :  string []

// Usage:
interactiveSession.CommandLineArgs
interactiveSession.CommandLineArgs <- commandLineArgs
```

#### Parameters
commandLineArgs
Type: [string](../core-library-reference/core.string-type-abbreviation-[fsharp].md)[[]](../core-library-reference/core.['t]-type-1d-[fsharp].md)

The array of command line arguments.

## Remarks
For example, the command line `fsi.exe test1.fs test2.fs -- hello goodbye`will give arguments `test2.fs`, `hello`, `goodbye`. This value will normally be different to those returned by `System.Environment.GetCommandLineArgs`.

## See Also
[Interactive.InteractiveSession Class](Interactive.InteractiveSession-Class.md)

[Microsoft.FSharp.Compiler.Interactive Namespace](index.md)
