# Exception Events
These runtime events capture information about exceptions that are thrown.

This category consists of the following events:

- [ExceptionThrown_V1 Event](#exceptionthrown_v1-event)
- [ExceptionCatchStart Event](#exceptioncatchstart-event)
- [ExceptionCatchStop Event](#exceptioncatchstop-event)
- [ExceptionFinallyStart Event](#exceptionfinallystart-event)
- [ExceptionFinallyStop Event](#exceptionfinallystop-event)
- [ExceptionFilterStart Event](#exceptionfilterstart-event)
- [ExceptionFilterStop Event](#exceptionfilterstop-event)
- [ExceptionThrownStop Event](#exceptionthrownstop-event)

## ExceptionThrown_V1 Event
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Error (1)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionThrown_V1`|80|A managed exception is thrown.|  

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|Exception Type|win:UnicodeString|Type of the exception; for example, `System.NullReferenceException`.|  
|Exception Message|win:UnicodeString|Actual exception message.|  
|EIPCodeThrow|win:Pointer|Instruction pointer where exception occurred.|  
|ExceptionHR|win:UInt32|Exception [HRESULT](https://docs.microsoft.com/openspecs/windows_protocols/ms-erref/0642cb2f-2075-4469-918c-4441e69c548a).|  
|ExceptionFlags|win:UInt16|0x01: HasInnerException (see [CLR ETW Events](clr-etw-events.md) in the Visual Basic documentation).<br /><br /> 0x02: IsNestedException.<br /><br /> 0x04: IsRethrownException.<br /><br /> 0x08: IsCorruptedStateException (indicates that the process state is corrupt; see [Handling Corrupted State Exceptions](https://docs.microsoft.com/archive/msdn-magazine/2009/february/clr-inside-out-handling-corrupted-state-exceptions)).<br /><br /> 0x10: IsCLSCompliant (an exception that derives from <xref:System.Exception> is CLS-compliant; otherwise, it is not CLS-compliant).|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  


## ExceptionCatchStart Event

This event is emitted when a managed exception catch handler begins.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionCatchStart`|250|A managed exception is handled by the runtime.|  

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|EIPCodeThrow|win:Pointer|Instruction pointer where exception occurred.|  
|MethodID|win:Pointer|Pointer to the method descriptor on the method where exception occurred.|
|MethodName|win:String|Name of the method where exception occurred.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  


## ExceptionCatchStop Event

This event is emitted when a managed exception catch handler ends.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionCatchStop`|251|A managed exception catch handler is done.|


## ExceptionFinallyStart Event

This event is emitted when a managed exception finally handler begins.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionFinallyStart`|252|A managed exception is handled by the runtime.|  

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|EIPCodeThrow|win:Pointer|Instruction pointer where exception occurred.|  
|MethodID|win:Pointer|Pointer to the method descriptor on the method where exception occurred.|
|MethodName|win:String|Name of the method where exception occurred.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  


## ExceptionFinallyStop Event

This event is emitted when a managed exception catch handler ends.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionFinallyStop`|253|A managed exception finally handler is done.|

## ExceptionFilterStart Event

This event is emitted when a managed exception filtering begins.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionFilterStart`|254|A managed exception filtering begins.|  

|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|EIPCodeThrow|win:Pointer|Instruction pointer where exception occurred.|  
|MethodID|win:Pointer|Pointer to the method descriptor on the method where exception occurred.|
|MethodName|win:String|Name of the method where exception occurred.|
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  


## ExceptionFilterStop Event

This event is emitted when a managed exception filtering ends.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionFilteringStart`|255|A managed exception filtering ends.|  

## ExceptionThrownStop Event

This event is emitted when the runtime is done handling a managed exception that was thrown.

|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`ExceptionKeyword` (0x8000)|Informational (4)|  
  
 The following table shows event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`ExceptionThrownStop`|256|A managed exception filtering ends.|  

