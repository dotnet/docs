---
description: "Learn more about: DacpMethodTableData Structure"
title: "DacpMethodTableData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpMethodTableData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpMethodTableData Structure"
helpviewer.keywords:
  - "DacpMethodTableData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpMethodTableData Structure

Defines a transport buffer for method table information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpMethodTableData : ZeroInit<DacpMethodTableData>
{
    BOOL bIsFree; // everything else is NULL if this is true.
    CLRDATA_ADDRESS Module;
    CLRDATA_ADDRESS Class;
    CLRDATA_ADDRESS ParentMethodTable;
    WORD wNumInterfaces;
    WORD wNumMethods;
    WORD wNumVtableSlots;
    WORD wNumVirtuals;
    DWORD BaseSize;
    DWORD ComponentSize;
    mdTypeDef cl; // Metadata token    
    DWORD dwAttrClass; // cached metadata
    BOOL bIsShared; // flags & enum_flag_DomainNeutral
    BOOL bIsDynamic;
    BOOL bContainsPointers;
    
    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr)
    {
        return sos->GetMethodTableData(addr, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `bIsFree` | A value that indicates whether the method table is free. If this member is `TRUE`, all other members are `NULL`. |
| `Module` | The address of the module that contains the method table. |
| `Class` | The address of the EEClass for the method table. |
| `ParentMethodTable` | The address of the parent method table. |
| `wNumInterfaces` | The number of interfaces implemented by the type. |
| `wNumMethods` | The number of methods on the method table. |
| `wNumVtableSlots` | The number of vtable slots on the method table. |
| `wNumVirtuals` | The number of virtual methods on the method table. |
| `BaseSize` | The base size for instances of the type. |
| `ComponentSize` | The component size for array or string instances. |
| `cl` | The metadata token for the type. |
| `dwAttrClass` | The cached metadata attributes for the type. |
| `bIsShared` | A value that indicates whether the method table is shared. |
| `bIsDynamic` | A value that indicates whether the method table represents a dynamic type. |
| `bContainsPointers` | A value that indicates whether instances of the type contain object references. |
| `Request` | Populates the structure from a method table address by calling `ISOSDacInterface::GetMethodTableData`. |

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
