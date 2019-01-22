---
title: "Exception Thrown_V1 ETW Event"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "ExceptionThrown_V1 event [.NET Framework]"
  - "ETW, ExceptionThrown_V1 event (CLR)"
ms.assetid: 0d3da389-6b7b-40f6-a877-fac546d6019c
author: "mairaw"
ms.author: "mairaw"
---
# Exception Thrown_V1 ETW Event
This event captures information about the exceptions that are thrown.  
  
 The following table shows the keyword under which the event is raised, and the level of the event. (For more information, see [CLR ETW Keywords and Levels](../../../docs/framework/performance/clr-etw-keywords-and-levels.md).)  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Warning (2)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionThrown_V1`|80|A managed exception is thrown.|  
  
 The following table shows event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Exception Type|win:UnicodeString|Type of the exception; for example, `System.NullReferenceException`.|  
|Exception Message|win:UnicodeString|Actual exception message.|  
|EIPCodeThrow|win:Pointer|Instruction pointer where exception occurred.|  
|ExceptionHR|win:UInt32|Exception [HRESULT](https://go.microsoft.com/fwlink/?LinkId=179679).|  
|ExceptionFlags|win:UInt16|0x01: HasInnerException (see [CLR ETW Events](../../../docs/framework/performance/clr-etw-events.md) in the Visual Basic documentation).<br /><br /> 0x02: IsNestedException.<br /><br /> 0x04: IsRethrownException.<br /><br /> 0x08: IsCorruptedStateException (indicates that the process state is corrupt; see [Handling Corrupted State Exceptions](https://go.microsoft.com/fwlink/?LinkId=179681) on MSDN).<br /><br /> 0x10: IsCLSCompliant (an exception that derives from <xref:System.Exception> is CLS-compliant; otherwise, it is not CLS-compliant).|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
## See also
 [CLR ETW Events](../../../docs/framework/performance/clr-etw-events.md)
