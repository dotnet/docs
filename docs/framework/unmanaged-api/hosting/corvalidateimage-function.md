---
title: "_CorValidateImage Function"
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
  - "_CorValidateImage"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "_CorValidateImage"
helpviewer_keywords: 
  - "_CorValidateImage function [.NET Framework hosting]"
ms.assetid: 0117e080-05f9-4772-885d-e1847230947c
topic_type: 
  - "apiref"
caps.latest.revision: 22
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# _CorValidateImage Function
Validates managed module images, and notifies the operating system loader after they have been loaded.  
  
## Syntax  
  
```  
STDAPI _CorValidateImage (   
   [in] PVOID* ImageBase,  
   [in] LPCWSTR FileName  
);  
```  
  
#### Parameters  
 `ImageBase`  
 [in] A pointer to the starting location of the image to validate as managed code. The image must already be loaded into memory.  
  
 `FileName`  
 [in] The file name of the image.  
  
## Return Value  
 This function returns the standard values `E_INVALIDARG`, `E_OUTOFMEMORY`, `E_UNEXPECTED`, and `E_FAIL`, as well as the following values.  
  
|Return value|Description|  
|------------------|-----------------|  
|`STATUS_INVALID_IMAGE_FORMAT`|The image is invalid. This value has the HRESULT 0xC000007BL.|  
|`STATUS_SUCCESS`|The image is valid. This value has the HRESULT 0x00000000L.|  
  
## Remarks  
 In Windows XP and later versions, the operating system loader checks for managed modules by examining the COM Descriptor Directory bit in the common object file format (COFF) header. A set bit indicates a managed module. If the loader detects a managed module, it loads MsCorEE.dll and calls `_CorValidateImage`, which performs the following actions:  
  
-   Confirms that the image is a valid managed module.  
  
-   Changes the entry point in the image to an entry point in the common language runtime (CLR).  
  
-   For 64-bit versions of Windows, modifies the image that is in memory by transforming it from PE32 to PE32+ format.  
  
-   Returns to the loader when the managed module images are loaded.  
  
 For executable images, the operating system loader then calls the [_CorExeMain](../../../../docs/framework/unmanaged-api/hosting/corexemain-function.md) function, regardless of the entry point specified in the executable. For DLL assembly images, the loader calls the [_CorDllMain](../../../../docs/framework/unmanaged-api/hosting/cordllmain-function.md) function.  
  
 `_CorExeMain` or `_CorDllMain` performs the following actions:  
  
-   Initializes the CLR.  
  
-   Locates the managed entry point from the assembly's CLR header.  
  
-   Begins execution.  
  
 The loader calls the [_CorImageUnloading](../../../../docs/framework/unmanaged-api/hosting/corimageunloading-function.md) function when managed module images are unloaded. However, this function does not perform any action; it just returns.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Global Static Functions](../../../../docs/framework/unmanaged-api/metadata/metadata-global-static-functions.md)
