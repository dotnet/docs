---
title: "Tiered compilation runtime events"
description: Learn about the .NET runtime tiered compilation events that collect diagnostic information about tiered compilation in .NET Core.
ms.date: "9/15/2023"
helpviewer_keywords:
  - "Tiered compilation events (CoreCLR)"
  - "ETW, tiered compilation events (CoreCLR)"
---
# .NET runtime tiered compilation events

The events described in this article collect information about tiered compilation. For more information about how to use these events for diagnostic purposes, see [logging and tracing .NET applications](../../core/diagnostics/logging-tracing.md).

## TieredCompilationSettings event

The following table shows the keyword and level.

|Keyword for raising the event|Level|
|-|-|
|`CompilationKeyword` (0x1000000000)|Informational (4)|

The following table shows the event information.

|Event|Event ID|Raised when|
|-|-|-|
|`TieredCompilationSettings`|280|Provides information about tiered compilation settings.|

The following table shows the event data.

|Field name|Data type|Description|
|-|-|-|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|
|`Flags`|`win:UInt32`|Flags that indicate various settings. Multiple flags may be provided with bitwise-OR, and a value of `0x0` indicates that no flags were provided.<br/><br/>`0x1` - Quick JIT is enabled. If a method does not have precompiled code, for the first tier it will be JIT-compiled quickly but with fewer optimizations.<br/><br/>`0x2` - Quick JIT is enabled for methods containing loops.<br/><br/>`0x4` - Tiered PGO is enabled. Methods may be profiled before they are optimized.<br/><br/>`0x8` - ReadyToRun is enabled. Methods that have precompiled ReadyToRun code will use that for the first tier.|

## TieredCompilationPause event

The following table shows the keyword and level.

|Keyword for raising the event|Level|
|-|-|
|`CompilationKeyword` (0x1000000000)|Informational (4)|

The following table shows the event information.

|Event|Event ID|Raised when|
|-|-|-|
|`TieredCompilationPause`|281|Tiered compilation was paused. Tiered compilation may be paused due to startup-like activities, such as a new method being called for the first time, to reduce overhead during application startup, such as call-counting and background JIT-compilation. It resumes after startup-like activities cease for a short duration.|

The following table shows the event data.

|Field name|Data type|Description|
|-|-|-|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## TieredCompilationResume event

The following table shows the keyword and level.

|Keyword for raising the event|Level|
|-|-|
|`CompilationKeyword` (0x1000000000)|Informational (4)|

The following table shows the event information.

|Event|Event ID|Raised when|
|-|-|-|
|`TieredCompilationResume`|282|Tiered compilation was resumed.|

The following table shows the event data.

|Field name|Data type|Description|
|-|-|-|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|
|`NewMethodCount`|`win:UInt32`|The number of new methods called for the first time while tiered compilation was paused.|

## TieredCompilationBackgroundJitStart event

The following table shows the keyword and level.

|Keyword for raising the event|Level|
|-|-|
|`CompilationKeyword` (0x1000000000)|Informational (4)|

The following table shows the event information.

|Event|Event ID|Raised when|
|-|-|-|
|`TieredCompilationBackgroundJitStart`|283|Background JIT-compilation has started.|

The following table shows the event data.

|Field name|Data type|Description|
|-|-|-|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|
|`PendingMethodCount`|`win:UInt32`|The number of methods pending background JIT-compilation.|

## TieredCompilationBackgroundJitStop event

The following table shows the keyword and level.

|Keyword for raising the event|Level|
|-|-|
|`CompilationKeyword` (0x1000000000)|Informational (4)|

The following table shows the event information.

|Event|Event ID|Raised when|
|-|-|-|
|`TieredCompilationBackgroundJitStop`|284|Background JIT-compilation has stopped.|

The following table shows the event data.

|Field name|Data type|Description|
|-|-|-|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|
|`PendingMethodCount`|`win:UInt32`|The number of methods still pending background JIT-compilation.|
|`JittedMethodCount`|`win:UInt32`|The number of methods that were JIT-compiled in the background since background JIT-compilation last started.|
