---
title: "IXCLRDataMethodDefinition::EndEnumInstances Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataMethodDefinition::EndEnumInstances Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodDefinition::EndEnumInstances Method"
helpviewer.keywords:
  - "IXCLRDataMethodDefinition::EndEnumInstances Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataMethodDefinition::EndEnumInstances Method

Releases the resources used by internal iterators used during instance enumeration.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```
HRESULT EndEnumInstances(
    [in] CLRDATA_ENUM handle
);
```

### Parameters

`handle`
[out] A handle for enumerating the instances.

## Remarks

The provided method is part of the `IXCLRDataMethodDefinition` interface and corresponds to the fifth slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [IXCLRDataMethodDefinition Interface](../../../../docs/framework/unmanaged-api/debugging/ixclrdatamethoddefinition-interface.md)
