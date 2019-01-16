---
title: "IXCLRDataProcess::EndEnumMethodInstancesByAddress Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataProcess::EndEnumMethodInstancesByAddress Method"
api.location:
  - "mscordaccore.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::EndEnumMethodInstancesByAddress Method"
helpviewer.keywords:
  - "IXCLRDataProcess::EndEnumMethodInstancesByAddress Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess::EndEnumMethodInstancesByAddress Method

End enumerate method instances of this process by an address.

## Syntax

```
HRESULT EndEnumMethodInstancesByAddress(
    [in] CLRDATA_ENUM handle
);
```

### Parameters

`handle`
[out] A handle for enumerating the method instances.

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 29th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See Also

- [CLRDataSourceType, CLRDATA_ENUM Enumeration](../../../../docs/framework/unmanaged-api/debugging/clrdata-enum-enumeration-enumeration.md)
- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [IXCLRDataProcess Interface](../../../../docs/framework/unmanaged-api/debugging/ixclrdataprocess-interface.md)