---
description: "Learn more about: ICLRRuntimeHost::Stop Method"
title: "ICLRRuntimeHost::Stop Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRRuntimeHost.Stop"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRRuntimeHost::Stop"
helpviewer_keywords:
  - "ICLRRuntimeHost::Stop method [.NET Framework hosting]"
  - "Stop method, ICLRRuntimeHost interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRRuntimeHost::Stop Method

Stops the execution of code by the common language runtime (CLR).

> [!IMPORTANT]
> This method does not release resources to the host, unload application domains, or destroy threads. You must terminate the process to release these resources.

## Syntax

```cpp
HRESULT Stop();
```

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`Stop` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRRuntimeHost Interface](iclrruntimehost-interface.md)
