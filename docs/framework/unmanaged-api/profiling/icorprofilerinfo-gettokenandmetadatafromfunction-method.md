---
title: "ICorProfilerInfo::GetTokenAndMetadataFromFunction Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetTokenAndMetadataFromFunction"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetTokenAndMetadataFromFunction"
helpviewer_keywords: 
  - "ICorProfilerInfo::GetTokenAndMetadataFromFunction method [.NET Framework profiling]"
  - "GetTokenAndMetadataFromFunction method [.NET Framework profiling]"
ms.assetid: e525aa16-c923-4b16-833b-36f1f0dd70fc
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerInfo::GetTokenAndMetadataFromFunction Method
Gets the metadata token and a metadata interface instance that can be used against the token for the specified function.  
  
## Syntax  
  
```  
HRESULT GetTokenAndMetaDataFromFunction(  
    [in]  FunctionID functionId,  
    [in]  REFIID     riid,  
    [out] IUnknown   **ppImport,  
    [out] mdToken    *pToken);  
```  
  
#### Parameters  
 `functionId`  
 [in] The ID of the function for which to get the metadata token and metadata interface.  
  
 `riid`  
 [in] The reference ID of the metadata interface to get the instance of.  
  
 `ppImport`  
 [out] A pointer to the address of the metadata interface instance that can be used against the token for the specified function.  
  
 `pToken`  
 [out] A pointer to the metadata token for the specified function.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
