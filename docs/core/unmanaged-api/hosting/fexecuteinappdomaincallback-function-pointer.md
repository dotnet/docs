---
description: "Learn more about: FExecuteInAppDomainCallback Function Pointer"
title: "FExecuteInAppDomainCallback Function Pointer"
ms.date: "03/30/2017"
api_name:
  - "FExecuteInAppDomainCallback"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "FExecuteInAppDomainCallback"
helpviewer_keywords:
  - "FExecuteInAppDomainCallback function pointer [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# FExecuteInAppDomainCallback Function Pointer

Points to a function that is called by the common language runtime (CLR) to execute managed code.

 This function pointer has been deprecated in the .NET Framework 4.

## Syntax

```cpp
typedef HRESULT (__stdcall *FExecuteInAppDomainCallback) (
    [in] void  *cookie
);
```

## Parameters

 `cookie`
 [in] A pointer to opaque caller-allocated memory that contains the managed code to be executed.

 The allocation and lifetime of this memory are controlled by the caller (that is, the CLR). This is not CLR managed-heap memory.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorWks.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
