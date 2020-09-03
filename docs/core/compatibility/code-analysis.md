---
title: Code analysis breaking changes
description: Lists the breaking changes in .NET source code analyzers.
ms.date: 08/22/2020
---
# Code analysis breaking changes

The following breaking changes are documented on this page:

| Breaking change | Version introduced |
| - | :-: |
| [CA1831: Use AsSpan or AsMemory instead of Range-based indexer](#ca1831-use-asspan-or-asmemory-instead-of-range-based-indexer) | 5.0 |
| [CA2014: Do not use stackalloc in loops](#ca2014-do-not-use-stackalloc-in-loops) | 5.0 |
| [CA2015: Do not define finalizers for types derived from MemoryManager\<T>](#ca2015-do-not-define-finalizers-for-types-derived-from-memorymanagert) | 5.0 |
| [CA2247: Argument to TaskCompletionSource constructor should be TaskCreationOptions value](#ca2247-argument-to-taskcompletionsource-constructor-should-be-taskcreationoptions-value) | 5.0 |

## .NET 5.0

[!INCLUDE [range-based-indexer-on-string](../../../includes/core-changes/codeanalysis/5.0/range-based-indexer-on-string.md)]

***

[!INCLUDE [stackalloc-in-loops](../../../includes/core-changes/codeanalysis/5.0/stackalloc-in-loops.md)]

***

[!INCLUDE [finalizers-for-memorymanager-types](../../../includes/core-changes/codeanalysis/5.0/finalizers-for-memorymanager-types.md)]

***

[!INCLUDE [ctor-arg-should-be-taskcreationoptions](../../../includes/core-changes/codeanalysis/5.0/ctor-arg-should-be-taskcreationoptions.md)]

***
