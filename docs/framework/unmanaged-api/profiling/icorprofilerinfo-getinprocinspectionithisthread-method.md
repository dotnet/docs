---
title: "ICorProfilerInfo::GetInprocInspectionIThisThread Method"
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
  - "ICorProfilerInfo.GetInprocInspectionIThisThread"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetInprocInspectionIThisThread"
helpviewer_keywords: 
  - "ICorProfilerInfo::GetInprocInspectionIThisThread method [.NET Framework profiling]"
  - "GetInprocInspectionIThisThread method [.NET Framework profiling]"
ms.assetid: badddccd-f85c-416e-9f0f-419eab2c9d42
topic_type: 
  - "apiref"
caps.latest.revision: 20
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo::GetInprocInspectionIThisThread Method
Gets an object that can be queried for the ICorDebugThread interface. This method is obsolete in the .NET Framework version 2.0.  
  
## Syntax  
  
```  
HRESULT GetInprocInspectionIThisThread(  
    [out] IUnknown **ppicd);  
```  
  
#### Parameters  
 `ppicd`  
 [out](/cpp/atl/iunknown) object that can be queried for the `ICorDebugThread` interface.  
  
## Remarks  
 The common language runtime (CLR) debugging services supported limited in-process debugging in the .NET Framework version 1.0. In-process debugging enabled a profiler to use the inspection portions of the debugging API. As a result of customer feedback, in-process debugging has been removed from the .NET Framework in version 2.0, and replaced with a set of functionality that is more in line with the profiling API.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Version:** 1.0  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
