---
description: "Learn more about: ICorPublishEnum::Skip Method"
title: "ICorPublishEnum::Skip Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorPublishEnum.Skip"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishEnum::Skip"
helpviewer_keywords: 
  - "ICorPublishEnum::Skip method [.NET Framework debugging]"
  - "Skip method, ICorDebugEnum interface [.NET Framework debugging]"
ms.assetid: 1680ec06-4ab0-447e-93ad-cdb8693fde5c
topic_type: 
  - "apiref"
---
# ICorPublishEnum::Skip Method

Moves the cursor forward in the enumeration by the specified number of items.  
  
## Syntax  
  
```cpp  
HRESULT Skip (  
    [in] ULONG   celt  
);  
```  
  
## Parameters  

 `celt`  
 [in] The number of items by which to move the cursor forward.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorPublishEnum Interface](icorpublishenum-interface.md)
