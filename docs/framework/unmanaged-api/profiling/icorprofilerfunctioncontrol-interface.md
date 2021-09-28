---
description: "Learn more about: ICorProfilerFunctionControl Interface"
title: "ICorProfilerFunctionControl Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerFunctionControl"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerFunctionControl"
helpviewer_keywords: 
  - "ICorProfilerFunctionControl interface [.NET Framework profiling]"
ms.assetid: 4e3d3141-4662-4166-8f05-bc857c1b4216
topic_type: 
  - "apiref"
---
# ICorProfilerFunctionControl Interface

Provides methods that allow a code profiler to communicate with the common language runtime (CLR) to control how the JIT compiler should generate code when recompiling a specific method.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[SetCodegenFlags Method](icorprofilerfunctioncontrol-setcodegenflags-method.md)|Sets one or more flags from the [COR_PRF_CODEGEN_FLAGS](cor-prf-codegen-flags-enumeration.md) enumeration to control code generation for a just-in-time (JIT) recompiled function.|  
|[SetILFunctionBody Method](icorprofilerfunctioncontrol-setilfunctionbody-method.md)|Replaces the Common Intermediate Language (CIL) body of the method.|  
|[SetILInstrumentedCodeMap Method](icorprofilerfunctioncontrol-setilinstrumentedcodemap-method.md)|Sets a code map for the specified function by using the specified Common Intermediate Language (CIL) map entries.|  
  
## Remarks  

 The `ICorProfilerFunctionControl` interface provides methods for controlling code generation for a single recompiled function. The profiler obtains an instance of this interface through the [ICorProfilerCallback4::GetReJITParameters](icorprofilercallback4-getrejitparameters-method.md) callback. Each instance of `ICorProfilerFunctionControl` controls all instances of one function.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorProfilerInfo4 Interface](icorprofilerinfo4-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [EnumJITedFunctions2 Method](icorprofilerinfo4-enumjitedfunctions2-method.md)
