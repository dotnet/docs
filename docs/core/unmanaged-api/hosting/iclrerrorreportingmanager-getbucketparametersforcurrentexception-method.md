---
description: "Learn more about: ICLRErrorReportingManager::GetBucketParametersForCurrentException Method"
title: "ICLRErrorReportingManager::GetBucketParametersForCurrentException Method"
ms.date: "03/30/2017"
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
---
# ICLRErrorReportingManager::GetBucketParametersForCurrentException Method

Gets the Watson bucket for the current exception on the calling thread.  
  
 A *bucket* is a collection of error data that is related to the same code defect. *Watson* refers to a set of technologies for collecting and analyzing data that is associated with an exception.  
  
## Syntax  
  
```cpp  
HRESULT GetBucketParametersForCurrentException(  
    [out] BucketParameters *pParams  
);  
```  
  
## Parameters  

 `pParams`  
 [out] A pointer to a [BucketParameters](bucketparameters-structure.md) structure that contains error data for the exception.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRErrorReportingManager Interface](iclrerrorreportingmanager-interface.md)
