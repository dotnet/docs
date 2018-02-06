---
title: "RunDll32ShimW Function"
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
  - "RunDll32ShimW"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "RunDll32ShimW"
helpviewer_keywords: 
  - "RunDll32ShimW function [.NET Framework hosting]"
ms.assetid: 9ea07b57-96e2-44df-8711-8fe6c119087f
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# RunDll32ShimW Function
Executes the specified command.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT RunDll32ShimW (  
    [in] HWND        hwnd,  
    [in] HINSTANCE   hinst,  
    [in] LPCWSTR     lpszCmdLine,  
    [in] int         nCmdShow  
);  
```  
  
#### Parameters  
 `hwnd`  
 [in] A handle to a window in which the command output will be displayed.  
  
 `hinst`  
 [in] A handle to the library that contains the command.  
  
 `lpszCmdLine`  
 [in] A string that specifies the command to be executed.  
  
 `nCmdShow`  
 [in] An integer that specifies the display mode for the output window.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
