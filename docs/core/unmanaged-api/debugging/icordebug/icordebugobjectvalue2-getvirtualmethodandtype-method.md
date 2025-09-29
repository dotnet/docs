---
description: "Learn more about: ICorDebugObjectValue2::GetVirtualMethodAndType Method"
title: "ICorDebugObjectValue2::GetVirtualMethodAndType Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugObjectValue2.GetVirtualMethodAndType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugObjectValue2::GetVirtualMethodAndType"
helpviewer_keywords:
  - "GetVirtualMethodAndType method [.NET debugging]"
  - "ICorDebugObjectValue2::GetVirtualMethodAndType method"
topic_type:
  - "apiref"
---
# ICorDebugObjectValue2::GetVirtualMethodAndType Method

This method is not yet implemented.

## Syntax

```cpp
HRESULT GetVirtualMethodAndType (
    [in] mdMemberRef          memberRef,
    [out] ICorDebugFunction   **ppFunction,
    [out] ICorDebugType       **ppType
);
```

## Remarks

Gets interface pointers to the "ICorDebugFunction" and "ICorDebugType" instances that represent the most derived method and type for the specified member reference.

## See also
