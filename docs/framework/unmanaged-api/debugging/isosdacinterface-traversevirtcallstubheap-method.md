---
description: "Learn more about: ISOSDacInterface::TraverseVirtCallStubHeap Method"
title: "ISOSDacInterface::TraverseVirtCallStubHeap Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::TraverseVirtCallStubHeap Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::TraverseVirtCallStubHeap Method"
helpviewer.keywords:
  - "ISOSDacInterface::TraverseVirtCallStubHeap Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::TraverseVirtCallStubHeap Method

Enumerates blocks in a virtual call stub heap for the specified application domain.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT TraverseVirtCallStubHeap(CLRDATA_ADDRESS pAppDomain, VCSHeapType heaptype, VISITHEAP pCallback);
```

## Parameters

`pAppDomain`\
[in] The address of the application domain that contains the virtual call stub heap.

`heaptype`\
[in] A [VCSHeapType enumeration](vcsheaptype-enumeration.md) value that identifies the virtual call stub heap to traverse.

`pCallback`\
[in] A `VISITHEAP` callback function that receives each heap block.

## Remarks

The `VISITHEAP` callback has the signature `void (*VISITHEAP)(CLRDATA_ADDRESS blockData,size_t blockSize,BOOL blockIsCurrentBlock)`. The runtime calls the callback for each heap block and supplies the block address, block size, and a value that indicates whether the block is the current block.

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 70th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [VCSHeapType Enumeration](vcsheaptype-enumeration.md)
- [ISOSDacInterface::TraverseLoaderHeap Method](isosdacinterface-traverseloaderheap-method.md)
