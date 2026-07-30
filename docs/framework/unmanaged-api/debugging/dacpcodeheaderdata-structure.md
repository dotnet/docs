---
description: "Learn more about: DacpCodeHeaderData Structure"
title: "DacpCodeHeaderData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpCodeHeaderData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpCodeHeaderData Structure"
helpviewer.keywords:
  - "DacpCodeHeaderData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpCodeHeaderData Structure

Defines a transport buffer for JIT-compiled code header information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpCodeHeaderData : ZeroInit<DacpCodeHeaderData>
{        
    CLRDATA_ADDRESS GCInfo;
    JITTypes                   JITType;
    CLRDATA_ADDRESS MethodDescPtr;
    CLRDATA_ADDRESS MethodStart;
    DWORD                    MethodSize;
    CLRDATA_ADDRESS ColdRegionStart;
    DWORD           ColdRegionSize;
    DWORD           HotRegionSize;
    
    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS IPAddr)
    {
        return sos->GetCodeHeaderData(IPAddr, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `GCInfo` | The address of the garbage collection information for the method. |
| `JITType` | A `JITTypes` value that identifies the kind of JIT compiler that produced the code. |
| `MethodDescPtr` | The address of the method descriptor for the code. |
| `MethodStart` | The starting address of the hot code region. |
| `MethodSize` | The size, in bytes, of the method code. |
| `ColdRegionStart` | The starting address of the cold code region. |
| `ColdRegionSize` | The size, in bytes, of the cold code region. |
| `HotRegionSize` | The size, in bytes, of the hot code region. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetCodeHeaderData`. |

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
