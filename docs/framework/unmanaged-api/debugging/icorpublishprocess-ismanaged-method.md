---
title: "ICorPublishProcess::IsManaged Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorPublishProcess.IsManaged"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishProcess::IsManaged"
helpviewer_keywords: 
  - "IsManaged method, ICorPublishProcess interface [.NET Framework debugging]"
  - "ICorPublishProcess::IsManaged method [.NET Framework debugging]"
ms.assetid: 06b1f7cc-acdf-47a6-9d53-d9dec2424152
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorPublishProcess::IsManaged Method
Gets a value that indicates whether the process referenced by this [ICorPublishProcess](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocess-interface.md) is known to have managed code.  
  
## Syntax  
  
```  
HRESULT IsManaged (  
    [out] BOOL   *pbManaged  
);  
```  
  
#### Parameters  
 `pbManaged`  
 [out] A pointer to a Boolean value that indicates whether the process has managed code. The value is `true` if the process has managed code; otherwise, `false`.  
  
## Remarks  
 Since the current version of `ICorPublishProcess` allows access only to processes that have managed code, `IsManaged` always returns `true`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
- [ICorPublishProcess Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocess-interface.md)
