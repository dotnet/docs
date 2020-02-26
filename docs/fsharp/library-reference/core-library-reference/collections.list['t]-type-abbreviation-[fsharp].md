---
title: Collections.list<'T> Type Abbreviation (F#)
description: Collections.list<'T> Type Abbreviation (F#)
ms.date: 02/25/2020
---

# Collections.list<'T> Type Abbreviation (F#)

An abbreviation for [`List`](collections.list-module-[fsharp].md), the type of immutable singly-linked lists.

**Namespace/Module Path:** Microsoft.FSharp.Collections

## Syntax

```fsharp
type list<'T> = List<'T>
```

## Remarks
Use the constructors `[]` and `::` (infix) to create values of this type, or the notation `[1;2;3]`. Use the values in the [List module](collections.list-module-[fsharp].md) to manipulate values of this type, or pattern match against the values directly.


## See Also
[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

[Collections.List&#60;'T&#62; Union &#40;F&#35;&#41;](Collections.List%5B%27T%5D-Union-%5BFSharp%5D.md)

[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Lists](../../language-reference/lists.md)
