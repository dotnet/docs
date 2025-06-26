---
description: "Learn more about: ICLRAssemblyReferenceList::IsStringAssemblyReferenceInList Method"
title: "ICLRAssemblyReferenceList::IsStringAssemblyReferenceInList Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRAssemblyReferenceList.IsStringAssemblyReferenceInList"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRAssemblyReferenceList::IsStringAssemblyReferenceInList"
helpviewer_keywords:
  - "ICLRAssemblyReferenceList::IsStringAssemblyReferenceInList method [.NET Framework hosting]"
  - "IsStringAssemblyReferenceInList method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRAssemblyReferenceList::IsStringAssemblyReferenceInList Method

Gets a value that indicates whether the supplied name matches the name of an assembly in the list.

## Syntax

```cpp
HRESULT IsStringAssemblyReferenceInList (
    [in] LPCWSTR pwzAssemblyName
);
```

## Parameters

 `pwzAssemblyName`
 [in] The name of the assembly for which to search.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The string appears in the list.|
|S_FALSE|The string does not appear in the list.|
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the common language runtime is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
- [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)
- [IHostAssemblyManager Interface](ihostassemblymanager-interface.md)
- [IHostAssemblyStore Interface](ihostassemblystore-interface.md)
