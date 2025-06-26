---
description: "Learn more about: IHostTaskManager::GetStackGuarantee Method"
title: "IHostTaskManager::GetStackGuarantee Method"
ms.date: "03/30/2017"
api_name:
  - "IHostTaskManager.GetStackGuarantee"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostTaskManager::GetStackGuarantee"
helpviewer_keywords:
  - "GetStackGuarantee method [.NET Framework hosting]"
  - "IHostTaskManager::GetStackGuarantee method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostTaskManager::GetStackGuarantee Method

Gets the amount of stack space that is guaranteed to be available after a stack operation completes, but before the closing of a process.

## Syntax

```cpp
HRESULT GetStackGuarantee(
    [out] ULONG *pGuarantee
);
```

## Parameters

 `pGuarantee`
 [out] A pointer to the number of bytes that are available.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
