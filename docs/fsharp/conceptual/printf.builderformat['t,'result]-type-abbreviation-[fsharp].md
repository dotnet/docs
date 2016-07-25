---
title: Printf.BuilderFormat<'T,'Result> Type Abbreviation (F#)
description: Printf.BuilderFormat<'T,'Result> Type Abbreviation (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 25b966f0-24ba-4fa9-98a1-cc3e56e396b7
---

# Printf.BuilderFormat<'T,'Result> Type Abbreviation (F#)

Represents a statically-analyzed format associated with writing to a `System.Text.StringBuilder`. The first type parameter indicates the arguments of the format operation and the last the overall return type. This type is a type abbreviation for [Format&lt;'T,StringBuilder,unit,'Result&gt;](https://msdn.microsoft.com/library/470f484f-a026-40af-8f8c-1e3aaf013bdc).

**Namespace/Module Path:** Microsoft.FSharp.Core.Printf

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type BuilderFormat<'T,'Result> = Format<'T,StringBuilder,unit,'Result>
```

## Platforms
Windows 8, Windows7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Printf Module &#40;F&#35;&#41;](Core.Printf-Module-%5BFSharp%5D.md)

[Core.Format&#60;'Printer,'State,'Residue,'Result&#62; Type Abbreviation &#40;F&#35;&#41;](Core.Format%5B%27Printer%2C%27State%2C%27Residue%2C%27Result%5D-Type-Abbreviation-%5BFSharp%5D.md)
