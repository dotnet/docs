---
title: "ESymbolReadingPolicy Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "ESymbolReadingPolicy"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ESymbolReadingPolicy"
helpviewer_keywords: 
  - "ESymbolReadingPolicy enumeration [.NET Framework hosting]"
ms.assetid: 4dc6c80d-b694-480b-a378-d5b18420ce17
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ESymbolReadingPolicy Enumeration
Contains values that set the policy for reading program database (PDB) files.  
  
## Syntax  
  
```  
typedef enum {  
    eSymbolReadingNever,  
    eSymbolReadingAlways,  
    eSymbolReadingFullTrustOnly  
} ESymbolReadingPolicy;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`eSymbolReadingAlways`|Specifies that the debugger should always read PDB files.|  
|`eSymbolReadingFullTrustOnly`|Specifies that the debugger should read only PDB files that are associated with full-trust assemblies.|  
|`eSymbolReadingNever`|Specifies that the debugger should never read PDB files.|  
  
## Remarks  
 The `ESymbolReadingPolicy` enumeration is used with the [ICLRDebugManager::SetSymbolReadingPolicy](../../../../docs/framework/unmanaged-api/hosting/iclrdebugmanager-setsymbolreadingpolicy-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
