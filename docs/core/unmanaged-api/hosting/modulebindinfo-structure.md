---
description: "Learn more about: ModuleBindInfo Structure"
title: "ModuleBindInfo Structure"
ms.date: "03/30/2017"
api_name:
  - "ModuleBindInfo"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ModuleBindInfo"
helpviewer_keywords:
  - "ModuleBindInfo structure [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ModuleBindInfo Structure

Provides detailed information about the referenced module and the assembly that contains it.

## Syntax

```cpp
typedef struct _ModuleBindInfo {
    DWORD    dwAppDomainId;
    LPCWSTR  lpAssemblyIdentity;
    LPCWSTR  lpModuleName
} ModuleBindInfo;
```

## Members

|Member|Description|
|------------|-----------------|
|`dwAppDomainId`|A unique identifier for the `IStream` that is returned by a call to the [IHostAssemblyStore::ProvideModule](ihostassemblystore-providemodule-method.md) method from which the referenced module is to be loaded.|
|`lpAssemblyIdentity`|A unique identifier for the assembly that contains the referenced module.|
|`lpModuleName`|The name of the referenced module.|

## Remarks

 `ModuleBindInfo` is passed as a parameter to `IHostAssemblyStore::ProvideModule`. The host supplies the unique identifier `dwAppDomainId` to the common language runtime (CLR). After a call to the [IHostAssemblyStore::ProvideAssembly](ihostassemblystore-provideassembly-method.md) method returns, the runtime uses the identifier to determine whether the contents of the `IStream` have been mapped. If so, the runtime loads the existing copy rather than remapping the stream. The runtime also uses this identifier as a lookup key for streams that are returned from calls to the `IHostAssemblyStore::ProvideAssembly` method. Therefore, the identifier must be unique for module requests as well as for assembly requests.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.idl

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Hosting Structures](hosting-structures.md)
- [AssemblyBindInfo Structure](assemblybindinfo-structure.md)
- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
- [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)
- [IHostAssemblyManager Interface](ihostassemblymanager-interface.md)
