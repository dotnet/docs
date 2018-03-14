---
title: "ICorProfilerInfo::BeginInprocDebugging Method"
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
  - "ICorProfilerInfo.BeginInprocDebugging"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::BeginInprocDebugging"
helpviewer_keywords: 
  - "BeginInprocDebugging method [.NET Framework profiling]"
  - "ICorProfilerInfo::BeginInprocDebugging method [.NET Framework profiling]"
ms.assetid: c5c82c69-99f8-4447-aee0-42cca0a5eb5c
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo::BeginInprocDebugging Method
Initializes in-process debugging support. This method is obsolete in the .NET Framework version 2.0.  
  
## Syntax  
  
```  
HRESULT BeginInprocDebugging(  
    [in]  BOOL   fThisThreadOnly,  
    [out] DWORD *pdwProfilerContext);  
```  
  
#### Parameters  
 `fThisThreadOnly`  
 [in] Set this value to `true` to initialize debugging support for only the current thread; set it to `false` to initialize debugging support for all threads.  
  
 `pdwProfilerContext`  
 [out] The pointer to a returned value that identifies the debugging session.  
  
## Remarks  
 The CLR debugging services supported limited in-process debugging in the .NET Framework versions 1.0 and 1.1. In-process debugging enabled a profiler to use the inspection portions of the debugging API. However, due to customer feedback, in-process debugging has been removed from the .NET Framework in version 2.0, and replaced with a set of functionality that is more in line with the profiling API.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Version:** 1.0  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
