---
description: "Learn more about: DacpJitCodeHeapInfo Structure"
title: "DacpJitCodeHeapInfo Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpJitCodeHeapInfo Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpJitCodeHeapInfo Structure"
helpviewer.keywords:
  - "DacpJitCodeHeapInfo Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpJitCodeHeapInfo Structure

Defines a transport buffer for JIT code heap information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpJitCodeHeapInfo : ZeroInit<DacpJitCodeHeapInfo>
{
    DWORD codeHeapType; // for union below

    union
    {
        CLRDATA_ADDRESS LoaderHeap;    // if CODEHEAP_LOADER
        struct
        {
            CLRDATA_ADDRESS baseAddr; // if CODEHEAP_HOST
            CLRDATA_ADDRESS currentAddr;
        } HostData;
    };
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `codeHeapType` | The code heap type value. |
| `LoaderHeap` | The address of the loader heap when `codeHeapType` is `CODEHEAP_LOADER`. |
| `HostData` | Host code heap data when `codeHeapType` is `CODEHEAP_HOST`. |
| `HostData.baseAddr` | The base address of the host code heap. |
| `HostData.currentAddr` | The current address in the host code heap. |

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [Debugging Structures](debugging-structures.md)
