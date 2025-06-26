---
description: "Learn more about: ICLRProbingAssemblyEnum Interface"
title: "ICLRProbingAssemblyEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRProbingAssemblyEnum"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRProbingAssemblyEnum"
helpviewer_keywords:
  - "ICLRProbingAssemblyEnum interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRProbingAssemblyEnum Interface

Provides methods that enable the host to get the probing identities of an assembly by using the assembly's identity information that is internal to the common language runtime (CLR), without needing to create or understand that identity.

## Methods

|Method|Description|
|------------|-----------------|
|[Get Method](iclrprobingassemblyenum-get-method.md)|Gets the assembly identity at the specified index.|

## Remarks

 Methods such as [ICLRAssemblyIdentityManager::GetProbingAssembliesFromReference](iclrassemblyidentitymanager-getprobingassembliesfromreference-method.md) return an `ICLRProbingAssemblyEnum` instance.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
- [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
