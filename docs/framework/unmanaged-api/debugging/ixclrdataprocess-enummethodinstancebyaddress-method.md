---
title: "IXCLRDataProcess::EnumMethodInstanceByAddress Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataProcess::EnumMethodInstanceByAddress Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::EnumMethodInstanceByAddress Method"
helpviewer.keywords:
  - "IXCLRDataProcess::EnumMethodInstanceByAddress Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess::EnumMethodInstanceByAddress Method

Enumerates the method instances of this process starting at an address offset.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```
HRESULT EnumMethodInstanceByAddress(
    [in] CLRDATA_ENUM              *handle,
    [out] IXCLRDataMethodInstance **method
);
```

### Parameters

`handle`
[in] A handle for enumerating the method instances.

`mod`
[out] The enumerated method instance.

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 28th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).   
**Header:** None   
**Library:** None   
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]   
 
## See also
- [CLRDataSourceType Enumeration](../../../../docs/framework/unmanaged-api/debugging/clrdatasourcetype-enumeration.md)
- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [IXCLRDataProcess Interface](../../../../docs/framework/unmanaged-api/debugging/ixclrdataprocess-interface.md)
