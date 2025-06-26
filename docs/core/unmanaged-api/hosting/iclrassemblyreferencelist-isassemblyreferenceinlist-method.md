---
description: "Learn more about: ICLRAssemblyReferenceList::IsAssemblyReferenceInList Method"
title: "ICLRAssemblyReferenceList::IsAssemblyReferenceInList Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRAssemblyReferenceList.IsAssemblyReferenceInList"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRAssemblyReferenceList::IsAssemblyReferenceInList"
helpviewer_keywords:
  - "ICLRAssemblyReferenceList::IsAssemblyReferenceInList method [.NET Framework hosting]"
  - "IsAssemblyReferenceInList method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRAssemblyReferenceList::IsAssemblyReferenceInList Method

Gets a value that indicates whether the supplied pointer refers to an assembly in the list.

## Syntax

```cpp
HRESULT IsAssemblyReferenceInList (
    [in] IUnknown *pName
);
```

## Parameters

 `pName`
 [in] An interface pointer to the assembly for which to search. Valid values are of type `IAssemblyName` or `IReferenceIdentity`.

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
