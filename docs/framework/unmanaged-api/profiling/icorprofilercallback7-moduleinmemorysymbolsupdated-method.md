---
description: "Learn more about: ICorProfilerCallback7::ModuleInMemorySymbolsUpdated Method"
title: "ICorProfilerCallback7::ModuleInMemorySymbolsUpdated Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback7.ModuleInMemorySymbolsUpdated"
api_location: 
  - "mscorwks.dll"
  - "corprof.idl"
api_type: 
  - "COM"
ms.assetid: f362a896-3247-4894-9727-e48dbbcd2c78
---
# ICorProfilerCallback7::ModuleInMemorySymbolsUpdated Method

[Supported in the .NET Framework 4.6.1 and later versions]  
  
 Notifies the profiler whenever the symbol stream associated with an in-memory module is updated.  
  
## Syntax  
  
```cpp  
HRESULT ModuleInMemorySymbolsUpdated(  
     ModuleID moduleId  
);  
```  
  
## Parameters  

 `moduleId`  
 [in] The identifier of the in-memory module whose symbol stream is updated.  
  
## Remarks  

 This callback is controlled by setting the [COR_PRF_HIGH_IN_MEMORY_SYMBOLS_UPDATED](cor-prf-high-monitor-enumeration.md) event mask flag when calling the [ICorProfilerCallback5::SetEventMask2](icorprofilerinfo5-seteventmask2-method.md) method.  
  
> [!NOTE]
> This event is not currently raised for symbols implicitly created or modified via <xref:System.Reflection.Emit> APIs.  
  
 Even when symbols are provided up front in a call to one of the overloads of the managed <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> methods that includes a `rawSymbolStore` argument to specify the symbols for the assembly, the runtime may not actually associate the symbolic data with the module until after the [ModuleLoadFinished](icorprofilercallback-moduleloadfinished-method.md) callback has occurred. This event provides a later opportunity to collect symbols for such modules.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v461plus](../../../../includes/net-current-v461plus-md.md)]  
  
## See also

- [ModuleLoadFinished Method](icorprofilercallback-moduleloadfinished-method.md)
- [SetEventMask2 Method](icorprofilerinfo5-seteventmask2-method.md)
- [ICorProfilerCallback7 Interface](icorprofilercallback7-interface.md)
