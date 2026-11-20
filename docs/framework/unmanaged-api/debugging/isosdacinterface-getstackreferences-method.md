---
description: "Learn more about: ISOSDacInterface::GetStackReferences Method"
title: "ISOSDacInterface::GetStackReferences Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetStackReferences Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetStackReferences Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetStackReferences Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetStackReferences Method

Retrieves an enumerator for references on a thread call stack.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetStackReferences([in] DWORD osThreadID, [out] ISOSStackRefEnum **ppEnum);
```

## Parameters

`osThreadID`\
[in] The operating system thread ID for the stack to enumerate.

`ppEnum`\
[out] A pointer to an `ISOSStackRefEnum` interface pointer that receives the stack-reference enumerator.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 80th slot of the virtual method table.

The returned `ISOSStackRefEnum` enumerator derives from `ISOSEnum` and provides a `Next` method that returns `SOSStackRefData` entries. It also provides an `EnumerateErrors` method that reports stack frames for which the runtime could not enumerate GC references.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [ISOSDacInterface::GetHandleEnum Method](isosdacinterface-gethandleenum-method.md)
- [ISOSDacInterface::GetHandleEnumForTypes Method](isosdacinterface-gethandleenumfortypes-method.md)
