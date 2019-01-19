---
title: "DacpGetModuleAddress Structure"
ms.date: "01/16/2019"
api.name:
  - "DacpGetModuleAddress Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpGetModuleAddress Structure"
helpviewer.keywords:
  - "DacpGetModuleAddress Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# DacpGetModuleAddress Structure

Defines the container for a module address request.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```
struct DacpGetModuleAddress
{
    CLRDATA_ADDRESS ModulePtr;
};
```

## Members

| Member      | Description                |
| ----------- | -------------------------- |
| `ModulePtr` | The pointer to the module. |

## Methods

| Method                                                                                               | Description                                                                    |
| ---------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------ |
| [Request](../../../../docs/framework/unmanaged-api/debugging/dacpgetmoduleaddress-request-method.md) | Performs a request to populate the structure from the given runtime structure. |

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above, where `CLRDATA_ADDRESS` is a 64-bit unsigned integer.

## Requirements
**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See Also
- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)
