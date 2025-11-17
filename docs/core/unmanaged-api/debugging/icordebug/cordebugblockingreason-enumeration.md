---
description: "Learn more about: CorDebugBlockingReason Enumeration"
title: "CorDebugBlockingReason Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugBlockingReason"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugBlockingReason"
helpviewer_keywords:
  - "CorDebugBlockingReason enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugBlockingReason Enumeration

Specifies the reasons why a thread may become blocked on a given object.

## Syntax

```cpp
Typedef enum CorDebugBlockingReason
{
   BLOCKING_NONE = 0
   BLOCKING_MONITOR_CRITICAL_SECTION = 1
   BLOCKING_MONITOR_EVENT = 2
}  CorDebugBlockingReason;
```

## Members

| Member          | Description        |
|-----------------|--------------------|
| `BLOCKING_NONE` | Internal use only. |
|`BLOCKING_MONITOR_CRITICAL_SECTION`|A thread is trying to acquire the critical section that is associated with the monitor lock on an object. Typically, this occurs when you call one of the <xref:System.Threading.Monitor.Enter%2A?displayProperty=nameWithType> or <xref:System.Threading.Monitor.TryEnter%2A?displayProperty=nameWithType> methods.|
|`BLOCKING_MONITOR_EVENT`|A thread is waiting on the event that is associated with a monitor lock for an object. Typically, this occurs when you call one of the <xref:System.Threading.Monitor?displayProperty=nameWithType>`Wait` methods.|

## Remarks

 When the `BLOCKING_MONITOR_CRITICAL_SECTION` or `BLOCKING_MONITOR_EVENT` member is used in a [CorDebugBlockingObject](cordebugblockingobject-structure.md) structure, the `pBlockingObject` member of the structure points to an "ICorDebugValue" interface that represents the object that is being entered. It is also guaranteed to implement the [ICorDebugHeapValue3](icordebugheapvalue3-interface.md) interface.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0
