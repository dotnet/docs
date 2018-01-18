---
title: "EApiCategories Enumeration"
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
  - "EApiCategories"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EApiCategories"
helpviewer_keywords: 
  - "EApiCategories enumeration [.NET Framework hosting]"
ms.assetid: 3c4a8a5a-8a46-4ac9-947f-4959bc9d6ac6
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# EApiCategories Enumeration
Describes the categories of capabilities that the host can block from running in partially trusted code.  
  
## Syntax  
  
```  
typedef enum {  
    eNoCategory               = 0,  
    eSynchronization          = 0x1,  
    eSharedState              = 0x2,  
    eExternalProcessMgmt      = 0x4,  
    eSelfAffectingProcessMgmt = 0x8,  
    eExternalThreading        = 0x10,  
    eSelfAffectingThreading   = 0x20,  
    eSecurityInfrastructure   = 0x40,  
    eUI                       = 0x80,  
    eMayLeakOnAbort           = 0x100,  
    eAll                      = 0x1ff  
} EHostProtectionCategories;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`eAll`|Specifies that all managed classes and members that are covered by other `EApiCategories` fields be blocked from running in partially trusted code.|  
|`eExternalProcessMgmt`|Specifies that managed classes and members that allow the creation, manipulation, and destruction of external processes be blocked from running in partially trusted code.|  
|`eExternalThreading`|Specifies that managed classes and members that allow the creation, manipulation, and destruction of external threads be blocked from running in partially trusted code.|  
|`eMayLeakOnAbort`|Specifies that managed types and members that could potentially leak memory on abort be blocked from running in partially trusted code.|  
|`eNoCategory`|Specifies that no managed code categories be blocked from running in partially trusted code.|  
|`eSecurityInfrastructure`|Specifies that the common language runtime (CLR) security infrastructure be blocked from being used by partially trusted code.|  
|`eSelfAffectingProcessMgmt`|Specifies that managed classes and members whose capabilities can affect the hosted process be blocked from running in partially trusted code.|  
|`eSelfAffectingThreading`|Specifies that managed classes and members whose capabilities can affect threads in the hosted process be blocked from running in partially trusted code.|  
|`eSharedState`|Specifies that managed classes and members that expose shared state be blocked from running in partially trusted code.|  
|`eSynchronization`|Specifies that common language runtime classes and members that allow user code to hold locks be blocked from running in partially trusted code.|  
|`eUI`|Specifies that managed classes and members that allow or require human interaction be blocked from running in partially trusted code.|  
  
## Remarks  
 The [ICLRHostProtectionManager::SetProtectedCategories](../../../../docs/framework/unmanaged-api/hosting/iclrhostprotectionmanager-setprotectedcategories-method.md) method takes a parameter of type `EApiCategories`.  
  
 The `EApiCategories` enumeration and the `SetProtectedCategories` method are directly related to the managed <xref:System.Security.Permissions.HostProtectionAttribute?displayProperty=nameWithType> class. The managed class is used with the <xref:System.Security.Permissions.HostProtectionResource?displayProperty=nameWithType> enumeration, whose values correspond directly to the `EApiCategories` values, to mark managed types and members that expose capabilities corresponding to the categories described by `EApiCategories`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRHostProtectionManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrhostprotectionmanager-interface.md)  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
