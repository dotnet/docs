---
title: "Stack ETW Event"
description: Read about the stack ETW event, which should be used in conjunction with other events to generate stack traces after an event is raised.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "stack event [.NET Framework]"
  - "ETW, stack event (CLR)"
ms.topic: reference
---
# Stack ETW Event

The stack event should be used in conjunction with other events to generate stack traces after an event is raised. It is logged when the runtime provider is enabled. This is a very high frequency event, because it is raised whenever another runtime event is raised. For this reason, we recommend that you use this event with caution.  
  
 The following table shows the keyword and level. (For more information, see [CLR ETW Keywords and Levels](clr-etw-keywords-and-levels.md).)  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`StackKeyword` (0x40000000)|LogAlways(0)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`CLRStackWalk`|82|In conjunction with other events to generate stack traces following an event.|  
  
 The following table shows the event data.  
  
|Field name|Data Type|Description|  
|----------------|---------------|-----------------|  
|ClrInstanceID|win:Uint16|Unique runtime identifier.|  
|Reserved1|win:UInt8|Reserved.|  
|Reserved2|win:UInt8|Reserved.|  
|FrameCount|win:UInt32|The number of frames in the stack trace.|  
|Stack|win:Pointer|Columns of instruction pointers.|  
  
## See also

- [CLR ETW Events](clr-etw-events.md)
