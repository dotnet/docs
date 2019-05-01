---
title: "DacpReJitData Structure"
ms.date: "02/01/2019"
api.name:
  - "DacpReJitData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpReJitData Structure"
helpviewer.keywords:
  - "DacpReJitData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "hoyosjs"
ms.author: "juhoyosa"
---
# DacpReJitData Structure

Defines the basic information about a given profiler-instrumented method.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```
struct MSLAYOUT DacpReJitData
{
    enum Flags
    {
        kUnknown,
        kRequested,
        kActive,
        kReverted,
    };

    CLRDATA_ADDRESS                 rejitID;
    Flags                           flags;
    CLRDATA_ADDRESS                 NativeCodeAddr;
};
```

## Members

| Member           | Description                                                                                      |
| ---------------- | ------------------------------------------------------------------------------------------------ |
| `rejitID`        | The ReJit revision number for a method.                                                          |
| `flags`          | A flag indicating the current state of the method's ReJit instrumentation for the given version. |
| `NativeCodeAddr` | The base address of the method's rejitted implementation.                                         |

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above. The structure must also be defined using `ms_struct` packing if not using the Microsoft compilers.

## Requirements
**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)
