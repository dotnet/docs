---
title: "DacpGetModuleAddress::Request Method"
ms.date: "01/16/2019"
api.name:
  - "DacpGetModuleAddress::Request Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpGetModuleAddress::Request Method"
helpviewer.keywords:
  - "DacpGetModuleAddress::Request Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# DacpGetModuleAddress::Request Method

Performs a request to populate the structure from the given runtime structure.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```
HRESULT Request(
    [in] IXCLRDataModule* pDataModule
);
```

### Parameters

`pDataModule`
[in] A pointer to the seed data module.

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, the easiest way is to mimic the implementation:

- Return the value obtained from calling the `Request` method on the `IXCLRDataModule*` parameter with the following parameters: `((uint32) 0xf0000000, 0, 0, (uint32) sizeof(*this), (uint8*) this)`


## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None     
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See Also

- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [DacpGetModuleAddress Interface](../../../../docs/framework/unmanaged-api/debugging/dacpgetmoduleaddress-structure.md)
