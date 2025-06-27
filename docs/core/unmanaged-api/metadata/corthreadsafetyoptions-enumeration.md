---
description: "Learn more about: CorThreadSafetyOptions Enumeration"
title: "CorThreadSafetyOptions Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorThreadSafetyOptions"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorThreadSafetyOptions"
helpviewer_keywords:
  - "CorThreadSafetyOptions enumeration [.NET Framework metadata]"
topic_type:
  - "apiref"
---

# CorThreadSafetyOptions Enumeration

Specifies flags to select options for thread safety.

## Syntax

```cpp
typedef enum CorThreadSafetyOptions {
    MDThreadSafetyDefault       = 0x00000000,
    MDThreadSafetyOff           = 0x00000000,
    MDThreadSafetyOn            = 0x00000001,
} CorThreadSafetyOptions;
```

## Members

|Member|Description|
|------------|-----------------|
|`MDThreadSafetyDefault`|Default value. Same as `MDThreadSafetyOff`.|
|`MDThreadSafetyOff`|Indicates that a reader/writer lock cannot be set.|
|`MDThreadSafetyOn`|Indicates that a reader/writer lock can be set.|

## Requirements

**Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

**Header:** CorHdr.h

**.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Enumerations](metadata-enumerations.md)
