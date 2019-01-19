---
title: "IXCLRDataMethodDefinition::StartEnumInstances Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataMethodDefinition::StartEnumInstances Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodDefinition::StartEnumInstances Method"
helpviewer.keywords:
  - "IXCLRDataMethodDefinition::StartEnumInstances Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataMethodDefinition::StartEnumInstances Method

Provides a handle for the enumeration of method instances for a given `IXCLRDataAppDomain`.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```
HRESULT StartEnumInstances(
    [in] IXCLRDataAppDomain* appDomain,
    [out] CLRDATA_ENUM *handle
);
```

### Parameters

`appDomain`
[in] An AppDomain for the enumeration.

`handle`
[out] A handle for enumerating the instances.

## Remarks

The provided method is part of the `IXCLRDataMethodDefinition` interface and corresponds to the third slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See Also

- [CLRDataSourceType Enumeration](../../../../docs/framework/unmanaged-api/debugging/clrdatasourcetype-enumeration.md)
- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [IXCLRDataMethodDefinition Interface](../../../../docs/framework/unmanaged-api/debugging/ixclrdatamethoddefinition-interface.md)
