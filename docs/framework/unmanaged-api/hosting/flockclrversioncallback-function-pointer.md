---
title: "FLockClrVersionCallback Function Pointer"
ms.date: "03/30/2017"
api_name: 
  - "FLockClrVersionCallback"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FLockClrVersionCallback"
helpviewer_keywords: 
  - "FLockClrVersionCallback function pointer [.NET Framework hosting]"
ms.assetid: 98a4762d-9ad2-45bd-9d03-39064a028b44
topic_type: 
  - "apiref"
---
# FLockClrVersionCallback Function Pointer
Points to a function that the common language runtime (CLR) calls to indicate that initialization has either started or completed.  
  
 This function pointer has been deprecated in the .NET Framework 4.  
  
## Syntax  
  
```cpp  
typedef HRESULT (__stdcall *FLockClrVersionCallback) ( );  
```  
  
## Remarks  
 This function is implemented by the host.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorWks.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [LockClrVersion Function](../../../../docs/framework/unmanaged-api/hosting/lockclrversion-function.md)
- [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
