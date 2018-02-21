---
title: "ICLRMetaHost::RequestRuntimeLoadedNotification Method"
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
  - "ICLRMetaHost.RequestRuntimeLoadedNotification"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRMetaHost::RequestRuntimeLoadedNotification"
helpviewer_keywords: 
  - "RequestRuntimeLoadedNotification method [.NET Framework hosting]"
  - "ICLRMetaHost::RequestRuntimeLoadedNotification method [.NET Framework hosting]"
ms.assetid: 0d5ccc4d-0193-41f5-af54-45d7b70d5321
topic_type: 
  - "apiref"
caps.latest.revision: 21
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRMetaHost::RequestRuntimeLoadedNotification Method
Provides a callback function that is guaranteed to be called when a common language runtime (CLR) version is first loaded, but not yet started. This method supersedes the [LockClrVersion](../../../../docs/framework/unmanaged-api/hosting/lockclrversion-function.md) function.  
  
## Syntax  
  
```  
HRESULT RequestRuntimeLoadedNotification (  
    [in] RuntimeLoadedCallbackFnPtr pCallbackFunction);  
```  
  
#### Parameters  
 `pCallbackFunction`  
 [in] The callback function that is invoked when a new runtime has been loaded.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`pCallbackFunction` is null.|  
  
## Remarks  
 The callback works in the following way:  
  
-   The callback is invoked only when a runtime is loaded for the first time.  
  
-   The callback is not invoked for reentrant loads of the same runtime.  
  
-   For non-reentrant runtime loads, calls to the callback function are serialized.  
  
 The callback function has the following prototype:  
  
```  
typedef void (__stdcall *RuntimeLoadedCallbackFnPtr)(  
                     ICLRRuntimeInfo *pRuntimeInfo,  
                     CallbackThreadSetFnPtr pfnCallbackThreadSet,  
                     CallbackThreadUnsetFnPtr pfnCallbackThreadUnset);  
```  
  
 The callback function prototypes are as follows:  
  
-   `pfnCallbackThreadSet`:  
  
    ```  
    typedef HRESULT (__stdcall *CallbackThreadSetFnPtr)();  
    ```  
  
-   `pfnCallbackThreadUnset`:  
  
    ```  
    typedef HRESULT (__stdcall *CallbackThreadUnsetFnPtr)();  
    ```  
  
 If the host intends to load or cause another runtime to be loaded in a reentrant manner, the `pfnCallbackThreadSet` and `pfnCallbackThreadUnset` parameters that are provided in the callback function must be used in the following way:  
  
-   `pfnCallbackThreadSet` must be called by the thread that might cause a runtime load before such a load is attempted.  
  
-   `pfnCallbackThreadUnset` must be called when the thread will no longer cause such a runtime load (and before returning from the initial callback).  
  
-   `pfnCallbackThreadSet` and `pfnCallbackThreadUnset` are both non-reentrant.  
  
> [!NOTE]
>  Host applications must not call `pfnCallbackThreadSet` and `pfnCallbackThreadUnset` outside the scope of the `pCallbackFunction` parameter.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICLRMetaHost Interface](../../../../docs/framework/unmanaged-api/hosting/iclrmetahost-interface.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
