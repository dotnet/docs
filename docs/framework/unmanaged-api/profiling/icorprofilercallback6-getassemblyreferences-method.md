---
title: "ICorProfilerCallback6::GetAssemblyReferences Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorProfilerCallback6.GetAssemblyReferences"
api_location: 
  - "mscorwks.dll"
  - "corprof.idl"
api_type: 
  - "COM"
ms.assetid: 8b391afb-d79f-41bd-94ce-43ce62c6b5fc
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback6::GetAssemblyReferences Method
[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Notifies the profiler that an assembly is in a very early loading stage, when the common language runtime performs an assembly reference closure walk.  
  
## Syntax  
  
```cpp
HRESULT GetAssemblyReferences(        [in, string] const WCHAR* wszAssemblyPath,  
        [in] ICorProfilerAssemblyReferenceProvider* pAsmRefProvider  
);  
```  
  
#### Parameters  
 `wszAssemblyPath`  
 [in] The path and name of the assembly whose metadata will be modified.  
  
 `pAsmRefProvider`  
 [in] A pointer to the address of an [ICorProfilerAssemblyReferenceProvider](../../../../docs/framework/unmanaged-api/profiling/icorprofilerassemblyreferenceprovider-interface.md) interface that specifies the assembly references to add.  
  
## Return Value  
 Return values from this callback are ignored.  
  
## Remarks  
 This callback is controlled by setting the [COR_PRF_HIGH_ADD_ASSEMBLY_REFERENCES](../../../../docs/framework/unmanaged-api/profiling/cor-prf-high-monitor-enumeration.md) event mask flag when calling the [ICorProfilerCallback5::SetEventMask2](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo5-seteventmask2-method.md) method. If the profiler registers for the [ICorProfilerCallback6::GetAssemblyReferences](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback6-getassemblyreferences-method.md) callback method, the runtime passes the path and name of the assembly to be loaded, along with a pointer to an [ICorProfilerAssemblyReferenceProvider](../../../../docs/framework/unmanaged-api/profiling/icorprofilerassemblyreferenceprovider-interface.md) interface object to that method. The profiler can then call the [ICorProfilerAssemblyReferenceProvider::AddAssemblyReference](../../../../docs/framework/unmanaged-api/profiling/icorprofilerassemblyreferenceprovider-addassemblyreference-method.md) method with a `COR_PRF_ASSEMBLY_REFERENCE_INFO` object for each target assembly it plans to reference from the assembly specified in the `GetAssemblyReferences` callback.  
  
 Use the `GetAssemblyReferences` callback only if the profiler has to modify an assembly's metadata to add assembly references. (But note that the actual modification of an assembly's metadata is done in the [ICorProfilerCallback::ModuleLoadFinished](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-moduleloadfinished-method.md)callback method.) The profiler should implement the `GetAssemblyReferences` callback method to inform the common language runtime (CLR) that assembly references will be added when the module has been loaded.  This helps ensure that assembly sharing decisions made by the CLR during this early stage remain valid although the profiler plans to modify the metadata assembly references later.  This can avoid some instances in which profiler metadata modifications cause an `SECURITY_E_INCOMPATIBLE_SHARE` error.  
  
 The profiler uses the [ICorProfilerAssemblyReferenceProvider](../../../../docs/framework/unmanaged-api/profiling/icorprofilerassemblyreferenceprovider-interface.md) object provided by this method to add assembly references to the CLR assembly reference closure walker.  The [ICorProfilerAssemblyReferenceProvider](../../../../docs/framework/unmanaged-api/profiling/icorprofilerassemblyreferenceprovider-interface.md) object should be used only from within this callback. Calls to the [ICorProfilerAssemblyReferenceProvider::AddAssemblyReference](../../../../docs/framework/unmanaged-api/profiling/icorprofilerassemblyreferenceprovider-addassemblyreference-method.md) method from this callback don't result in modified metadata, but only in a modified assembly reference closure walk. The profiler will still have to use an [IMetaDataAssemblyEmit](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-interface.md) object to explicitly add assembly references from within the [ICorProfilerCallback::ModuleLoadFinished](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-moduleloadfinished-method.md) callback for the referencing assembly, even if it implements the `GetAssemblyReferences` callback.  
  
 The profiler should be prepared to receive duplicate calls to this callback for the same assembly, and should respond identically for each such duplicate call (by making the same set of [ICorProfilerAssemblyReferenceProvider::AddAssemblyReference](../../../../docs/framework/unmanaged-api/profiling/icorprofilerassemblyreferenceprovider-addassemblyreference-method.md) calls).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback6 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback6-interface.md)  
 [ModuleLoadFinished Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-moduleloadfinished-method.md)  
 [COR_PRF_ASSEMBLY_REFERENCE_INFO Structure](../../../../docs/framework/unmanaged-api/profiling/cor-prf-assembly-reference-info-structure.md)  
 [ICorProfilerAssemblyReferenceProvider Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerassemblyreferenceprovider-interface.md)
