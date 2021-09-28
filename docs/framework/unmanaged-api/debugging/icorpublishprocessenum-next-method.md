---
description: "Learn more about: ICorPublishProcessEnum::Next Method"
title: "ICorPublishProcessEnum::Next Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorPublishProcessEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishProcessEnum::Next"
helpviewer_keywords: 
  - "ICorPublishProcessEnum::Next method [.NET Framework debugging]"
  - "Next method, ICorPublishProcessEnum interface [.NET Framework debugging]"
ms.assetid: 6c399f37-1e38-4ca1-b70d-8ae41f7228b7
topic_type: 
  - "apiref"
---
# ICorPublishProcessEnum::Next Method

Gets the specified number of processes from the collection, starting at the current cursor position.  
  
## Syntax  
  
```cpp  
HRESULT Next (  
    [in] ULONG celt,  
    [out, size_is(celt), length_is(*pceltFetched)]  
        ICorPublishProcess **objects,  
    [out] ULONG *pceltFetched  
);  
```  
  
## Parameters  

 `celt`  
 [in] The number of processes to be retrieved.  
  
 `objects`  
 [out] A pointer to the array of retrieved [ICorPublishProcess](icorpublishprocess-interface.md) objects, each of which represents a process.  
  
 `pceltFetched`  
 [out] Pointer to the number of processes actually returned. This value may be null if `celt` is one.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorPublishProcessEnum Interface](icorpublishprocessenum-interface.md)
