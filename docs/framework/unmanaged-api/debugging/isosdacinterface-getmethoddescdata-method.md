---
title: "ISOSDacInterface::GetMethodDescData Method"
ms.date: "01/16/2019"
api.name:
  - "ISOSDacInterface::GetMethodDescData Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetMethodDescData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetMethodDescData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# ISOSDacInterface::GetMethodDescData Method

Gets the data for the given [MethodDesc](../../../../docs/framework/unmanaged-api/common-data-types-unmanaged-api-reference.md).

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```
HRESULT GetMethodDescData(
    CLRDATA_ADDRESS            methodDesc,
    CLRDATA_ADDRESS            ip,
    void                       *data,
    ULONG                      cRevertedRejitVersions,
    void                      *rgRevertedRejitData,
    void                      *pcNeededRevertedRejitData
);
```

### Parameters

`methodDesc`
[in] The address of the MethodDesc.

`ip`
[in] The IP address of the method.

`data`
[out] The data associated with the MethodDesc as returned from the internal APIs. The structure needs at least 168 bytes.

`cRevertedRejitVersions`
[out] The number of reverted rejit versions.

`rgRevertedRejitData`
[out] The data associated with the reverted rejit versions as returned from the internal APIs. The structure needs at least 24 bytes.

`pcNeededRevertedRejitData`
[out] The number of bytes required to store the data associated with the reverted ReJit versions.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 20th slot of the virtual method table. Also the `CLRDATA_ADDRESS` are 64-bit unsigned integer.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See Also

- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [ISOSDacInterface Interface](../../../../docs/framework/unmanaged-api/debugging/isosdacinterface-interface.md)
