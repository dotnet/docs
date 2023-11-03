---
title: "Method runtime events"
description: Learn about the .NET runtime events that collect diagnostic information specific to methods, like CLR method events, CLR method marker or CLR method verbose events, and MethodJittingStarted.
ms.date: "11/13/2020"
helpviewer_keywords:
  - "Method events (CoreCLR)"
  - "ETW, EventPipe, LTTng method events (CoreCLR)"
---

# .NET runtime method events

The events described in this article collect information that is specific to methods. The payload of these events is required for symbol resolution. In addition, these events provide helpful information such as methods that are loaded and unloaded. For more information about how to use these events for diagnostic purposes, see [logging and tracing .NET applications](../../core/diagnostics/logging-tracing.md)

All method events have a level of "Informational (4)". All method verbose events have a level of "Verbose (5)".

All method events are raised by the `JITKeyword` (0x10) keyword or the `NGenKeyword` (0x20) keyword under the runtime provider, or `JitRundownKeyword` (0x10) or `NGENRundownKeyword` (0x20) under the rundown provider.

The V2 versions of these events include the ReJITID, the V1 versions do not.

## MethodLoad_V1 event

The following table shows the event information:

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodLoad_V1`|141|Raised when a method is just-in-time loaded (JIT-loaded) or an NGEN image is loaded. Dynamic and generic methods do not use this version for method loads. JIT helpers never use this version.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) runtime provider|Informational (4)|
|`NGenKeyword` (0x20) runtime provider|Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodID`|`win:UInt64`|Unique identifier of a method. For JIT helper methods, this is set to the start address of the method.|
|`ModuleID`|`win:UInt64`|Identifier of the module to which this method belongs (0 for JIT helpers).|
|`MethodStartAddress`|`win:UInt64`|Start address of the method.|
|`MethodSize`|`win:UInt32`|Size of the method.|
|`MethodToken`|`win:UInt32`|0 for dynamic methods and JIT helpers.|
|`MethodFlags`|`win:UInt32`|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled code method (otherwise NGEN native image code).<br /><br /> 0x8: Helper method.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## MethodLoad_V2 event

|Event|Event ID|Description|
|----------------|---------------|-----------------|
|`MethodLoad_V2`|141|Raised when a method is just-in-time loaded (JIT-loaded) or an NGEN image is loaded. Dynamic and generic methods do not use this version for method loads. JIT helpers never use this version.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) runtime provider|Informational (4)|
|`NGenKeyword` (0x20) runtime provider|Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodID`|`win:UInt64`|Unique identifier of a method. For JIT helper methods, this is set to the start address of the method.|
|`ModuleID`|`win:UInt64`|Identifier of the module to which this method belongs (0 for JIT helpers).|
|`MethodStartAddress`|`win:UInt64`|Start address of the method.|
|`MethodSize`|`win:UInt32`|Size of the method.|
|`MethodToken`|`win:UInt32`|0 for dynamic methods and JIT helpers.|
|`MethodFlags`|`win:UInt32`|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled code method (otherwise NGEN native image code).<br /><br /> 0x8: Helper method.|
|`ReJITID`|`win:UInt64`|ReJIT ID of the method.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## MethodUnLoad_V1 event

|Event|Event ID|Description|
|----------------|---------------|-----------------|
|`MethodUnLoad_V1`|142|Raised when a module is unloaded, or an application domain is destroyed. Dynamic methods never use this version for method unloads.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10)|Informational (4)|
|`NGenKeyword` (0x20)|Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodID`|`win:UInt64`|Unique identifier of a method. For JIT helper methods, this is set to the start address of the method.|
|`ModuleID`|`win:UInt64`|Identifier of the module to which this method belongs (0 for JIT helpers).|
|`MethodStartAddress`|`win:UInt64`|Start address of the method.|
|`MethodSize`|`win:UInt32`|Size of the method.|
|`MethodToken`|`win:UInt32`|0 for dynamic methods and JIT helpers.|
|`MethodFlags`|`win:UInt32`|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled code method (otherwise NGEN native image code).<br /><br /> 0x8: Helper method.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## MethodUnLoad_V2 event

