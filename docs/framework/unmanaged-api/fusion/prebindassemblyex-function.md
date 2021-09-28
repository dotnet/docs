---
description: "Learn more about: PreBindAssemblyEx Function"
title: "PreBindAssemblyEx Function"
ms.date: "03/30/2017"
api_name: 
  - "PreBindAssemblyEx"
api_location: 
  - "fusion.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "PreBindAssemblyEx"
helpviewer_keywords: 
  - "PreBindAssemblyEx function [.NET Framework fusion]"
ms.assetid: bd285233-a4a2-4b52-bbca-0025a60e4864
topic_type: 
  - "apiref"
---
# PreBindAssemblyEx Function

Gets the post-policy display name for an assembly.  
  
 This function supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```cpp  
HRESULT PreBindAssemblyEx (  
    [in]  IApplicationContext *pAppCtx,  
    [in]  IAssemblyName       *pName,  
    [in]  IAssembly           *pAsmParent,  
    [in]  LPCWSTR             pwzRuntimeVersion,  
    [out] IAssemblyName       **ppNamePostPolicy,  
    [in]  LPVOID              pvReserved  
 );  
```  
  
## Parameters  

 `pAppCtx`  
 [in] Identifies the application context.  
  
 `pName`  
 [in] Identifies the assembly name.  
  
 `pAsmParent`  
 [in] Identifies the parent assembly. This parameter is ignored.  
  
 `pwzRuntimeVersion`  
 [in] Identifies the runtime version.  
  
 `ppNamePostPolicy`  
 [out] Contains the post-policy display name.  
  
 `pvReserved`  
 [in] Reserved for future extensibility. `pvReserved` must be a null reference.  
  
## Remarks  

 The `ppNamePostPolicy` output parameter is set only if the function returns HRESULT FUSION_E_REF_DEF_MISMATCH. Otherwise, it is null.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Fusion Global Static Functions](fusion-global-static-functions.md)
