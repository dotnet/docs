---
description: "Learn more about: ICLRDebugManager::GetDacl Method"
title: "ICLRDebugManager::GetDacl Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRDebugManager.GetDacl"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRDebugManager::GetDacl"
helpviewer_keywords:
  - "GetDacl method [.NET Framework hosting]"
  - "ICLRDebugManager::GetDacl method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRDebugManager::GetDacl Method

This method is not implemented.

## Syntax

```cpp
HRESULT GetDacl (
    [out] PACL* ppacl
);
```

## Parameters

 `ppacl`
 [out] An interface pointer to the Access Control List (ACL).

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|E_NOTIMPL|The method is not implemented.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLRDebugManager Interface](iclrdebugmanager-interface.md)
- [SetDacl Method](iclrdebugmanager-setdacl-method.md)
- [IHostControl Interface](ihostcontrol-interface.md)
