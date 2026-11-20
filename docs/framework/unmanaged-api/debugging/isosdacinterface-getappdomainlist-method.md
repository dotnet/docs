---
description: "Learn more about: ISOSDacInterface::GetAppDomainList Method"
title: "ISOSDacInterface::GetAppDomainList Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetAppDomainList Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetAppDomainList Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetAppDomainList Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetAppDomainList Method

Retrieves the list of application domains in the runtime.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetAppDomainList(unsigned int count, CLRDATA_ADDRESS values[], unsigned int *pNeeded);
```

## Parameters

`count`\
[in] The number of elements that the `values` array can hold.

`values`\
[out] An array of `CLRDATA_ADDRESS` values that receives the application domain addresses.

`pNeeded`\
[out] A pointer to the number of application domain addresses available.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 6th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [ISOSDacInterface::GetAppDomainStoreData Method](isosdacinterface-getappdomainstoredata-method.md)
- [ISOSDacInterface::GetAppDomainData Method](isosdacinterface-getappdomaindata-method.md)
- [ISOSDacInterface::GetAssemblyData Method](isosdacinterface-getassemblydata-method.md)
