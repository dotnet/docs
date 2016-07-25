---
title: Printf.TextWriterFormat<'T,'Result> Type Abbreviation (F#)
description: Printf.TextWriterFormat<'T,'Result> Type Abbreviation (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8fe03ee6-cc17-49cc-bb03-b3456ccefea2
---

# Printf.TextWriterFormat<'T,'Result> Type Abbreviation (F#)

Represents a statically-analyzed format associated with writing to a `System.IO.TextWriter`. The first type parameter indicates the arguments of the format operation and the last the overall return type. This type is a type abbreviation for [Format&lt;'Printer,TextWriter,unit,'Result&gt;](https://msdn.microsoft.com/library/470f484f-a026-40af-8f8c-1e3aaf013bdc).

**Namespace/Module Path:** Microsoft.FSharp.Core.Printf

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type TextWriterFormat<'T,'Result> = Format<'Printer,'State,'Residue,'Result>
```

## Platforms
Windows 8, Windows7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Printf Module &#40;F&#35;&#41;](Core.Printf-Module-%5BFSharp%5D.md)

[Format&lt;'Printer,'State,'Residue,'Result&gt;](https://msdn.microsoft.com/library/470f484f-a026-40af-8f8c-1e3aaf013bdc)
