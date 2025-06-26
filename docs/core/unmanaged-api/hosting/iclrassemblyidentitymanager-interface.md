---
description: "Learn more about: ICLRAssemblyIdentityManager Interface"
title: "ICLRAssemblyIdentityManager Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRAssemblyIdentityManager"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRAssemblyIdentityManager"
helpviewer_keywords:
  - "ICLRAssemblyIdentityManager interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRAssemblyIdentityManager Interface

Provides methods that support communication between the host and the common language runtime (CLR) about assemblies.

## Methods

|Method|Description|
|------------|-----------------|
|[GetBindingIdentityFromFile Method](iclrassemblyidentitymanager-getbindingidentityfromfile-method.md)|Gets the assembly identity binding data for the assembly at the specified file path.|
|[GetBindingIdentityFromStream Method](iclrassemblyidentitymanager-getbindingidentityfromstream-method.md)|Gets the canonical assembly identity data for the assembly in the specified stream.|
|[GetCLRAssemblyReferenceList Method](iclrassemblyidentitymanager-getclrassemblyreferencelist-method.md)|Gets an [ICLRAssemblyReferenceList](iclrassemblyreferencelist-interface.md) instance from the supplied list of partial assembly identities.|
|[GetProbingAssembliesFromReference Method](iclrassemblyidentitymanager-getprobingassembliesfromreference-method.md)|Gets an [ICLRProbingAssemblyEnum](iclrprobingassemblyenum-interface.md) enumerator for the assembly identities referenced by the assembly with the specified identity.|
|[GetReferencedAssembliesFromFile Method](iclrassemblyidentitymanager-getreferencedassembliesfromfile-method.md)|Gets an [ICLRReferenceAssemblyEnum](iclrreferenceassemblyenum-interface.md) instance that contains a list of assemblies referenced by the assembly at the specified file path.|
|[GetReferencedAssembliesFromStream Method](iclrassemblyidentitymanager-getreferencedassembliesfromstream-method.md)|Gets a pointer to an `ICLRReferenceAssemblyEnum` object that contains assembly identity data for the assemblies referenced by the assembly in the specified stream.|
|[IsStronglyNamed Method](iclrassemblyidentitymanager-isstronglynamed-method.md)|Gets a value that indicates whether the specified assembly is strongly named.|

## Remarks

 Use `ICLRAssemblyIdentityManager` to get instances of `ICLRAssemblyReferenceList` and to enumerate assembly identities.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)
- [ICLRProbingAssemblyEnum Interface](iclrprobingassemblyenum-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
