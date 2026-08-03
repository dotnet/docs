---
description: "Learn more about: DacpCOMInterfacePointerData Structure"
title: "DacpCOMInterfacePointerData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpCOMInterfacePointerData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpCOMInterfacePointerData Structure"
helpviewer.keywords:
  - "DacpCOMInterfacePointerData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpCOMInterfacePointerData Structure

Defines a transport buffer for COM interface pointer information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpCOMInterfacePointerData : ZeroInit<DacpCOMInterfacePointerData>
{
    CLRDATA_ADDRESS methodTable;
    CLRDATA_ADDRESS interfacePtr;
    CLRDATA_ADDRESS comContext;
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `methodTable` | The address of the method table for the interface. |
| `interfacePtr` | The address of the COM interface pointer. |
| `comContext` | The address of the COM context associated with the interface pointer. |

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
