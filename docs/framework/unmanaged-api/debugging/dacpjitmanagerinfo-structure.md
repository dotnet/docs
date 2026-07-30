---
description: "Learn more about: DacpJitManagerInfo Structure"
title: "DacpJitManagerInfo Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpJitManagerInfo Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpJitManagerInfo Structure"
helpviewer.keywords:
  - "DacpJitManagerInfo Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpJitManagerInfo Structure

Defines a transport buffer for JIT manager information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpJitManagerInfo : ZeroInit<DacpJitManagerInfo>
{
    CLRDATA_ADDRESS managerAddr;
    DWORD codeType; // for union below
    CLRDATA_ADDRESS ptrHeapList;    // A HeapList * if IsMiIL(codeType)
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `managerAddr` | The address of the JIT manager. |
| `codeType` | The JIT code type value. |
| `ptrHeapList` | The address of the heap list when `codeType` represents MiIL code. |

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
