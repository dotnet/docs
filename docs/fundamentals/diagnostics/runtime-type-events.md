---
title: "Type system runtime events"
description: Learn about the .NET runtime events that collect diagnostic information specific to the .NET type system, such as TypeLoadStart and TypeLoadStop.
ms.date: "11/13/2020"
ms.topic: reference
helpviewer_keywords:
  - "type system events (CoreCLR)"
  - "ETW, EventPipe, LTTng type system events (CoreCLR)"
---

# .NET runtime type events

The events described in this article collect information relating to loading types. For more information about how to use these events for diagnostic purposes, see [logging and tracing .NET applications](../../core/diagnostics/logging-tracing.md)

## TypeLoadStart Event

|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`TypeDiagnosticKeyword` (0x8000000000)|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`TypeLoadStart`|73|A type load has started.|

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|`TypeLoadStartID`|`win:UInt32`|ID for the type load operation.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CLR or CoreCLR.|  

## TypeLoadStop Event

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|-----------|  
|`TypeDiagnosticKeyword` (0x8000000000)|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`TypeLoadStop`|74|A type load is finished.|

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|`TypeLoadStartID`|`win:UInt32`|ID for the type load operation (matches the corresponding TypeLoadStart event's TypeLoadStartID).|
|`LoadLevel`|`win:UInt16`|Type load level.|
|`TypeID`|`win:UInt64`|Pointer to the type handle.|
|`TypeName`|`win:UnicodeString`|Name of the type.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CLR or CoreCLR.|  
