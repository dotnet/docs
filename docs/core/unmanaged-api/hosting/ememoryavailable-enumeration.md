---
description: "Learn more about: EMemoryAvailable Enumeration"
title: "EMemoryAvailable Enumeration"
ms.date: "03/30/2017"
api_name:
  - "EMemoryAvailable"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "EMemoryAvailable"
helpviewer_keywords:
  - "EMemoryAvailable enumeration [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# EMemoryAvailable Enumeration

Contains values that indicate the amount of free physical memory on the computer. These values logically map to the events for high and low memory returned from the `CreateMemoryResourceNotification` function in the Windows API.

## Syntax

```cpp
typedef enum {
    eMemoryAvailableLow     = 1,
    eMemoryAvailableNeutral = 2,
    eMemoryAvailableHigh    = 3
} EMemoryAvailable;
```

## Members

|Member|Description|
|------------|-----------------|
|`eMemoryAvailableHigh`|Plenty of physical memory is available.|
|`eMemoryAvailableLow`|Very little physical memory is available.|
|`eMemoryAvailableNeutral`|The available physical memory is neutral.|

## Remarks

 This value is passed by the host to the common language runtime (CLR) by using a call to the [ICLRMemoryNotificationCallback::OnMemoryNotification](iclrmemorynotificationcallback-onmemorynotification-method.md) method.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Hosting Enumerations](hosting-enumerations.md)
