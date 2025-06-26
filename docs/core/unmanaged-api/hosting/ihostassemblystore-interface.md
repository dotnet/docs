---
description: "Learn more about: IHostAssemblyStore Interface"
title: "IHostAssemblyStore Interface"
ms.date: "03/30/2017"
api_name: 
  - "IHostAssemblyStore"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostAssemblyStore"
helpviewer_keywords: 
  - "IHostAssemblyStore interface [.NET Framework hosting]"
ms.assetid: cccb650f-abe0-41e2-9fd1-b383788eb1f6
topic_type: 
  - "apiref"
---
# IHostAssemblyStore Interface

Provides methods that allow a host to load assemblies and modules independently of the common language runtime (CLR).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ProvideAssembly Method](ihostassemblystore-provideassembly-method.md)|Gets a reference to an assembly that is not referenced by the [ICLRAssemblyReferenceList](iclrassemblyreferencelist-interface.md) returned from a call to [IHostAssemblyManager::GetNonHostStoreAssemblies](ihostassemblymanager-getnonhoststoreassemblies-method.md).|  
|[ProvideModule Method](ihostassemblystore-providemodule-method.md)|Resolves a module within an assembly or a linked (not embedded) resource file.|  
  
## Remarks  

 `IHostAssemblyStore` provides a way for a host to load assemblies efficiently based on assembly identity. The host loads assemblies by returning `IStream` instances that point directly at the bytes.  
  
 The CLR determines whether a host has implemented `IHostAssemblyStore` by calling `IHostAssemblyManager::GetNonHostAssemblyStores` upon initialization. This allows the host, for example, to control binding to user assemblies, but to rely on the runtime to bind to .NET Framework assemblies.  
  
> [!NOTE]
> In providing an implementation of `IHostAssemblyStore`, the host specifies its intent to resolve all assemblies that are not referenced by the `ICLRAssemblyReferenceList` returned from `IHostAssemblyManager::GetNonHostStoreAssemblies`.  
  
> [!NOTE]
> The .NET Framework version 2.0 does not provide a way for the host to load the native image of an assembly, as provided by the [Native Image Generator (Ngen.exe)](../../tools/ngen-exe-native-image-generator.md) utility.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)
- [IHostAssemblyManager Interface](ihostassemblymanager-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
