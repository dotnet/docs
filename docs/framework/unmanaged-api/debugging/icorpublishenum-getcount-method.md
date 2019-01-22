---
title: "ICorPublishEnum::GetCount Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorPublishEnum.GetCount"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishEnum::GetCount"
helpviewer_keywords: 
  - "GetCount method, ICorPublishEnum interface [.NET Framework debugging]"
  - "ICorPublishEnum::GetCount method [.NET Framework debugging]"
ms.assetid: d228f684-2be3-4029-93ae-31fe02213c1f
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorPublishEnum::GetCount Method
Gets the number of items in the enumeration.  
  
## Syntax  
  
```  
HRESULT GetCount (  
    [out] ULONG   *pcelt  
);  
```  
  
#### Parameters  
 `pcelt`  
 [out] A pointer to the number of items in the enumeration.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
- [ICorPublishEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishenum-interface.md)
