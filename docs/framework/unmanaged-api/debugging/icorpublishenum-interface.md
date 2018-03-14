---
title: "ICorPublishEnum Interface"
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
  - "ICorPublishEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishEnum"
helpviewer_keywords: 
  - "ICorPublishEnum interface [.NET Framework debugging]"
ms.assetid: 76a136b5-e444-417a-8ade-f1596d597dc7
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorPublishEnum Interface
Serves as the abstract base interface for the enumerators that are used in the publishing of information about processes and application domains.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Clone Method](../../../../docs/framework/unmanaged-api/debugging/icorpublishenum-clone-method.md)|Creates a copy of this `ICorPublishEnum` object.|  
|[GetCount Method](../../../../docs/framework/unmanaged-api/debugging/icorpublishenum-getcount-method.md)|Gets the number of items in the enumeration.|  
|[Reset Method](../../../../docs/framework/unmanaged-api/debugging/icorpublishenum-reset-method.md)|Moves the cursor of to the beginning of the enumeration.|  
|[Skip Method](../../../../docs/framework/unmanaged-api/debugging/icorpublishenum-skip-method.md)|Moves the cursor forward in the enumeration by the specified number of items.|  
  
## Remarks  
 The following enumerators derive from `ICorPublishEnum`:  
  
-   [ICorPublishAppDomainEnum](../../../../docs/framework/unmanaged-api/debugging/icorpublishappdomainenum-interface.md)  
  
-   [ICorPublishProcessEnum](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocessenum-interface.md)  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [CorpubPublish Coclass](../../../../docs/framework/unmanaged-api/debugging/corpubpublish-coclass.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
