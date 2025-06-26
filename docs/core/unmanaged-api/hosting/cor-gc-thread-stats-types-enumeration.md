---
description: "Learn more about: COR_GC_THREAD_STATS_TYPES Enumeration"
title: "COR_GC_THREAD_STATS_TYPES Enumeration"
ms.date: "03/30/2017"
api_name:
  - "COR_GC_THREAD_STATS_TYPES"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "COR_GC_THREAD_STATS_TYPES"
helpviewer_keywords:
  - "COR_GC_THREAD_STATS_TYPES enumeration [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# COR_GC_THREAD_STATS_TYPES Enumeration

Indicates the garbage collection statistics for a thread.

## Syntax

```cpp
typedef enum {
    COR_GC_THREAD_HAS_PROMOTED_BYTES  = 0x00000001
} COR_GC_THREAD_STATS_TYPES;
```

## Members

|Member|Description|
|------------|-----------------|
|`COR_GC_THREAD_HAS_PROMOTED_BYTES`|The thread has bytes that were promoted in the most recent garbage collection.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** GCHost.idl, GCHost.h

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Hosting Enumerations](hosting-enumerations.md)
