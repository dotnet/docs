---
description: "Learn more about: ICorPublish Interface"
title: "ICorPublish Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorPublish"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublish"
helpviewer_keywords: 
  - "ICorPublish interface [.NET Framework debugging]"
ms.assetid: 87c4fcb2-7703-4a2e-afb6-42973381b960
topic_type: 
  - "apiref"
---
# ICorPublish Interface

Serves as the general interface for publishing information about processes and information about the application domains in those processes.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumProcesses Method](icorpublish-enumprocesses-method.md)|Gets an [ICorPublishProcessEnum](icorpublishprocessenum-interface.md) instance that contains the managed processes running on this computer.|  
|[GetProcess Method](icorpublish-getprocess-method.md)|Gets an [ICorPublishProcess](icorpublishprocess-interface.md) instance that represents the process with the specified identifier.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [CorpubPublish Coclass](corpubpublish-coclass.md)
