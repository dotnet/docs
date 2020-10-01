---
title: "Thread Contention Events"
description: See ETW events that collect information specific to the monitor lock contentions.
ms.date: "09/27/2020"
ms.topic: reference
helpviewer_keywords:
  - "thread contention events" [.NET Core]"
  - "ETW, EventPipe, LTTng contention events (CoreCLR)"
ms.assetid: 167a4459-bb6e-476c-9046-7920880f2bb5
---

# Contention Events

These runtime events capture information about monitor lock contentions such as with Monitor.Enter or the C# lock keyword.

This category consists of the following events:

- [ContentionStart_V1](#contentionstart_v1-event)
- [ContentionStop_V1](#contentionstop_v1-event)

## ContentionStart_V1 Event

This event is emitted at the start of a managed thread contention.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ContentionKeyword` (0x4000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ContentionStart_V1`|81|A managed thread contention starts.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|Flags|win:UInt8|0 for managed; 1 for native.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|

## ContentionStop_V1 Event

This event is emitted at the end of a managed thread contention.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ContentionKeyword` (0x4000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ContentionStop_V1`|91|A managed thread contention ends.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|Flags|win:UInt8|0 for managed; 1 for native.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CoreCLR.|
|DurationNs|win:Double|Duration of the contention in nanoseconds.|
