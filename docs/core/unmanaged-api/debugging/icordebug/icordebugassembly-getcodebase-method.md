---
description: "Learn more about: ICorDebugAssembly::GetCodeBase Method"
title: "ICorDebugAssembly::GetCodeBase Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAssembly.GetCodeBase"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAssembly::GetCodeBase"
helpviewer_keywords:
  - "GetCodeBase method [.NET debugging]"
  - "ICorDebugAssembly::GetCodeBase method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAssembly::GetCodeBase Method

This method is not implemented.

## Syntax

```cpp
HRESULT GetCodeBase (
    [in] ULONG32  cchName,
    [out] ULONG32 *pcchName,
    [out, size_is(cchName), length_is(*pcchName)]
        WCHAR szName[]
);
```
