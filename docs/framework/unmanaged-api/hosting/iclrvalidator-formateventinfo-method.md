---
title: "ICLRValidator::FormatEventInfo Method"
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
  - "ICLRValidator.FormatEventInfo"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRValidator::FormatEventInfo"
helpviewer_keywords: 
  - "FormatEventInfo method, ICLRValidator interface [.NET Framework hosting]"
  - "ICLRValidator::FormatEventInfo method [.NET Framework hosting]"
ms.assetid: 808e1f1d-52f4-47c4-83cc-dcf47d075219
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRValidator::FormatEventInfo Method
Gets a detailed message about the specified validation error.  
  
## Syntax  
  
```  
HRESULT FormatEventInfo (  
    [in] HRESULT            hVECode,  
    [in] VEContext          Context,  
    [in, out] LPWSTR        msg,  
    [in] unsigned long      ulMaxLength,  
    [in] SAFEARRAY(VARIANT) psa  
);  
```  
  
#### Parameters  
 `hVECode`  
 [in] The HRESULT value that was passed to the validation error handler.  
  
 `Context`  
 [in] A `VEContext` instance that contains context information about the validation errors.  
  
 `msg`  
 [in, out] The friendly error message.  
  
 `ulMaxLength`  
 [in] The maximum length of the error message.  
  
 `psa`  
 [in] A safe array of additional parameters to be used in the message.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`FormatEventInfo` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** IValidator.idl, IValidator.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRErrorReportingManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrerrorreportingmanager-interface.md)  
 [ICLRValidator Interface](../../../../docs/framework/unmanaged-api/hosting/iclrvalidator-interface.md)
