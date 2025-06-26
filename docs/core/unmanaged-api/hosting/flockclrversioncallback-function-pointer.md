---
description: "Learn more about: FLockClrVersionCallback Function Pointer"
title: "FLockClrVersionCallback Function Pointer"
ms.date: "03/30/2017"
api_name:
  - "FLockClrVersionCallback"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "FLockClrVersionCallback"
helpviewer_keywords:
  - "FLockClrVersionCallback function pointer [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# FLockClrVersionCallback Function Pointer

Points to a function that the common language runtime (CLR) calls to indicate that initialization has either started or completed.

 This function pointer has been deprecated in the .NET Framework 4.

## Syntax

```cpp
typedef HRESULT (__stdcall *FLockClrVersionCallback) ( );
```

## Remarks

 This function is implemented by the host.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorWks.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [LockClrVersion Function](lockclrversion-function.md)
- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
