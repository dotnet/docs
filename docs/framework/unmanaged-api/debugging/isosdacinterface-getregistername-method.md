---
description: "Learn more about: ISOSDacInterface::GetRegisterName Method"
title: "ISOSDacInterface::GetRegisterName Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetRegisterName Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetRegisterName Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetRegisterName Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetRegisterName Method

Retrieves the display name for a runtime register identifier.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetRegisterName([in] int regName, [in] unsigned int count, [out] wchar_t *buffer, [out] unsigned int *pNeeded);
```

## Parameters

`regName`\
[in] The register identifier whose name to retrieve.

`count`\
[in] The number of characters available in `buffer`.

`buffer`\
[out] A pointer to a buffer that receives the register name.

`pNeeded`\
[out] A pointer to the number of characters required for the register name.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 81st slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  


## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