|Event|Event ID|Description|
|----------------|---------------|-----------------|
|`MethodUnLoad_V2`|142|Raised when a module is unloaded, or an application domain is destroyed. Dynamic methods never use this version for method unloads.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10)|Informational (4)|
|`NGenKeyword` (0x20)|Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodID`|`win:UInt64`|Unique identifier of a method. For JIT helper methods, this is set to the start address of the method.|
|`ModuleID`|`win:UInt64`|Identifier of the module to which this method belongs (0 for JIT helpers).|
|`MethodStartAddress`|`win:UInt64`|Start address of the method.|
|`MethodSize`|`win:UInt32`|Size of the method.|
|`MethodToken`|`win:UInt32`|0 for dynamic methods and JIT helpers.|
|`MethodFlags`|`win:UInt32`|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled code method (otherwise NGEN native image code).<br /><br /> 0x8: Helper method.|
|`ReJITID`|`win:UInt64`|ReJIT ID of the method.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## R2RGetEntryPoint event

|Event|Event ID|Description|
|----------------|---------------|-----------------|
|`R2RGetEntryPoint`|159|Raised when an R2R entry point lookup ends.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`CompilationDiagnosticKeyword` (0x2000000000) |Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodID`|`win:UInt64`|Unique identifier of a R2R method.|
|`MethodNamespace`|`win:UnicodeString`|The namespace of method being looked up.|
|`MethodName`|`win:UnicodeString`|The name of the method being looked up.|
|`MethodSignature`|`win:UnicodeString`|Signature of the method (comma-separated list of type names).|
|`EntryPoint`|`win:UInt64`|The pointer to the entry point of the R2R method|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## R2RGetEntryPointStart event

