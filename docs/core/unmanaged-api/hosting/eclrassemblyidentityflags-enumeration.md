---
description: "Learn more about: ECLRAssemblyIdentityFlags Enumeration"
title: "ECLRAssemblyIdentityFlags Enumeration"
ms.date: "03/30/2017"
api_name:
  - "ECLRAssemblyIdentityFlags"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ECLRAssemblyIdentityFlags"
helpviewer_keywords:
  - "ECLRAssemblyIdentityFlags enumeration [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ECLRAssemblyIdentityFlags Enumeration

Indicates the type of an assembly's identity.

## Syntax

```cpp
typedef enum _CLRAssemblyIdentityFlags {
    CLR_ASSEMBLY_IDENTITY_FLAGS_DEFAULT = 0
} ECLRAssemblyIdentityFlags;
```

## Members

|Member|Description|
|------------|-----------------|
|`CLR_ASSEMBLY_IDENTITY_FLAGS_DEFAULT`|The identity is canonicalized.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Hosting Enumerations](hosting-enumerations.md)
