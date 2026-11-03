---
description: "Learn more about: DacpDomainLocalModuleData Structure"
title: "DacpDomainLocalModuleData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpDomainLocalModuleData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpDomainLocalModuleData Structure"
helpviewer.keywords:
  - "DacpDomainLocalModuleData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpDomainLocalModuleData Structure

Defines a transport buffer for domain-local module information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpDomainLocalModuleData : ZeroInit<DacpDomainLocalModuleData>
{
    // These two parameters are used as input parameters when calling Request below.
    CLRDATA_ADDRESS appDomainAddr;
    ULONG64  ModuleID;
    
    CLRDATA_ADDRESS pClassData;   
    CLRDATA_ADDRESS pDynamicClassTable;   
    CLRDATA_ADDRESS pGCStaticDataStart;
    CLRDATA_ADDRESS pNonGCStaticDataStart; 

    // Called when you have a pointer to the DomainLocalModule
    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr)
    {
        return sos->GetDomainLocalModuleData(addr, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `appDomainAddr` | The address of the application domain used as an input parameter for a request. |
| `ModuleID` | The module identifier used as an input parameter for a request. |
| `pClassData` | The address of the class data. |
| `pDynamicClassTable` | The address of the dynamic class table. |
| `pGCStaticDataStart` | The start address for garbage-collected static data. |
| `pNonGCStaticDataStart` | The start address for non-garbage-collected static data. |
| `Request` | Populates the structure by calling [`ISOSDacInterface::GetDomainLocalModuleData`](isosdacinterface-getdomainlocalmoduledata-method.md). |

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
- [ISOSDacInterface::GetDomainLocalModuleData Method](isosdacinterface-getdomainlocalmoduledata-method.md)