|Event|Event ID|Description|
|----------------|---------------|-----------------|
|`R2RGetEntryPointStart`|160|Raised when an R2R entry point lookup starts.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`CompilationDiagnosticKeyword` (0x2000000000) |Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodID`|`win:UInt64`|Unique identifier of a R2R method.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## MethodLoadVerbose_V1 event

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodLoadVerbose_V1`|143|Raised when a method is JIT-loaded or an NGEN image is loaded. Dynamic and generic methods always use this version for method loads. JIT helpers always use this version.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) |Informational (4)|
|`NGenKeyword` (0x20) |Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodID`|`win:UInt64`|Unique identifier of the method. For JIT helper methods, set to the start address of the method.|
|`ModuleID`|`win:UInt64`|Identifier of the module to which this method belongs (0 for JIT helpers).|
|`MethodStartAddress`|`win:UInt64`|Start address.|
|`MethodSize`|`win:UInt32`|Method length.|
|`MethodToken`|`win:UInt32`|0 for dynamic methods and JIT helpers.|
|`MethodFlags`|`win:UInt32`|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled method (otherwise, generated by NGen.exe)<br /><br /> 0x8: Helper method.|
|`MethodNameSpace`|`win:UnicodeString`|Full namespace name associated with the method.|
|`MethodName`|`win:UnicodeString`|Full class name associated with the method.|
|`MethodSignature`|`win:UnicodeString`|Signature of the method (comma-separated list of type names).|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## MethodLoadVerbose_V2 event

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodLoadVerbose_V1`|143|Raised when a method is JIT-loaded or an NGEN image is loaded. Dynamic and generic methods always use this version for method loads. JIT helpers always use this version.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) |Informational (4)|
|`NGenKeyword` (0x20) |Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodID`|`win:UInt64`|Unique identifier of the method. For JIT helper methods, set to the start address of the method.|
|`ModuleID`|`win:UInt64`|Identifier of the module to which this method belongs (0 for JIT helpers).|
|`MethodStartAddress`|`win:UInt64`|Start address.|
|`MethodSize`|`win:UInt32`|Method length.|
|`MethodToken`|`win:UInt32`|0 for dynamic methods and JIT helpers.|
|`MethodFlags`|`win:UInt32`|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled method (otherwise, generated by NGen.exe)<br /><br /> 0x8: Helper method.|
|`MethodNameSpace`|`win:UnicodeString`|Full namespace name associated with the method.|
|`MethodName`|`win:UnicodeString`|Full class name associated with the method.|
|`MethodSignature`|`win:UnicodeString`|Signature of the method (comma-separated list of type names).|
|`ReJITID`|`win:UInt64`|ReJIT ID of the method.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## MethodUnLoadVerbose_V1 event

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodUnLoadVerbose_V1`|144|Raised when a dynamic method is destroyed, a module is unloaded, or an application domain is destroyed. Dynamic methods always use this version for method unloads.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) |Informational (4)|
|`NGenKeyword` (0x20) |Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodID`|`win:UInt64`|Unique identifier of the method. For JIT helper methods, set to the start address of the method.|
|`ModuleID`|`win:UInt64`|Identifier of the module to which this method belongs (0 for JIT helpers).|
|`MethodStartAddress`|`win:UInt64`|Start address.|
|`MethodSize`|`win:UInt32`|Method length.|
|`MethodToken`|`win:UInt32`|0 for dynamic methods and JIT helpers.|
|`MethodFlags`|`win:UInt32`|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled method (otherwise, generated by NGen.exe)<br /><br /> 0x8: Helper method.|
|`MethodNameSpace`|`win:UnicodeString`|Full namespace name associated with the method.|
|`MethodName`|`win:UnicodeString`|Full class name associated with the method.|
|`MethodSignature`|`win:UnicodeString`|Signature of the method (comma-separated list of type names).|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## MethodUnLoadVerbose_V2 event

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodUnLoadVerbose_V2`|144|Raised when a dynamic method is destroyed, a module is unloaded, or an application domain is destroyed. Dynamic methods always use this version for method unloads.|

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) |Informational (4)|
|`NGenKeyword` (0x20) |Informational (4)|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodID`|`win:UInt64`|Unique identifier of the method. For JIT helper methods, set to the start address of the method.|
|`ModuleID`|`win:UInt64`|Identifier of the module to which this method belongs (0 for JIT helpers).|
|`MethodStartAddress`|`win:UInt64`|Start address.|
|`MethodSize`|`win:UInt32`|Method length.|
|`MethodToken`|`win:UInt32`|0 for dynamic methods and JIT helpers.|
|`MethodFlags`|`win:UInt32`|0x1: Dynamic method.<br /><br /> 0x2: Generic method.<br /><br /> 0x4: JIT-compiled method (otherwise, generated by NGen.exe)<br /><br /> 0x8: Helper method.|
|`MethodNameSpace`|`win:UnicodeString`|Full namespace name associated with the method.|
|`MethodName`|`win:UnicodeString`|Full class name associated with the method.|
|`MethodSignature`|`win:UnicodeString`|Signature of the method (comma-separated list of type names).|
|`ReJITID`|`win:UInt64`|ReJIT ID of the method.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## MethodJittingStarted_V1 event

The following table shows the keyword and level:

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITKeyword` (0x10) |Verbose (5)|
|`NGenKeyword` (0x20) |Verbose (5)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodJittingStarted_V1`|145|Raised when a method is being JIT-compiled.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodID`|`win:UInt64`|Unique identifier of the method.|
|`ModuleID`|`win:UInt64`|Identifier of the module to which this method belongs.|
|`MethodToken`|`win:UInt32`|0 for dynamic methods and JIT helpers.|
|`MethodILSize`|`win:UInt32`|The size of the Common Intermediate Language (CIL) for the method that is being JIT-compiled.|
|`MethodNameSpace`|`win:UnicodeString`|Full class name associated with the method.|
|`MethodName`|`win:UnicodeString`|Name of the method.|
|`MethodSignature`|`win:UnicodeString`|Signature of the method (comma-separated list of type names).|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## MethodJitInliningSucceeded event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITTracingKeyword` (0x1000) |Verbose (5)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodJitInliningSucceeded`|185|Raised when a method is successfully inlined by the JIT compiler.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodBeingCompiledNamespace`|`win:UnicodeString`|Namespace of the method being compiled.|
|`MethodBeingCompiledName`|`win:UnicodeString`|Name of the method being compiled.|
|`MethodBeingCompiledNameSignature`|`win:UnicodeString`|Signature of the method (comma-separated list of type names) being compiled.|
|`InlinerNamespace`|`win:UnicodeString`|The namespace of inliner ("parent") method.|
|`InlinerName`|`win:UnicodeString`|Name of the inliner ("parent") method.|
|`InlinerNameSignature`|`win:UnicodeString`|Signature of the inliner ("parent") method (comma-separated list of type names).|
|`InlineeNamespace`|`win:UnicodeString`|The namespace of inlinee ("child") method.|
|`InlineeName`|`win:UnicodeString`|Name of the inlinee ("child") method.|
|`InlineeNameSignature`|`win:UnicodeString`|Signature of the inlinee ("child") method (comma-separated list of type names).|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## MethodJitInliningFailed event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITTracingKeyword` (0x1000) |Verbose (5)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodJitInliningFailed`|192|Raised when a method was failed to be inlined by the JIT compiler.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodBeingCompiledNamespace`|`win:UnicodeString`|Namespace of the method being compiled.|
|`MethodBeingCompiledName`|`win:UnicodeString`|Name of the method being compiled.|
|`MethodBeingCompiledNameSignature`|`win:UnicodeString`|Signature of the method (comma-separated list of type names) being compiled.|
|`InlinerNamespace`|`win:UnicodeString`|The namespace of inliner ("parent") method.|
|`InlinerName`|`win:UnicodeString`|Name of the inliner ("parent") method.|
|`InlinerNameSignature`|`win:UnicodeString`|Signature of the inliner ("parent") method (comma-separated list of type names).|
|`InlineeNamespace`|`win:UnicodeString`|The namespace of inlinee ("child") method.|
|`InlineeName`|`win:UnicodeString`|Name of the inlinee ("child") method.|
|`InlineeNameSignature`|`win:UnicodeString`|Signature of the inlinee ("child") method (comma-separated list of type names).|
|`FailAlways`|`win:Boolean`|Whether the method is marked as not inlinable.|
|`FailReason`|`win:UnicodeString`|Reason inlining failed.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## MethodJitTailCallSucceeded event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITTracingKeyword` (0x1000) |Verbose (5)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodJitTailCallSucceeded`|192|Raised by the JIT compiler when a method can be successfully tail called.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodBeingCompiledNamespace`|`win:UnicodeString`|Namespace of the method being compiled.|
|`MethodBeingCompiledName`|`win:UnicodeString`|Name of the method being compiled.|
|`MethodBeingCompiledNameSignature`|`win:UnicodeString`|Signature of the method (comma-separated list of type names) being compiled.|
|`CallerNamespace`|`win:UnicodeString`|Namespace of the caller method.|
|`CallerName`|`win:UnicodeString`|Name of the caller method.|
|`CallerNameSignature`|`win:UnicodeString`|Signature of the caller method (Comma-separated list of type names).|
|`CalleeNamespace`|`win:UnicodeString`|Namespace of the callee method.|
|`CalleeName`|`win:UnicodeString`|Name of the callee method.|
|`CalleeNameSignature`|`win:UnicodeString`|Signature of the callee method (Comma-separated list of type names).|
|`TailPrefix`|`win:Boolean`|Whether it is a tail prefix instruction.|
|`TailCallType`|`win:UInt32`|The type of tail call.<br/><br/>0: Optimized tail call (epilog + jmp)<br/><br/>1: Recursive tail call (method tail calls itself)<br/><br/>2: Helper assisted tail call|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## MethodJitTailCallFailed event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JITTracingKeyword` (0x1000) |Verbose (5)|

