---
title: "ICorProfilerInfo::GetCodeInfo Method"
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
  - "ICorProfilerInfo.GetCodeInfo"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetCodeInfo"
helpviewer_keywords: 
  - "GetCodeInfo method [.NET Framework profiling]"
  - "ICorProfilerInfo::GetCodeInfo method [.NET Framework profiling]"
ms.assetid: 90140b0f-a926-4a7e-b6fa-23e05f703cce
topic_type: 
  - "apiref"
caps.latest.revision: 18
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo::GetCodeInfo Method
Gets the extent of native code associated with the specified function ID.  
  
 This method is obsolete. Use the [ICorProfilerInfo2::GetCodeInfo2](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo2-getcodeinfo2-method.md) method instead.  
  
## Syntax  
  
```  
HRESULT GetCodeInfo(  
    [in]  FunctionID functionId,  
    [out] LPCBYTE    *pStart,  
    [out] ULONG      *pcSize);  
```  
  
#### Parameters  
 `functionId`  
 [in] The ID of the function with which the native code is associated.  
  
 `pStart`  
 [out] A pointer to an array of bytes that compose the native code of the function.  
  
 `pcSize`  
 [out] A pointer to an integer that specifies the size, in bytes, of the native code.  
  
## Remarks  
 To optimize performance, the runtime in the .NET Framework version 2.0 splits the precompiled, native code of a function into multiple regions. Consequently, the `GetCodeInfo` method is obsolete in the .NET Framework 2.0 because it is unable to handle the extent of a function's native code. Profilers should switch to using the more general `ICorProfilerInfo2::GetCodeInfo2` method instead.  
  
 This function uses caller-allocated buffers.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.0  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)
