---
description: "Learn more about: IHostAssemblyManager Interface"
title: "IHostAssemblyManager Interface"
ms.date: "03/30/2017"
api_name:
  - "IHostAssemblyManager"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostAssemblyManager"
helpviewer_keywords:
  - "IHostAssemblyManager interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostAssemblyManager Interface

Provides methods that allow a host to specify sets of assemblies that should be loaded by the common language runtime (CLR) or by the host.

## Methods

|Method|Description|
|------------|-----------------|
|[GetAssemblyStore Method](ihostassemblymanager-getassemblystore-method.md)|Gets an interface pointer to an [IHostAssemblyStore](ihostassemblystore-interface.md) that represents the list of assemblies loaded by the host.|
|[GetNonHostStoreAssemblies Method](ihostassemblymanager-getnonhoststoreassemblies-method.md)|Gets an interface pointer to an [ICLRAssemblyReferenceList](iclrassemblyreferencelist-interface.md) that represents the list of assemblies that the host expects the CLR to load.|

## Remarks

 The host is not required to implement `IHostAssemblyManager` or `IHostAssemblyStore`. If the host does implement `IHostAssemblyManager`, it must also implement `IHostAssemblyStore`.

 The runtime queries for an `IHostAssemblyManager` by calling [IHostControl::GetHostManager](ihostcontrol-gethostmanager-method.md) upon initialization with an `IID` of IID_IHostAssemblyManager.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)
- [IHostAssemblyStore Interface](ihostassemblystore-interface.md)
- [IHostControl Interface](ihostcontrol-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
