---
description: "Learn more about: GetCLRIdentityManager Function"
title: "GetCLRIdentityManager Function"
ms.date: "03/30/2017"
api_name: 
  - "GetCLRIdentityManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetCLRIdentityManager"
helpviewer_keywords: 
  - "GetCLRIdentityManager function [.NET Framework hosting]"
ms.assetid: 66eeca30-adb4-45f4-aff5-347564c95724
topic_type: 
  - "apiref"
---
# GetCLRIdentityManager Function

Gets a pointer to an interface that allows the common language runtime (CLR) to manage identities.  
  
 This function has been deprecated in the .NET Framework 4.  
  
## Syntax  
  
```cpp  
STDAPI GetCLRIdentityManager(  
    [in]  REFIID      riid,  
    [out] IUnknown  **ppManager  
);  
```  
  
## Parameters  

 `riid`  
 [in] A `REFIID` (an interface identifier) that specifies which interface to get. This value must be either IID_ICLRAssemblyIdentityManager or IID_ICLRHostBindingPolicyManager.  
  
 `ppManager`  
 [out] A pointer to the address of either an [ICLRAssemblyIdentityManager](iclrassemblyidentitymanager-interface.md) or an [ICLRHostBindingPolicyManager](iclrhostbindingpolicymanager-interface.md) object.  
  
## Remarks  

 Call the [GetRealProcAddress](getrealprocaddress-function.md) function to get a pointer to the `GetCLRIdentityManager` function.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorWks.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
