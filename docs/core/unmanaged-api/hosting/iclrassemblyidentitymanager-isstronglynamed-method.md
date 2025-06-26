---
description: "Learn more about: ICLRAssemblyIdentityManager::IsStronglyNamed Method"
title: "ICLRAssemblyIdentityManager::IsStronglyNamed Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRAssemblyIdentityManager.IsStronglyNamed"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRAssemblyIdentityManager::IsStronglyNamed"
helpviewer_keywords:
  - "IsStronglyNamed method [.NET Framework hosting]"
  - "ICLRAssemblyIdentityManager::IsStronglyNamed method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRAssemblyIdentityManager::IsStronglyNamed Method

Gets a value that indicates whether the specified assembly is strongly named.

## Syntax

```cpp
RESULT IsStronglyNamed (
    [in]  LPCWSTR  pwzAssemblyIdentity,
    [out] BOOL    *pbIsStronglyNamed
);
```

## Parameters

 `pwzAssemblyIdentity`
 [in] The opaque canonical assembly identity data of the assembly to be evaluated.

 `pbIsStronglyNamed`
 [out] `true`, if the assembly referenced by the `pwzAssemblyIdentity` parameter is strongly named; otherwise, `false`.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The method returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
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

- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
