---
description: "Learn more about: COR_GC_THREAD_STATS Structure"
title: "COR_GC_THREAD_STATS Structure"
ms.date: "03/30/2017"
api_name:
  - "COR_GC_THREAD_STATS"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "COR_GC_THREAD_STATS"
helpviewer_keywords:
  - "COR_GC_THREAD_STATS structure [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# COR_GC_THREAD_STATS Structure

Contains per-thread statistics pertaining to garbage collection.

## Syntax

```cpp
typedef struct _COR_GC_THREAD_STATS {
    ULONGLONG  PerThreadAllocation;
    ULONG      Flags;
} COR_GC_THREAD_STATS;
```

## Members

|Member|Description|
|------------|-----------------|
|`PerThreadAllocation`|The number of bytes of memory allocated on the thread that is associated with the current `COR_GC_THREAD_STATS` instance. This number is cleared to zero each time a generation-zero garbage collection occurs.|
|`Flags`|The number of bytes promoted to a higher generation at the most recent garbage collection.|

## Remarks

 [ICLRTask::GetMemStats](iclrtask-getmemstats-method.md) takes an output parameter of type `COR_GC_THREAD_STATS`.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** GCHost.idl

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Hosting Structures](hosting-structures.md)
- [IHostTask Interface](ihosttask-interface.md)
