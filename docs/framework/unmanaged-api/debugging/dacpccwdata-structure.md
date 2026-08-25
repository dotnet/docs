---
description: "Learn more about: DacpCCWData Structure"
title: "DacpCCWData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpCCWData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpCCWData Structure"
helpviewer.keywords:
  - "DacpCCWData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpCCWData Structure

Defines a transport buffer for COM callable wrapper (CCW) information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpCCWData : ZeroInit<DacpCCWData>
{
    CLRDATA_ADDRESS outerIUnknown;
    CLRDATA_ADDRESS managedObject;
    CLRDATA_ADDRESS handle;
    CLRDATA_ADDRESS ccwAddress;

    LONG refCount;
    LONG interfaceCount;
    BOOL isNeutered;

    LONG jupiterRefCount;
    BOOL isPegged;
    BOOL isGlobalPegged;
    BOOL hasStrongRef;
    BOOL isExtendsCOMObject;
    BOOL isAggregated;
    
    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS ccw)
    {
        return sos->GetCCWData(ccw, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `outerIUnknown` | The address of the outer `IUnknown` pointer. |
| `managedObject` | The address of the managed object associated with the CCW. |
| `handle` | The address of the handle for the managed object. |
| `ccwAddress` | The address of the CCW. |
| `refCount` | The reference count for the CCW. |
| `interfaceCount` | The number of interfaces associated with the CCW. |
| `isNeutered` | A value that indicates whether the CCW is neutered. |
| `jupiterRefCount` | The Jupiter reference count for the CCW. |
| `isPegged` | A value that indicates whether the CCW is pegged. |
| `isGlobalPegged` | A value that indicates whether the CCW is globally pegged. |
| `hasStrongRef` | A value that indicates whether the CCW has a strong reference. |
| `isExtendsCOMObject` | A value that indicates whether the managed object extends a COM object. |
| `isAggregated` | A value that indicates whether the CCW is aggregated. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetCCWData`. |

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
