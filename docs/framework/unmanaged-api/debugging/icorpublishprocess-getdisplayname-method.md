---
title: "ICorPublishProcess::GetDisplayName Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorPublishProcess.GetDisplayName"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishProcess::GetDisplayName"
helpviewer_keywords: 
  - "ICorPublishProcess::GetDisplayName method [.NET Framework debugging]"
  - "GetDisplayName method, ICorPublishProcess interface [.NET Framework debugging]"
ms.assetid: 7c0af9e9-a73f-41aa-a685-b21c439e059d
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorPublishProcess::GetDisplayName Method
Gets the full path of the executable for the process referenced by this [ICorPublishProcess](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocess-interface.md).  
  
## Syntax  
  
```  
HRESULT GetDisplayName (  
    [in]  ULONG32                    cchName,   
    [out] ULONG32                    *pcchName,  
    [out, size_is(cchName), length_is(*pcchName)]   
        WCHAR                        *szName  
);  
```  
  
#### Parameters  
 `cchName`  
 [in] The size of the `szName` array.  
  
 `pcchName`  
 [out] The number of wide characters returned in the `szName` array.  
  
 `szName`  
 [out] An array to store the name, including the full path, of the executable. The name is null-terminated.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
 [ICorPublishProcess Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocess-interface.md)
