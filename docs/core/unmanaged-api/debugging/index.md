---
description: "Learn more about unmanaged APIs for debugging .NET"
title: .NET debugging (unmanaged API reference)
ms.date: 09/19/2023
---
# .NET debugging (unmanaged API reference)

The articles in this section describe the unmanaged APIs that the common language runtime (CLR) provides to support debugging .NET applications that are running on Windows, Linux, or macOS operating systems.

These articles describe APIs that were introduced in .NET Core 2.0 or later, or were introduced in .NET Framework but can be used on .NET (Core). For .NET Framework-specific unmanaged APIs, see [.NET Framework debugging](../../../framework/unmanaged-api/debugging/index.md).

## Functions

[CloseCLREnumeration function](closeclrenumeration-function.md)\
Closes any valid CLR continue-startup events located in an array of handles returned by the [EnumerateCLRs function](enumerateclrs-function.md), and frees the memory for the handle and string path arrays.

[CloseResumeHandle function](closeresumehandle-function.md)\
Closes the handle returned by the [CreateProcessForLaunch function](createprocessforlaunch-function.md).

[CLRCreateInstance function](clrcreateinstance-function.md)\
Provides the [ICLRDebugging](../../../framework/unmanaged-api/debugging/iclrdebugging-interface.md) interface.

[CreateDebuggingInterfaceFromVersion function](createdebugginginterfacefromversion-function.md)\
Accepts a CLR version string returned from the [CreateVersionStringFromModule function](createversionstringfrommodule-function.md) function, and returns a corresponding debugger interface.

[CreateDebuggingInterfaceFromVersionEx function](createdebugginginterfacefromversionex-function.md)\
Accepts a CLR version string returned from the [CreateVersionStringFromModule function](createversionstringfrommodule-function.md) function, and returns a corresponding debugger interface.

[CreateDebuggingInterfaceFromVersion2 function](createdebugginginterfacefromversion2-function.md)\
Accepts a CLR version string returned from the [CreateVersionStringFromModule function](createversionstringfrommodule-function.md)function, and returns a corresponding debugger interface.

[CreateDebuggingInterfaceFromVersion3 function](createdebugginginterfacefromversion3-function.md)\
Accepts a CLR version string returned from the [CreateVersionStringFromModule function](createversionstringfrommodule-function.md) function, and returns a corresponding debugger interface.

[CreateProcessForLaunch function](createprocessforlaunch-function.md)\
A subset of the Windows CreateProcess that can be supported cross-platform.

[CreateVersionStringFromModule function](createversionstringfrommodule-function.md)\
Creates a version string from a CLR path in a target process.

[EnumerateCLRs function](enumerateclrs-function.md)\
Provides a mechanism for enumerating the CLRs in a process.

[GetStartupNotificationEvent function](getstartupnotificationevent-function.md)\
Creates or opens an event handle that will be signaled upon by any common language runtime (CLR) that is loading in the specified target process.

[RegisterForRuntimeStartup function](registerforruntimestartup-function.md)\
Executes the callback when the .NET runtime starts in the specified process.

[RegisterForRuntimeStartupEx function](registerforruntimestartupex-function.md)\
Executes the callback when the .NET runtime starts in the specified process.

[RegisterForRuntimeStartup3 function](registerforruntimestartup3-function.md)\
Executes the callback when the .NET runtime starts in the specified process.

[ResumeProcess function](resumeprocess-function.md)\
Resumes the process using the resume handle returned by the [CreateProcessForLaunch function](createprocessforlaunch-function.md).

[UnregisterForRuntimeStartup function](unregisterforruntimestartup-function.md)\
Stops/cancels runtime startup notification.

## Function pointers

[PSTARTUP_CALLBACK function pointer](pstartup_callback-function-pointer.md)\
Points to a function that's called when the .NET runtime has started for the [RegisterForRuntimeStartup](registerforruntimestartup-function.md) API.

## Enumerations

