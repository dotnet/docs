---
description: "Learn more about: ICLRAssemblyReferenceList Interface"
title: "ICLRAssemblyReferenceList Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRAssemblyReferenceList"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRAssemblyReferenceList"
helpviewer_keywords:
  - "ICLRAssemblyReferenceList interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRAssemblyReferenceList Interface

Manages a list of assemblies that are loaded by the common language runtime (CLR) and not by the host.

## Methods

|Method|Description|
|------------|-----------------|
|[IsAssemblyReferenceInList Method](iclrassemblyreferencelist-isassemblyreferenceinlist-method.md)|Gets a value that indicates whether the supplied pointer references an assembly in the list.|
|[IsStringAssemblyReferenceInList Method](iclrassemblyreferencelist-isstringassemblyreferenceinlist-method.md)|Gets a value that indicates whether the supplied name matches the name of an assembly in the list.|

## Remarks

 Call the [ICLRAssemblyIdentityManager::GetCLRAssemblyReferenceList](iclrassemblyidentitymanager-getclrassemblyreferencelist-method.md) method to get a pointer to an instance of `ICLRAssemblyReferenceList`.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
- [IHostAssemblyStore Interface](ihostassemblystore-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
