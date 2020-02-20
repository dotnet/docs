---
title: "Debugging Interfaces"
ms.date: "02/07/2019"
helpviewer_keywords: 
  - "unmanaged interfaces [.NET Framework], debugging"
  - "debugging interfaces [.NET Framework]"
  - "interfaces [.NET Framework debugging]"
ms.assetid: b6297c26-7624-4431-8af4-14112d07bcd5
---
# Debugging Interfaces
This section describes the unmanaged interfaces that handle the debugging of a program that is executing in the common language runtime (CLR).  
  
## In This Section  
 [ICLRDataEnumMemoryRegions Interface](iclrdataenummemoryregions-interface.md)\
 Provides a method to enumerate regions of memory that are specified by callers.  
  
 [ICLRDataEnumMemoryRegionsCallback Interface](iclrdataenummemoryregionscallback-interface.md)\
 Provides a callback method for `EnumMemoryRegions` to report to the debugger, the result of an attempt to enumerate a specified region of memory.  
  
 [ICLRDataTarget Interface](iclrdatatarget-interface.md)\
 Provides methods for interaction with a target CLR process.  
  
 [ICLRDataTarget2 Interface](iclrdatatarget2-interface.md)\
 A subclass of `ICLRDataTarget` that is used by the data access services layer to manipulate virtual memory regions in the target process.  
  
 [ICLRDataTarget3 Interface](iclrdatatarget3-interface.md)\
 A subclass of [ICLRDataTarget2](iclrdatatarget2-interface.md) that provides access to exception information.  
  
 [ICLRDebugging Interface](iclrdebugging-interface.md)\
 Provides methods that handle loading and unloading modules for debugging.  
  
 [ICLRDebuggingLibraryProvider Interface](iclrdebugginglibraryprovider-interface.md)\
 Includes the [ProvideLibrary Method](iclrdebugginglibraryprovider-providelibrary-method.md) method, which gets a library provider callback interface that allows common language runtime version-specific debugging libraries to be located and loaded on demand.  
  
 [ICLRMetadataLocator Interface](iclrmetadatalocator-interface.md)\
 Interface used by the data access services layer to locate metadata of assemblies in a target process.  
  
 [ICorDebug Interface](icordebug-interface.md)\
 Provides methods that allow developers to debug applications in the CLR environment.  
  
 [ICorDebugAppDomain Interface](icordebugappdomain-interface.md)\
 Provides methods for debugging application domains.  
  
 [ICorDebugAppDomain2 Interface](icordebugappdomain2-interface.md)\
 Provides methods to work with arrays, pointers, function pointers, and ByRef types. This interface is an extension of the `ICorDebugAppDomain` interface.  
  
 [ICorDebugAppDomain3 Interface](icordebugappdomain3-interface.md)\
 Provides methods to work with the Windows Runtime types in an application domain. This interface is an extension of the `ICorDebugAppDomain` and `ICorDebugAppDomain2` interfaces.  
  
 [ICorDebugAppDomain4 Interface](icordebugappdomain4-interface.md)\
 Logically extends the [ICorDebugAppDomain](icordebugappdomain-interface.md) interface to get a managed object from a COM callable wrapper.  
  
 [ICorDebugAppDomainEnum Interface](icordebugappdomainenum-interface.md)\
 Provides a method that returns a specified number of `ICorDebugAppDomain` values starting at the next location in the enumeration.  
  
 [ICorDebugArrayValue Interface](icordebugarrayvalue-interface.md)\
 A subclass of `ICorDebugHeapValue` that represents a single-dimensional or multi-dimensional array.  
  
 [ICorDebugAssembly Interface](icordebugassembly-interface.md)\
 Represents an assembly.  
  
 [ICorDebugAssembly2 Interface](icordebugassembly2-interface.md)\
 Represents an assembly. This interface is an extension of the `ICorDebugAssembly` interface.  
  
 [ICorDebugAssembly3 Interface](icordebugassembly3-interface.md)\
 Logically extends the [ICorDebugAssembly](icordebugassembly-interface.md) interface to provide support for container assemblies and their contained assemblies. **Available on .NET Native only.**  
  
 [ICorDebugAssemblyEnum Interface](icordebugassemblyenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugAssembly` arrays.  
  
 [ICorDebugBlockingObjectEnum Interface](icordebugblockingobjectenum-interface.md)\
 Provides an enumerator for a list of [CorDebugBlockingObject](cordebugblockingobject-structure.md) structures.  
  
 [ICorDebugBoxValue Interface](icordebugboxvalue-interface.md)\
 A subclass of `ICorDebugHeapValue` that represents a boxed value class object.  
  
 [ICorDebugBreakpoint Interface](icordebugbreakpoint-interface.md)\
 Represents a breakpoint in a function or a watch point on a value.  
  
 [ICorDebugBreakpointEnum Interface](icordebugbreakpointenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugBreakpoint` arrays.  
  
 [ICorDebugChain Interface](icordebugchain-interface.md)\
 Represents a segment of a physical or logical call stack.  
  
 [ICorDebugChainEnum Interface](icordebugchainenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugChain` arrays.  
  
 [ICorDebugClass Interface](icordebugclass-interface.md)\
 Represents a type, which can be either basic or complex (that is, user-defined). If the type is generic, `ICorDebugClass` represents the uninstantiated generic type.  
  
 [ICorDebugClass2 Interface](icordebugclass2-interface.md)\
 Represents a generic class or a class with a method parameter of type <xref:System.Type>. This interface extends `ICorDebugClass`.  
  
 [ICorDebugCode Interface](icordebugcode-interface1.md)\
 Represents a segment of either Microsoft intermediate language (MSIL) code or native code.  
  
 [ICorDebugCode2 Interface](icordebugcode2-interface.md)\
 Provides methods that extend the capabilities of `ICorDebugCode`.  
  
 [ICorDebugCode3 Interface](icordebugcode3-interface.md)\
 Provides a method that extends [ICorDebugCode](icordebugcode-interface1.md) and [ICorDebugCode2](icordebugcode2-interface.md) to provide information about a managed return value.  
  
 [ICorDebugCode4 Interface](icordebugcode4-interface.md)\
 Provides a method that enables a debugger to enumerate the local variables and arguments in a function.  
  
 [ICorDebugCodeEnum Interface](icordebugcodeenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugCode` arrays.  
  
 [ICorDebugComObjectValue Interface](icordebugcomobjectvalue-interface.md)\
 Provides methods to retrieve cached interface objects.  
  
 [ICorDebugContext Interface](icordebugcontext-interface.md)\
 Represents a context object. This interface has not been implemented yet.  
  
 [ICorDebugController Interface](icordebugcontroller-interface.md)\
 Represents a scope, either a <xref:System.Diagnostics.Process> or an <xref:System.AppDomain>, in which code execution context can be controlled.  
  
 [ICorDebugDataTarget Interface](icordebugdatatarget-interface.md)\
 Provides a callback interface that provides access to a particular target process.  
  
 [ICorDebugDataTarget2 Interface](icordebugdatatarget2-interface.md)\
 Logically extends the [ICorDebugDataTarget](icordebugdatatarget-interface.md) interface. **Available on .NET Native only.**  
  
 [ICorDebugDataTarget3 Interface](icordebugdatatarget3-interface.md)\
 Logically extends the [ICorDebugDataTarget](icordebugdatatarget-interface.md) interface to provide information about loaded modules. **Available on .NET Native only.**  
  
 [ICorDebugDebugEvent Interface](icordebugdebugevent-interface.md)\
 Defines the base interface from which all `ICorDebug` debug events derive. **Available on .NET Native only.**  
  
 [ICorDebugEditAndContinueErrorInfo Interface](icordebugeditandcontinueerrorinfo-interface.md)\
 Obsolete. Do not use this interface.  
  
 [ICorDebugEditAndContinueSnapshot Interface](icordebugeditandcontinuesnapshot-interface.md)\
 Obsolete. Do not use this interface.  
  
 [ICorDebugEnum Interface](icordebugenum-interface1.md)\
 Serves as the abstract base interface for debugging enumerators.  
  
 [ICorDebugErrorInfoEnum Interface](icordebugerrorinfoenum-interface.md)\
 Obsolete. Do not use this interface.  
  
 [ICorDebugEval Interface](icordebugeval-interface.md)\
 Provides methods to enable the debugger to execute code within the context of the code being debugged.  
  
 [ICorDebugEval2 Interface](icordebugeval2-interface.md)\
 Extends `ICorDebugEval` to provide support for generic types.  
  
 [ICorDebugExceptionDebugEvent Interface](icordebugexceptiondebugevent-interface.md)\
 Extends the [ICorDebugDebugEvent](icordebugdebugevent-interface.md) interface to support exception events. **Available on .NET Native only.**  
  
 [ICorDebugExceptionObjectCallStackEnum Interface](icordebugexceptionobjectcallstackenum-interface.md)\
 Provides an enumerator for call stack information that is embedded in an exception object.  
  
 [ICorDebugExceptionObjectValue Interface](icordebugexceptionobjectvalue-interface.md)\
 Extends the [ICorDebugObjectValue](icordebugobjectvalue-interface.md) interface to provide stack trace information from a managed exception object.  
  
 [ICorDebugFrame Interface](icordebugframe-interface.md)\
 Represents a frame on the current stack.  
  
 [ICorDebugFrameEnum Interface](icordebugframeenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugFrame` arrays.  
  
 [ICorDebugFunction Interface](icordebugfunction-interface1.md)\
 Represents a managed function or method.  
  
 [ICorDebugFunction2 Interface](icordebugfunction2-interface.md)\
 Logically extends `ICorDebugFunction` to provide support for Just My Code step-through debugging.  
  
 [ICorDebugFunction3 Interface](icordebugfunction3-interface.md)\
 Logically extends the [ICorDebugFunction](icordebugfunction-interface1.md) interface to provide access to code from a ReJIT request.  
  
 [ICorDebugFunctionBreakpoint Interface](icordebugfunctionbreakpoint-interface.md)\
 Extends `ICorDebugBreakpoint` to support breakpoints within functions.  
  
 [ICorDebugGCReferenceEnum Interface](icordebuggcreferenceenum-interface.md)\
 Provides an enumerator for objects that will be garbage-collected.  
  
 [ICorDebugGenericValue Interface](icordebuggenericvalue-interface.md)\
 A subclass of `ICorDebugValue` that applies to all values. This interface provides Get and Set methods for the value.  
  
 [ICorDebugGuidToTypeEnum Interface](icordebugguidtotypeenum-interface.md)\
 Provides an enumerator for an object that maps GUIDs and their corresponding `ICorDebugType` objects.  
  
 [ICorDebugHandleValue Interface](icordebughandlevalue-interface.md)\
 A subclass of `ICorDebugReferenceValue` that represents a reference value to which the debugger has created a handle for garbage collection.  
  
 [ICorDebugHeapEnum Interface](icordebugheapenum-interface.md)\
 Provides an enumerator for objects on the managed heap.  
  
 [ICorDebugHeapSegmentEnum Interface](icordebugheapsegmentenum-interface.md)\
 Provides an enumerator for the memory regions of the managed heap.  
  
 [ICorDebugHeapValue Interface](icordebugheapvalue-interface.md)\
 A subclass of `ICorDebugValue` that represents an object that has been collected by the CLR garbage collector.  
  
 [ICorDebugHeapValue2 Interface](icordebugheapvalue2-interface1.md)\
 An extension of `ICorDebugHeapValue` that provides support for runtime handles.  
  
 [ICorDebugHeapValue3 Interface](icordebugheapvalue3-interface.md)\
 Exposes the monitor lock properties of objects.  
  
 [ICorDebugILCode Interface](icordebugilcode-interface.md)\
 Represents a segment of intermediate language (IL) code.  
  
 [ICorDebugILCode2 Interface](icordebugilcode2-interface.md)\
 Logically extends the [ICorDebugILCode](icordebugilcode-interface.md) interface to provide methods that return the token for a function's local variable signature, and that map a profiler's instrumented intermediate language (IL) offsets to original method IL offsets.  
  
 [ICorDebugILFrame Interface](icordebugilframe-interface.md)\
 Represents a stack frame of MSIL code.  
  
 [ICorDebugILFrame2 Interface](icordebugilframe2-interface.md)\
 A logical extension of `ICorDebugILFrame`.  
  
 [ICorDebugILFrame3 Interface](icordebugilframe3-interface.md)\
 Provides a method that encapsulates the return value of a function.  
  
 [ICorDebugILFrame4 Interface](icordebugilframe4-interface.md)\
 Provides methods that allow you to access the local variables and code in a stack frame of intermediate language (IL) code. A parameter specifies whether the debugger has access to variables and code added in profiler ReJIT instrumentation.  
  
 [ICorDebugInstanceFieldSymbol Interface](icordebuginstancefieldsymbol-interface.md)\
 Represents the debug symbol information for an instance field. **Available on .NET Native only.**  
  
 [ICorDebugInternalFrame Interface](icordebuginternalframe-interface.md)\
 Identifies frame types for the debugger.  
  
 [ICorDebugInternalFrame2 Interface](icordebuginternalframe2-interface.md)\
 Provides information about internal frames, including stack address and position in relation to [ICorDebugFrame](icordebugframe-interface.md) objects.  
  
 [ICorDebugLoadedModule Interface](icordebugloadedmodule-interface.md)\
 Provides information about a loaded module. **Available on .NET Native only.**  
  
 [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)\
 Provides methods to process debugger callbacks.  
  
 [ICorDebugManagedCallback2 Interface](icordebugmanagedcallback2-interface.md)\
 Provides methods to support debugger exception handling and managed debugging assistants (MDAs). `ICorDebugManagedCallback2` is a logical extension of `ICorDebugManagedCallback`.  
  
 [ICorDebugManagedCallback3 Interface](icordebugmanagedcallback3-interface.md)\
 Provides a callback method that indicates that an enabled custom debugger notification has been raised.  
  
 [ICorDebugMDA Interface](icordebugmda-interface.md)\
 Represents a managed debugging assistant (MDA) message.  
  
 [ICorDebugMemoryBuffer Interface](icordebugmemorybuffer-interface.md)\
 Represents an in-memory buffer. **Available on .NET Native only.**  
  
 [ICorDebugMergedAssemblyRecord Interface](icordebugmergedassemblyrecord-interface.md)\
 Provides information about a merged assembly. **Available on .NET Native only.**  
  
 [ICorDebugMetaDataLocator Interface](icordebugmetadatalocator-interface.md)\
 Provides metadata information to the debugger.  
  
 [ICorDebugModule Interface](icordebugmodule-interface.md)\
 Represents a CLR module, which is either an executable or a dynamic-link library (DLL).  
  
 [ICorDebugModule2 Interface](icordebugmodule2-interface.md)\
 Serves as a logical extension to `ICorDebugModule`.  
  
 [ICorDebugModule3 Interface](icordebugmodule3-interface.md)\
 Creates a symbol reader for a dynamic module.  
  
 [ICorDebugModuleBreakpoint Interface](icordebugmodulebreakpoint-interface.md)\
 Extends `ICorDebugBreakpoint` to provide access to specific modules.  
  
 [ICorDebugModuleDebugEvent Interface](icordebugmoduledebugevent-interface.md)\
 Extends the [ICorDebugDebugEvent](icordebugdebugevent-interface.md) interface to support module-level events. **Available on .NET Native only.**  
  
 [ICorDebugModuleEnum Interface](icordebugmoduleenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugModule` arrays.  
  
 [ICorDebugMutableDataTarget Interface](icordebugmutabledatatarget-interface.md)\
 Extends the [ICorDebugDataTarget](icordebugdatatarget-interface.md) interface to support mutable data targets.  
  
 [ICorDebugNativeFrame Interface](icordebugnativeframe-interface.md)\
 A specialized implementation of `ICorDebugFrame` used for native frames.  
  
 [ICorDebugNativeFrame2 Interface](icordebugnativeframe2-interface.md)\
 Provides methods that test for child and parent frame relationships.  
  
 [ICorDebugObjectEnum Interface](icordebugobjectenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates arrays of objects by their relative virtual addresses (RVAs).  
  
 [ICorDebugObjectValue Interface](icordebugobjectvalue-interface.md)\
 A subclass of `ICorDebugValue` that represents a value that contains an object.  
  
 [ICorDebugObjectValue2 Interface](icordebugobjectvalue2-interface.md)\
 Extends `ICorDebugObjectValue` to support inheritance and overrides.  
  
 [ICorDebugProcess Interface](icordebugprocess-interface.md)\
 Represents a process that is executing managed code.  
  
 [ICorDebugProcess2 Interface](icordebugprocess2-interface1.md)\
 A logical extension of `ICorDebugProcess`.  
  
 [ICorDebugProcess3 Interface](icordebugprocess3-interface.md)\
 Controls custom debugger notifications.

 [ICorDebugProcess4 Interface](icordebugprocess4-interface.md)\
 Provides support for out of process execution control.
  
 [ICorDebugProcess5 Interface](icordebugprocess5-interface.md)\
 Extends the [ICorDebugProcess](icordebugprocess-interface.md) interface to support access to the managed heap, to provide information about garbage collection of managed objects, and to determine whether a debugger loads images from the application's local native image cache.  
  
 [ICorDebugProcess6 Interface](icordebugprocess6-interface.md)\
 Logically extends the [ICorDebugProcess](icordebugprocess-interface.md) interface to enable features such as decoding managed debug events that are encoded in native exception debug events and virtual module splitting. **Available on .NET Native only.**  
  
 [ICorDebugProcess7 Interface](icordebugprocess7-interface.md)\
 Provides a method that configures the debugger to handle in-memory metadata updates in the target process.  
  
 [ICorDebugProcess8 Interface](icordebugprocess8-interface.md)\
 Logically extends the [ICorDebugProcess](icordebugprocess-interface.md) interface to enable or disable certain types of [ICorDebugManagedCallback2](icordebugmanagedcallback2-interface.md) exception callbacks.  
  
 [ICorDebugProcessEnum Interface](icordebugprocessenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugProcess` arrays.  
  
 [ICorDebugReferenceValue Interface](icordebugreferencevalue-interface.md)\
 A subclass of `ICorDebugValue` that supports reference types.  
  
 [ICorDebugRegisterSet Interface](icordebugregisterset-interface.md)\
 Represents the set of registers available on the machine that is currently executing code.  
  
 [ICorDebugRegisterSet2 Interface](icordebugregisterset2-interface.md)\
 Extends the capabilities of `ICorDebugRegisterSet` for hardware platforms that have more than 64 registers.  
  
 [ICorDebugRemote Interface](icordebugremote-interface.md)\
 Provides the ability to launch or attach a managed debugger to a remote target process.  
  
 [ICorDebugRemoteTarget Interface](icordebugremotetarget-interface.md)\
 Provides methods that enable you to debug Silverlight-based applications in the CLR environment.  
  
 [ICorDebugRuntimeUnwindableFrame Interface](icordebugruntimeunwindableframe-interface.md)\
 Provides support for unmanaged methods that require the common language runtime (CLR) to unwind a frame.  
  
 [ICorDebugStackWalk Interface](icordebugstackwalk-interface.md)\
 Provides methods for getting the managed methods, or frames, on a thread’s stack.  
  
 [ICorDebugStaticFieldSymbol Interface](icordebugstaticfieldsymbol-interface.md)\
 Represents the debug symbol information for a static field. **Available on .NET Native only.**  
  
 [ICorDebugStepper Interface](icordebugstepper-interface.md)\
 Represents a step in code execution that is performed by a debugger, serves as an identifier between the issuance and completion of a command, and provides a way to cancel a step.  
  
 [ICorDebugStepper2 Interface](icordebugstepper2-interface1.md)\
 Provides support for Just My Code (JMC) debugging.  
  
 [ICorDebugStepperEnum Interface](icordebugstepperenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugStepper` arrays.  
  
 [ICorDebugStringValue Interface](icordebugstringvalue-interface.md)\
 A subclass of `ICorDebugHeapValue` that applies to string values.  
  
 [ICorDebugSymbolProvider Interface](icordebugsymbolprovider-interface.md)\
 Provides methods that can be used to retrieve debug symbol information. **Available on .NET Native only.**  
  
 [ICorDebugSymbolProvider2 Interface](icordebugsymbolprovider2-interface.md)\
 Logically extends the [ICorDebugSymbolProvider](icordebugsymbolprovider-interface.md) interface to retrieve additional debug symbol information. **Available on .NET Native only.**  
  
 [ICorDebugThread Interface](icordebugthread-interface.md)\
 Represents a thread in a process. The lifetime of an `ICorDebugThread` instance is the same as the lifetime of the thread it represents.  
  
 [ICorDebugThread2 Interface](icordebugthread2-interface.md)\
 Serves as a logical extension to `ICorDebugThread`.  
  
 [ICorDebugThread3 Interface](icordebugthread3-interface.md)\
 Provides the entry point to the [ICorDebugStackWalk](icordebugstackwalk-interface.md) and corresponding interfaces.  
  
 [ICorDebugThread4 Interface](icordebugthread4-interface.md)\
 Provides thread blocking information.  
  
 [ICorDebugThreadEnum Interface](icordebugthreadenum-interface1.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugThread` arrays.  
  
 [ICorDebugType Interface](icordebugtype-interface.md)\
 Represents a type, which can be either basic or complex (that is, user-defined). If the type is generic, `ICorDebugType` represents the instantiated generic type.  
  
 [ICorDebugType2 Interface](icordebugtype2-interface.md)\
 Extends the [ICorDebugType](icordebugtype-interface.md) interface to retrieve the type identifier  of a base type or complex (user-defined) type.  
  
 [ICorDebugTypeEnum Interface](icordebugtypeenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugType` arrays.  
  
 [ICorDebugUnmanagedCallback Interface](icordebugunmanagedcallback-interface.md)\
 Provides notification of native events that are not directly related to the CLR.  
  
 [ICorDebugValue](icordebugvalue-interface.md)\
 Represents a read or write value in the process being debugged.  
  
 [ICorDebugValue2](icordebugvalue2-interface.md)\
 Extends `ICorDebugValue` to provide support for `ICorDebugType`.  
  
 [ICorDebugValue3 Interface](icordebugvalue3-interface.md)\
 Extends the "ICorDebugValue" and "ICorDebugValue2" interfaces to provide support for arrays that are larger than 2 GB.  
  
 [ICorDebugValueBreakpoint](icordebugvaluebreakpoint-interface.md)\
 Extends `ICorDebugBreakpoint` to provide access to specific values.  
  
 [ICorDebugValueEnum](icordebugvalueenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugValue` arrays.  
  
 [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)\
 Represents a local variable or argument of a function.  
  
 [ICorDebugVariableHomeEnum Interface](icordebugvariablehomeenum-interface.md)\
 Provides an enumerator to the local variables and arguments in a function.  
  
 [ICorDebugVariableSymbol Interface](icordebugvariablesymbol-interface.md)\
 Retrieves the debug symbol information for a variable. **Available on .NET Native only.**  
  
 [ICorDebugVirtualUnwinder Interface](icordebugvirtualunwinder-interface.md)\
 Provides methods to help in stack unwinding. **Available on .NET Native only.**  
  
 [ICorPublish Interface](icorpublish-interface.md)\
 Serves as the general interface for the publishing processes.  
  
 [ICorPublishAppDomain Interface](icorpublishappdomain-interface.md)\
 Represents and provides information about an application domain.  
  
 [ICorPublishAppDomainEnum Interface](icorpublishappdomainenum-interface.md)\
 Provides methods that traverse a collection of `ICorPublishAppDomain` objects that currently exist within a process.  
  
 [ICorPublishEnum Interface](icorpublishenum-interface.md)\
 Serves as the abstract base for publishing enumerators.  
  
 [ICorPublishProcess Interface](icorpublishprocess-interface.md)\
 Provides methods that access information about a process.  
  
 [ICorPublishProcessEnum Interface](icorpublishprocessenum-interface.md)\
 Provides methods that traverse a collection of `ICorPublishProcess` objects.  

 [ISOSDacInterface Interface](isosdacinterface-interface.md)\
 Provides helper methods to access data from `SOS`.

 [IXCLRDataMethodDefinition Interface](ixclrdatamethoddefinition-interface.md)\
 Provides methods for querying information about a method definition.
 
 [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)\
 Provides methods for querying information about a method instance.
 
 [IXCLRDataModule Interface](ixclrdatamodule-interface.md)\
 Provides methods for querying information about a loaded module.
 
 [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)\
 Provides methods for querying information about a process.
  
## Related Sections  
 [Debugging Coclasses](debugging-coclasses.md)\
 [Debugging Global Static Functions](debugging-global-static-functions.md)\
 [Debugging Enumerations](debugging-enumerations.md)\
 [Debugging Structures](debugging-structures.md)\