|Event|Event ID|Description|
|-----------|--------------|-----------------|
|`MethodJitTailCallFailed`|191|Raised by the JIT compiler when a method was failed to be tail called.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodBeingCompiledNamespace`|`win:UnicodeString`|Namespace of the method being compiled.|
|`MethodBeingCompiledName`|`win:UnicodeString`|Name of the method being compiled.|
|`MethodBeingCompiledNameSignature`|`win:UnicodeString`|Signature of the method (comma-separated list of type names) being compiled.|
|`CallerNamespace`|`win:UnicodeString`|Namespace of the caller method.|
|`CallerName`|`win:UnicodeString`|Name of the caller method.|
|`CallerNameSignature`|`win:UnicodeString`|Signature of the caller method (Comma-separated list of type names).|
|`CalleeNamespace`|`win:UnicodeString`|Namespace of the callee method.|
|`CalleeName`|`win:UnicodeString`|Name of the callee method.|
|`CalleeNameSignature`|`win:UnicodeString`|Signature of the callee method (Comma-separated list of type names).|
|`TailPrefix`|`win:Boolean`|Whether it is a tail prefix instruction.|
|`FailReason`|`win:UnicodeString`|Reason tail call failed.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|

## MethodILToNativeMap event

|Keyword for raising the event|Level|
|-----------------------------------|-----------|
|`JittedMethodILToNativeMapKeyword` (0x20000) |Verbose (5)|

|Event|Event ID|Description|
|----------------|---------------|-----------------|
|`MethodILToNativeMap`|190|Maps the IL-to-native map event for JIT-compiled methods.|

|Field name|Data type|Description|
|----------------|---------------|-----------------|
|`MethodID`|`win:UInt64`|Unique identifier of a method.|
|`ReJITID`|`win:UInt64`|The ReJIT ID of the method.|
|`MethodExtent`|`win:UInt8`|The extent for the jitted method.|
|`CountOfMapEntries`|`win:UInt8`|Number of map entries|
|`ILOffsets`|`win:UInt32`|The IL offset.|
|`NativeOffsets`|`win:UInt32`|The native code offset.|
|`ClrInstanceID`|`win:UInt16`|Unique ID for the instance of CoreCLR.|
