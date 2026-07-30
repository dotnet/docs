---
description: "Learn more about: ISOSDacInterface::GetDomainLocalModuleDataFromAppDomain Method"
title: "ISOSDacInterface::GetDomainLocalModuleDataFromAppDomain Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetDomainLocalModuleDataFromAppDomain Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetDomainLocalModuleDataFromAppDomain Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetDomainLocalModuleDataFromAppDomain Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetDomainLocalModuleDataFromAppDomain Method

Retrieves domain-local module data for the specified application domain and module identifier.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetDomainLocalModuleDataFromAppDomain(CLRDATA_ADDRESS appDomainAddr, int moduleID, struct DacpDomainLocalModuleData *data);
```

## Parameters

`appDomainAddr`\
[in] The address of the application domain.

`moduleID`\
[in] The module identifier.

`data`\
[out] A pointer to a [DacpDomainLocalModuleData structure](dacpdomainlocalmoduledata-structure.md) that receives the domain-local module data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 57th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpDomainLocalModuleData Structure](dacpdomainlocalmoduledata-structure.md)
