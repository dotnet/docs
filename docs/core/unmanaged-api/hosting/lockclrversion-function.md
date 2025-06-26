---
description: "Learn more about: LockClrVersion Function"
title: "LockClrVersion Function"
ms.date: "03/30/2017"
api_name: 
  - "LockClrVersion"
api_location: 
  - "mscoree.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "LockClrVersion"
helpviewer_keywords: 
  - "LockClrVersion function [.NET Framework hosting]"
ms.assetid: 1318ee37-c43b-40eb-bbe8-88fc46453d74
topic_type: 
  - "apiref"
---
# LockClrVersion Function

Allows the host to determine which version of the common language runtime (CLR) will be used within the process before explicitly initializing the CLR.  
  
 This function has been deprecated in the .NET Framework 4.  
  
## Syntax  
  
```cpp  
HRESULT LockClrVersion (  
    [in] FLockClrVersionCallback   hostCallback,  
    [in] FLockClrVersionCallback  *pBeginHostSetup,  
    [in] FLockClrVersionCallback  *pEndHostSetup  
);  
```  
  
## Parameters  

 `hostCallback`  
 [in] The function to be called by the CLR upon initialization.  
  
 `pBeginHostSetup`  
 [in] The function to be called by the host to inform the CLR that initialization is starting.  
  
 `pEndHostSetup`  
 [in] The function to be called by the host to inform the CLR that initialization is complete.  
  
## Return Value  

 This method returns standard COM error codes, as defined in WinError.h, in addition to the following values.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_INVALIDARG|One or more of the arguments is null.|  
  
## Remarks  

 The host calls `LockClrVersion` before initializing the CLR. `LockClrVersion` takes three parameters, all of which are callbacks of type [FLockClrVersionCallback](flockclrversioncallback-function-pointer.md). This type is defined as follows.  
  
```cpp  
typedef HRESULT ( __stdcall *FLockClrVersionCallback ) ();  
```  
  
 The following steps occur upon initialization of the runtime:  
  
1. The host calls [CorBindToRuntimeEx](corbindtoruntimeex-function.md) or one of the other runtime initialization functions. Alternatively, the host could initialize the runtime using COM object activation.  
  
2. The runtime calls the function specified by the `hostCallback` parameter.  
  
3. The function specified by `hostCallback` then makes the following sequence of calls:  
  
    - The function specified by the `pBeginHostSetup` parameter.  
  
    - `CorBindToRuntimeEx` (or another runtime initialization function).  
  
    - [ICLRRuntimeHost::SetHostControl](iclrruntimehost-sethostcontrol-method.md).  
  
    - [ICLRRuntimeHost::Start](iclrruntimehost-start-method.md).  
  
    - The function specified by the `pEndHostSetup` parameter.  
  
 All the calls from `pBeginHostSetup` to `pEndHostSetup` must occur on a single thread or fiber, with the same logical stack. This thread can be different from the thread upon which `hostCallback` is called.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
