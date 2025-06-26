---
description: "Learn more about: ICLRHostProtectionManager::SetEagerSerializeGrantSets Method"
title: "ICLRHostProtectionManager::SetEagerSerializeGrantSets Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRHostProtectionManager.SetEagerSerializeGrantSets"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRHostProtectionManager::SetEagerSerializeGrantSets"
helpviewer_keywords:
  - "SetEagerSerializeGrantSets method [.NET Framework hosting]"
  - "ICLRHostProtectionManager::SetEagerSerializeGrantSets method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRHostProtectionManager::SetEagerSerializeGrantSets Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.

## Syntax

```cpp
HRESULT SetEagerSerializeGrantSets ();
```

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`SetEagerSerializeGrantSets` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICLRHostProtectionManager Interface](iclrhostprotectionmanager-interface.md)
