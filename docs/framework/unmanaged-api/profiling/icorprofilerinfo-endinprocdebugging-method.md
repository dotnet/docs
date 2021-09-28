---
description: "Learn more about: ICorProfilerInfo::EndInprocDebugging Method"
title: "ICorProfilerInfo::EndInprocDebugging Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.EndInprocDebugging"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::EndInprocDebugging"
helpviewer_keywords: 
  - "ICorProfilerInfo::EndInprocDebugging method [.NET Framework profiling]"
  - "EndInprocDebugging method [.NET Framework profiling]"
ms.assetid: 35bc1188-9767-4141-8038-60ea015b99ac
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::EndInprocDebugging Method

Shuts down an in-process debugging session. This method is obsolete in the .NET Framework version 2.0.  
  
## Syntax  
  
```cpp  
HRESULT EndInprocDebugging(  
    [in]  DWORD dwProfilerContext);  
```  
  
## Parameters  

 `dwProfilerContext`  
 [in] A value that identifies the debugging session. This value must be the same as that received in the [ICorProfilerInfo::BeginInprocDebugging](icorprofilerinfo-begininprocdebugging-method.md) method.  
  
## Remarks  

 You must call [ICorProfilerInfo::BeginInprocDebugging](icorprofilerinfo-begininprocdebugging-method.md) and `EndInprocDebugging` within the same callback method.  
  
 The CLR debugging services supported limited in-process debugging in the .NET Framework versions 1.0 and 1.1. In-process debugging enabled a profiler to use the inspection portions of the debugging API. However, due to customer feedback, in-process debugging has been removed from the .NET Framework in version 2.0, and replaced with a set of functionality that is more in line with the profiling API.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Version:** 1.0  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
