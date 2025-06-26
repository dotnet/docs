---
description: "Learn more about: ICLRMetaHost::ExitProcess Method"
title: "ICLRMetaHost::ExitProcess Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRMetaHost.ExitProcess"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRMetaHost::ExitProcess"
helpviewer_keywords: 
  - "ICLRMetaHost::ExitProcess method [.NET Framework hosting]"
  - "ExitProcess method, ICLRMetaHost interface [.NET Framework hosting]"
ms.assetid: b4df98cc-4e4e-407b-b8f4-e0076afef3a4
topic_type: 
  - "apiref"
---
# ICLRMetaHost::ExitProcess Method

Attempts to shut down all loaded runtimes gracefully and then terminates the process. Supersedes the [CorExitProcess](corexitprocess-function.md) function.  
  
## Syntax  
  
```cpp  
HRESULT ExitProcess (  
    [in] INT32 iExitCode);  
```  
  
## Parameters  

 `iExitCode`  
 [in] The exit code for the process.  
  
## Return Value  

 This method never returns, so its return value is undefined.  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRMetaHost Interface](iclrmetahost-interface.md)
- [Hosting](index.md)
