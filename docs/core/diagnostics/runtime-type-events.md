---
title: "Type Runtime Events"
description: See ETW events that collect information specific to the type system, such as TypeLoadStart and TypeLoadStop.
ms.date: "09/27/2020"
ms.topic: reference
helpviewer_keywords:
  - "type system events" [.NET Core]"
  - "ETW, EventPipe, LTTng type system events (CoreCLR)"
ms.assetid: 167a4459-bb6e-476c-9046-7920880f2bb5
---

# Runtime Type Events

These events collect information relating to loading types.

## TypeLoadStart Event

|Keyword for raising the event|Event|Level|  
|-----------------------------------|-----------|-----------|  
|`TypeDiagnosticKeyword` (0x8000000000)|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`TypeLoadStart`|73|A type load has started.|

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|TypeLoadStartID|win:UInt32|ID for the type load operation.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  

## TypeLoadStop Event

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|-----------|  
|`TypeDiagnosticKeyword` (0x8000000000)|Informational (4)|  

|Event|Event ID|Description|  
|-----------|--------------|-----------------|  
|`TypeLoadStop`|74|A type load is finished.|

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|TypeLoadStartID|win:UInt32|ID for the type load operation (matches the corresponding TypeLoadStart event's TypeLoadStartID).|
|LoadLevel|win:UInt16|Type load level.|
|TypeID|win:UInt64|Pointer to the type handle.|
|TypeName|win:UnicodeString|Name of the type.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
