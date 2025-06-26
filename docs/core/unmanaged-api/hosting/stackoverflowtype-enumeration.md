---
description: "Learn more about: StackOverflowType Enumeration"
title: "StackOverflowType Enumeration"
ms.date: "03/30/2017"
api_name:
  - "StackOverflowType"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "StackOverflowType"
helpviewer_keywords:
  - "StackOverflowType enumeration [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# StackOverflowType Enumeration

Contains values that indicate the underlying cause of a stack overflow event.

## Syntax

```cpp
typedef enum {
    SO_Managed,
    SO_ClrEngine,
    SO_Other
} StackOverflowType;
```

## Members

|Member|Description|
|------------|-----------------|
|`SO_ClrEngine`|The stack overflow was caused by the execution engine.|
|`SO_Managed`|The stack overflow was caused by managed code.|
|`SO_Other`|The stack overflow was caused by unmanaged code.|

## Remarks

 This information is passed to the host through a call to the [IActionOnCLREvent::OnEvent](iactiononclrevent-onevent-method.md) method.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Hosting Enumerations](hosting-enumerations.md)
