---
description: "Learn more about: ISOSDacInterface::GetThreadLocalModuleData Method"
title: "ISOSDacInterface::GetThreadLocalModuleData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetThreadLocalModuleData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetThreadLocalModuleData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetThreadLocalModuleData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetThreadLocalModuleData Method

Retrieves thread-local module data for the specified thread and module index.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetThreadLocalModuleData(CLRDATA_ADDRESS thread, unsigned int index, struct DacpThreadLocalModuleData *data);
```

## Parameters

`thread`\
[in] The address of the thread.

`index`\
[in] The module index.

`data`\
[out] A pointer to a [DacpThreadLocalModuleData structure](dacpthreadlocalmoduledata-structure.md) that receives the thread-local module data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 59th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpThreadLocalModuleData Structure](dacpthreadlocalmoduledata-structure.md)
