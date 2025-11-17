---
description: "Learn more about: COR_PUB_ENUMPROCESS Enumeration"
title: "COR_PUB_ENUMPROCESS Enumeration"
ms.date: "03/30/2017"
api_name:
  - "COR_PUB_ENUMPROCESS"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "COR_PUB_ENUMPROCESS"
helpviewer_keywords:
  - "COR_PUB_ENUMPROCESS enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# COR_PUB_ENUMPROCESS Enumeration

Identifies the type of process to be enumerated.

## Syntax

```cpp
typedef enum {
    COR_PUB_MANAGEDONLY    = 0x00000001
} COR_PUB_ENUMPROCESS;
```

## Members

| Member name           | Description        |
|-----------------------|--------------------|
| `COR_PUB_MANAGEDONLY` | A managed process. |

## Remarks

 The current version of the unmanaged debugging API enumerates only managed processes.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorPub.idl, CorPub.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
