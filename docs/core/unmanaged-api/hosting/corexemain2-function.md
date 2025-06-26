---
description: "Learn more about: _CorExeMain2 Function"
title: "_CorExeMain2 Function"
ms.date: "03/30/2017"
api_name: 
  - "_CorExeMain2"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "_CorExeMain2"
helpviewer_keywords: 
  - "_CorExeMain2 function [.NET Framework hosting]"
ms.assetid: 72ea68b4-689f-4733-9416-9664b75e8892
topic_type: 
  - "apiref"
---
# _CorExeMain2 Function

Executes the entry point in the specified memory-mapped code. This function is called by the operating system loader.  
  
## Syntax  
  
```cpp  
__int32 STDMETHODCALLTYPE _CorExeMain2 (  
   [in] PBYTE           pUnmappedPE,  
   [in] DWORD           cUnmappedPE,  
   [in] __in LPWSTR     pImageNameIn,  
   [in] __in LPWSTR     pLoadersFileName,  
   [in] __in LPWSTR     pCmdLine  
);  
```  
  
## Parameters  

 `pUnmappedPE`  
 [in] A pointer to the memory-mapped code.  
  
 `cUnmappedPE`  
 [in] The number of elements `pUnmappedPE` can hold.  
  
 `pImageNameIn`  
 [in] A pointer to the name of the executable image.  
  
 `pLoadersFileName`  
 [in] The name of the loader file.  
  
 `pCmdLine`  
 [in] Command-line parameters, if any.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Global Static Functions](../metadata/metadata-global-static-functions.md)
