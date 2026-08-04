---
description: "Learn more about: ISOSDacInterface::GetAssemblyData Method"
title: "ISOSDacInterface::GetAssemblyData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetAssemblyData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetAssemblyData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetAssemblyData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetAssemblyData Method

Retrieves data for the assembly at the specified address.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetAssemblyData(CLRDATA_ADDRESS baseDomainPtr, CLRDATA_ADDRESS assembly, struct DacpAssemblyData *data);
```

## Parameters

`baseDomainPtr`\
[in] The address of the base domain that contains the assembly, or `NULL` to use the default base domain context.

`assembly`\
[in] The address of the assembly to retrieve information for.

`data`\
[out] A pointer to a [DacpAssemblyData structure](dacpassemblydata-structure.md) that receives the assembly data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 11th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpAssemblyData Structure](dacpassemblydata-structure.md)
- [ISOSDacInterface::GetAppDomainStoreData Method](isosdacinterface-getappdomainstoredata-method.md)
- [ISOSDacInterface::GetAppDomainList Method](isosdacinterface-getappdomainlist-method.md)
- [ISOSDacInterface::GetAppDomainData Method](isosdacinterface-getappdomaindata-method.md)
