---
description: "Learn more about: DacpThreadData Structure"
title: "DacpThreadData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpThreadData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpThreadData Structure"
helpviewer.keywords:
  - "DacpThreadData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpThreadData Structure

Defines a transport buffer for runtime thread information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpThreadData : ZeroInit<DacpThreadData>
{
    DWORD corThreadId;
    DWORD osThreadId;
    int state;
    ULONG preemptiveGCDisabled;
    CLRDATA_ADDRESS allocContextPtr;
    CLRDATA_ADDRESS allocContextLimit;
    CLRDATA_ADDRESS context;
    CLRDATA_ADDRESS domain;
    CLRDATA_ADDRESS pFrame;
    DWORD lockCount;
    CLRDATA_ADDRESS firstNestedException; // Pass this pointer to DacpNestedExceptionInfo
    CLRDATA_ADDRESS teb;
    CLRDATA_ADDRESS fiberData;
    CLRDATA_ADDRESS lastThrownObjectHandle;
    CLRDATA_ADDRESS nextThread;

    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr)
    {
        return sos->GetThreadData(addr, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `corThreadId` | The managed thread identifier. |
| `osThreadId` | The operating system thread identifier. |
| `state` | The thread state flags. |
| `preemptiveGCDisabled` | A value that indicates whether preemptive garbage collection is disabled for the thread. |
| `allocContextPtr` | The current allocation context pointer for the thread. |
| `allocContextLimit` | The allocation context limit for the thread. |
| `context` | The address of the thread context. |
| `domain` | The address of the application domain for the thread. |
| `pFrame` | The address of the current frame. |
| `lockCount` | The number of locks held by the thread. |
| `firstNestedException` | The address of the first nested exception. Pass this pointer to `DacpNestedExceptionInfo`. |
| `teb` | The address of the thread environment block. |
| `fiberData` | The address of the fiber data. |
| `lastThrownObjectHandle` | The handle for the last object thrown on the thread. |
| `nextThread` | The address of the next thread in the runtime thread list. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetThreadData`. |

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
