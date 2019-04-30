---
title: "DacpModuleData Structure"
ms.date: "02/01/2019"
api.name:
  - "DacpModuleData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpModuleData Structure"
helpviewer.keywords:
  - "DacpModuleData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "hoyosjs"
ms.author: "juhoyosa"
---
# DacpModuleData Structure

Defines a transport buffer for a module's runtime information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```
struct DacpModuleData
{
    CLRDATA_ADDRESS Address;
    CLRDATA_ADDRESS File; 
    CLRDATA_ADDRESS  ilBase;
    char payLoad[132];
};
```

## Members

| Member    | Description                                                             |
| --------- | ----------------------------------------------------------------------- |
| `Address` | Address of the module object.                                           |
| `File`    | A pointer to the portable executable (PE) file.                       |
| `ilBase`  | The address of the loaded image's base.                                 |
| `payLoad` | A payload buffer for additional module information used by the runtime. |

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above.

## Requirements
**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)
