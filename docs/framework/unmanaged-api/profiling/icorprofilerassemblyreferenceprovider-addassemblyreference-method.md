---
description: "Learn more about: ICorProfilerAssemblyReferenceProvider::AddAssemblyReference Method"
title: "ICorProfilerAssemblyReferenceProvider::AddAssemblyReference Method"
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorProfilerAssemblyReferenceProvider.AddAssemblyReference"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
ms.assetid: 3d5af8e7-c337-48f4-9fa6-97c83878b9b1
topic_type: 
  - "apiref"
---
# ICorProfilerAssemblyReferenceProvider::AddAssemblyReference Method

[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Informs the common language runtime (CLR) of an assembly reference that the profiler plans to add in the [ICorProfilerCallback::ModuleLoadFinished](icorprofilercallback-moduleloadfinished-method.md) callback.  
  
## Syntax  
  
```cpp
HRESULT AddAssemblyReference(  
        const COR_PRF_ASSEMBLY_REFERENCE_INFO* pAssemblyRefInfo  
);  
```  
  
## Parameters

`pAssemblyRefInfo`
A pointer to a [COR_PRF_ASSEMBLY_REFERENCE_INFO](cor-prf-assembly-reference-info-structure.md) structure that provides the CLR with information about an assembly reference that it should consider when performing an assembly reference closure walk.
  
## Remarks  

 The profiler calls this method for each target assembly it plans to reference from the assembly specified in the `wszAssemblyPath` argument of the [ICorProfilerCallback6::GetAssemblyReferences](icorprofilercallback6-getassemblyreferences-method.md) callback. The [ICorProfilerAssemblyReferenceProvider](icorprofilerassemblyreferenceprovider-interface.md) interface object is passed to the profiler's [ICorProfilerCallback6::GetAssemblyReferences](icorprofilercallback6-getassemblyreferences-method.md) callback, along with the assembly path and name in the `wszAssemblyPath` argument.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See also

- [ICorProfilerAssemblyReferenceProvider Interface](icorprofilerassemblyreferenceprovider-interface.md)
- [GetAssemblyReferences Method](icorprofilercallback6-getassemblyreferences-method.md)
- [ModuleLoadFinished Method](icorprofilercallback-moduleloadfinished-method.md)
