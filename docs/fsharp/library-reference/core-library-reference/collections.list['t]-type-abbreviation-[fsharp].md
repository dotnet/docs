---
title: Collections.list<'T> Type Abbreviation (F#)
description: Collections.list<'T> Type Abbreviation (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4f5da77e-a58d-49a7-8cd6-aa17d9993846 
---

# Collections.list<'T> Type Abbreviation (F#)

An abbreviation for [`List`](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7), the type of immutable singly-linked lists.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type list<'T> = List<'T>
```

## Remarks
Use the constructors `[]` and `::` (infix) to create values of this type, or the notation `[1;2;3]`. Use the values in the [List module](https://msdn.microsoft.com/library/a2264ba3-2d45-40dd-9040-4f7aa2ad9788) to manipulate values of this type, or pattern match against the values directly.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

[Collections.List&#60;'T&#62; Union &#40;F&#35;&#41;](Collections.List%5B%27T%5D-Union-%5BFSharp%5D.md)

[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Lists &#40;F&#35;&#41;](Lists-%5BFSharp%5D.md)