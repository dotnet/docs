---
description: "Learn more about: ICLRTaskManager::SetUILocale Method"
title: "ICLRTaskManager::SetUILocale Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRTaskManager.SetUILocale"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRTaskManager::SetUILocale"
helpviewer_keywords:
  - "ICLRTaskManager::SetUILocale method [.NET Framework hosting]"
  - "SetUILocale method, ICLRTaskManager interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRTaskManager::SetUILocale Method

Notifies the common language runtime (CLR) that the host has modified the user interface (UI) locale, or culture, on the currently executing task.

## Syntax

```cpp
HRESULT SetUILocale (
    [in] LCID lcid
);
```

## Parameters

 `lcid`
 [in] The locale identifier value that maps to the newly assigned geographical culture and language for the user interface.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`SetUILocale` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 `SetUILocale` provides an opportunity for the host to execute any mechanisms it might have for the synchronization of locales.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
