---
title: "Debugging Interfaces"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "unmanaged interfaces [.NET Framework], debugging"
  - "debugging interfaces [.NET Framework]"
  - "interfaces [.NET Framework debugging]"
ms.assetid: b6297c26-7624-4431-8af4-14112d07bcd5
caps.latest.revision: 32
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Debugging Interfaces
This section describes the unmanaged interfaces that handle the debugging of a program that is executing in the common language runtime (CLR).  
  
## In This Section  
 [ICLRDataEnumMemoryRegions Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdataenummemoryregions-interface.md)  
 Provides a method to enumerate regions of memory that are specified by callers.  
  
 [ICLRDataEnumMemoryRegionsCallback Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdataenummemoryregionscallback-interface.md)  
 Provides a callback method for `EnumMemoryRegions` to report to the debugger, the result of an attempt to enumerate a specified region of memory.  
  
 [ICLRDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-interface.md)  
 Provides methods for interaction with a target CLR process.  
  
 [ICLRDataTarget2 Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget2-interface.md)  
 A subclass of `ICLRDataTarget` that is used by the data access services layer to manipulate virtual memory regions in the target process.  
  
 [ICLRDataTarget3 Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget3-interface.md)  
 A subclass of [ICLRDataTarget2](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget2-interface.md) that provides access to exception information.  
  
 [ICLRDebugging Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdebugging-interface.md)  
 Provides methods that handle loading and unloading modules for debugging.  
  
 [ICLRDebuggingLibraryProvider Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdebugginglibraryprovider-interface.md)  
 Includes the [ProvideLibrary Method](../../../../docs/framework/unmanaged-api/debugging/iclrdebugginglibraryprovider-providelibrary-method.md) method, which gets a library provider callback interface that allows common language runtime version-specific debugging libraries to be located and loaded on demand.  
  
 [ICLRMetadataLocator Interface](../../../../docs/framework/unmanaged-api/debugging/iclrmetadatalocator-interface.md)  
 Interface used by the data access services layer to locate metadata of assemblies in a target process.  
  
 [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)  
 Provides methods that allow developers to debug applications in the CLR environment.  
  
 [ICorDebugAppDomain Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugappdomain-interface.md)  
 Provides methods for debugging application domains.  
  
 [ICorDebugAppDomain2 Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugappdomain2-interface.md)  
 Provides methods to work with arrays, pointers, function pointers, and ByRef types. This interface is an extension of the `ICorDebugAppDomain` interface.  
  
 [ICorDebugAppDomain3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugappdomain3-interface.md)  
 Provides methods to work with the [!INCLUDE[wrt](../../../../includes/wrt-md.md)] types in an application domain. This interface is an extension of the `ICorDebugAppDomain` and `ICorDebugAppDomain2` interfaces.  
  
 [ICorDebugAppDomain4 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugappdomain4-interface.md)  
 Logically extends the [ICorDebugAppDomain](../../../../docs/framework/unmanaged-api/debugging/icordebugappdomain-interface.md) interface to get a managed object from a COM callable wrapper.  
  
 [ICorDebugAppDomainEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugappdomainenum-interface.md)  
 Provides a method that returns a specified number of `ICorDebugAppDomain` values starting at the next location in the enumeration.  
  
 [ICorDebugArrayValue Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugarrayvalue-interface.md)  
 A subclass of `ICorDebugHeapValue` that represents a single-dimensional or multi-dimensional array.  
  
 [ICorDebugAssembly Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugassembly-interface.md)  
 Represents an assembly.  
  
 [ICorDebugAssembly2 Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugassembly2-interface.md)  
 Represents an assembly. This interface is an extension of the `ICorDebugAssembly` interface.  
  
 [ICorDebugAssembly3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugassembly3-interface.md)  
 Logically extends the [ICorDebugAssembly](../../../../docs/framework/unmanaged-api/debugging/icordebugassembly-interface.md) interface to provide support for container assemblies and their contained assemblies. **Available on .NET Native only.**  
  
 [ICorDebugAssemblyEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugassemblyenum-interface.md)  
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugAssembly` arrays.  
  
 [ICorDebugBlockingObjectEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugblockingobjectenum-interface.md)  
 Provides an enumerator for a list of [CorDebugBlockingObject](../../../../docs/framework/unmanaged-api/debugging/cordebugblockingobject-structure.md) structures.  
  
 [ICorDebugBoxValue Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugboxvalue-interface.md)  
 A subclass of `ICorDebugHeapValue` that represents a boxed value class object.  
  
 [ICorDebugBreakpoint Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugbreakpoint-interface.md)  
 Represents a breakpoint in a function or a watch point on a value.  
  
 [ICorDebugBreakpointEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugbreakpointenum-interface.md)  
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugBreakpoint` arrays.  
  
 [ICorDebugChain Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugchain-interface.md)  
 Represents a segment of a physical or logical call stack.  
  
 [ICorDebugChainEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugchainenum-interface.md)  
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugChain` arrays.  
  
 [ICorDebugClass Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugclass-interface.md)  
 Represents a type, which can be either basic or complex (that is, user-defined). If the type is generic, `ICorDebugClass` represents the uninstantiated generic type.  
  
 [ICorDebugClass2 Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugclass2-interface.md)  
 Represents a generic class or a class with a method parameter of type <xref:System.Type>. This interface extends `ICorDebugClass`.  
  
 [ICorDebugCode Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-interface1.md)  
 Represents a segment of either Microsoft intermediate language (MSIL) code or native code.  
  
 [ICorDebugCode2 Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugcode2-interface.md)  
 Provides methods that extend the capabilities of `ICorDebugCode`.  
  
 [ICorDebugCode3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugcode3-interface.md)  
 Provides a method that extends [ICorDebugCode](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-interface1.md) and [ICorDebugCode2](../../../../docs/framework/unmanaged-api/debugging/icordebugcode2-interface.md) to provide information about a managed return value.  
  
 [ICorDebugCode4 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugcode4-interface.md)  
 Provides a method that enables a debugger to enumerate the local variables and arguments in a function.  
  
 [ICorDebugCodeEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugcodeenum-interface.md)  
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugCode` arrays.  
  
 [ICorDebugComObjectValue Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugcomobjectvalue-interface.md)  
 Provides methods to retrieve cached interface objects.  
  
 [ICorDebugContext Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugcontext-interface.md)  
 Represents a context object. This interface has not been implemented yet.  
  
 [ICorDebugController Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugcontroller-interface.md)  
 Represents a scope, either a <xref:System.Diagnostics.Process> or an <xref:System.AppDomain>, in which code execution context can be controlled.  
  
 [ICorDebugDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-interface.md)  
 Provides a callback interface that provides access to a particular target process.  
  
 [ICorDebugDataTarget2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget2-interface.md)  
 Logically extends the [ICorDebugDataTarget](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-interface.md) interface. **Available on .NET Native only.**  
  
 [ICorDebugDataTarget3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget3-interface.md)  
 Logically extends the [ICorDebugDataTarget](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-interface.md) interface to provide information about loaded modules. **Available on .NET Native only.**  
  
 [ICorDebugDebugEvent Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugdebugevent-interface.md)  
 Defines the base interface from which all `ICorDebug` debug events derive. **Available on .NET Native only.**  
  
 [ICorDebugEditAndContinueErrorInfo Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugeditandcontinueerrorinfo-interface.md)  
 Obsolete. Do not use this interface.  
  
 [ICorDebugEditAndContinueSnapshot Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugeditandcontinuesnapshot-interface.md)  
 Obsolete. Do not use this interface.  
  
 [ICorDebugEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugenum-interface1.md)  
 Serves as the abstract base interface for debugging enumerators.  
  
 [ICorDebugErrorInfoEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugerrorinfoenum-interface.md)  
 Obsolete. Do not use this interface.  
  
 [ICorDebugEval Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugeval-interface.md)  
 Provides methods to enable the debugger to execute code within the context of the code being debugged.  
  
 [ICorDebugEval2 Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugeval2-interface.md)  
 Extends `ICorDebugEval` to provide support for generic types.  
  
 [ICorDebugExceptionDebugEvent Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugexceptiondebugevent-interface.md)  
 Extends the [ICorDebugDebugEvent](../../../../docs/framework/unmanaged-api/debugging/icordebugdebugevent-interface.md) interface to support exception events. **Available on .NET Native only.**  
  
 [ICorDebugExceptionObjectCallStackEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugexceptionobjectcallstackenum-interface.md)  
 Provides an enumerator for call stack information that is embedded in an exception object.  
  
 [ICorDebugExceptionObjectValue Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugexceptionobjectvalue-interface.md)  
 Extends the [ICorDebugObjectValue](../../../../docs/framework/unmanaged-api/debugging/icordebugobjectvalue-interface.md) interface to provide stack trace information from a managed exception object.  
  
 [ICorDebugFrame Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugframe-interface.md)  
 Represents a frame on the current stack.  
  
 [ICorDebugFrameEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugframeenum-interface.md)  
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugFrame` arrays.  
  
 [ICorDebugFunction Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction-interface1.md)  
 Represents a managed function or method.  
  
 [ICorDebugFunction2 Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction2-interface.md)  
 Logically extends `ICorDebugFunction` to provide support for Just My Code step-through debugging.  
  
 [ICorDebugFunction3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction3-interface.md)  
 Logically extends the [ICorDebugFunction](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction-interface1.md) interface to provide access to code from a ReJIT request.  
  
 [ICorDebugFunctionBreakpoint Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugfunctionbreakpoint-interface.md)  
 Extends `ICorDebugBreakpoint` to support breakpoints within functions.  
  
 [ICorDebugGCReferenceEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icordebuggcreferenceenum-interface.md)  
 Provides an enumerator for objects that will be garbage-collected.  
  
 [ICorDebugGenericValue Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebuggenericvalue-interface.md)  
 A subclass of `ICorDebugValue` that applies to all values. This interface provides Get and Set methods for the value.  
  
 [ICorDebugGuidToTypeEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugguidtotypeenum-interface.md)  
 Provides an enumerator for an object that maps GUIDs and their corresponding `ICorDebugType` objects.  
  
 [ICorDebugHandleValue Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebughandlevalue-interface.md)  
 A subclass of `ICorDebugReferenceValue` that represents a reference value to which the debugger has created a handle for garbage collection.  
  
 [ICorDebugHeapEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugheapenum-interface.md)  
 Provides an enumerator for objects on the managed heap.  
  
 [ICorDebugHeapSegmentEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugheapsegmentenum-interface.md)  
 Provides an enumerator for the memory regions of the managed heap.  
  
 [ICorDebugHeapValue Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugheapvalue-interface.md)  
 A subclass of `ICorDebugValue` that represents an object that has been collected by the CLR garbage collector.  
  
 [ICorDebugHeapValue2 Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugheapvalue2-interface1.md)  
 An extension of `ICorDebugHeapValue` that provides support for runtime handles.  
  
 [ICorDebugHeapValue3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugheapvalue3-interface.md)  
 Exposes the monitor lock properties of objects.  
  
 [ICorDebugILCode Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode-interface.md)  
 Represents a segment of intermediate language (IL) code.  
  
 [ICorDebugILCode2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode2-interface.md)  
 Logically extends the [ICorDebugILCode](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode-interface.md) interface to provide methods that return the token for a function's local variable signature, and that map a profiler's instrumented intermediate language (IL) offsets to original method IL offsets.  
  
 [ICorDebugILFrame Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-interface.md)  
 Represents a stack frame of MSIL code.  
  
 [ICorDebugILFrame2 Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe2-interface.md)  
 A logical extension of `ICorDebugILFrame`.  
  
 [ICorDebugILFrame3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe3-interface.md)  
 Provides a method that encapsulates the return value of a function.  
  
 [ICorDebugILFrame4 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe4-interface.md)  
 Provides methods that allow you to access the local variables and code in a stack frame of intermediate language (IL) code. A parameter specifies whether the debugger has access to variables and code added in profiler ReJIT instrumentation.  
  
 [ICorDebugInstanceFieldSymbol Interface](../../../../docs/framework/unmanaged-api/debugging/icordebuginstancefieldsymbol-interface.md)  
 Represents the debug symbol information for an instance field. **Available on .NET Native only.**  
  
 [ICorDebugInternalFrame Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebuginternalframe-interface.md)  
 Identifies frame types for the debugger.  
  
 [ICorDebugInternalFrame2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebuginternalframe2-interface.md)  
 Provides information about internal frames, including stack address and position in relation to [ICorDebugFrame](../../../../docs/framework/unmanaged-api/debugging/icordebugframe-interface.md) objects.  
  
 [ICorDebugLoadedModule Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugloadedmodule-interface.md)  
 Provides information about a loaded module. **Available on .NET Native only.**  
  
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)  
 Provides methods to process debugger callbacks.  
  
 [ICorDebugManagedCallback2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback2-interface.md)  
 Provides methods to support debugger exception handling and managed debugging assistants (MDAs). `ICorDebugManagedCallback2` is a logical extension of `ICorDebugManagedCallback`.  
  
 [ICorDebugManagedCallback3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback3-interface.md)  
 Provides a callback method that indicates that an enabled custom debugger notification has been raised.  
  
 [ICorDebugMDA Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmda-interface.md)  
 Represents a managed debugging assistant (MDA) message.  
  
 [ICorDebugMemoryBuffer Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmemorybuffer-interface.md)  
 Represents an in-memory buffer. **Available on .NET Native only.**  
  
 [ICorDebugMergedAssemblyRecord Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmergedassemblyrecord-interface.md)  
 Provides information about a merged assembly. **Available on .NET Native only.**  
  
 [ICorDebugMetaDataLocator Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmetadatalocator-interface.md)  
 Provides metadata information to the debugger.  
  
 [ICorDebugModule Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule-interface.md)  
 Represents a CLR module, which is either an executable or a dynamic-link library (DLL).  
  
 [ICorDebugModule2 Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule2-interface.md)  
 Serves as a logical extension to `ICorDebugModule`.  
  
 [ICorDebugModule3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmodule3-interface.md)  
 Creates a symbol reader for a dynamic module.  
  
 [ICorDebugModuleBreakpoint Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugmodulebreakpoint-interface.md)  
 Extends `ICorDebugBreakpoint` to provide access to specific modules.  
  
 [ICorDebugModuleDebugEvent Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmoduledebugevent-interface.md)  
 Extends the [ICorDebugDebugEvent](../../../../docs/framework/unmanaged-api/debugging/icordebugdebugevent-interface.md) interface to support module-level events. **Available on .NET Native only.**  
  
 [ICorDebugModuleEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugmoduleenum-interface.md)  
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugModule` arrays.  
  
 [ICorDebugMutableDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmutabledatatarget-interface.md)  
 Extends the [ICorDebugDataTarget](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-interface.md) interface to support mutable data targets.  
  
 [ICorDebugNativeFrame Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugnativeframe-interface.md)  
 A specialized implementation of `ICorDebugFrame` used for native frames.  
  
 [ICorDebugNativeFrame2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugnativeframe2-interface.md)  
 Provides methods that test for child and parent frame relationships.  
  
 [ICorDebugObjectEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugobjectenum-interface.md)  
 Implements `ICorDebugEnum` methods, and enumerates arrays of objects by their relative virtual addresses (RVAs).  
  
 [ICorDebugObjectValue Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugobjectvalue-interface.md)  
 A subclass of `ICorDebugValue` that represents a value that contains an object.  
  
 [ICorDebugObjectValue2 Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugobjectvalue2-interface.md)  
 Extends `ICorDebugObjectValue` to support inheritance and overrides.  
  
 [ICorDebugProcess Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-interface.md)  
 Represents a process that is executing managed code.  
  
 [ICorDebugProcess2 Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess2-interface1.md)  
 A logical extension of `ICorDebugProcess`.  
  
 [ICorDebugProcess3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess3-interface.md)  
 Controls custom debugger notifications.  
  
 [ICorDebugProcess5 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-interface.md)  
 Extends the [ICorDebugProcess](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-interface.md) interface to support access to the managed heap, to provide information about garbage collection of managed objects, and to determine whether a debugger loads images from the application's local native image cache.  
  
 [ICorDebugProcess6 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess6-interface.md)  
 Logically extends the [ICorDebugProcess](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-interface.md) interface to enable features such as decoding managed debug events that are encoded in native exception debug events and virtual module splitting. **Available on .NET Native only.**  
  
 [ICorDebugProcess7 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess7-interface.md)  
 Provides a method that configures the debugger to handle in-memory metadata updates in the target process.  
  
 [ICorDebugProcess8 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess8-interface.md)  
 Logically extends the [ICorDebugProcess](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess-interface.md) interface to enable or disable certain types of [ICorDebugManagedCallback2](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback2-interface.md) exception callbacks.  
  
 [ICorDebugProcessEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugprocessenum-interface.md)  
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugProcess` arrays.  
  
 [ICorDebugReferenceValue Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugreferencevalue-interface.md)  
 A subclass of `ICorDebugValue` that supports reference types.  
  
 [ICorDebugRegisterSet Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-interface.md)  
 Represents the set of registers available on the machine that is currently executing code.  
  
 [ICorDebugRegisterSet2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset2-interface.md)  
 Extends the capabilities of `ICorDebugRegisterSet` for hardware platforms that have more than 64 registers.  
  
 [ICorDebugRemote Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugremote-interface.md)  
 Provides the ability to launch or attach a managed debugger to a remote target process.  
  
 [ICorDebugRemoteTarget Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugremotetarget-interface.md)  
 Provides methods that enable you to debug Silverlight-based applications in the CLR environment.  
  
 [ICorDebugRuntimeUnwindableFrame Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugruntimeunwindableframe-interface.md)  
 Provides support for unmanaged methods that require the common language runtime (CLR) to unwind a frame.  
  
 [ICorDebugStackWalk Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugstackwalk-interface.md)  
 Provides methods for getting the managed methods, or frames, on a thread’s stack.  
  
 [ICorDebugStaticFieldSymbol Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugstaticfieldsymbol-interface.md)  
 Represents the debug symbol information for a static field. **Available on .NET Native only.**  
  
 [ICorDebugStepper Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-interface.md)  
 Represents a step in code execution that is performed by a debugger, serves as an identifier between the issuance and completion of a command, and provides a way to cancel a step.  
  
 [ICorDebugStepper2 Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper2-interface1.md)  
 Provides support for Just My Code (JMC) debugging.  
  
 [ICorDebugStepperEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugstepperenum-interface.md)  
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugStepper` arrays.  
  
 [ICorDebugStringValue Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugstringvalue-interface.md)  
 A subclass of `ICorDebugHeapValue` that applies to string values.  
  
 [ICorDebugSymbolProvider Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugsymbolprovider-interface.md)  
 Provides methods that can be used to retrieve debug symbol information. **Available on .NET Native only.**  
  
 [ICorDebugSymbolProvider2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugsymbolprovider2-interface.md)  
 Logically extends the [ICorDebugSymbolProvider](../../../../docs/framework/unmanaged-api/debugging/icordebugsymbolprovider-interface.md) interface to retrieve additional debug symbol information. **Available on .NET Native only.**  
  
 [ICorDebugThread Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugthread-interface.md)  
 Represents a thread in a process. The lifetime of an `ICorDebugThread` instance is the same as the lifetime of the thread it represents.  
  
 [ICorDebugThread2 Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugthread2-interface.md)  
 Serves as a logical extension to `ICorDebugThread`.  
  
 [ICorDebugThread3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugthread3-interface.md)  
 Provides the entry point to the [ICorDebugStackWalk](../../../../docs/framework/unmanaged-api/debugging/icordebugstackwalk-interface.md) and corresponding interfaces.  
  
 [ICorDebugThread4 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugthread4-interface.md)  
 Provides thread blocking information.  
  
 [ICorDebugThreadEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugthreadenum-interface1.md)  
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugThread` arrays.  
  
 [ICorDebugType Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugtype-interface.md)  
 Represents a type, which can be either basic or complex (that is, user-defined). If the type is generic, `ICorDebugType` represents the instantiated generic type.  
  
 [ICorDebugType2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugtype2-interface.md)  
 Extends the [ICorDebugType](../../../../docs/framework/unmanaged-api/debugging/icordebugtype-interface.md) interface to retrieve the type identifier  of a base type or complex (user-defined) type.  
  
 [ICorDebugTypeEnum Interface1](../../../../docs/framework/unmanaged-api/debugging/icordebugtypeenum-interface.md)  
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugType` arrays.  
  
 [ICorDebugUnmanagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugunmanagedcallback-interface.md)  
 Provides notification of native events that are not directly related to the CLR.  
  
 "ICorDebugValue"  
 Represents a read or write value in the process being debugged.  
  
 "ICorDebugValue2"  
 Extends `ICorDebugValue` to provide support for `ICorDebugType`.  
  
 [ICorDebugValue3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvalue3-interface.md)  
 Extends the "ICorDebugValue" and "ICorDebugValue2" interfaces to provide support for arrays that are larger than 2 GB.  
  
 "ICorDebugValueBreakpoint"  
 Extends `ICorDebugBreakpoint` to provide access to specific values.  
  
 "ICorDebugValueEnum"  
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugValue` arrays.  
  
 [ICorDebugVariableHome Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablehome-interface.md)  
 Represents a local variable or argument of a function.  
  
 [ICorDebugVariableHomeEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablehomeenum-interface.md)  
 Provides an enumerator to the local variables and arguments in a function.  
  
 [ICorDebugVariableSymbol Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablesymbol-interface.md)  
 Retrieves the debug symbol information for a variable. **Available on .NET Native only.**  
  
 [ICorDebugVirtualUnwinder Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvirtualunwinder-interface.md)  
 Provides methods to help in stack unwinding. **Available on .NET Native only.**  
  
 [ICorPublish Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublish-interface.md)  
 Serves as the general interface for the publishing processes.  
  
 [ICorPublishAppDomain Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishappdomain-interface.md)  
 Represents and provides information about an application domain.  
  
 [ICorPublishAppDomainEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishappdomainenum-interface.md)  
 Provides methods that traverse a collection of `ICorPublishAppDomain` objects that currently exist within a process.  
  
 [ICorPublishEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishenum-interface.md)  
 Serves as the abstract base for publishing enumerators.  
  
 [ICorPublishProcess Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocess-interface.md)  
 Provides methods that access information about a process.  
  
 [ICorPublishProcessEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocessenum-interface.md)  
 Provides methods that traverse a collection of `ICorPublishProcess` objects.  
  
## Related Sections  
 [Debugging Coclasses](../../../../docs/framework/unmanaged-api/debugging/debugging-coclasses.md)  
  
 [Debugging Global Static Functions](../../../../docs/framework/unmanaged-api/debugging/debugging-global-static-functions.md)  
  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)  
  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)
