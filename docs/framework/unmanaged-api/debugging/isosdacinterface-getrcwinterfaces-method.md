---
description: "Learn more about: ISOSDacInterface::GetRCWInterfaces Method"
title: "ISOSDacInterface::GetRCWInterfaces Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetRCWInterfaces Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetRCWInterfaces Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetRCWInterfaces Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetRCWInterfaces Method

Retrieves COM interface pointer data for a runtime callable wrapper (RCW).

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetRCWInterfaces(CLRDATA_ADDRESS rcw, unsigned int count, struct DacpCOMInterfacePointerData *interfaces, unsigned int *pNeeded);
```

## Parameters

`rcw`\
[in] The address of the RCW to retrieve interface information for.

`count`\
[in] The number of elements that the `interfaces` array can hold.

`interfaces`\
[out] An array of [DacpCOMInterfacePointerData structures](dacpcominterfacepointerdata-structure.md) that receives interface pointer data.

`pNeeded`\
[out] A pointer to the number of interface pointer entries available.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 76th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [DacpCOMInterfacePointerData Structure](dacpcominterfacepointerdata-structure.md)
- [ISOSDacInterface::GetRCWData Method](isosdacinterface-getrcwdata-method.md)
- [ISOSDacInterface::TraverseRCWCleanupList Method](isosdacinterface-traversercwcleanuplist-method.md)
