---
description: "Learn more about: ICLRRuntimeHost::GetCurrentAppDomainId Method"
title: "ICLRRuntimeHost::GetCurrentAppDomainId Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRRuntimeHost.GetCurrentAppDomainId"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRRuntimeHost::GetCurrentAppDomainId"
helpviewer_keywords:
  - "ICLRRuntimeHost::GetCurrentAppDomainId method [.NET Framework hosting]"
  - "GetCurrentAppDomainId method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRRuntimeHost::GetCurrentAppDomainId Method

Gets the numeric identifier of the <xref:System.AppDomain> that is currently executing.

## Syntax

```cpp
HRESULT GetCurrentAppDomainId(
    [out] DWORD* pdwAppDomainId
);
```

## Parameters

 `pdwAppDomainId`
 [out] The numeric identifier of the <xref:System.AppDomain> that is currently executing.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`GetCurrentAppDomainId` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 The `pdwAppDomainId` parameter is set to the value of the <xref:System.AppDomain.Id%2A> property of the <xref:System.AppDomain> in which the current thread is executing.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- <xref:System.AppDomain>
- <xref:System.AppDomainManager>
- [ICLRRuntimeHost Interface](iclrruntimehost-interface.md)
