---
title: "Wait handle runtime events"
description: See ETW events that collect information specific to the wait handles.
ms.date: "05/27/2024"
helpviewer_keywords:
  - "wait handle events (CoreCLR)"
  - "ETW, EventPipe, LTTng wait handle events (CoreCLR)"
---

# .NET runtime wait handle events

These runtime events capture information about wait handles. They can be useful to investigate thread pool starvation issues. For more information about how to use these events for diagnostic purposes, see [logging and tracing .NET applications](../../core/diagnostics/logging-tracing.md)

## WaitHandleWaitStart event

This event is emitted at the start of a wait operation on a wait handle. Here is a non-exhaustive list of managed method that could emit this event:

- `Monitor.Wait`
- `Monitor.Enter` or the C# lock keyword
- `ManualResetEvent.WaitOne`
- `Task.Wait`

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`WaitHandleKeyword` (0x40000000000)|Verbose (5)|

The following table shows event information.

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`WaitHandleWaitStart`|301|A wait starts.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`WaitSource`|`win:UInt8`|`0x0` - Other sources.<br /><br /> `0x1` - The wait originated from managed code through the `Monitor.Wait` method.|
|`AssociatedObjectID`|`win:Pointer`|Address of the associated object (e.g. address of `obj` in the code `lock(obj) {}`).|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## WaitHandleWaitStop event

This event is emitted at the end of a wait operation on a wait handle.

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`WaitHandleKeyword` (0x40000000000)|Verbose (5)|

The following table shows event information.

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`WaitHandleWaitStop`|302|A wait stops.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|
