---
title: "_CorExeMain Function"
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
  - "_CorExeMain"
api_location: 
  - "mscoree.dll"
  - "clr.dll"
  - "mscorwks.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "_CorExeMain"
helpviewer_keywords: 
  - "_CorExeMain function [.NET Framework hosting]"
ms.assetid: 898f76e2-16f4-4a63-b7d9-dad2d3824d8a
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# _CorExeMain Function
Initializes the common language runtime (CLR), locates the managed entry point in the executable assembly's CLR header, and begins execution.  
  
## Syntax  
  
```  
__int32 STDMETHODCALLTYPE _CorExeMain ();  
```  
  
## Remarks  
 This function is called by the loader in processes created from managed executable assemblies. For DLL assemblies, the loader calls the [_CorDllMain](../../../../docs/framework/unmanaged-api/hosting/cordllmain-function.md) function instead.  
  
 The operating system loader calls this method regardless of the entry point specified in the image file.  
  
 In Windows 98, Windows ME, Windows NT, and Windows 2000, the `_CorExeMain` function is called indirectly through a fixup in the operating system loader. In all other versions of Windows, it is called directly by the operating system loader.  
  
 For additional information, see the Remarks section in the [_CorValidateImage](../../../../docs/framework/unmanaged-api/hosting/corvalidateimage-function.md) topic.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Global Static Functions](../../../../docs/framework/unmanaged-api/metadata/metadata-global-static-functions.md)
