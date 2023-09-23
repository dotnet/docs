---
title: "Exception runtime events"
description: Learn about the .NET runtime events that collect diagnostic information specific to the exceptions and exception handling.
ms.date: "11/13/2020"
ms.topic: reference
helpviewer_keywords:
  - "exception events (CoreCLR)"
  - "exception handling events (CoreCLR)"
  - "ETW, EventPipe, LTTng exception events (CoreCLR)"
---

# .NET runtime exception events

These runtime events capture information about exceptions that are thrown. For more information about how to use these events for diagnostic purposes, see [logging and tracing .NET applications](../../core/diagnostics/logging-tracing.md)

## ExceptionThrown_V1 event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`ExceptionKeyword` (0x8000)|Error (1)|

 The following table shows event information.

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`ExceptionThrown_V1`|80|A managed exception is thrown.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`ExceptionType`|`win:UnicodeString`|Type of the exception; for example, `System.NullReferenceException`.|
|`ExceptionMessage`|`win:UnicodeString`|Actual exception message.|
|`EIPCodeThrow`|`win:Pointer`|Instruction pointer where exception occurred.|
|`ExceptionHR`|`win:UInt32`|Exception [HRESULT](/openspecs/windows_protocols/ms-erref/0642cb2f-2075-4469-918c-4441e69c548a).|
|`ExceptionFlags`|`win:UInt16`|`0x01`: HasInnerException.<br /><br /> `0x02`: IsNestedException.<br /><br /> `0x04`: IsRethrownException.<br /><br /> `0x08`: IsCorruptedStateException (indicates that the process state is corrupt; see [Handling Corrupted State Exceptions](/archive/msdn-magazine/2009/february/clr-inside-out-handling-corrupted-state-exceptions)).<br /><br /> `0x10`: IsCLSCompliant (an exception that derives from <xref:System.Exception> is CLS-compliant; otherwise, it is not CLS-compliant).|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CLR or CoreCLR.|

## ExceptionCatchStart event

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
|`EIPCodeThrow`|`win:Pointer`|Instruction pointer where exception occurred.|
|`MethodID`|`win:Pointer`|Pointer to the method descriptor on the method where exception occurred.|
|`MethodName`|`win:UnicodeString`|Name of the method where exception occurred.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CLR or CoreCLR.|

## ExceptionCatchStop event

This event is emitted when a managed exception catch handler ends.

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`ExceptionKeyword` (0x8000)|Informational (4)|

 The following table shows event information.

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`ExceptionCatchStop`|251|A managed exception catch handler is done.|

## ExceptionFinallyStart event

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
|`EIPCodeThrow`|`win:Pointer`|Instruction pointer where exception occurred.|
|`MethodID`|`win:Pointer`|Pointer to the method descriptor on the method where exception occurred.|
|`MethodName`|`win:UnicodeString`|Name of the method where exception occurred.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CLR or CoreCLR.|

## ExceptionFinallyStop event

This event is emitted when a managed exception catch handler ends.

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`ExceptionKeyword` (0x8000)|Informational (4)|

 The following table shows event information.

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`ExceptionFinallyStop`|253|A managed exception finally handler is done.|

## ExceptionFilterStart event

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
|`EIPCodeThrow`|`win:Pointer`|Instruction pointer where exception occurred.|
|`MethodID`|`win:Pointer`|Pointer to the method descriptor on the method where exception occurred.|
|`MethodName`|`win:UnicodeString`|Name of the method where exception occurred.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## ExceptionFilterStop event

This event is emitted when a managed exception filtering ends.

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`ExceptionKeyword` (0x8000)|Informational (4)|

 The following table shows event information.

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`ExceptionFilteringStart`|255|A managed exception filtering ends.|

## ExceptionThrownStop event

This event is emitted when the runtime is done handling a managed exception that was thrown.

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`ExceptionKeyword` (0x8000)|Informational (4)|
  
 The following table shows event information.

|Event|Event ID|Raised when|
|-----------|--------------|-----------------|
|`ExceptionThrownStop`|256|A managed exception filtering ends.|
