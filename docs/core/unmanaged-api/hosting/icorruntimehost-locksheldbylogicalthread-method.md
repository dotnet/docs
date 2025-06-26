---
description: "Learn more about: ICorRuntimeHost::LocksHeldByLogicalThread Method"
title: "ICorRuntimeHost::LocksHeldByLogicalThread Method"
ms.date: "03/30/2017"
api_name:
  - "ICorRuntimeHost.LocksHeldByLogicalThread"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorRuntimeHost::LocksHeldByLogicalThread"
helpviewer_keywords:
  - "ICorRuntimeHost::LocksHeldByLogicalThread method [.NET Framework hosting]"
  - "LocksHeldByLogicalThread method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICorRuntimeHost::LocksHeldByLogicalThread Method

Retrieves the number of locks that current thread holds.

 This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.

## Syntax

```cpp
HRESULT LocksHeldByLogicalThread(
    [out] DWORD *pCount
);
```

## Parameters

 `pCount`
 [out] A pointer to the number of locks that the current thread holds.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** 1.0, 1.1

## See also

- [ICorRuntimeHost Interface](icorruntimehost-interface.md)
