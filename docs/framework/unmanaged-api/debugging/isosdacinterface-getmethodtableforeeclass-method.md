---
description: "Learn more about: ISOSDacInterface::GetMethodTableForEEClass Method"
title: "ISOSDacInterface::GetMethodTableForEEClass Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetMethodTableForEEClass Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetMethodTableForEEClass Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetMethodTableForEEClass Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetMethodTableForEEClass Method

Gets the method table address that corresponds to an EEClass address.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetMethodTableForEEClass(CLRDATA_ADDRESS eeClass, CLRDATA_ADDRESS *value);
```

## Parameters

`eeClass`\
[in] The address of the EEClass.

`value`\
[out] The method table address that corresponds to the EEClass.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 42nd slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
