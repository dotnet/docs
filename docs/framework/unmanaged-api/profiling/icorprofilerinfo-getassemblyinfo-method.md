---
description: "Learn more about: ICorProfilerInfo::GetAssemblyInfo Method"
title: "ICorProfilerInfo::GetAssemblyInfo Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetAssemblyInfo"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetAssemblyInfo Method"
helpviewer_keywords: 
  - "GetAssemblyInfo method [.NET Framework profiling]"
  - "ICorProfilerInfo::GetAssemblyInfo method [.NET Framework profiling]"
ms.assetid: 7a3c97c3-1e31-47b1-bf23-386785c509c4
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::GetAssemblyInfo Method

Accepts an assembly ID, and returns the assembly's name and the ID of its manifest module.  
  
## Syntax  
  
```cpp  
HRESULT GetAssemblyInfo(  
    [in]  AssemblyID  assemblyId,  
    [in]  ULONG       cchName,  
    [out] ULONG       *pcchName,  
    [out, size_is(cchName), length_is(*pcchName)]  
          WCHAR       szName[] ,  
    [out] AppDomainID *pAppDomainId,  
    [out] ModuleID    *pModuleId);  
```  
  
## Parameters  

 `assemblyId`  
 [in] The identifier of the assembly.  
  
 `cchName`  
 [in] The length, in characters, of `szName`.  
  
 `pcchName`  
 [out] A pointer to the total character length of the assembly's name.  
  
 `szName`  
 [out] A caller-provided wide character buffer. When the function returns, it will contain the assembly's name.  
  
 `pAppDomainId`  
 [out] A pointer to the ID of the application domain that contains the assembly.  
  
 `pModuleId`  
 [out] A pointer to the ID of the assembly's manifest module.  
  
## Remarks  

 After this method returns, you must verify that the `szName` buffer was large enough to contain the full name of the assembly. To do this, compare the value that `pcchName` points to with the value of the `cchName` parameter. If `pcchName` points to a value that is larger than `cchName`, allocate a larger `szName` buffer, update `cchName` with the new, larger size, and call `GetAssemblyInfo` again.  
  
 Alternatively, you can first call `GetAssemblyInfo` with a zero-length `szName` buffer to obtain the correct buffer size. You can then adjust the buffer size based on the value returned in `pcchName` and call `GetAssemblyInfo` again.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)
- [Profiling](index.md)
