---
description: "Learn more about: IXCLRDataModule::GetName Method"
title: "IXCLRDataModule::GetName Method"
ms.date: "07/30/2026"
api.name:
  - "IXCLRDataModule::GetName Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataModule::GetName Method"
helpviewer.keywords:
  - "IXCLRDataModule::GetName Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "leculver"
ms.author: "leculver"
ai-usage: ai-assisted
---
# IXCLRDataModule::GetName Method

Gets the module's base name.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetName(
    [in] ULONG32 bufLen,
    [out] ULONG32 *nameLen,
    [out, size_is(bufLen)] WCHAR name[]
);
```

## Parameters

`bufLen`\
[in] The number of characters in the `name` buffer.

`nameLen`\
[out] A pointer to the number of characters actually written into the `name` buffer.

`name`\
[out, size_is(bufLen)] A pointer to a character array.

## Remarks

The provided method is part of the `IXCLRDataModule` interface and corresponds to the 30th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
