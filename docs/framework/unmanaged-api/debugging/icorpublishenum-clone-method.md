---
description: "Learn more about: ICorPublishEnum::Clone Method"
title: "ICorPublishEnum::Clone Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorPublishEnum.Clone"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishEnum::Clone"
helpviewer_keywords: 
  - "Clone method, ICorPublishEnum interface [.NET Framework debugging]"
  - "ICorPublishEnum::Clone method [.NET Framework debugging]"
ms.assetid: c9a26ea3-b8eb-4b8e-854f-9a2ca26b3b39
topic_type: 
  - "apiref"
---
# ICorPublishEnum::Clone Method

Creates a copy of this [ICorPublishEnum](icorpublishenum-interface.md) object.  
  
## Syntax  
  
```cpp  
HRESULT Clone (  
    [out] ICorPublishEnum   **ppEnum  
);  
```  
  
## Parameters  

 `ppEnum`  
 [out] A pointer to the address of an `ICorPublishEnum` object that is a copy of this `ICorPublishEnum` object.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorPublishEnum Interface](icorpublishenum-interface.md)
