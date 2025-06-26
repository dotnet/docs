---
description: "Learn more about: EContextType Enumeration"
title: "EContextType Enumeration"
ms.date: "03/30/2017"
api_name:
  - "EContextType"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "EContextType"
helpviewer_keywords:
  - "EContextType enumeration [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# EContextType Enumeration

Describes the security context of the currently executing thread.

## Syntax

```cpp
typedef enum {
    eCurrentContext    = 0x00,
    eRestrictedContext = 0x01
} EContextType;
```

## Members

|Member|Description|
|------------|-----------------|
|`eCurrentContext`|Indicates the context on the current thread at the time the common language runtime (CLR) calls the [IHostSecurityManager::GetSecurityContext](ihostsecuritymanager-getsecuritycontext-method.md) method, or the context requested by the CLR in a call to the [IHostSecurityManager::SetSecurityContext](ihostsecuritymanager-setsecuritycontext-method.md) method.|
|`eRestrictedContext`|Indicates a context over which the host has lower privileges, such as the garbage collector, or class or module constructors.|

## Remarks

 The CLR supplies one of the `EContextType` values as a parameter value in calls to the `IHostSecurityManager::GetSecurityContext` and `IHostSecurityManager::SetSecurityContext` methods.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IHostSecurityContext Interface](ihostsecuritycontext-interface.md)
- [IHostSecurityManager Interface](ihostsecuritymanager-interface.md)
- [Hosting Enumerations](hosting-enumerations.md)
