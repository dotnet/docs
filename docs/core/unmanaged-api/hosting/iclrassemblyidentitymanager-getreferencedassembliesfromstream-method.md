---
description: "Learn more about: ICLRAssemblyIdentityManager::GetReferencedAssembliesFromStream Method"
title: "ICLRAssemblyIdentityManager::GetReferencedAssembliesFromStream Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRAssemblyIdentityManager.GetReferencedAssembliesFromStream"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRAssemblyIdentityManager::GetReferencedAssembliesFromStream"
helpviewer_keywords:
  - "ICLRAssemblyIdentityManager::GetReferencedAssembliesFromStream method [.NET Framework hosting]"
  - "GetReferencedAssembliesFromStream method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRAssemblyIdentityManager::GetReferencedAssembliesFromStream Method

Gets a pointer to an [ICLRReferenceAssemblyEnum](iclrreferenceassemblyenum-interface.md) object that contains assembly identity data for the assemblies referenced by the assembly in the specified stream.

## Syntax

```cpp
HRESULT GetReferencedAssembliesFromStream (
    [in]  IStream *pStream,
    [in]  DWORD    dwFlags,
    [in]  ICLRAssemblyReferenceList  *pExcludeAssembliesList,
    [out] ICLRReferenceAssemblyEnum **ppReferenceEnum
);
```

## Parameters

 `pStream`
 [in] An interface pointer to an `IStream` containing the assembly to be evaluated.

 `dwFlags`
 [in] Provided for future extensibility. CLR_ASSEMBLY_IDENTITY_FLAGS_DEFAULT is the only value that the current version of the common language runtime (CLR) supports.

 `pExcludeAssembliesList`
 [in] A pointer to an [ICLRAssemblyReferenceList](iclrassemblyreferencelist-interface.md) object that contains assembly identity data for the assemblies to be excluded from `ppReferenceEnum`.

 `ppReferenceEnum`
 [out] A pointer to the address of an `ICLRReferenceAssemblyEnum` object that contains assembly identity data for the assemblies referenced by the assembly in `pStream`, excluding the assemblies in `pExcludeAssembliesList`.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The method returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 The caller can choose to exclude a set of known assembly references from the returned list. This set is defined by `pExcludeAssembliesList`.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
- [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)
- [ICLRReferenceAssemblyEnum Interface](iclrreferenceassemblyenum-interface.md)
