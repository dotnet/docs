---
description: "Learn more about: DacpThreadStoreData Structure"
title: "DacpThreadStoreData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpThreadStoreData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpThreadStoreData Structure"
helpviewer.keywords:
  - "DacpThreadStoreData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpThreadStoreData Structure

Defines a transport buffer for runtime thread store information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpThreadStoreData : ZeroInit<DacpThreadStoreData>
{
    LONG threadCount;
    LONG unstartedThreadCount;
    LONG backgroundThreadCount;
    LONG pendingThreadCount;
    LONG deadThreadCount;
    CLRDATA_ADDRESS firstThread;
    CLRDATA_ADDRESS finalizerThread;
    CLRDATA_ADDRESS gcThread;
    DWORD fHostConfig;          // Uses hosting flags defined above
 
    HRESULT Request(ISOSDacInterface *sos)
    {
        return sos->GetThreadStoreData(this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `threadCount` | The total number of runtime threads. |
| `unstartedThreadCount` | The number of threads that have not started. |
| `backgroundThreadCount` | The number of background threads. |
| `pendingThreadCount` | The number of pending threads. |
| `deadThreadCount` | The number of dead threads. |
| `firstThread` | The address of the first thread in the runtime thread list. |
| `finalizerThread` | The address of the finalizer thread. |
| `gcThread` | The address of the garbage collection thread. |
| `fHostConfig` | A bitmask of runtime hosting flags such as `CLRMEMORYHOSTED`, `CLRTASKHOSTED`, and `CLRHOSTED`. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetThreadStoreData`. |

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
