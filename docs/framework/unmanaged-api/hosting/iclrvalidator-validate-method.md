---
title: "ICLRValidator::Validate Method"
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
  - "ICLRValidator.Validate"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRValidator::Validate"
helpviewer_keywords: 
  - "Validate method, ICLRValidator interface [.NET Framework hosting]"
  - "ICLRValidator::Validate method [.NET Framework hosting]"
ms.assetid: 0b1b432a-d234-4002-839b-81366c3a8bdc
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRValidator::Validate Method
Validates the portable executable (PE) or Microsoft intermediate language (MSIL) in the specified file.  
  
## Syntax  
  
```  
HRESULT Validate (  
    [in] IVEHandler        *veh,  
    [in] unsigned long      ulAppDomainId,  
    [in] unsigned long      ulFlags,  
    [in] unsigned long      ulMaxError,  
    [in] unsigned long      token,  
    [in] LPWSTR             fileName,  
    [in, size_is(ulSize)] BYTE *pe,  
    [in] unsigned long      ulSize  
);      
```  
  
#### Parameters  
 `veh`  
 [in] A pointer to an `IVEHandler` instance that handles validation errors.  
  
 `ulAppDomainId`  
 [in] The identifier for the current <xref:System.AppDomain>.  
  
 `ulFlags`  
 [in] A combination of [ValidatorFlags](../../../../docs/framework/unmanaged-api/hosting/validatorflags-enumeration.md) values, indicating the kind of validation that should be performed.  
  
 `ulMaxError`  
 [in] The maximum number of errors to allow before exiting the validation.  
  
 `token`  
 [in] Unused.  
  
 `fileName`  
 [in] The name of the file to be validated.  
  
 `pe`  
 [in] A pointer to the file buffer.  
  
 `ulSize`  
 [in] The size, in bytes, of the file to be validated.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Validate` returned successfully.|  
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
 [ICLRValidator Interface](../../../../docs/framework/unmanaged-api/hosting/iclrvalidator-interface.md)
