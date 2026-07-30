---
description: "Learn more about: ISOSDacInterface::GetDomainLocalModuleData Method"
title: "ISOSDacInterface::GetDomainLocalModuleData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetDomainLocalModuleData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetDomainLocalModuleData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetDomainLocalModuleData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetDomainLocalModuleData Method

Retrieves data for the domain-local module at the specified address.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetDomainLocalModuleData(CLRDATA_ADDRESS addr, struct DacpDomainLocalModuleData *data);
```

## Parameters

`addr`\
[in] The address of the domain-local module to retrieve information for.

`data`\
[out] A pointer to a [DacpDomainLocalModuleData structure](dacpdomainlocalmoduledata-structure.md) that receives the domain-local module data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 56th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpDomainLocalModuleData Structure](dacpdomainlocalmoduledata-structure.md)
