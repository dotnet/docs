---
description: "Learn more about: DacpMethodTableFieldData Structure"
title: "DacpMethodTableFieldData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpMethodTableFieldData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpMethodTableFieldData Structure"
helpviewer.keywords:
  - "DacpMethodTableFieldData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpMethodTableFieldData Structure

Defines a transport buffer for method table field information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpMethodTableFieldData : ZeroInit<DacpMethodTableFieldData>
{
    WORD wNumInstanceFields;
    WORD wNumStaticFields;
    WORD wNumThreadStaticFields;

    CLRDATA_ADDRESS FirstField; // If non-null, you can retrieve more
    
    WORD wContextStaticOffset;
    WORD wContextStaticsSize;
    
    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr)
    {
        return sos->GetMethodTableFieldData(addr, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `wNumInstanceFields` | The number of instance fields. |
| `wNumStaticFields` | The number of static fields. |
| `wNumThreadStaticFields` | The number of thread-static fields. |
| `FirstField` | The address of the first field. If this member is non-null, you can retrieve more fields. |
| `wContextStaticOffset` | The context-static field offset. |
| `wContextStaticsSize` | The size of the context-static fields. |
| `Request` | Populates the structure from a method table address by calling `ISOSDacInterface::GetMethodTableFieldData`. |

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