[LIBRARY_PROVIDER_INDEX_TYPE enumeration](libraryproviderindextype-enumeration.md)\
The type of index information passed to the library provider is either the identity of the requested module or of the runtime (coreclr) module.

## interfaces

[ICLRDebuggingLibraryProvider2 interface](iclrdebugginglibraryprovider2-interface.md)\
Includes the [ProvideLibrary2](iclrdebugginglibraryprovider2-providelibrary2-method.md) method, which allows the debugger to provide a path to a version-specific debugging library.

[ICLRDebuggingLibraryProvider3 interface](iclrdebugginglibraryprovider3-interface.md)\
Includes callback methods that allow common language runtime version-specific debugging libraries to be located and loaded on demand for .NET regular and single-file applications.

 [ICorDebug interface](icordebug/icordebug-interface.md)\
 Provides methods that allow developers to debug applications in the CLR environment.

 [ICorDebugAppDomain interface](icordebug/icordebugappdomain-interface.md)\
 Provides methods for debugging application domains.

 [ICorDebugAppDomain2 interface](icordebug/icordebugappdomain2-interface.md)\
 Provides methods to work with arrays, pointers, function pointers, and ByRef types. This interface is an extension of the `ICorDebugAppDomain` interface.

 [ICorDebugAppDomain3 interface](icordebug/icordebugappdomain3-interface.md)\
 Provides methods to work with the Windows Runtime types in an application domain. This interface is an extension of the `ICorDebugAppDomain` and `ICorDebugAppDomain2` interfaces.

 [ICorDebugAppDomain4 interface](icordebug/icordebugappdomain4-interface.md)\
 Logically extends the [ICorDebugAppDomain](icordebug/icordebugappdomain-interface.md) interface to get a managed object from a COM callable wrapper.

 [ICorDebugAppDomainEnum interface](icordebug/icordebugappdomainenum-interface.md)\
 Provides a method that returns a specified number of `ICorDebugAppDomain` values starting at the next location in the enumeration.

 [ICorDebugArrayValue interface](icordebug/icordebugarrayvalue-interface.md)\
 A subclass of `ICorDebugHeapValue` that represents a single-dimensional or multi-dimensional array.

 [ICorDebugAssembly interface](icordebug/icordebugassembly-interface.md)\
 Represents an assembly.

 [ICorDebugAssembly2 interface](icordebug/icordebugassembly2-interface.md)\
 Represents an assembly. This interface is an extension of the `ICorDebugAssembly` interface.

 [ICorDebugAssembly3 interface](icordebug/icordebugassembly3-interface.md)\
 Logically extends the [ICorDebugAssembly](icordebug/icordebugassembly-interface.md) interface to provide support for container assemblies and their contained assemblies. **Available on .NET Native only.**

 [ICorDebugAssemblyEnum interface](icordebug/icordebugassemblyenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugAssembly` arrays.

 [ICorDebugBlockingObjectEnum interface](icordebug/icordebugblockingobjectenum-interface.md)\
 Provides an enumerator for a list of [CorDebugBlockingObject](cordebugblockingobject-structure.md) structures.

 [ICorDebugBoxValue interface](icordebug/icordebugboxvalue-interface.md)\
 A subclass of `ICorDebugHeapValue` that represents a boxed value class object.

 [ICorDebugBreakpoint interface](icordebug/icordebugbreakpoint-interface.md)\
 Represents a breakpoint in a function or a watch point on a value.

 [ICorDebugBreakpointEnum interface](icordebug/icordebugbreakpointenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugBreakpoint` arrays.

 [ICorDebugChain interface](icordebug/icordebugchain-interface.md)\
 Represents a segment of a physical or logical call stack.

 [ICorDebugChainEnum interface](icordebug/icordebugchainenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugChain` arrays.

 [ICorDebugClass interface](icordebug/icordebugclass-interface.md)\
 Represents a type, which can be either basic or complex (that is, user-defined). If the type is generic, `ICorDebugClass` represents the uninstantiated generic type.

 [ICorDebugClass2 interface](icordebug/icordebugclass2-interface.md)\
 Represents a generic class or a class with a method parameter of type <xref:System.Type>. This interface extends `ICorDebugClass`.

 [ICorDebugCode interface](icordebug/icordebugcode-interface1.md)\
 Represents a segment of either common intermediate language (CIL) code or native code.

 [ICorDebugCode2 interface](icordebug/icordebugcode2-interface.md)\
 Provides methods that extend the capabilities of `ICorDebugCode`.

 [ICorDebugCode3 interface](icordebug/icordebugcode3-interface.md)\
 Provides a method that extends [ICorDebugCode](icordebug/icordebugcode-interface1.md) and [ICorDebugCode2](icordebug/icordebugcode2-interface.md) to provide information about a managed return value.

 [ICorDebugCode4 interface](icordebug/icordebugcode4-interface.md)\
 Provides a method that enables a debugger to enumerate the local variables and arguments in a function.

 [ICorDebugCodeEnum interface](icordebug/icordebugcodeenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugCode` arrays.

 [ICorDebugComObjectValue interface](icordebug/icordebugcomobjectvalue-interface.md)\
 Provides methods to retrieve cached interface objects.

 [ICorDebugContext interface](icordebug/icordebugcontext-interface.md)\
 Represents a context object. This interface has not been implemented yet.

 [ICorDebugController interface](icordebug/icordebugcontroller-interface.md)\
 Represents a scope, either a <xref:System.Diagnostics.Process> or an <xref:System.AppDomain>, in which code execution context can be controlled.

 [ICorDebugDataTarget interface](icordebug/icordebugdatatarget-interface.md)\
 Provides a callback interface that provides access to a particular target process.

 [ICorDebugDataTarget2 interface](icordebug/icordebugdatatarget2-interface.md)\
 Logically extends the [ICorDebugDataTarget](icordebug/icordebugdatatarget-interface.md) interface. **Available on .NET Native only.**

 [ICorDebugDataTarget3 interface](icordebug/icordebugdatatarget3-interface.md)\
 Logically extends the [ICorDebugDataTarget](icordebug/icordebugdatatarget-interface.md) interface to provide information about loaded modules. **Available on .NET Native only.**

 [ICorDebugDebugEvent interface](icordebug/icordebugdebugevent-interface.md)\
 Defines the base interface from which all `ICorDebug` debug events derive. **Available on .NET Native only.**

 [ICorDebugEditAndContinueErrorInfo interface](icordebug/icordebugeditandcontinueerrorinfo-interface.md)\
 Obsolete. Do not use this interface.

 [ICorDebugEditAndContinueSnapshot interface](icordebug/icordebugeditandcontinuesnapshot-interface.md)\
 Obsolete. Do not use this interface.

 [ICorDebugEnum interface](icordebug/icordebugenum-interface1.md)\
 Serves as the abstract base interface for debugging enumerators.

 [ICorDebugErrorInfoEnum interface](icordebug/icordebugerrorinfoenum-interface.md)\
 Obsolete. Do not use this interface.

 [ICorDebugEval interface](icordebug/icordebugeval-interface.md)\
 Provides methods to enable the debugger to execute code within the context of the code being debugged.

 [ICorDebugEval2 interface](icordebug/icordebugeval2-interface.md)\
 Extends `ICorDebugEval` to provide support for generic types.

 [ICorDebugExceptionDebugEvent interface](icordebug/icordebugexceptiondebugevent-interface.md)\
 Extends the [ICorDebugDebugEvent](icordebug/icordebugdebugevent-interface.md) interface to support exception events. **Available on .NET Native only.**

 [ICorDebugExceptionObjectCallStackEnum interface](icordebug/icordebugexceptionobjectcallstackenum-interface.md)\
 Provides an enumerator for call stack information that is embedded in an exception object.

 [ICorDebugExceptionObjectValue interface](icordebug/icordebugexceptionobjectvalue-interface.md)\
 Extends the [ICorDebugObjectValue](icordebug/icordebugobjectvalue-interface.md) interface to provide stack trace information from a managed exception object.

 [ICorDebugFrame interface](icordebug/icordebugframe-interface.md)\
 Represents a frame on the current stack.

 [ICorDebugFrameEnum interface](icordebug/icordebugframeenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugFrame` arrays.

 [ICorDebugFunction interface](icordebug/icordebugfunction-interface1.md)\
 Represents a managed function or method.

 [ICorDebugFunction2 interface](icordebug/icordebugfunction2-interface.md)\
 Logically extends `ICorDebugFunction` to provide support for Just My Code step-through debugging.

 [ICorDebugFunction3 interface](icordebug/icordebugfunction3-interface.md)\
 Logically extends the [ICorDebugFunction](icordebug/icordebugfunction-interface1.md) interface to provide access to code from a ReJIT request.

 [ICorDebugFunctionBreakpoint interface](icordebug/icordebugfunctionbreakpoint-interface.md)\
 Extends `ICorDebugBreakpoint` to support breakpoints within functions.

 [ICorDebugGCReferenceEnum interface](icordebug/icordebuggcreferenceenum-interface.md)\
 Provides an enumerator for objects that will be garbage-collected.

 [ICorDebugGenericValue interface](icordebug/icordebuggenericvalue-interface.md)\
 A subclass of `ICorDebugValue` that applies to all values. This interface provides Get and Set methods for the value.

 [ICorDebugGuidToTypeEnum interface](icordebug/icordebugguidtotypeenum-interface.md)\
 Provides an enumerator for an object that maps GUIDs and their corresponding `ICorDebugType` objects.

 [ICorDebugHandleValue interface](icordebug/icordebughandlevalue-interface.md)\
 A subclass of `ICorDebugReferenceValue` that represents a reference value to which the debugger has created a handle for garbage collection.

 [ICorDebugHeapEnum interface](icordebug/icordebugheapenum-interface.md)\
 Provides an enumerator for objects on the managed heap.

 [ICorDebugHeapSegmentEnum interface](icordebug/icordebugheapsegmentenum-interface.md)\
 Provides an enumerator for the memory regions of the managed heap.

 [ICorDebugHeapValue interface](icordebug/icordebugheapvalue-interface.md)\
 A subclass of `ICorDebugValue` that represents an object that has been collected by the CLR garbage collector.

 [ICorDebugHeapValue2 interface](icordebug/icordebugheapvalue2-interface1.md)\
 An extension of `ICorDebugHeapValue` that provides support for runtime handles.

 [ICorDebugHeapValue3 interface](icordebug/icordebugheapvalue3-interface.md)\
 Exposes the monitor lock properties of objects.

 [ICorDebugILCode interface](icordebug/icordebugilcode-interface.md)\
 Represents a segment of intermediate language (IL) code.

 [ICorDebugILCode2 interface](icordebug/icordebugilcode2-interface.md)\
 Logically extends the [ICorDebugILCode](icordebug/icordebugilcode-interface.md) interface to provide methods that return the token for a function's local variable signature, and that map a profiler's instrumented intermediate language (IL) offsets to original method IL offsets.

 [ICorDebugILFrame interface](icordebug/icordebugilframe-interface.md)\
 Represents a stack frame of CIL code.

 [ICorDebugILFrame2 interface](icordebug/icordebugilframe2-interface.md)\
 A logical extension of `ICorDebugILFrame`.

 [ICorDebugILFrame3 interface](icordebug/icordebugilframe3-interface.md)\
 Provides a method that encapsulates the return value of a function.

 [ICorDebugILFrame4 interface](icordebug/icordebugilframe4-interface.md)\
 Provides methods that allow you to access the local variables and code in a stack frame of intermediate language (IL) code. A parameter specifies whether the debugger has access to variables and code added in profiler ReJIT instrumentation.

 [ICorDebugInstanceFieldSymbol interface](icordebug/icordebuginstancefieldsymbol-interface.md)\
 Represents the debug symbol information for an instance field. **Available on .NET Native only.**

 [ICorDebugInternalFrame interface](icordebug/icordebuginternalframe-interface.md)\
 Identifies frame types for the debugger.

 [ICorDebugInternalFrame2 interface](icordebug/icordebuginternalframe2-interface.md)\
 Provides information about internal frames, including stack address and position in relation to [ICorDebugFrame](icordebug/icordebugframe-interface.md) objects.

 [ICorDebugLoadedModule interface](icordebug/icordebugloadedmodule-interface.md)\
 Provides information about a loaded module. **Available on .NET Native only.**

 [ICorDebugManagedCallback interface](icordebug/icordebugmanagedcallback-interface.md)\
 Provides methods to process debugger callbacks.

 [ICorDebugManagedCallback2 interface](icordebug/icordebugmanagedcallback2-interface.md)\
 Provides methods to support debugger exception handling and managed debugging assistants (MDAs). `ICorDebugManagedCallback2` is a logical extension of `ICorDebugManagedCallback`.

 [ICorDebugManagedCallback3 interface](icordebug/icordebugmanagedcallback3-interface.md)\
 Provides a callback method that indicates that an enabled custom debugger notification has been raised.

 [ICorDebugMDA interface](icordebug/icordebugmda-interface.md)\
 Represents a managed debugging assistant (MDA) message.

 [ICorDebugMemoryBuffer interface](icordebug/icordebugmemorybuffer-interface.md)\
 Represents an in-memory buffer. **Available on .NET Native only.**

 [ICorDebugMergedAssemblyRecord interface](icordebug/icordebugmergedassemblyrecord-interface.md)\
 Provides information about a merged assembly. **Available on .NET Native only.**

 [ICorDebugMetaDataLocator interface](icordebug/icordebugmetadatalocator-interface.md)\
 Provides metadata information to the debugger.

 [ICorDebugModule interface](icordebug/icordebugmodule-interface.md)\
 Represents a CLR module, which is either an executable or a dynamic-link library (DLL).

 [ICorDebugModule2 interface](icordebug/icordebugmodule2-interface.md)\
 Serves as a logical extension to `ICorDebugModule`.

 [ICorDebugModule3 interface](icordebug/icordebugmodule3-interface.md)\
 Creates a symbol reader for a dynamic module.

 [ICorDebugModule4 interface](icordebug/icordebugmodule4-interface.md)\
 Provides a method that determines whether the module is loaded into memory in mapped/hydrated format.

 [ICorDebugModuleBreakpoint interface](icordebug/icordebugmodulebreakpoint-interface.md)\
 Extends `ICorDebugBreakpoint` to provide access to specific modules.

 [ICorDebugModuleDebugEvent interface](icordebug/icordebugmoduledebugevent-interface.md)\
 Extends the [ICorDebugDebugEvent](icordebug/icordebugdebugevent-interface.md) interface to support module-level events. **Available on .NET Native only.**

 [ICorDebugModuleEnum interface](icordebug/icordebugmoduleenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugModule` arrays.

 [ICorDebugMutableDataTarget interface](icordebug/icordebugmutabledatatarget-interface.md)\
 Extends the [ICorDebugDataTarget](icordebug/icordebugdatatarget-interface.md) interface to support mutable data targets.

 [ICorDebugNativeFrame interface](icordebug/icordebugnativeframe-interface.md)\
 A specialized implementation of `ICorDebugFrame` used for native frames.

 [ICorDebugNativeFrame2 interface](icordebug/icordebugnativeframe2-interface.md)\
 Provides methods that test for child and parent frame relationships.

 [ICorDebugObjectEnum interface](icordebug/icordebugobjectenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates arrays of objects by their relative virtual addresses (RVAs).

 [ICorDebugObjectValue interface](icordebug/icordebugobjectvalue-interface.md)\
 A subclass of `ICorDebugValue` that represents a value that contains an object.

 [ICorDebugObjectValue2 interface](icordebug/icordebugobjectvalue2-interface.md)\
 Extends `ICorDebugObjectValue` to support inheritance and overrides.

 [ICorDebugProcess interface](icordebug/icordebugprocess-interface.md)\
 Represents a process that is executing managed code.

 [ICorDebugProcess2 interface](icordebug/icordebugprocess2-interface1.md)\
 A logical extension of `ICorDebugProcess`.

 [ICorDebugProcess3 interface](icordebug/icordebugprocess3-interface.md)\
 Controls custom debugger notifications.

 [ICorDebugProcess4 interface](icordebug/icordebugprocess4-interface.md)\
 Provides support for out of process execution control.

 [ICorDebugProcess5 interface](icordebug/icordebugprocess5-interface.md)\
 Extends the [ICorDebugProcess](icordebug/icordebugprocess-interface.md) interface to support access to the managed heap, to provide information about garbage collection of managed objects, and to determine whether a debugger loads images from the application's local native image cache.

 [ICorDebugProcess6 interface](icordebug/icordebugprocess6-interface.md)\
 Logically extends the [ICorDebugProcess](icordebug/icordebugprocess-interface.md) interface to enable features such as decoding managed debug events that are encoded in native exception debug events and virtual module splitting. **Available on .NET Native only.**

 [ICorDebugProcess7 interface](icordebug/icordebugprocess7-interface.md)\
 Provides a method that configures the debugger to handle in-memory metadata updates in the target process.

 [ICorDebugProcess8 interface](icordebug/icordebugprocess8-interface.md)\
 Logically extends the [ICorDebugProcess](icordebug/icordebugprocess-interface.md) interface to enable or disable certain types of [ICorDebugManagedCallback2](icordebug/icordebugmanagedcallback2-interface.md) exception callbacks.

 [ICorDebugProcess11 interface](icordebug/icordebugprocess11-interface.md)\
 Provides a method that enumerates ranges of native memory that are used by the .NET runtime to store internal data structures that describe .NET types and methods. The information returned is the same information that would be shown by using the SOS `eeheap -loader` command.

 [ICorDebugProcessEnum interface](icordebug/icordebugprocessenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugProcess` arrays.

 [ICorDebugReferenceValue interface](icordebug/icordebugreferencevalue-interface.md)\
 A subclass of `ICorDebugValue` that supports reference types.

 [ICorDebugRegisterSet interface](icordebug/icordebugregisterset-interface.md)\
 Represents the set of registers available on the machine that is currently executing code.

 [ICorDebugRegisterSet2 interface](icordebug/icordebugregisterset2-interface.md)\
 Extends the capabilities of `ICorDebugRegisterSet` for hardware platforms that have more than 64 registers.

 [ICorDebugRemote interface](icordebug/icordebugremote-interface.md)\
 Provides the ability to launch or attach a managed debugger to a remote target process.

 [ICorDebugRemoteTarget interface](icordebug/icordebugremotetarget-interface.md)\
 Provides methods that enable you to debug Silverlight-based applications in the CLR environment.

 [ICorDebugRuntimeUnwindableFrame interface](icordebug/icordebugruntimeunwindableframe-interface.md)\
 Provides support for unmanaged methods that require the common language runtime (CLR) to unwind a frame.

 [ICorDebugStackWalk interface](icordebug/icordebugstackwalk-interface.md)\
 Provides methods for getting the managed methods, or frames, on a thread’s stack.

 [ICorDebugStaticFieldSymbol interface](icordebug/icordebugstaticfieldsymbol-interface.md)\
 Represents the debug symbol information for a static field. **Available on .NET Native only.**

 [ICorDebugStepper interface](icordebug/icordebugstepper-interface.md)\
 Represents a step in code execution that is performed by a debugger, serves as an identifier between the issuance and completion of a command, and provides a way to cancel a step.

 [ICorDebugStepper2 interface](icordebug/icordebugstepper2-interface1.md)\
 Provides support for Just My Code (JMC) debugging.

 [ICorDebugStepperEnum interface](icordebug/icordebugstepperenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugStepper` arrays.

 [ICorDebugStringValue interface](icordebug/icordebugstringvalue-interface.md)\
 A subclass of `ICorDebugHeapValue` that applies to string values.

 [ICorDebugSymbolProvider interface](icordebug/icordebugsymbolprovider-interface.md)\
 Provides methods that can be used to retrieve debug symbol information. **Available on .NET Native only.**

 [ICorDebugSymbolProvider2 interface](icordebug/icordebugsymbolprovider2-interface.md)\
 Logically extends the [ICorDebugSymbolProvider](icordebug/icordebugsymbolprovider-interface.md) interface to retrieve additional debug symbol information. **Available on .NET Native only.**

 [ICorDebugThread interface](icordebug/icordebugthread-interface.md)\
 Represents a thread in a process. The lifetime of an `ICorDebugThread` instance is the same as the lifetime of the thread it represents.

 [ICorDebugThread2 interface](icordebug/icordebugthread2-interface.md)\
 Serves as a logical extension to `ICorDebugThread`.

 [ICorDebugThread3 interface](icordebug/icordebugthread3-interface.md)\
 Provides the entry point to the [ICorDebugStackWalk](icordebug/icordebugstackwalk-interface.md) and corresponding interfaces.

 [ICorDebugThread4 interface](icordebug/icordebugthread4-interface.md)\
 Provides thread blocking information.

 [ICorDebugThreadEnum interface](icordebug/icordebugthreadenum-interface1.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugThread` arrays.

 [ICorDebugType interface](icordebug/icordebugtype-interface.md)\
 Represents a type, which can be either basic or complex (that is, user-defined). If the type is generic, `ICorDebugType` represents the instantiated generic type.

 [ICorDebugType2 interface](icordebug/icordebugtype2-interface.md)\
 Extends the [ICorDebugType](icordebug/icordebugtype-interface.md) interface to retrieve the type identifier  of a base type or complex (user-defined) type.

 [ICorDebugTypeEnum interface](icordebug/icordebugtypeenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugType` arrays.

 [ICorDebugUnmanagedCallback interface](icordebug/icordebugunmanagedcallback-interface.md)\
 Provides notification of native events that are not directly related to the CLR.

 [ICorDebugValue](icordebug/icordebugvalue-interface.md)\
 Represents a read or write value in the process being debugged.

 [ICorDebugValue2](icordebug/icordebugvalue2-interface.md)\
 Extends `ICorDebugValue` to provide support for `ICorDebugType`.

 [ICorDebugValue3 interface](icordebug/icordebugvalue3-interface.md)\
 Extends the "ICorDebugValue" and "ICorDebugValue2" interfaces to provide support for arrays that are larger than 2 GB.

 [ICorDebugValueBreakpoint](icordebug/icordebugvaluebreakpoint-interface.md)\
 Extends `ICorDebugBreakpoint` to provide access to specific values.

 [ICorDebugValueEnum](icordebug/icordebugvalueenum-interface.md)\
 Implements `ICorDebugEnum` methods, and enumerates `ICorDebugValue` arrays.

 [ICorDebugVariableHome interface](icordebug/icordebugvariablehome-interface.md)\
 Represents a local variable or argument of a function.

 [ICorDebugVariableHomeEnum interface](icordebug/icordebugvariablehomeenum-interface.md)\
 Provides an enumerator to the local variables and arguments in a function.

 [ICorDebugVariableSymbol interface](icordebug/icordebugvariablesymbol-interface.md)\
 Retrieves the debug symbol information for a variable. **Available on .NET Native only.**

 [ICorDebugVirtualUnwinder interface](icordebug/icordebugvirtualunwinder-interface.md)\
 Provides methods to help in stack unwinding. **Available on .NET Native only.**
