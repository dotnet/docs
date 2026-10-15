---
description: "Learn more about: ISOSDacInterface::GetJitManagerList Method"
title: "ISOSDacInterface::GetJitManagerList Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetJitManagerList Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetJitManagerList Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetJitManagerList Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetJitManagerList Method

Retrieves the list of JIT managers known to the runtime.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetJitManagerList(unsigned int count, struct DacpJitManagerInfo *managers, unsigned int *pNeeded);
```

## Parameters

`count`\
[in] The number of elements available in the `managers` array.

`managers`\
[out] A pointer to an array of [DacpJitManagerInfo structures](dacpjitmanagerinfo-structure.md) that receives the JIT manager data.

`pNeeded`\
[out] A pointer to the number of JIT manager entries required.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 28th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpJitManagerInfo Structure](dacpjitmanagerinfo-structure.md)
- [ISOSDacInterface::GetCodeHeaderData Method](isosdacinterface-getcodeheaderdata-method.md)
- [ISOSDacInterface::GetCodeHeapList Method](isosdacinterface-getcodeheaplist-method.md)
