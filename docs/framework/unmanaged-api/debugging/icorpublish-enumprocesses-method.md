---
description: "Learn more about: ICorPublish::EnumProcesses Method"
title: "ICorPublish::EnumProcesses Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorPublish.EnumProcesses"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublish::EnumProcesses"
helpviewer_keywords: 
  - "ICorPublish::EnumProcesses method [.NET Framework debugging]"
  - "EnumProcesses method [.NET Framework debugging]"
ms.assetid: 4ae765f0-93b2-4b6f-aea1-7b0cf44e04a7
topic_type: 
  - "apiref"
---
# ICorPublish::EnumProcesses Method

Gets an enumerator for the managed processes running on this computer.  
  
## Syntax  
  
```cpp  
HRESULT EnumProcesses (  
    [in] COR_PUB_ENUMPROCESS       Type,  
    [out] ICorPublishProcessEnum   **ppIEnum  
);  
```  
  
## Parameters  

 `Type`  
 A value of the [COR_PUB_ENUMPROCESS](cor-pub-enumprocess-enumeration.md) enumeration that specifies the type of process to be retrieved. In the current version, only COR_PUB_MANAGEDONLY is valid.  
  
 `ppIEnum`  
 A pointer to the address of an [ICorPublishProcessEnum](icorpublishprocessenum-interface.md) instance that is the enumerator of the processes.  
  
## Remarks  

 The enumerator's collection of processes is based on a snapshot of the processes that are running when the `EnumProcesses` method is called. The enumerator will not include any processes that terminate before or start after `EnumProcesses` is called.  
  
 The `EnumProcesses` method may be called more than once on this [ICorPublish](icorpublish-interface.md) instance to create a new up-to-date collection of processes. Existing collections will not be affected by subsequent calls of the `EnumProcesses` method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorPublish Interface](icorpublish-interface.md)
