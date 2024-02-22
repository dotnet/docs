---
title: "Monitor lock contention runtime events"
description: See ETW events that collect information specific to the monitor lock contentions.
ms.date: "11/13/2020"
helpviewer_keywords:
  - "monitor lock contention events (CoreCLR)"
  - "ETW, EventPipe, LTTng contention events (CoreCLR)"
---

# .NET runtime contention events

These runtime events capture information about monitor lock contentions such as with `Monitor.Enter` or the C# lock keyword. For more information about how to use these events for diagnostic purposes, see [logging and tracing .NET applications](../../core/diagnostics/logging-tracing.md)

## ContentionStart_V2 event

This event is emitted at the start of a monitor lock contention.

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`ContentionKeyword` (0x4000)|Informational (4)|

 The following table shows event information.

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`ContentionStart_V2`|81|A monitor lock contention starts.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`Flags`|`win:UInt8`|`0` for managed; `1` for native.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|
|`LockObjectID`|`win:Pointer`|Address of the lock object.|
|`LockOwnerThreadID`|`win:Pointer`|Address of the thread that owns the lock.|

## ContentionStop_V1 event

This event is emitted at the end of a monitor lock contention.

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`ContentionKeyword` (0x4000)|Informational (4)|

 The following table shows event information.

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`ContentionStop_V1`|91|A monitor lock contention ends.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`Flags`|`win:UInt8`|`0` for managed; `1` for native.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|
|`DurationNs`|`win:Double`|Duration of the contention in nanoseconds.|
