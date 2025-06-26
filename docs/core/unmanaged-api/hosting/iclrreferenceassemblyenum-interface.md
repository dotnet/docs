---
description: "Learn more about: ICLRReferenceAssemblyEnum Interface"
title: "ICLRReferenceAssemblyEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRReferenceAssemblyEnum"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRReferenceAssemblyEnum"
helpviewer_keywords:
  - "ICLRReferenceAssemblyEnum interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRReferenceAssemblyEnum Interface

Provides methods that allow the host to manipulate the set of assemblies referenced by a file or stream using assembly identity data that is internal to the common language runtime (CLR), without needing to create or understand those identities.

## Methods

|Method|Description|
|------------|-----------------|
|[Get Method](iclrreferenceassemblyenum-get-method.md)|Gets the assembly identity at the supplied index.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
- [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
