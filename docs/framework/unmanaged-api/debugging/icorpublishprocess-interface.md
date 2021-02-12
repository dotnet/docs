---
description: "Learn more about: ICorPublishProcess Interface"
title: "ICorPublishProcess Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorPublishProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishProcess"
helpviewer_keywords: 
  - "ICorPublishProcess interface [.NET Framework debugging]"
ms.assetid: 6d1dc41b-8aa2-4889-bb00-1cbccc00c123
topic_type: 
  - "apiref"
---
# ICorPublishProcess Interface

Provides methods that access information to be displayed about a process.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumAppDomains Method](icorpublishprocess-enumappdomains-method.md)|Gets an [ICorPublishAppDomainEnum](icorpublishappdomainenum-interface.md) instance that contains the application domains in the process referenced by this `ICorPublishProcess`.|  
|[GetDisplayName Method](icorpublishprocess-getdisplayname-method.md)|Gets the full path of the executable for the process referenced by this `ICorPublishProcess`.|  
|[GetProcessID Method](icorpublishprocess-getprocessid-method.md)|Gets the operating system identifier for the process referenced by this `ICorPublishProcess`.|  
|[IsManaged Method](icorpublishprocess-ismanaged-method.md)|Gets a value that indicates whether the process referenced by this `ICorPublishProcess` is known to be running managed code.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [CorpubPublish Coclass](corpubpublish-coclass.md)
