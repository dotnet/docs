---
title: "RUNTIME_INFO_FLAGS Enumeration"
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
  - "RUNTIME_INFO_FLAGS"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "RUNTIME_INFO_FLAGS"
helpviewer_keywords: 
  - "RUNTIME_INFO_FLAGS enumeration [.NET Framework hosting]"
ms.assetid: adba37be-f775-4cdb-8919-5746ce694f33
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# RUNTIME_INFO_FLAGS Enumeration
Contains values that indicate what information about the common language runtime (CLR) should be returned.  
  
## Syntax  
  
```  
typedef enum {  
  
    RUNTIME_INFO_UPGRADE_VERSION             = 0x01,  
    RUNTIME_INFO_REQUEST_IA64                = 0x02,  
    RUNTIME_INFO_REQUEST_AMD64               = 0x04,  
    RUNTIME_INFO_REQUEST_X86                 = 0x08,  
    RUNTIME_INFO_DONT_RETURN_DIRECTORY       = 0x10,  
    RUNTIME_INFO_DONT_RETURN_VERSION         = 0x20,  
    RUNTIME_INFO_DONT_SHOW_ERROR_DIALOG      = 0x40,  
    RUNTIME_INFO_IGNORE_ERROR_MODE           = 0x1000  
  
} RUNTIME_INFO_FLAGS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`RUNTIME_INFO_DONT_RETURN_DIRECTORY`|Indicates that directory information should not be included.|  
|`RUNTIME_INFO_DONT_RETURN_VERSION`|Indicates that version information should not be included.|  
|`RUNTIME_INFO_DONT_SHOW_ERROR_DIALOG`|Indicates that an error dialog box should not be shown upon failure.|  
|`RUNTIME_INFO_IGNORE_ERROR_MODE`|Indicates that the effects of calling the [SetErrorMode](http://go.microsoft.com/fwlink/p/?LinkId=255242) function with the SEM_FAILCRITICALERRORS flag should be overridden. That is, an installation dialog box should be shown upon failure, instead of being suppressed.|  
|`RUNTIME_INFO_REQUEST_AMD64`|Indicates a request for information about an AMD-64-compatible version of the runtime.|  
|`RUNTIME_INFO_REQUEST_IA64`|Indicates a request for information about an IA-64-compatible version of the runtime.|  
|`RUNTIME_INFO_REQUEST_X86`|Indicates a request for information about an x86-compatible version of the runtime.|  
|`RUNTIME_INFO_UPGRADE_VERSION`|Indicates that version upgrade information should be included.|  
  
## Remarks  
 The following platform architecture flags can be specified only one at a time and cannot be combined:  
  
-   RUNTIME_INFO_REQUEST_IA64  
  
-   RUNTIME_INFO_REQUEST_AMD64  
  
-   RUNTIME_INFO_REQUEST_X86  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
