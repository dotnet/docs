---
description: "Learn more about: DacpAssemblyData Structure"
title: "DacpAssemblyData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpAssemblyData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpAssemblyData Structure"
helpviewer.keywords:
  - "DacpAssemblyData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpAssemblyData Structure

Defines a transport buffer for runtime assembly information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpAssemblyData : ZeroInit<DacpAssemblyData>
{
    CLRDATA_ADDRESS AssemblyPtr; //useful to have
    CLRDATA_ADDRESS ClassLoader;
    CLRDATA_ADDRESS ParentDomain;
    CLRDATA_ADDRESS BaseDomainPtr;
    CLRDATA_ADDRESS AssemblySecDesc;
    BOOL isDynamic;
    UINT ModuleCount;
    UINT LoadContext;
    BOOL isDomainNeutral;
    DWORD dwLocationFlags;

    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr, CLRDATA_ADDRESS baseDomainPtr)
    {
        return sos->GetAssemblyData(baseDomainPtr, addr, this);
    }

    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr)
    {
        return Request(sos, addr, NULL);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `AssemblyPtr` | The address of the assembly. |
| `ClassLoader` | The address of the class loader for the assembly. |
| `ParentDomain` | The address of the parent application domain. |
| `BaseDomainPtr` | The address of the base domain that contains the assembly. |
| `AssemblySecDesc` | The address of the assembly security descriptor. |
| `isDynamic` | A value that indicates whether the assembly is dynamic. |
| `ModuleCount` | The number of modules in the assembly. |
| `LoadContext` | The assembly load context value. |
| `isDomainNeutral` | A value that indicates whether the assembly is domain-neutral. |
| `dwLocationFlags` | A bitmask of location flags for the assembly. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetAssemblyData`. |

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
