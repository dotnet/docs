---
description: "Learn more about: ICorDebugCode::GetEnCRemapSequencePoints Method"
title: "ICorDebugCode::GetEnCRemapSequencePoints Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCode.GetEnCRemapSequencePoints"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCode::GetEnCRemapSequencePoints"
helpviewer_keywords:
  - "GetEnCRemapSequencePoints method [.NET debugging]"
  - "ICorDebugCode::GetEnCRemapSequencePoints method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugCode::GetEnCRemapSequencePoints Method

This method is not implemented in the current version of the .NET Framework.

## Syntax

```cpp
HRESULT GetEnCRemapSequencePoints(
    [in] ULONG32 cMap,
    [out] ULONG32 *pcMap,
    [out, size_is(cMap), length_is(*pcMap)]
        ULONG32 offsets[]
);
```
