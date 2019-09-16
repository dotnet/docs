---
title: "CorExitProcess Function"
ms.date: "03/30/2017"
api_name: 
  - "CorExitProcess"
api_location: 
  - "mscoree.dll"
  - "clr.dll"
  - "mscorwks.dll"
  - "mscoreei.dll"
  - "mscorsvr.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CorExitProcess"
helpviewer_keywords: 
  - "CorExitProcess function [.NET Framework hosting]"
ms.assetid: a5cab4c6-990e-47f3-8798-cf422b791015
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# CorExitProcess Function
Shuts down the current unmanaged process.  
  
 This function has been deprecated in the .NET Framework 4. Use the [ICLRMetaHost::ExitProcess](../../../../docs/framework/unmanaged-api/hosting/iclrmetahost-exitprocess-method.md) method instead.  
  
## Syntax  
  
```cpp  
void STDMETHODCALLTYPE CorExitProcess (   
  int  exitCode  
);  
```  
  
## Parameters  
 `exitCode`  
 An integer that specifies the process exit code.  
  
## Remarks  
  
> [!NOTE]
> Beginning with the .NET Framework 4, `CorExitProcess` exits every started runtime in the process, not just the runtime to which the legacy APIs have been bound.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
