---
description: "Learn more about: DacpSyncBlockData Structure"
title: "DacpSyncBlockData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpSyncBlockData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpSyncBlockData Structure"
helpviewer.keywords:
  - "DacpSyncBlockData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpSyncBlockData Structure

Defines a transport buffer for sync block information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpSyncBlockData : ZeroInit<DacpSyncBlockData>
{        
    CLRDATA_ADDRESS Object;
    BOOL            bFree; // if set, no other fields are useful
    
    // fields below provide data from this, so it's just for display
    CLRDATA_ADDRESS SyncBlockPointer;
    DWORD           COMFlags;
    UINT            MonitorHeld;
    UINT            Recursion;
    CLRDATA_ADDRESS HoldingThread;
    UINT            AdditionalThreadCount;
    CLRDATA_ADDRESS appDomainPtr;
    
    // SyncBlockCount will always be filled in with the number of SyncBlocks.
    // SyncBlocks may be requested from [1,SyncBlockCount]
    UINT            SyncBlockCount;

    // SyncBlockNumber must be from [1,SyncBlockCount]    
    // If there are no SyncBlocks, a call to Request with SyncBlockCount = 1
    // will return E_FAIL.
    HRESULT Request(ISOSDacInterface *sos, UINT SyncBlockNumber)
    {
        return sos->GetSyncBlockData(SyncBlockNumber, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `Object` | The address of the object associated with the sync block. |
| `bFree` | A value that indicates whether the sync block is free. If this member is set, no other fields are useful. |
| `SyncBlockPointer` | The address of the sync block. |
| `COMFlags` | Flags that describe COM interop data associated with the sync block. |
| `MonitorHeld` | The number of times the monitor is held. |
| `Recursion` | The monitor recursion count. |
| `HoldingThread` | The address of the thread that holds the monitor. |
| `AdditionalThreadCount` | The number of additional threads associated with the sync block. |
| `appDomainPtr` | The address of the application domain associated with the sync block. |
| `SyncBlockCount` | The number of sync blocks. Sync blocks can be requested from 1 through this value. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetSyncBlockData`. |

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
