---
description: "Learn more about: _CorDllMain Function"
title: "_CorDllMain Function"
ms.date: "03/30/2017"
api_name: 
  - "_CorDllMain"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "_CorDllMain"
helpviewer_keywords: 
  - "_CorDllMain function [.NET Framework hosting]"
ms.assetid: bc7b51cf-39d3-48ec-a5cb-2f179fbefff8
topic_type: 
  - "apiref"
---
# \_CorDllMain Function

Initializes the common language runtime (CLR), locates the managed entry point in the DLL assembly's CLR header, and begins execution.  
  
## Syntax  
  
```cpp  
BOOL STDMETHODCALLTYPE _CorDllMain (  
   [in] HINSTANCE hInst,  
   [in] DWORD     dwReason,  
   [in] LPVOID    lpReserved  
);  
```  
  
## Parameters  

 `hInst`  
 [in] The instance handle of the loaded module.  
  
 `dwReason`  
 [in]Indicates why the DLL entry-point function is being called. This parameter can be one of the following values: DLL\_PROCESS_ATTACH, DLL\_THREAD\_ATTACH, DLL\_THREAD\_ATTACH, or DLL\_PROCESS\_DETACH. For descriptions of these values, see the `DllMain` documentation in the Platform SDK.  
  
 `lpReserved`  
 [in] Unused.  
  
## Return Value  

 This method returns `true` for success and `false` if an error occurs.  
  
## Remarks  

 This function is called by the operating system loader for DLL assemblies. For executable assemblies, the loader calls the [\_CorExeMain](corexemain-function.md) function instead.  
  
 The operating system loader calls this method regardless of the entry point specified in the DLL file.  
  
The `_CorDllMain` function is called directly by the operating system loader.
  
 For additional information, see the Remarks section in the [\_CorValidateImage](corvalidateimage-function.md) topic.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Global Static Functions](../metadata/metadata-global-static-functions.md)
