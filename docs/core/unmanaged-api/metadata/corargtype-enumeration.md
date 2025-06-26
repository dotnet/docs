---
description: "Learn more about: CorArgType Enumeration"
title: "CorArgType Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorArgType"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorArgType"
helpviewer_keywords:
  - "CorArgType enumeration [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# CorArgType Enumeration

Contains values that describe the native type of a runtime handle.

## Syntax

```cpp
typedef enum CorArgType {

    IMAGE_CEE_CS_END        = 0x0,
    IMAGE_CEE_CS_VOID       = 0x1,
    IMAGE_CEE_CS_I4         = 0x2,
    IMAGE_CEE_CS_I8         = 0x3,
    IMAGE_CEE_CS_R4         = 0x4,
    IMAGE_CEE_CS_R8         = 0x5,
    IMAGE_CEE_CS_PTR        = 0x6,
    IMAGE_CEE_CS_OBJECT     = 0x7,
    IMAGE_CEE_CS_STRUCT4    = 0x8,
    IMAGE_CEE_CS_STRUCT32   = 0x9,
    IMAGE_CEE_CS_BYVALUE    = 0xA

} CorArgType;
```

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** CorHdr.h

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Enumerations](metadata-enumerations.md)
