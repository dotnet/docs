---
description: "Learn more about: ICorProfilerInfo2::GetThreadStaticAddress Method"
title: "ICorProfilerInfo2::GetThreadStaticAddress Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo2.GetThreadStaticAddress"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetThreadStaticAddress"
helpviewer_keywords: 
  - "GetThreadStaticAddress method [.NET Framework profiling]"
  - "ICorProfilerInfo2::GetThreadStaticAddress method [.NET Framework profiling]"
ms.assetid: 8e7dbf14-98a2-4384-a950-58a7640e59df
topic_type: 
  - "apiref"
---
# ICorProfilerInfo2::GetThreadStaticAddress Method

Gets the address of the specified thread-static field that is in the scope of the specified thread.  
  
## Syntax  
  
```cpp  
HRESULT GetThreadStaticAddress(  
    [in] ClassID     classId,  
    [in] mdFieldDef  fieldToken,  
    [in] ThreadID    threadId,  
    [out] void       **ppAddress);  
```  
  
## Parameters  

 `classId`  
 [in] The ID of the class that contains the requested thread-static field.  
  
 `fieldToken`  
 [in] The metadata token for the requested thread-static field.  
  
 `threadId`  
 [in] The ID of the thread that is the scope for the requested static field.  
  
 `ppAddress`  
 [out] A pointer to the address of the static field that is within the specified thread.  
  
## Remarks  

 The `GetThreadStaticAddress` method may return one of the following:  
  
- A CORPROF_E_DATAINCOMPLETE HRESULT if the given static field has not been assigned an address in the specified context.  
  
- The addresses of objects that may be in the garbage collection heap. These addresses may become invalid after garbage collection, so after garbage collection profilers should not assume that they are valid.  
  
 Before a class’s class constructor is completed, `GetThreadStaticAddress` will return CORPROF_E_DATAINCOMPLETE for all its static fields, although some of the static fields may already be initialized and rooting garbage collection objects.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [ICorProfilerInfo2 Interface](icorprofilerinfo2-interface.md)
