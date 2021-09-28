---
description: "Learn more about: ICorProfilerInfo2::GetContextStaticAddress Method"
title: "ICorProfilerInfo2::GetContextStaticAddress Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo2.GetContextStaticAddress"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetContextStaticAddress"
helpviewer_keywords: 
  - "GetContextStaticAddress method [.NET Framework profiling]"
  - "ICorProfilerInfo2::GetContextStaticAddress method [.NET Framework profiling]"
ms.assetid: 2b374116-0972-416a-8cf5-79213129be9a
topic_type: 
  - "apiref"
---
# ICorProfilerInfo2::GetContextStaticAddress Method

Gets the address for the specified context-static field that is in the scope of the specified context.  
  
## Syntax  
  
```cpp  
HRESULT GetContextStaticAddress(  
    [in] ClassID classId,  
    [in] mdFieldDef fieldToken,  
    [in] ContextID contextId,  
    [out] void **ppAddress);  
```  
  
## Parameters  

 `classId`  
 [in] The ID of the class that contains the requested context-static field.  
  
 `fieldToken`  
 [in] The metadata token for the requested context-static field.  
  
 `contextId`  
 [in] The ID of the context that is the scope for the requested context-static field.  
  
 `ppAddress`  
 [out] A pointer to the address of the static field that is within the specified context.  
  
## Remarks  

 The `GetContextStaticAddress` method may return one of the following:  
  
- A CORPROF_E_DATAINCOMPLETE HRESULT if the given static field has not been assigned an address in the specified context.  
  
- The addresses of objects that may be in the garbage collection heap. These addresses may become invalid after garbage collection, so after garbage collection, profilers should not assume that they are valid.  
  
 Before a class’s class constructor is completed, `GetContextStaticAddress` will return CORPROF_E_DATAINCOMPLETE for all its static fields, although some of the static fields may already be initialized and rooting garbage collection objects.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [ICorProfilerInfo2 Interface](icorprofilerinfo2-interface.md)
