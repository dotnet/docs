---
title: "ICLRErrorReportingManager::GetBucketParametersForCurrentException Method"
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
  - "ICLRErrorReportingManager.GetBucketParametersForCurrentException"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRErrorReportingManager::GetBucketParametersForCurrentException"
helpviewer_keywords: 
  - "ICLRErrorReportingManager::GetBucketParametersForCurrentException method [.NET Framework hosting]"
  - "GetBucketParametersForCurrentException method [.NET Framework hosting]"
ms.assetid: a13ec8a6-8e18-4acb-8054-77f5b1a0e0b9
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRErrorReportingManager::GetBucketParametersForCurrentException Method
Gets the Watson bucket for the current exception on the calling thread.  
  
 A *bucket* is a collection of error data that is related to the same code defect. *Watson* refers to a set of technologies for collecting and analyzing data that is associated with an exception.  
  
## Syntax  
  
```  
HRESULT GetBucketParametersForCurrentException(  
    [out] BucketParameters *pParams  
);  
```  
  
#### Parameters  
 `pParams`  
 [out] A pointer to a [BucketParameters](../../../../docs/framework/unmanaged-api/hosting/bucketparameters-structure.md) structure that contains error data for the exception.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRErrorReportingManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrerrorreportingmanager-interface.md)
