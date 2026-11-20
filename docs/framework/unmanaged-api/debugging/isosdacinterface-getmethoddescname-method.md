---
description: "Learn more about: ISOSDacInterface::GetMethodDescName Method"
title: "ISOSDacInterface::GetMethodDescName Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetMethodDescName Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetMethodDescName Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetMethodDescName Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetMethodDescName Method

Gets the name that corresponds to a MethodDesc address.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetMethodDescName(CLRDATA_ADDRESS methodDesc, unsigned int count, wchar_t *name, unsigned int *pNeeded);
```

## Parameters

`methodDesc`\
[in] The address of the MethodDesc.

`count`\
[in] The size of the `name` buffer, in wide characters.

`name`\
[out] A buffer that receives the MethodDesc name.

`pNeeded`\
[out] The number of wide characters required for the MethodDesc name.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 23rd slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [ISOSDacInterface::GetMethodDescData Method](isosdacinterface-getmethoddescdata-method.md)
- [ISOSDacInterface::GetMethodDescPtrFromIP Method](isosdacinterface-getmethoddescptrfromip-method.md)
- [ISOSDacInterface::GetMethodDescPtrFromFrame Method](isosdacinterface-getmethoddescptrfromframe-method.md)
- [ISOSDacInterface::GetMethodDescFromToken Method](isosdacinterface-getmethoddescfromtoken-method.md)
