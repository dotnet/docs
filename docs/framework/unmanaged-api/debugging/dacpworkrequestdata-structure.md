---
description: "Learn more about: DacpWorkRequestData Structure"
title: "DacpWorkRequestData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpWorkRequestData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpWorkRequestData Structure"
helpviewer.keywords:
  - "DacpWorkRequestData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpWorkRequestData Structure

Defines a transport buffer for thread pool work request information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpWorkRequestData : ZeroInit<DacpWorkRequestData>
{
    CLRDATA_ADDRESS Function;
    CLRDATA_ADDRESS Context;
    CLRDATA_ADDRESS NextWorkRequest;
        
    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr)
    {
        return sos->GetWorkRequestData(addr, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `Function` | The address of the function associated with the work request. |
| `Context` | The address of the context associated with the work request. |
| `NextWorkRequest` | The address of the next work request. |
| `Request` | Populates the structure by calling `ISOSDacInterface::GetWorkRequestData`. |

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
