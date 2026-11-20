---
description: "Learn more about: ISOSDacInterface::GetDomainLocalModuleDataFromModule Method"
title: "ISOSDacInterface::GetDomainLocalModuleDataFromModule Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetDomainLocalModuleDataFromModule Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetDomainLocalModuleDataFromModule Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetDomainLocalModuleDataFromModule Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetDomainLocalModuleDataFromModule Method

Retrieves domain-local module data for the specified module.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetDomainLocalModuleDataFromModule(CLRDATA_ADDRESS moduleAddr, struct DacpDomainLocalModuleData *data);
```

## Parameters

`moduleAddr`\
[in] The address of the module.

`data`\
[out] A pointer to a [DacpDomainLocalModuleData structure](dacpdomainlocalmoduledata-structure.md) that receives the domain-local module data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 58th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpDomainLocalModuleData Structure](dacpdomainlocalmoduledata-structure.md)
- [ISOSDacInterface::GetDomainLocalModuleData Method](isosdacinterface-getdomainlocalmoduledata-method.md)
- [ISOSDacInterface::GetDomainLocalModuleDataFromAppDomain Method](isosdacinterface-getdomainlocalmoduledatafromappdomain-method.md)
- [ISOSDacInterface::GetThreadLocalModuleData Method](isosdacinterface-getthreadlocalmoduledata-method.md)
