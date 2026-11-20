---
description: "Learn more about: DacpSyncBlockCleanupData Structure"
title: "DacpSyncBlockCleanupData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpSyncBlockCleanupData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpSyncBlockCleanupData Structure"
helpviewer.keywords:
  - "DacpSyncBlockCleanupData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpSyncBlockCleanupData Structure

Defines a transport buffer for sync block cleanup information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpSyncBlockCleanupData : ZeroInit<DacpSyncBlockCleanupData>
{
    CLRDATA_ADDRESS SyncBlockPointer;
    
    CLRDATA_ADDRESS nextSyncBlock;
    CLRDATA_ADDRESS blockRCW;
    CLRDATA_ADDRESS blockClassFactory;
    CLRDATA_ADDRESS blockCCW;
    
    // Pass NULL on the first request to start a traversal.
    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS psyncBlock)
    {
        return sos->GetSyncBlockCleanupData(psyncBlock, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `SyncBlockPointer` | The address of the sync block. |
| `nextSyncBlock` | The address of the next sync block in the cleanup list. |
| `blockRCW` | The address of the runtime callable wrapper associated with the sync block. |
| `blockClassFactory` | The address of the class factory associated with the sync block. |
| `blockCCW` | The address of the COM callable wrapper associated with the sync block. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetSyncBlockCleanupData`. Pass `NULL` on the first request to start a traversal. |

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
