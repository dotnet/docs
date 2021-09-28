---
description: "Learn more about: ICorProfilerInfo::GetInprocInspectionInterface Method"
title: "ICorProfilerInfo::GetInprocInspectionInterface Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetInprocInspectionInterface"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetInprocInspectionInterface"
helpviewer_keywords: 
  - "GetInprocInspectionInterface method [.NET Framework profiling]"
  - "ICorProfilerInfo::GetInprocInspectionInterface method [.NET Framework profiling]"
ms.assetid: 22a92d1d-8849-4af6-8304-ecc53dd1d289
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::GetInprocInspectionInterface Method

Gets an object that can be queried for an "ICorDebugProcess" interface. This method is obsolete in the .NET Framework version 2.0.  
  
## Syntax  
  
```cpp  
HRESULT GetInprocInspectionInterface(  
    [out] IUnknown **ppicd);  
```  
  
## Parameters  

 `ppicd`  
 [out](/cpp/atl/iunknown) object that can be queried for an `ICorDebugProcess` interface.  
  
## Remarks  

 The common language runtime (CLR) debugging API supported limited in-process debugging in the .NET Framework version 1.0. In-process debugging enabled a profiler to use the inspection portions of the debugging API. As a result of customer feedback, in-process debugging has been removed from the .NET Framework in version 2.0, and replaced with a set of functionality that is more in line with the profiling API.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Version:** 1.0  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
