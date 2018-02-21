---
title: "ICorPublishProcess Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorPublishProcess Interface
Provides methods that access information to be displayed about a process.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumAppDomains Method](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocess-enumappdomains-method.md)|Gets an [ICorPublishAppDomainEnum](../../../../docs/framework/unmanaged-api/debugging/icorpublishappdomainenum-interface.md) instance that contains the application domains in the process referenced by this `ICorPublishProcess`.|  
|[GetDisplayName Method](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocess-getdisplayname-method.md)|Gets the full path of the executable for the process referenced by this `ICorPublishProcess`.|  
|[GetProcessID Method](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocess-getprocessid-method.md)|Gets the operating system identifier for the process referenced by this `ICorPublishProcess`.|  
|[IsManaged Method](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocess-ismanaged-method.md)|Gets a value that indicates whether the process referenced by this `ICorPublishProcess` is known to be running managed code.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [CorpubPublish Coclass](../../../../docs/framework/unmanaged-api/debugging/corpubpublish-coclass.md)
