---
title: InteractiveSession.CommandLineArgs Property (F#)
description: InteractiveSession.CommandLineArgs Property (F#)
ms.date: 02/26/2020
---

# InteractiveSession.CommandLineArgs Property (F#)

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
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)[Core.string Type Abbreviation &#40;F&#35;&#41;](../core-library-reference/core.string-type-abbreviation-[fsharp].md)[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The array of command line arguments.

## Remarks
For example, the command line `fsi.exe test1.fs test2.fs -- hello goodbye`will give arguments `test2.fs`, `hello`, `goodbye`. This value will normally be different to those returned by `System.Environment.GetCommandLineArgs`.


## Platforms
Windows 7, Windows Vista SP2, Windows XP SP3, Windows XP x64 SP2, Windows Server 2008 R2, Windows Server 2008 SP2, Windows Server 2003 SP2


## Version Information
**F# Runtime**

Supported in: 2.0, 4.0

## See Also
[Interactive.InteractiveSession Class &#40;F&#35;&#41;](Interactive.InteractiveSession-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Compiler.Interactive Namespace &#40;F&#35;&#41;](index.md)