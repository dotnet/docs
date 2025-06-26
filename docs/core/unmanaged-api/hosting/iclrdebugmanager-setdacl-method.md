---
description: "Learn more about: ICLRDebugManager::SetDacl Method"
title: "ICLRDebugManager::SetDacl Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRDebugManager.SetDacl"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRDebugManager::SetDacl"
helpviewer_keywords:
  - "SetDacl method [.NET Framework hosting]"
  - "ICLRDebugManager::SetDacl method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRDebugManager::SetDacl Method

This method is not implemented.

## Syntax

```cpp
HRESULT SetDacl (
    [in] PACL pacl
);
```

## Parameters

 `pacl`
 [in] A pointer to the Access Control List (ACL).

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
- [GetDacl Method](iclrdebugmanager-getdacl-method.md)
- [IHostControl Interface](ihostcontrol-interface.md)
