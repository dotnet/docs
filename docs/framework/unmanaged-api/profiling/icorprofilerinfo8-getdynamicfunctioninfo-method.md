---
title: "ICorProfilerInfo8::GetDynamicFunctionInfo"
ms.date: "08/DD/YYYY"
dev_langs: 
  - "cpp"
api_name: 
  - "ICorProfilerInfo8.GetDynamicFunctionInfo"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
ms.assetid: 74636166-6592-4bee-bb23-6003c9d98169
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo8::GetDynamicFunctionInfo Method
  
 Retrieves information about dynamic methods.
  
## Syntax  
  
```cpp
HRESULT GetDynamicFunctionInfo( [in]  FunctionID              functionId,
                                [out] ModuleID                *moduleId,
                                [out] PCCOR_SIGNATURE         *ppvSig,
                                [out] ULONG                   *pbSig,
                                [in]  ULONG                   cchName,
                                [out] ULONG                   *pcchName,
                                [out] WCHAR                    wszName[]);
```  
  
#### Parameters  
 `functionId`  
 [in] The ID of the function for which to retrieve information.  

 `moduleId`  
 [in] A pointer to the module in which the function's parent class is defined.  
  
 `ppvSig`  
 [out] A pointer to the signature for the function.  
  
 `pbSig`  
 [out] A pointer to the count of bytes for the function signature.
  
 `cchName`  
 [out] The maximum size of the `wszName` array.
  
 `pcchName`  
 [out] The number of characters in the `wszName` array.

 `wszName`
 [out] An array of `WCHAR` which is the name of the function, if one exists.
  
## Remarks  
 Certain methods like IL Stubs or LCG do not have associated metadata that can be retrieved using the IMetaDataImport APIs

 Such methods can be encountered by profilers through instruction pointers or by listening to ICorProfilerCallback::DynamicMethodJITCompilationStarted

 This API can be used to retrieve information about dynamic methods including a friendly name if available.  
  

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)  
  
## See also
- [ICorProfilerInfo8 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo8-interface.md)

