---
title: "ICorProfilerInfo::SetILFunctionBody Method"
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
  - "ICorProfilerInfo.SetILFunctionBody"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::SetILFunctionBody"
helpviewer_keywords: 
  - "ICorProfilerInfo::SetILFunctionBody method [.NET Framework profiling]"
  - "SetILFunctionBody method [.NET Framework profiling]"
ms.assetid: b159c712-00f4-4fc7-a990-40bf9f642e8f
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo::SetILFunctionBody Method
Replaces the body of the specified function in the specified module.  
  
## Syntax  
  
```  
HRESULT SetILFunctionBody(  
    [in] ModuleID    moduleId,  
    [in] mdMethodDef methodid,  
    [in] LPCBYTE     pbNewILMethodHeader);  
```  
  
#### Parameters  
 `moduleId`  
 [in] The ID of the module in which the function resides.  
  
 `methodid`  
 [in] The token of the function for which to replace the body.  
  
 `pbNewILMethodHeader`  
 [in] The new header for the function.  
  
## Remarks  
 The `SetILFunctionBody` method replaces the relative virtual address of the function in the metadata so that it points to the new function body, and adjusts any internal data structures as required.  
  
 The `SetILFunctionBody` method can be called on only those functions that have never been compiled by a just-in-time (JIT) compiler.  
  
 Use the [ICorProfilerInfo::GetILFunctionBodyAllocator](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-getilfunctionbodyallocator-method.md) method to allocate space for the new method to ensure that the buffer is compatible.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
