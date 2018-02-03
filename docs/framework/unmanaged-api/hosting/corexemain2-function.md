---
title: "_CorExeMain2 Function"
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
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# _CorExeMain2 Function
Executes the entry point in the specified memory-mapped code. This function is called by the operating system loader.  
  
## Syntax  
  
```  
__int32 STDMETHODCALLTYPE _CorExeMain2 (  
   [in] PBYTE           pUnmappedPE,  
   [in] DWORD           cUnmappedPE,  
   [in] __in LPWSTR     pImageNameIn,  
   [in] __in LPWSTR     pLoadersFileName,  
   [in] __in LPWSTR     pCmdLine  
);  
```  
  
#### Parameters  
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
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Global Static Functions](../../../../docs/framework/unmanaged-api/metadata/metadata-global-static-functions.md)
