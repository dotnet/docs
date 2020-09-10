---
title: Code analysis breaking changes
description: Lists the breaking changes in .NET source code analyzers.
ms.date: 09/02/2020
---
# Code analysis breaking changes

The following breaking changes are documented on this page:

| Breaking change | Version introduced |
| - | :-: |
| [CA1416: Platform compatibility](#ca1416-platform-compatibility) | 5.0 |
| [CA1417: OutAttribute on string parameter for P/Invoke](#ca1417-outattribute-on-string-parameter-for-pinvoke) | 5.0 |
| [CA1831: Use AsSpan instead of Range-based indexers for string](#ca1831-use-asspan-instead-of-range-based-indexers-for-string) | 5.0 |
| [CA2013: Do not use ReferenceEquals with value types](#ca2013-do-not-use-referenceequals-with-value-types) | 5.0 |
| [CA2014: Do not use stackalloc in loops](#ca2014-do-not-use-stackalloc-in-loops) | 5.0 |
| [CA2015: Do not define finalizers for types derived from MemoryManager\<T>](#ca2015-do-not-define-finalizers-for-types-derived-from-memorymanagert) | 5.0 |
| [CA2247: Argument to TaskCompletionSource constructor should be TaskCreationOptions value](#ca2247-argument-to-taskcompletionsource-constructor-should-be-taskcreationoptions-value) | 5.0 |

## .NET 5.0

[!INCLUDE [ca1416-platform-compatibility-analyzer](../../../includes/core-changes/codeanalysis/5.0/ca1416-platform-compatibility-analyzer.md)]

***

[!INCLUDE [outattributes-on-pinvoke-string-parameters](../../../includes/core-changes/codeanalysis/5.0/ca1417-outattributes-on-pinvoke-string-parameters.md)]

***

[!INCLUDE [range-based-indexer-on-string](../../../includes/core-changes/codeanalysis/5.0/ca1831-range-based-indexer-on-string.md)]

***

[!INCLUDE [referenceequals-on-value-types](../../../includes/core-changes/codeanalysis/5.0/ca2013-referenceequals-on-value-types.md)]

***

[!INCLUDE [stackalloc-in-loops](../../../includes/core-changes/codeanalysis/5.0/ca2014-stackalloc-in-loops.md)]

***

[!INCLUDE [finalizers-for-memorymanager-types](../../../includes/core-changes/codeanalysis/5.0/ca2015-finalizers-for-memorymanager-types.md)]

***

[!INCLUDE [ctor-arg-should-be-taskcreationoptions](../../../includes/core-changes/codeanalysis/5.0/ca2247-ctor-arg-should-be-taskcreationoptions.md)]

***
