---
description: "Learn more about: HOST_TYPE Enumeration"
title: "HOST_TYPE Enumeration"
ms.date: "03/30/2017"
api_name:
  - "HOST_TYPE"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "HOST_TYPE"
helpviewer_keywords:
  - "HOST_TYPE enumeration [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# HOST_TYPE Enumeration

Contains values that specify the type of host that is launching an application.

## Syntax

```cpp
typedef enum {
    HOST_TYPE_DEFAULT     = 0x0,
    HOST_TYPE_APPLAUNCH   = 0x1,
    HOST_TYPE_CORFLAG     = 0x2
} HOST_TYPE;
```

## Members

|Member|Description|
|------------|-----------------|
|`HOST_TYPE_APPLAUNCH`|Launch the application from AppLaunch.exe.<br /><br /> Use this value for partially-trusted applications.|
|`HOST_TYPE_CORFLAG`|Launch the application directly. That is, launch the application from its own .exe file.<br /><br /> Use this value for fully-trusted applications.|
|`HOST_TYPE_DEFAULT`|Same as HOST_TYPE_APPLAUNCH.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Hosting Enumerations](hosting-enumerations.md)
