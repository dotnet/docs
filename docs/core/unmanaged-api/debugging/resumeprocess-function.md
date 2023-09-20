---
description: "Learn more about: ResumeProcess Function"
title: "ResumeProcess Function"
ms.date: "03/21/2022"
api_name: 
  - "ResumeProcess"
api_location: 
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
f1_keywords: 
  - "ResumeProcess"
helpviewer_keywords: 
  - "debugging API [.NET Core]"
  - ".NET Core, debugging"
  - "ResumeProcess function"
ms.assetid: 5e3c3958-80bb-43b1-a96b-dd3e6dbd9cd7
topic_type: 
  - "apiref"
---
# ResumeProcess Function

Resumes the process using the resume handle returned by the [CreateProcessForLaunch function](createprocessforlaunch-function.md).
  
## Syntax  
  
```cpp  
HRESULT ResumeProcess (  
    [in] HANDLE hResumeHandle
);  
```  

## Parameters  

 `hResumeHandle`\
 [in] The resume handle returned by [CreateProcessForLaunch function](createprocessforlaunch-function.md).
  
## Return Value  

 S_OK  
 The process was successfully resumed.
  
 E_FAIL (or other E_ return codes)  
 The handle was invalid or the function failed.
  
## Requirements  

 **Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
  
 **Header:** dbgshim.h  
  
 **Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib
  
 **.NET Versions:** [!INCLUDE[net_core_21](../../../../includes/net-core-21-md.md)]
