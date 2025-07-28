---
description: "Learn more about: CorSaveSize Enumeration"
title: "CorSaveSize Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorSaveSize"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorSaveSize"
topic_type:
  - "apiref"
---
# CorSaveSize Enumeration

Contains values indicating the level of precision required when querying for the size of a save operation.

## Syntax

```cpp
typedef enum CorSaveSize {
    cssAccurate                = 0x0000,
    cssQuick                   = 0x0001,
    cssDiscardTransientCAs     = 0x0002
} CorSaveSize;
```

## Members

| Member | Description |
|------------|-----------------|
| `cssAccurate` | Specifies that the return value should be exact. |
| `cssQuick` | Specifies that the return value should be estimated. |
| `cssDiscardTransientCAs` | Specifies that discardable types should be removed. |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorHdr.h
