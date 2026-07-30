---
description: "Learn more about: ISOSDacInterface::GetAppDomainData Method"
title: "ISOSDacInterface::GetAppDomainData Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetAppDomainData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetAppDomainData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetAppDomainData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetAppDomainData Method

Retrieves data for the application domain at the specified address.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetAppDomainData(CLRDATA_ADDRESS addr, struct DacpAppDomainData *data);
```

## Parameters

`addr`\
[in] The address of the application domain to retrieve information for.

`data`\
[out] A pointer to a [DacpAppDomainData structure](dacpappdomaindata-structure.md) that receives the application domain data.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 7th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpAppDomainData Structure](dacpappdomaindata-structure.md)
