---
title: "Application Domain Resource Monitoring (ARM) ETW Events"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "ETW, application domain monitoring events"
  - "application domain monitoring events [.NET Framework]"
ms.assetid: d38ff268-a2ee-434e-b504-d570880e0289
---
# Application Domain Resource Monitoring (ARM) ETW Events

These events provide detailed diagnostic information about the state of an application domain. You can use these events or use the application domain resource monitoring (ARM) feature to obtain the same information.

## ThreadCreated Event

This event is also raised  under the rundown provider as `ThreadDC` (under the `AppDomainResourceManagementRundownKeyword` keyword). This is the only event that is raised under the rundown provider in this category.

The following table shows the keyword and level. For more information, see [CLR ETW Keywords and Levels](clr-etw-keywords-and-levels.md).

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`AppDomainResourceManagementKeyword` (0x800)|Informational(4)|
|`ThreadingKeyword` (0x10000)|Informational(4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`ThreadCreated`|85|A thread was created for the application domain.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|ThreadID|win:UInt64|ID of the thread that was created.|
|AppDomainID|win:UInt64|Identifier of the application domain for which thread activity is being reported.|
|Flags|win:UInt32|Thread creation flags.|
|ManagedThreadIndex|win:UInt32|Managed index of the thread that was created.|
|OSThreadID|win:UInt32|Operating system ID of the thread that was created.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

## AppDomainMemAllocated Event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`AppDomainResourceManagementKeyword` (0x800)|Informational(4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`AppDomainMemAllocated`|83|Every 4 MB of memory (approximately) is allocated in the application domain.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AppDomainID|win:UInt64|Identifier of the application domain for which resource usage is being reported.|
|Allocated|win:UInt64|The total number of bytes allocated in this application domain since the application domain was created (the amount of freed memory is not subtracted).|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

## AppDomainMemSurvived Event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`AppDomainResourceManagementKeyword` (0x800)|Informational(4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`AppDomainMemSurvived`|84|Each garbage collection has ended.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|AppDomainID|win:UInt64|Identifier of the domain for which resource usage is being reported.|
|Survived|win:UInt64|The number of bytes that survived after the last collection and that are known to be held by this application domain. This number is accurate and complete after a full collection, but may be incomplete after an ephemeral collection.|
|ProcessSurvived|win:UInt64|The total bytes that survived from the last collection. After a full collection, this number represents the number of bytes being held live in managed heaps. After an ephemeral collection, this number represents the number of bytes held live in ephemeral generations.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

## ThreadAppDomainEnter Event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`AppDomainResourceManagementKeyword` (0x800)|Informational(4)|
|`ThreadingKeyword` (0x10000)|Informational(4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`ThreadAppDomainEnter`|87|A thread enters an application domain.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|ThreadID|win:UInt64|The thread identifier.|
|AppDomainID|win:UInt64|The application domain identifier.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

## ThreadTerminated Event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`AppDomainResourceManagementKeyword` (0x800)|Informational(4)|
|`ThreadingKeyword` (0x10000)|Informational(4)|

The following table shows the event information:

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`ThreadTerminated`|86|A thread terminates.|

The following table shows the event data:

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|ThreadID|win:UInt64|The thread identifier.|
|AppDomainID|win:UInt64|The application domain identifier.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|

## See also

- [CLR ETW Events](clr-etw-events.md)
