---
description: "Learn more about: DacpAppDomainData Structure"
title: "DacpAppDomainData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpAppDomainData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpAppDomainData Structure"
helpviewer.keywords:
  - "DacpAppDomainData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpAppDomainData Structure

Defines a transport buffer for runtime application domain information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpAppDomainData : ZeroInit<DacpAppDomainData>
{
    // The pointer to the BaseDomain (not necessarily an AppDomain).  
    // It's useful to keep this around in the structure
    CLRDATA_ADDRESS AppDomainPtr; 
    CLRDATA_ADDRESS AppSecDesc;
    CLRDATA_ADDRESS pLowFrequencyHeap;
    CLRDATA_ADDRESS pHighFrequencyHeap;
    CLRDATA_ADDRESS pStubHeap;
    CLRDATA_ADDRESS DomainLocalBlock;
    CLRDATA_ADDRESS pDomainLocalModules;    
    // The creation sequence number of this app domain (starting from 1)
    DWORD dwId;
    LONG AssemblyCount;
    LONG FailedAssemblyCount;
    DacpAppDomainDataStage appDomainStage; 
    
    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr)
    {
        return sos->GetAppDomainData(addr, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `AppDomainPtr` | The address of the base domain. For an application domain, this value is the application domain address. |
| `AppSecDesc` | The address of the application security descriptor. |
| `pLowFrequencyHeap` | The address of the low-frequency loader heap. |
| `pHighFrequencyHeap` | The address of the high-frequency loader heap. |
| `pStubHeap` | The address of the stub heap. |
| `DomainLocalBlock` | The address of the domain local block. |
| `pDomainLocalModules` | The address of the domain local modules. |
| `dwId` | The creation sequence number of the application domain, starting from 1. |
| `AssemblyCount` | The number of assemblies in the application domain. |
| `FailedAssemblyCount` | The number of failed assemblies in the application domain. |
| `appDomainStage` | A `DacpAppDomainDataStage` value that indicates the application domain lifecycle stage. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetAppDomainData`. |

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
