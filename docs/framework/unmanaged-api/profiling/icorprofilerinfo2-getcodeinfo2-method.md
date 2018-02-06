---
title: "ICorProfilerInfo2::GetCodeInfo2 Method"
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
  - "ICorProfilerInfo2.GetCodeInfo2"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetCodeInfo2"
helpviewer_keywords: 
  - "ICorProfilerInfo2::GetCodeInfo2 method [.NET Framework profiling]"
  - "GetCodeInfo2 method [.NET Framework profiling]"
ms.assetid: 532da6ee-7f0a-401b-a61e-fc47ec235d2e
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo2::GetCodeInfo2 Method
Gets the extents of native code associated with the specified `FunctionID`.  
  
## Syntax  
  
```  
HRESULT GetCodeInfo2(  
    [in]  FunctionID functionID,  
    [in]  ULONG32 cCodeInfos,  
    [out] ULONG32 *pcCodeInfos,  
    [out, size_is(cCodeInfos), length_is(*pcCodeInfos)]  
    COR_PRF_CODE_INFO codeInfos[]);  
```  
  
#### Parameters  
 `functionID`  
 [in] The ID of the function with which the native code is associated.  
  
 `cCodeInfos`  
 [in] The size of the `codeInfos` array.  
  
 `pcCodeInfos`  
 [out] A pointer to the total number of [COR_PRF_CODE_INFO](../../../../docs/framework/unmanaged-api/profiling/cor-prf-code-info-structure.md) structures available.  
  
 `codeInfos`  
 [out] A caller-provided buffer. After the method returns, it contains an array of `COR_PRF_CODE_INFO` structures, each of which describes a block of native code.  
  
## Remarks  
 The extents are sorted in order of increasing Microsoft intermediate language (MSIL) offset.  
  
 After `GetCodeInfo2` returns, you must verify that the `codeInfos` buffer was large enough to contain all the `COR_PRF_CODE_INFO` structures. To do this, compare the value of `cCodeInfos` with the value of the `cchName` parameter. If `cCodeInfos` divided by the size of a `COR_PRF_CODE_INFO` structure is smaller than `pcCodeInfos`, allocate a larger `codeInfos` buffer, update `cCodeInfos` with the new, larger size, and call `GetCodeInfo2` again.  
  
 Alternatively, you can first call `GetCodeInfo2` with a zero-length `codeInfos` buffer to obtain the correct buffer size. You can then set the `codeInfos` buffer size to the value returned in `pcCodeInfos`, multiplied by the size of a `COR_PRF_CODE_INFO` structure, and call `GetCodeInfo2` again.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [GetCodeInfo3 Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo4-getcodeinfo3-method.md)  
 [ICorProfilerInfo2 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
