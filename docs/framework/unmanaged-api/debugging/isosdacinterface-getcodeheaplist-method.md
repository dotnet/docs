---
description: "Learn more about: ISOSDacInterface::GetCodeHeapList Method"
title: "ISOSDacInterface::GetCodeHeapList Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetCodeHeapList Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetCodeHeapList Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetCodeHeapList Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetCodeHeapList Method

Retrieves the list of code heaps for the specified JIT manager.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetCodeHeapList(CLRDATA_ADDRESS jitManager, unsigned int count, struct DacpJitCodeHeapInfo *codeHeaps, unsigned int *pNeeded);
```

## Parameters

`jitManager`\
[in] The address of the JIT manager whose code heaps to retrieve.

`count`\
[in] The number of elements available in the `codeHeaps` array.

`codeHeaps`\
[out] A pointer to an array of [DacpJitCodeHeapInfo structures](dacpjitcodeheapinfo-structure.md) that receives the code heap data.

`pNeeded`\
[out] A pointer to the number of code heap entries required.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 69th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  


## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpJitCodeHeapInfo Structure](dacpjitcodeheapinfo-structure.md)
