---
description: "Learn more about: DacpObjectData Structure"
title: "DacpObjectData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpObjectData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpObjectData Structure"
helpviewer.keywords:
  - "DacpObjectData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpObjectData Structure

Defines a transport buffer for runtime object information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpObjectData : ZeroInit<DacpObjectData>
{
    CLRDATA_ADDRESS MethodTable;
    DacpObjectType ObjectType;
    ULONG64 Size;
    CLRDATA_ADDRESS ElementTypeHandle;
    CorElementType ElementType;
    DWORD dwRank;
    ULONG64 dwNumComponents;
    ULONG64 dwComponentSize;
    CLRDATA_ADDRESS ArrayDataPtr;
    CLRDATA_ADDRESS ArrayBoundsPtr;
    CLRDATA_ADDRESS ArrayLowerBoundsPtr;

    CLRDATA_ADDRESS RCW;
    CLRDATA_ADDRESS CCW;
    
    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr)
    {
        return sos->GetObjectData(addr, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `MethodTable` | The address of the object's method table. |
| `ObjectType` | A [DacpObjectType enumeration](dacpobjecttype-enumeration.md) value that identifies the object type. |
| `Size` | The size of the object, in bytes. |
| `ElementTypeHandle` | For arrays, the address of the element type handle. |
| `ElementType` | For arrays, the CorElementType value for the element type. |
| `dwRank` | For arrays, the number of dimensions. |
| `dwNumComponents` | For arrays, the number of elements. |
| `dwComponentSize` | For arrays, the size of each component, in bytes. |
| `ArrayDataPtr` | For arrays, the address of the array data. |
| `ArrayBoundsPtr` | For arrays, the address of the array bounds. |
| `ArrayLowerBoundsPtr` | For arrays, the address of the array lower bounds. |
| `RCW` | The address of the runtime callable wrapper associated with the object. |
| `CCW` | The address of the COM callable wrapper associated with the object. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetObjectData`. |

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
- [DacpObjectType Enumeration](dacpobjecttype-enumeration.md)
