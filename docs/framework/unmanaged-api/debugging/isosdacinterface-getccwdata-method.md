---
title: "ISOSDacInterface::GetCCWData Method"
ms.date: "06/02/20202"
api.name:
  - "ISOSDacInterface::GetCCWData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetCCWData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetCCWData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "chuckries"
ms.author: "chuckr"
---
# ISOSDacInterface::GetCCWData Method

Gets the data for the given Com Callable Wrapper pointer.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetCCWData(
    CLRDATA_ADDRESS ccw
    DacpCCWData *ccwData
);
```

## Parameters

`ccw`\
[in] The address of the CCW pointer.

`ccwData`\
[out] The data associated with the CCW.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 77th slot of the virtual method table. To be able to use them, [`CLRDATA_ADDRESS`](../common-data-types-unmanaged-api-reference.md) must be defined as a 64-bit unsigned integer.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
