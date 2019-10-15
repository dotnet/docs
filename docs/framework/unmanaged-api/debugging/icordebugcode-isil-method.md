---
title: "ICorDebugCode::IsIL Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCode.IsIL"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCode::IsIL"
helpviewer_keywords:
  - "ICorDebugCode::IsIL method [.NET Framework debugging]"
  - "IsIL method [.NET Framework debugging]"
ms.assetid: 132ef8cc-d938-43f3-b8f2-e3b97c0ceb33
topic_type:
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugCode::IsIL Method

Gets a value that indicates whether this "ICorDebugCode" represents code that was compiled in Microsoft intermediate language (MSIL).

## Syntax

```cpp
HRESULT IsIL (
    [out] BOOL       *pbIL
);
```

## Parameters

`pbIL`  
[out] `true` if this `ICorDebugCode` represents code that was compiled in MSIL; otherwise, `false`.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** CorDebug.idl, CorDebug.h

**Library:** CorGuids.lib

**.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
