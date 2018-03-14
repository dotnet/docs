---
title: "ICorProfilerInfo2::GetClassLayout Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorProfilerInfo2.GetClassLayout"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetClassLayout"
helpviewer_keywords: 
  - "ICorProfilerInfo2::GetClassLayout method [.NET Framework profiling]"
  - "GetClassLayout method, ICorProfilerInfo2 interface [.NET Framework profiling]"
ms.assetid: a3a36987-5666-4e2f-95b5-d0cb246502ec
topic_type: 
  - "apiref"
caps.latest.revision: 21
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo2::GetClassLayout Method
Gets information about the layout, in memory, of the fields defined by the specified class. That is, this method gets the offsets of the class's fields.  
  
## Syntax  
  
```  
HRESULT GetClassLayout(  
    [in]  ClassID classID,  
    [in, out] COR_FIELD_OFFSET rFieldOffset[],  
    [in]  ULONG cFieldOffset,  
    [out] ULONG *pcFieldOffset,  
    [out] ULONG *pulClassSize);  
```  
  
#### Parameters  
 `classID`  
 [in] The ID of the class for which the layout will be retrieved.  
  
 `rFieldOffset`  
 [in, out] An array of [COR_FIELD_OFFSET](../../../../docs/framework/unmanaged-api/metadata/cor-field-offset-structure.md) structures, each of which contains the tokens and offsets of the class's fields.  
  
 `cFieldOffset`  
 [in] The size of the `rFieldOffset` array.  
  
 `pcFieldOffset`  
 [out] A pointer to the total number of available elements. If `cFieldOffset` is 0, this value indicates the number of elements needed.  
  
 `pulClassSize`  
 [out] A pointer to a location that contains the size, in bytes, of the class.  
  
## Remarks  
 The `GetClassLayout` method returns only the fields defined by the class itself. If the class's parent class has defined fields as well, the profiler must call `GetClassLayout` on the parent class to obtain those fields.  
  
 If you use `GetClassLayout` with string classes, the method will fail with error code E_INVALIDARG. Use [ICorProfilerInfo2::GetStringLayout](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-getstringlayout-method.md) to get information about the layout of a string. `GetClassLayout` will also fail when called with an array class.  
  
 After `GetClassLayout` returns, you must verify that the `rFieldOffset` buffer was large enough to contain all the available `COR_FIELD_OFFSET` structures. To do this, compare the value that `pcFieldOffset` points to with the size of `rFieldOffset` divided by the size of a `COR_FIELD_OFFSET` structure. If `rFieldOffset` is not large enough, allocate a larger `rFieldOffset` buffer, update `cFieldOffset` with the new, larger size, and call `GetClassLayout` again.  
  
 Alternatively, you can first call `GetClassLayout` with a zero-length `rFieldOffset` buffer to obtain the correct buffer size. You can then set the buffer size to the value returned in `pcFieldOffset` and call `GetClassLayout` again.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [ICorProfilerInfo2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
