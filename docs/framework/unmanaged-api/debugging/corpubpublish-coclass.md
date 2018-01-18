---
title: "CorpubPublish Coclass"
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
  - "CorpubPublish Coclass"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorpubPublish"
helpviewer_keywords: 
  - "CorpubPublish coclass [.NET Framework debugging]"
ms.assetid: 191015da-f54a-4bac-a28a-1de7ab3c3428
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorpubPublish Coclass
Provides interfaces for publishing information about application domains and processes.  
  
## Syntax  
  
```  
coclass CorpubPublish {  
    [default] interface ICorPublish;  
    interface           ICorPublishProcess;  
    interface           ICorPublishAppDomain;  
    interface           ICorPublishProcessEnum;  
    interface           ICorPublishAppDomainEnum;  
};  
```  
  
## Interfaces  
  
|Interface|Description|  
|---------------|-----------------|  
|[ICorPublish Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublish-interface.md)|Provides methods for publishing information about processes and the application domains in those processes.|  
|[ICorPublishAppDomain Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishappdomain-interface.md)|Represents, and provides information about, an application domain in a process.|  
|[ICorPublishAppDomainEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishappdomainenum-interface.md)|Provides methods that traverse a collection of application domains that currently exist within a process.|  
|[ICorPublishProcess Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocess-interface.md)|Represents a process that is running on a computer.|  
|[ICorPublishProcessEnum Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocessenum-interface.md)|Provides methods that traverse a collection of processes that are running on a computer.|  
  
## Remarks  
 A typical publishing scenario involves a developer who wants to debug managed code that is running on a computer within an application domain. The hosting environment may be running more than one application domain within a process. The developer would like to use a graphical user interface or some other means to list all of the processes that are running on the computer, and pick a specific process. The listing should include all of the application domains within processes that are running managed code. The developer can then identify the specific application domain and attach a debugger to that domain.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorPub.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:**  [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
